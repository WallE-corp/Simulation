#include "wall_e.h"

WallE::WallE(SimulationWorld* world) {
  // Initialize variables
  world = world;
  vPosition = {0, 0};
  fMoveSpeed = 100.0f;
  fFrontSensorReach = 100.0f;
}

void WallE::Update(olc::PixelGameEngine* gameEngine) {
  float fElapsedTime = gameEngine->GetElapsedTime();

   // Move player
    if (gameEngine->GetKey(olc::Key::W).bHeld) vPosition.y -= fMoveSpeed * fElapsedTime;
    if (gameEngine->GetKey(olc::Key::S).bHeld) vPosition.y += fMoveSpeed * fElapsedTime;
    if (gameEngine->GetKey(olc::Key::A).bHeld) vPosition.x -= fMoveSpeed * fElapsedTime;
    if (gameEngine->GetKey(olc::Key::D).bHeld) vPosition.x += fMoveSpeed * fElapsedTime;
}