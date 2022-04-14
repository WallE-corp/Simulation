#pragma once

#include "simulation_world.h"
#include "olcPixelGameEngine.h"
#include <optional>
#include <vector>

class WallE {
  public:
  olc::vf2d vPosition;
  float fMoveSpeed;
  float fFrontSensorReach;
  std::optional<olc::vf2d> vFrontSensorIntersection;
  olc::vf2d vFrontSensorDirection;
  std::vector<std::optional<olc::vf2d>> LiDARIntersections;
  std::vector<olc::vf2d> LiDARRays;

  WallE(SimulationWorld*);
  void Update(olc::PixelGameEngine*);
  void Draw(olc::PixelGameEngine*, float fElapsedTime);

  private:
  SimulationWorld* world;
};