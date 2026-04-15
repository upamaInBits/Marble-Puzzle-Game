# Marble Puzzle Game (C# Windows Forms)

## Overview

This is a desktop-based puzzle game built using C# and Windows Forms. The game challenges players to navigate marbles through a grid filled with walls and obstacles, with the goal of matching each marble to its corresponding hole.

The application combines game logic, UI design, and data management, providing an interactive experience with scoring, timing, and a leaderboard system.

---

## How the Game Works (Gameplay)

1. When the application starts, the player enters their name.
2. The player selects a puzzle file (which defines the grid, walls, marbles, and holes).
3. The game board is generated dynamically based on the file.

### Objective

* Move all marbles into their matching holes.
* Each marble must go into the correct hole (same number).

### Controls

* Use the directional buttons:

  * ⬅️ Left
  * ➡️ Right
  * ⬆️ Up
  * ⬇️ Down

### Movement Rules

* When a direction is selected, **all marbles move in that direction**.
* Marbles continue moving until:

  * They hit a wall
  * They hit another marble
* If a marble reaches its correct hole:

  * It disappears from the board 
* If a marble enters the wrong hole:

  * The game ends 

### Winning the Game

* The player wins when **all marbles are correctly placed into their matching holes**.
* The system records:

  * Number of moves
  * Time taken

---

## Features

*  Dynamic grid-based puzzle generation
* Game logic for movement, walls, and collision handling
* Image-based rendering of puzzle cells
* Timer with pause and resume functionality
* Leaderboard tracking player performance (moves & time)
* Raffle system to randomly select a winner from players
* Data persistence using file serialization

---

## Technologies Used

* C#
* Windows Forms
* Object-Oriented Programming (OOP)
* File Handling & Serialization
* Custom UI Components (PictureBox-based grid)

---

## Project Structure

* `Program.cs` → Entry point of the application
* `Form1.cs` → Main game logic and UI
* `AddForm.cs` → Player name input
* `Form2.cs` → Raffle and winner selection
* `PBXPictureBox.cs` → Custom grid cell component
* `PersonItem.cs` → Player data model

---



## Future Improvements

* Add difficulty levels
* Improve UI/UX design
* Add animations for smoother gameplay
* Convert to web-based or cross-platform version

---

## How to Run

1. Clone the repository
2. Open the project in Visual Studio
3. Build and run the solution
4. Select a puzzle base.mrb file and start playing

---
