#pragma once

#include "olcPixelGameEngine.h"
#include <stdlib.h>
#include <vector>
#include <optional>

struct sEdge {
    float sx, sy;
    float ex, ey;
};

struct sCell {
  int edge_id[4];
  bool edge_exist[4];
  bool exist = false;
};

#define NORTH 0
#define SOUTH 1
#define EAST 2
#define WEST 3

class SimulationWorld {
  public:
  sCell* world;
  int nWorldWidth = 80;
  int nWorldHeight = 60;
  float fBlockWidth = 8.0f;
  std::vector<sEdge> vecEdges;

  SimulationWorld();
  float GetTileIndex(float fSourceX, float fSourceY, float fBlockWidth);
  void ConvertTileMapToPolyMap(int sx, int sy, int w, int h, float fBlockWidth, int pitch);
  std::optional<olc::vf2d> CheckRayIntersection(olc::vf2d vRayStart, olc::vf2d vRayDir, float fMaxDistance);
};