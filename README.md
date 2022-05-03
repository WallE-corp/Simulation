# WallE Tools
## Contents
* [Unity Simulation](#unity-simulation)
* [Remote Controller](#remote-controller)
* [(deprecated)C++ Simulation](#deprecated-c-simulation)

## Unity Simulation
A simulation done with the Unity game engine. Used to simulation how the WallE moves in an environment.

### Features
*   An Environment with borders and obstacle that is easily editable.
*   Sensors for borders and obstacles
*   Can connect with the networking code made for the raspberry pi, via websocket.
    - Sends relative position data
    - Can receive movements commands and control movement in the simulation
        *   See [Remote Controller]
*   Can signal when obstacle is detected

### Running
#### Requirements
*   Unity
    * Editor version `2021.3.0f1`

#### Casual run
To run casually simply press play to start.

#### Running with remote controller
If you wish to run and control WallE with the remote controller:
1.  Start the `Wall-e-backend` app.
1.  Start the websocket server from the `RunWithSimulator` module in the Wall-e-networking repoistory.
    - In the terminal running the backend app, you should see that you have connected.
2.  Start the simulation.
    - In the python terminal running the networking code you should now see the simulation has started sending position data to the networking code.
3.  Start the `Remote Controller` tool.
    - In the terminal running the backend app, you should see that you have connected.

## Remote Controller
A small tool to simulate the mobile's connection to the `Wall-e-backend`.

### Simple use
For now ask me (Tifye) for the installer.

### For developing this tool
Requirements
*   Visual Studio 2022
    - with the `.NET desktop development` workload

## (deprecated) C++ Simulation 
## Linux
Requires a modern c++ compiler.
To compile use the command:

`g++ -o YourProgName YourSource.cpp -lX11 -lGL -lpthread -lpng -lstdc++fs -std=c++17 <link extra cpp here>`

## Windows

* latest G++ via MSYS2 MINGW [install from here](https://www.msys2.org/).
  - *Note* For IDEs other than Visual Studio follow: https://www.youtube.com/watch?v=jnI1gMxtrB4
* linked libraries needed:
  - `user32 gdi32 opengl32 gdiplus Shlwapi dwmapi stdc++fs`
* Cpp standard `c++17`