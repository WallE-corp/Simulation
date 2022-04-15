#pragma once

#include "MovementStrategy.h"


class PlayerControlledMovementStrategy : public MovementStrategy {
private:
  float sX;
  float sY;
  float dirX;
  float dirY;

public:
  tuple<float, float> CalculateNextPosition(float x, float y, float speed, olc::PixelGameEngine* gameEngine) {
     float fElapsedTime = gameEngine->GetElapsedTime();

     dirX = 0;
     dirY = 0;
     sX = x;
     sY = y;
     float fNewX = x;
     float fNewY = y;

     // Move player
     if (gameEngine->GetKey(olc::Key::W).bHeld) { 
       dirY = -1;
       fNewY -= speed * fElapsedTime;
     }
     if (gameEngine->GetKey(olc::Key::S).bHeld) { 
       dirY = 1;
       fNewY += speed * fElapsedTime;
     }
     if (gameEngine->GetKey(olc::Key::A).bHeld) { 
       dirX = -1;
       fNewX -= speed * fElapsedTime;
     }
     if (gameEngine->GetKey(olc::Key::D).bHeld) { 
       dirX = 1;
       fNewX += speed * fElapsedTime;
     }

     return { fNewX, fNewY };
	}

  void DrawGizmos(olc::PixelGameEngine* gameEngine) override {
    gameEngine->DrawLine(
      sX,
      sY,
      sX + dirX * 25.0,
      sY + dirY * 25.0,
      olc::BLUE
    );
  }
};