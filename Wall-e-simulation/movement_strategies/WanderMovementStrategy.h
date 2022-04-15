#pragma once

#define _USE_MATH_DEFINES

#include "MovementStrategy.h"
#include "simulation_world.h"
#include <math.h>
#include <format>
#include <stdlib.h>
#include <time.h>

using namespace std;

class WanderMovementStrategy : public MovementStrategy {
private:
	olc::vf2d pos;
	olc::vf2d vel;
	olc::vf2d acc;
	olc::vf2d wanderPoint;
	olc::vf2d followPoint;
	float wanderRadius;
	float angle;
	float maxSpeed;
	float maxForce;
	SimulationWorld* world;
	optional<olc::vf2d> evadeTarget;
	olc::vf2d evadeForce;

public:
	WanderMovementStrategy(SimulationWorld* _world) {
		vel = { 10, 0 };
		acc = { 0, 0 };
		wanderRadius = 25;
		maxSpeed = 100;
		maxForce = 1.5;
		angle = M_PI/2;
		srand(time(NULL));
		world = _world;
	}

	tuple<float, float> CalculateNextPosition(float x, float y, float speed, olc::PixelGameEngine* gameEngine) {
		float fElapsedTime = gameEngine->GetElapsedTime();

		pos.x = x;
		pos.y = y;

		// Wander
		wanderPoint = { vel.x, vel.y };
		SetMag(&wanderPoint, 100);
		AddVec(&wanderPoint, pos);

		auto theta = angle + AngleHeading(vel);

		followPoint.x = wanderRadius * cos(theta);
		followPoint.y = wanderRadius * sin(theta);

		AddVec(&followPoint, wanderPoint);

		auto steerForce = SubVec(followPoint, pos);
		SetMag(&steerForce, maxForce);
		ApplyForce(steerForce);
		//

		// Evande
		evadeTarget.reset();
		evadeTarget = world->CheckRayIntersection(pos, SubVec(followPoint, pos).norm(), 100);
		if (evadeTarget.has_value()) {
			evadeForce = Seek(evadeTarget.value());
			MultVec(&evadeForce, -1);
			SetMag(&evadeForce, maxForce * (followPoint.mag() / (maxSpeed/2)));
			ApplyForce(evadeForce);
		}

		//
		AddVec(&vel, acc);
		LimitVec(&vel, maxSpeed);
		acc.x = 0;
		acc.y = 0;

		angle += GetRandomInRange(-0.1, 0.1);

		return { x + vel.x * fElapsedTime, y + vel.y * fElapsedTime };
	}

	void DrawGizmos(olc::PixelGameEngine* gameEngine) override {
		// Wander point
		gameEngine->FillCircle(
			wanderPoint.x,
			wanderPoint.y,
			2,
			olc::WHITE
		);
		gameEngine->DrawCircle(
			wanderPoint.x,
			wanderPoint.y,
			2, 
			olc::RED
		);
		gameEngine->DrawLine(
			pos.x,
			pos.y,
			wanderPoint.x,
			wanderPoint.y,
			olc::RED,
			0x0F0F0F0F
		);

		// Wander point ring
		gameEngine->DrawCircle(
			wanderPoint.x,
			wanderPoint.y,
			wanderRadius,
			olc::RED
		);

		// Follow point
		gameEngine->FillCircle(
			followPoint.x,
			followPoint.y,
			3,
			olc::WHITE
		);
		gameEngine->DrawLine(
			pos.x,
			pos.y,
			followPoint.x,
			followPoint.y,
			olc::WHITE,
			0x0F0F0F0F
		);

		// Evade target
		if (evadeTarget.has_value()) {
			gameEngine->FillCircle(
				evadeTarget.value().x,
				evadeTarget.value().y,
				3,
				olc::RED
			);

			gameEngine->DrawString(
				{ 0, 0 },
				evadeForce.str()
			);

			gameEngine->DrawCircle(
				pos + evadeForce,
				3,
				olc::GREEN
			);
		}

	}

	olc::vf2d Evade(olc::vf2d target) {
		auto pursuit = Pursue(target);
		MultVec(&pursuit, -1);
		return pursuit;
	}

	olc::vf2d Pursue(olc::vf2d target) {
		olc::vf2d pursueTarget = { target.x, target.y };
		olc::vf2d prediction = { target.x, target.y };
		MultVec(&prediction, 10);
		AddVec(&pursueTarget, prediction);
		return Seek(pursueTarget);
	}

	olc::vf2d Seek(olc::vf2d target) {
		auto force = SubVec(target, pos);
		float desiredSpeed = maxSpeed;

		SetMag(&force, desiredSpeed);
		SubVec(&force, vel);
		LimitVec(&force, maxForce);
		return force;
	}

	float GetRandomInRange(float s, float e) {
		float rn = rand();
		rn = rn / (RAND_MAX / (e - s));
		rn += s;
		return rn;
	}

	void SetMag(olc::vf2d* v, float mag) {
		*v = v->norm() * mag;
	}

	void AddVec(olc::vf2d* v, olc::vf2d v1) {
		*v = *v + v1;
	}

	void MultVec(olc::vf2d* v, float n) {
		*v = *v * n;
	}

	olc::vf2d SubVec(olc::vf2d v, olc::vf2d v1) {
		return v - v1;
	}

	void SubVec(olc::vf2d* v, olc::vf2d v1) {
		*v = *v - v1;
	}

	void ApplyForce(olc::vf2d v) {
		AddVec(&acc, v);
	}

	void LimitVec(olc::vf2d* v, float m) {
		if (v->mag() > m) {
			SetMag(v, m);
		}
	}

	float AngleHeading(olc::vf2d v) {
		return atan2(v.y, v.x);
	}

};