#pragma once

#include "simulation_world.h"
#include "olcPixelGameEngine.h"
#include <optional>

class WallE {
  public:
  olc::vf2d vPosition;
  float fMoveSpeed;
  float fFrontSensorReach;
  std::optional<olc::vf2d> vFrontSensorIntersection;
  olc::vf2d vFrontSensorDirection;

  WallE(SimulationWorld*);
  void Update(olc::PixelGameEngine*);
  void Draw(olc::PixelGameEngine*, float fElapsedTime);

  private:
  SimulationWorld* world;
};