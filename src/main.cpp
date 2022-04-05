#define OLC_PGE_APPLICATION
#define OLC_IMAGE_STB

#include "olcPixelGameEngine.h"

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

// Override base class with your custom functionality
class WallESimulation : public olc::PixelGameEngine
{
public:
	WallESimulation()
	{
		sAppName = "Wall-E Simulation";
	}

private: 
  sCell* world;
  int nWorldWidth = 80;
  int nWorldHeight = 60;

  std::vector<sEdge> vecEdges;

  void ConvertTileMapToPolyMap(int sx, int sy, int w, int h, float fBlockWidth, int pitch) {
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

  float GetTileIndex(float fSourceX, float fSourceY, float fBlockWidth) {
    // index = y * width + x
    int nTileX = (int)(fSourceX / fBlockWidth);
    int nTileY = (int)(fSourceY / fBlockWidth);
    int nTileIndex = nTileY * nWorldWidth + nTileX;
    return nTileIndex;
  }

public:
	bool OnUserCreate() override {
		world = new sCell[nWorldWidth * nWorldHeight];
		return true;
	}

	bool OnUserUpdate(float fElapsedTime) override
	{
		// Called once per frame

    float fBlockWidth = 8.0f;
    float fSourceX = GetMouseX();
    float fSourceY = GetMouseY();

    // Set tile to on or off
    if (GetMouse(0).bHeld) {
      int nTileIndex = GetTileIndex(fSourceX, fSourceY, fBlockWidth);
      world[nTileIndex].exist = true;
    }
    if (GetMouse(1).bHeld) {
      int nTileIndex = GetTileIndex(fSourceX, fSourceY, fBlockWidth);
      world[nTileIndex].exist = false;
    }


    // Live convert world to PolyMap. Can be done in OnUserCreate() if no live drawing enabled
    ConvertTileMapToPolyMap(0, 0, 80, 60, fBlockWidth, nWorldWidth);

    // Drawing
    Clear(olc::BLACK);

    // Draw tiles
    for (int x = 0; x < nWorldWidth; x++)
      for (int y = 0; y < nWorldHeight; y++) {
        if (world[y * nWorldWidth + x].exist) {
          FillRect(x * fBlockWidth, y * fBlockWidth, fBlockWidth, fBlockWidth, olc::BLUE);
        }
      }

    // Draw edges in PolyMap
    for (auto &edge : vecEdges) {
      DrawLine(edge.sx, edge.sy, edge.ex, edge.ey, olc::RED);
      FillCircle(edge.sx, edge.sy, 3, olc::RED);
      FillCircle(edge.ex, edge.ey, 3, olc::RED);
    }

		return true;
	}
};

int main()
{
	WallESimulation demo;
	if (demo.Construct(640, 480, 2, 2))
		demo.Start();
	return 0;
}