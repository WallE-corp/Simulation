#include "wall_e.h"
#include <cmath>

WallE::WallE(SimulationWorld* _world) {
  // Initialize variables
  world = _world;
  vPosition = {0, 0};
  fMoveSpeed = 100.0f;
  fFrontSensorReach = 100.0f;
  vFrontSensorIntersection = { 0, 0 };
  vFrontSensorDirection = { 0, 0 };
}

void WallE::Update(olc::PixelGameEngine* gameEngine) {
  float fElapsedTime = gameEngine->GetElapsedTime();

   // Move player
  if (gameEngine->GetKey(olc::Key::W).bHeld) vPosition.y -= fMoveSpeed * fElapsedTime;
  if (gameEngine->GetKey(olc::Key::S).bHeld) vPosition.y += fMoveSpeed * fElapsedTime;
  if (gameEngine->GetKey(olc::Key::A).bHeld) vPosition.x -= fMoveSpeed * fElapsedTime;
  if (gameEngine->GetKey(olc::Key::D).bHeld) vPosition.x += fMoveSpeed * fElapsedTime;

  float fSourceX = gameEngine->GetMouseX();
  float fSourceY = gameEngine->GetMouseY();

  // Calculate front sensor ray direction
  olc::vf2d vRayStart = vPosition;
  olc::vf2d vMouse = { fSourceX, fSourceY };
  vFrontSensorDirection = (vMouse - vPosition).norm();
  // Calculate intersection
  vFrontSensorIntersection = world->CheckRayIntersection(vRayStart, vFrontSensorDirection, fFrontSensorReach);

  LiDARIntersections.clear();
  LiDARRays.clear();
  float radius = fFrontSensorReach;
  int nNumRays = 36;
  for (int i = 0; i < nNumRays; i++) {
    float angle = i * ((360 - nNumRays) / nNumRays);
    float fRayEndX = 1 * std::cos(angle);
    float fRayEndY = 1 * std::sin(angle);
    olc::vf2d ray = { fRayEndX, fRayEndY };
    LiDARRays.push_back(ray);

    auto vIntersection = world->CheckRayIntersection(vPosition, ray, radius);
    LiDARIntersections.push_back(vIntersection);
  }
}

void WallE::Draw(olc::PixelGameEngine* gameEngine, float fElapsedTime) {
  // Draw body
  gameEngine->FillCircle(vPosition.x, vPosition.y, 5, olc::YELLOW);

  // Draw front sensor ray
  gameEngine->DrawLine(
    vPosition.x,
    vPosition.y,
    vPosition.x +vFrontSensorDirection.x * fFrontSensorReach,
    vPosition.y +vFrontSensorDirection.y * fFrontSensorReach,
    olc::RED,
    0xFF0FF0FF
  );

  // Draw intersections
  if (vFrontSensorIntersection.has_value()) {
    gameEngine->DrawCircle(vFrontSensorIntersection.value(), 5, olc::GREEN);
  }

  for (auto vRay : LiDARRays) {
    gameEngine->DrawLine(
      vPosition.x,
      vPosition.y,
      vPosition.x + vRay.x * fFrontSensorReach,
      vPosition.y + vRay.y * fFrontSensorReach,
      olc::DARK_GREY,
      0xFF0FF0FF
    );
  }

  for (auto vIntersection : LiDARIntersections) {
    if (vIntersection.has_value()) {
      gameEngine->DrawCircle(vIntersection.value(), 5, olc::YELLOW);
    }
  }
}