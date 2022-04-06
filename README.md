# Compiling

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