# Move a Cube

A simple Unity project demonstrating basic player movement, camera controls, and arena automation (partially).

## Description

This project is a school assignment. The game allows the player to move a cube through an obstacle course.

## Features

- Basic cube movement (WASD + jump)
- Keyboard and controller support
- Moving obstacles

## Arena (Partly Automatic Generation)

The arena’s walls, ramps, start/finish points, and plane can be adjusted by modifying the respective properties in the ArenaController. This saves a lot of time by automatically ensuring the geometrical accuracy of how objects and their dependent elements are transformed, without needing to manually update them.

What can be adjusted:

- Wall width and height
- Ramp angle (whatever angle is entered, the ramps remain attached to the walls)
- Ramp size (height and width)
- Plane size (resizes the whole arena, affecting walls, ramps, and checkpoints)
- TODO: Checkpoint size

Changing any of the properties listed above updates the scene automatically.

## How the Gameplay Feels

As soon as the player spawns, the game begins. Static, falling, rolling, moving, and rotating obstacles make it challenging to complete the course with the highest score. If the player hits an obstacle, it is painted red, making it easier to track the success of the current run. The game ends once the player reaches the finish point, at which point the score is displayed.

## Possible Improvements/Bugfixes

- When the player moves onto a rising obstacle, it can:
  - Ignore the obstacle and not be affected by it
  - Be lifted by the obstacle, but the behavior isn't always smooth
- Time-consuming: Procedural obstacle generation
  - When combined with ArenaController’s automated adjustments, this can make each level unique and challenging
