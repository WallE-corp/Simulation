#define OLC_PGE_APPLICATION
#define OLC_IMAGE_STB

#include "olcPixelGameEngine.h"
#include "simulation_world.h"

// Override base class with your custom functionality
class WallESimulation : public olc::PixelGameEngine
{
public:
	WallESimulation()
	{
		sAppName = "Wall-E Simulation";
	}

private: 
  SimulationWorld* simulationWorld;


public:
	bool OnUserCreate() override {
    simulationWorld = new SimulationWorld();
		return true;
	}

	bool OnUserUpdate(float fElapsedTime) override
	{
		// Called once per frame
    float fBlockWidth = simulationWorld->fBlockWidth;
    float fSourceX = GetMouseX();
    float fSourceY = GetMouseY();

    // Set tile to on or off
    if (GetMouse(0).bHeld) {
      int nTileIndex = simulationWorld->GetTileIndex(fSourceX, fSourceY, fBlockWidth);
      simulationWorld->world[nTileIndex].exist = true;
    }
    if (GetMouse(1).bHeld) {
      int nTileIndex = simulationWorld->GetTileIndex(fSourceX, fSourceY, fBlockWidth);
      simulationWorld->world[nTileIndex].exist = false;
    }


    // Live convert world to PolyMap. Can be done in OnUserCreate() if no live drawing enabled
    simulationWorld->ConvertTileMapToPolyMap(0, 0, 80, 60, fBlockWidth, simulationWorld->nWorldWidth);

    // Drawing
    Clear(olc::BLACK);

    // Draw tiles
    for (int x = 0; x < simulationWorld->nWorldWidth; x++)
      for (int y = 0; y < simulationWorld->nWorldHeight; y++) {
        if (simulationWorld->world[y * simulationWorld->nWorldWidth + x].exist) {
          FillRect(x * fBlockWidth, y * fBlockWidth, fBlockWidth, fBlockWidth, olc::BLUE);
        }
      }

    // Draw edges in PolyMap
    for (auto &edge : simulationWorld->vecEdges) {
      DrawLine(edge.sx, edge.sy, edge.ex, edge.ey, olc::WHITE);
      FillCircle(edge.sx, edge.sy, 2, olc::RED);
      FillCircle(edge.ex, edge.ey, 2, olc::RED);
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