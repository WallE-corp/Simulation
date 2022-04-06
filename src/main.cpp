#define OLC_PGE_APPLICATION
#define OLC_IMAGE_STB

#include "olcPixelGameEngine.h"
#include "simulation_world.h"
#include "wall_e.h"

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
  WallE* wallE;

public:
	bool OnUserCreate() override {
    simulationWorld = new SimulationWorld();
    wallE = new WallE(simulationWorld);
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

    // Update WallE
    wallE->Update(this);

    olc::vf2d vRayStart = wallE->vPosition;
    olc::vf2d vMouse = {fSourceX, fSourceY};
    olc::vf2d vRayDir = (vMouse - wallE->vPosition).norm();
    auto vIntersection = simulationWorld->CheckRayIntersection(vRayStart, vRayDir, wallE->fFrontSensorReach);

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
      FillCircle(edge.sx, edge.sy, 1, olc::RED);
      FillCircle(edge.ex, edge.ey, 1, olc::RED);
    }

    // Draw player
    FillCircle(wallE->vPosition.x, wallE->vPosition.y, 5, olc::YELLOW);
    DrawLine(
      wallE->vPosition.x, 
      wallE->vPosition.y, 
      wallE->vPosition.x + vRayDir.x * wallE->fFrontSensorReach, 
      wallE->vPosition.y + vRayDir.y * wallE->fFrontSensorReach,
      olc::RED, 
      0xFF0FF0FF
    );

    if (vIntersection.has_value()) {
      DrawCircle(vIntersection.value(), 5, olc::GREEN);
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