#pragma once

#include <tuple>
#include "wall_e.h"
#include "olcPixelGameEngine.h"

using namespace std;

class MovementStrategy {
public:
	virtual tuple<float, float> CalculateNextPosition(float x, float y, float speed, olc::PixelGameEngine* gameEngine) = 0;

	virtual void DrawGizmos(olc::PixelGameEngine* gameEngine) {
		// 
	}
};