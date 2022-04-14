#include "simulation_world.h"

SimulationWorld::SimulationWorld() {
  world = new sCell[nWorldWidth * nWorldHeight];

  // Add initial borders
  for (int x = 0; x < nWorldWidth; x++) {
    world[x].exist = true;
    world[(nWorldHeight - 1) * nWorldWidth + x].exist = true;
  }
  for (int y = 0; y < nWorldHeight; y++) {
    world[y * nWorldWidth].exist = true;
    world[y * nWorldWidth + (nWorldWidth - 1)].exist = true;   
  }
}
float SimulationWorld::GetTileIndex(float fSourceX, float fSourceY, float fBlockWidth) {
  // index = y * width + x
  int nTileX = (int)(fSourceX / fBlockWidth);
  int nTileY = (int)(fSourceY / fBlockWidth);
  int nTileIndex = nTileY * nWorldWidth + nTileX;
  return nTileIndex;
}
void SimulationWorld::ConvertTileMapToPolyMap(int sx, int sy, int w, int h, float fBlockWidth, int pitch) {
  // Clear PolyMap
  vecEdges.clear();

  // Loop through and reset cells in desired region
  for (int x = 0; x < w; x++)
    for (int y = 0; y < h; y++) 
      for (int j = 0; j < 4; j++) {
        world[(y + sy) * pitch + (x + sx)].edge_exist[j] = false;
        world[(y + sy) * pitch + (x + sx)].edge_id[j] = 0;
      }

  // Look through desired region
  for (int x = 1; x < w - 1; x++)
    for (int y = 1; y < h - 1; y++) {
      // Cell indices
      int i = (y + sy) * pitch + (x + sx);        // Current Cell
      int i_n = (y + sy - 1) * pitch + (x + sx);  // North Neighbour
      int i_s = (y + sy + 1) * pitch + (x + sx);  // South Neighbour
      int i_w = (y + sy) * pitch + (x + sx - 1);  // West Neighbour
      int i_e = (y + sy) * pitch + (x + sx + 1);  // East Neighbour

      // If current cell exists, check if it needs edges
      if (world[i].exist) {
        // If current cell has no west neighbour, it needs a west edge
        if (!world[i_w].exist) {
          // Either extends edge from North neighbour
          // or create a new edge
          if (world[i_n].edge_exist[WEST]) {
            // North neighbour has a west edge, extend it
            vecEdges[world[i_n].edge_id[WEST]].ey += fBlockWidth;

            // Update cell information
            world[i].edge_id[WEST] = world[i_n].edge_id[WEST];
            world[i].edge_exist[WEST] = true;
          } else {
            // North neighbour does not have a west edge, create one
            sEdge edge;
            edge.sx = (x + sx) * fBlockWidth;
            edge.sy = (y + sy) * fBlockWidth;
            edge.ex = edge.sx;
            edge.ey = edge.sy + fBlockWidth;

            // Add edge to PolyMap
            int edge_id = vecEdges.size();
            vecEdges.push_back(edge);

            // Update cell information
            world[i].edge_id[WEST] = edge_id;
            world[i].edge_exist[WEST] = true;
          }
        }

        // If current cell has no east neighbour, it needs a east edge
        if (!world[i_e].exist) {
          // Either extends edge from North neighbour
          // or create a new edge
          if (world[i_n].edge_exist[EAST]) {
            // North neighbour has a east edge, extend it
            vecEdges[world[i_n].edge_id[EAST]].ey += fBlockWidth;

            // Update cell information
            world[i].edge_id[EAST] = world[i_n].edge_id[EAST];
            world[i].edge_exist[EAST] = true;
          } else {
            // North neighbour does not have an east edge, create one
            sEdge edge;
            edge.sx = (x + sx + 1) * fBlockWidth;
            edge.sy = (y + sy) * fBlockWidth;
            edge.ex = edge.sx;
            edge.ey = edge.sy + fBlockWidth;

            // Add edge to PolyMap
            int edge_id = vecEdges.size();
            vecEdges.push_back(edge);

            // Update cell information
            world[i].edge_id[EAST] = edge_id;
            world[i].edge_exist[EAST] = true;
          }
        }
        
        // If current cell has no North neighbour, it needs a north edge
        if (!world[i_n].exist) {
          // Either extends edge from west neighbour
          // or create a new edge
          if (world[i_w].edge_exist[NORTH]) {
            // West neighbour has a north edge, extend it
            vecEdges[world[i_w].edge_id[NORTH]].ex += fBlockWidth;

            // Update cell information
            world[i].edge_id[NORTH] = world[i_w].edge_id[NORTH];
            world[i].edge_exist[NORTH] = true;
          } else {
            // West neighbour does not have a north edge, create one
            sEdge edge;
            edge.sx = (x + sx) * fBlockWidth;
            edge.sy = (y + sy) * fBlockWidth;
            edge.ex = edge.sx + fBlockWidth;
            edge.ey = edge.sy;

            // Add edge to PolyMap
            int edge_id = vecEdges.size();
            vecEdges.push_back(edge);

            // Update cell information
            world[i].edge_id[NORTH] = edge_id;
            world[i].edge_exist[NORTH] = true;
          }
        }

        // If current cell has no South neighbour, it needs a south edge
        if (!world[i_s].exist) {
          // Either extends edge from west neighbour
          // or create a new edge
          if (world[i_w].edge_exist[SOUTH]) {
            // West neighbour has a north edge, extend it
            vecEdges[world[i_w].edge_id[SOUTH]].ex += fBlockWidth;

            // Update cell information
            world[i].edge_id[SOUTH] = world[i_w].edge_id[SOUTH];
            world[i].edge_exist[SOUTH] = true;
          } else {
            // West neighbour does not have a north edge, create one
            sEdge edge;
            edge.sx = (x + sx) * fBlockWidth;
            edge.sy = (y + sy + 1) * fBlockWidth;
            edge.ex = edge.sx + fBlockWidth;
            edge.ey = edge.sy;

            // Add edge to PolyMap
            int edge_id = vecEdges.size();
            vecEdges.push_back(edge);

            // Update cell information
            world[i].edge_id[SOUTH] = edge_id;
            world[i].edge_exist[SOUTH] = true;
          }
        }
      }
    }
}

