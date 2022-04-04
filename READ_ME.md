# Compiling

## Linux
Requires a modern c++ compiler.
To compile use the command:

`g++ -o YourProgName YourSource.cpp -lX11 -lGL -lpthread -lpng -lstdc++fs -std=c++17`

## Windows

* latest GCC via MSYS2 [install from here](https://www.msys2.org/).
* linked libraries needed:
  - `user32 gdi32 opengl32 gdiplus Shlwapi dwmapi stdc++fs`
* Cpp standard `c++17`