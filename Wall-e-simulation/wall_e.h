#pragma once

#include "simulation_world.h"
#include "olcPixelGameEngine.h"

class WallE {
  public:
  olc::vf2d vPosition;
  float fMoveSpeed;
  float fFrontSensorReach;

  WallE(SimulationWorld*);
  void Update(olc::PixelGameEngine*);

  private:
  SimulationWorld* world;
};