std::optional<olc::vf2d> SimulationWorld::CheckRayIntersection(olc::vf2d vRayStart, olc::vf2d vRayDir, float fMaxDistance) {
  // DDA Algorithm ==============
  // https://lodev.org/cgtutor/raycasting.html
  
  olc::vf2d vRayUnitStepSize = {
    sqrtf(1.0f + (vRayDir.y / vRayDir.x) * (vRayDir.y / vRayDir.x)),
    sqrtf(1.0f + (vRayDir.x / vRayDir.y) * (vRayDir.x / vRayDir.y))
  };
  olc::vi2d vMapCheck = vRayStart; // Implicit round downwards
  olc::vf2d vRayLength;   // x: Length of ray in x-axis, y: Length of ray in y-axis
  olc::vi2d vStep;

  // Adjust which direction we are stepping in
  // Set initial ray lengths
  if (vRayDir.x < 0) {
    vStep.x = -1;
    vRayLength.x = (vRayStart.x - float(vMapCheck.x)) * vRayUnitStepSize.x;
  }
  else {
    vStep.x = 1;
    vRayLength.x = (float(vMapCheck.x + 1) - vRayStart.x) * vRayUnitStepSize.x;
  }

  if (vRayDir.y < 0) {
    vStep.y = -1;
    vRayLength.y = (vRayStart.y - float(vMapCheck.y)) * vRayUnitStepSize.y;
  }
  else {
    vStep.y = 1;
    vRayLength.y = (float(vMapCheck.y + 1) - vRayStart.y) * vRayUnitStepSize.y;
  }

  bool bTileFound = false;
  float fDistance = 0.0f;
  while(!bTileFound && fDistance < fMaxDistance) {

    // Walk along ray
    // If x-axis ray is shorter then move along x-axis
    if (vRayLength.x < vRayLength.y) {
      vMapCheck.x += vStep.x;
      fDistance = vRayLength.x;
      vRayLength.x += vRayUnitStepSize.x;
    } else { // If y-axis ray is shorter then move along y-axis
      vMapCheck.y += vStep.y;
      fDistance = vRayLength.y;
      vRayLength.y += vRayUnitStepSize.y;
    }

    if (vMapCheck.x >= 0 && vMapCheck.x < nWorldWidth * fBlockWidth &&
        vMapCheck.y >= 0 && vMapCheck.y < nWorldHeight * fBlockWidth) {
      int nTileIndex = GetTileIndex(vMapCheck.x, vMapCheck.y, fBlockWidth);
      if (world[nTileIndex].exist) {
        bTileFound = true;
      }
    }
  }
  std::optional<olc::vf2d> vIntersection;
  if (bTileFound) {
    vIntersection = vRayStart + vRayDir * fDistance;
  }
  
  return vIntersection;
}