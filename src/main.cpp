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
		// Called once per frame, draws random coloured pixels
		for (int x = 0; x < ScreenWidth(); x++)
			for (int y = 0; y < ScreenHeight(); y++)
				Draw(x, y, olc::Pixel(rand() % 256, rand() % 256, rand() % 256));
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