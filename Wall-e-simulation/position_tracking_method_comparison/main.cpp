#define OLC_PGE_APPLICATION
#define OLC_IMAGE_STB

#include "../simulation_world.h"
#include "../wall_e.h"
#include "../olcPixelGameEngine.h"
#include "../movement_strategies/WanderMovementStrategy.h"

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
		delete wallE->movementStrategy;
		wallE->movementStrategy = new WanderMovementStrategy(simulationWorld);
		return true;
	}

	bool OnUserUpdate(float fElapsedTime) override
	{
		// Called once per frame

		simulationWorld->Update(this, fElapsedTime);
		wallE->Update(this);

		// Drawing
		Clear(olc::DARK_GREY);

		simulationWorld->Draw(this, fElapsedTime);
		wallE->Draw(this, fElapsedTime);


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