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
  olc::vf2d vPlayerPosition = {0, 0};
  float fPlayerSpeed = 100.0f;
  float fPlayerSightLength = 100.0f;

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

    // Move player
    if (GetKey(olc::Key::W).bHeld) vPlayerPosition.y -= fPlayerSpeed * fElapsedTime;
    if (GetKey(olc::Key::S).bHeld) vPlayerPosition.y += fPlayerSpeed * fElapsedTime;
    if (GetKey(olc::Key::A).bHeld) vPlayerPosition.x -= fPlayerSpeed * fElapsedTime;
    if (GetKey(olc::Key::D).bHeld) vPlayerPosition.x += fPlayerSpeed * fElapsedTime;
    

    // DDA Algorithm ==============
    // https://lodev.org/cgtutor/raycasting.html

    // Form ray cast from player 
    olc::vf2d vRayStart = vPlayerPosition;
    olc::vf2d vMouse = {fSourceX, fSourceY};
    olc::vf2d vRayDir = (vMouse - vPlayerPosition).norm();
    olc::vf2d vRayUnitStepSize = {
      sqrt(1 + (vRayDir.y / vRayDir.x) * (vRayDir.y / vRayDir.x)),
      sqrt(1 + (vRayDir.x / vRayDir.y) * (vRayDir.x / vRayDir.y))
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
    float fMaxDistance = fPlayerSightLength;
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
      
      if (vMapCheck.x >= 0 && vMapCheck.x < simulationWorld->nWorldWidth * fBlockWidth &&
          vMapCheck.y >= 0 && vMapCheck.y < simulationWorld->nWorldHeight * fBlockWidth) {
        int nTileIndex = simulationWorld->GetTileIndex(vMapCheck.x, vMapCheck.y, fBlockWidth);
        if (simulationWorld->world[nTileIndex].exist) {
          bTileFound = true;
        }
      }
    }

    olc::vf2d vIntersection;
    if (bTileFound) {
      vIntersection = vRayStart + vRayDir * fDistance;
    }

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
    FillCircle(vPlayerPosition.x, vPlayerPosition.y, 5, olc::YELLOW);
    DrawLine(
      vPlayerPosition.x, 
      vPlayerPosition.y, 
      vPlayerPosition.x + vRayDir.x * fPlayerSightLength, 
      vPlayerPosition.y + vRayDir.y * fPlayerSightLength,
      olc::RED, 
      0xFF0FF0FF
    );

    if (bTileFound) {
      DrawCircle(vIntersection, 5, olc::GREEN);
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