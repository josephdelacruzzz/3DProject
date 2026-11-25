# Hunted Hedges 

## Authors
| Name | Goals |
| -------- | ------- |
| Chinmay | Audio, Animations, UI |
| Daniel | Lighting, Keys |
| Joseph | Game Flow/Logic, Camera and Player Movement |
| Darren | Game Design, Enemy AI |

## Overview
Hunted Hedges is a first person horror escape game set inside a hedge maze. The player must collect colored orbs to unlock matching rooms. Each room contains a piece of an escape key, which the player must assemble before using it to unlock the final exit gate. Meanwhile, the player must avoid the Hound and survive with only three lives.

## Controls
The controls use a mouse and keyboard:
- **Move Forward / Back / Left / Right** - W / A / S / D
- **Look Around** - Mouse
- **Sprint** - Left Shift
- **Flashlight** - F
- **Interaction** - E near crafting station and doors
- **Pause** - Esc

## Art Assets
- Player: First person camera and flashlight
- Enemy: Hound with patrol, chase, and attack animations
- Maze: Hedge walls forming corridors and rooms
- Orbs: Colored collectibles that unlock matching rooms
- Key: Three collectible key pieces
- Crafting Station: Table used to combine the key pieces
- Final Gate: Exit gate opened with the completed gate key
- Lighting: Moonlight, campfires, lamps, and a player-held flashlight
- UI Elements: Lives counter, key pieces icons, main menu, pause menu, win screen, and lose screen

## Audio Assets
- Player and enemy footsteps
- Hound growls, breathing, and attacks
- Orb and key piece pickup sounds
- Crafting and gate opening sounds
- Chase and caught-player cues

## Game Flow
Title screen:
- Buttons: “Start Game” and “View Controls” buttons
- Background: flickering lights and faint monster noises

Game screen:
- Player spawns at the maze campsite with three lives.
- Explore the maze and collect colored orbs.
- Use each orb to unlock its matching colored room.
- Collect one key piece from each unlocked room.
- Press E at the crafting station after collecting all three pieces.
- Collect the completed gate key and reach the final exit gate.
- The Hound patrols the maze and chases the player when detected.
- Getting caught costs one life.
- Losing all three lives results in a game over.

End screen:
- If escaped: display a survival message with options to replay or quit.
- If all lives are lost: display a game over message with options to retry.

## Potential Challenges
- Enemy pathfinding through narrow hedge corridors
- Balancing the Hound’s patrol and chase behavior
- Maintaining a dark atmosphere while keeping the maze playable
- Balancing the player’s three lives and escape difficulty

## Extra Features (if time)
- Hound flashlight stun mechanic
- Flickering lamps and additional horror audio
- Randomized maze layouts
- Randomized orb locations
- Stamina and Flashlight cooldown

## Gameplay Video
- https://drive.google.com/file/d/1aGaDWeCWiVsBoTuEPE0PsF501i0ZwIwp/view
