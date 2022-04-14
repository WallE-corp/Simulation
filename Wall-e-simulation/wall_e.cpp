#include "wall_e.h"

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

  // Draw intersection
  if (vFrontSensorIntersection.has_value()) {
    gameEngine->DrawCircle(vFrontSensorIntersection.value(), 5, olc::GREEN);
  }
}