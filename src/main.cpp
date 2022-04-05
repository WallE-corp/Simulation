#define OLC_PGE_APPLICATION
#define OLC_IMAGE_STB

#include "olcPixelGameEngine.h"

struct sEdge {
    float sx, sy;
    float ex, Ey;
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

public:
	bool OnUserCreate() override
	{
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


    // Drawing
    Clear(olc::BLACK);

    // Draw tiles
    for (int x = 0; x < nWorldWidth; x++)
      for (int y = 0; y < nWorldHeight; y++) {
        if (world[y * nWorldWidth + x].exist) {
          FillRect(x * fBlockWidth, y * fBlockWidth, fBlockWidth, fBlockWidth, olc::BLUE);
        }
      }

		return true;
	}

  float GetTileIndex(float fSourceX, float fSourceY, float fBlockWidth) {
    // index = y * width + x
    int nTileX = (int)(fSourceX / fBlockWidth);
    int nTileY = (int)(fSourceY / fBlockWidth);
    int nTileIndex = nTileY * nWorldWidth + nTileX;
    return nTileIndex;
  }
};

int main()
{
	WallESimulation demo;
	if (demo.Construct(640, 480, 2, 2))
		demo.Start();
	return 0;
}