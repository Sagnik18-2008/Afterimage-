# AFTERIMAGE

AFTERIMAGE is a mobile-first 3D underwater endless-runner adventure prototype built in Unity. The core idea is that the player swims through a dangerous ocean, records their movement, and turns previous runs into playable Afterimages that can solve puzzles, trigger mechanisms, and alter the current run.

## Core mechanic

The game loop is:

- Swim through the ruins and hazards
- Dodge obstacles and survive the current
- Collect Memory Fragments
- Record a recent run
- Create a usable Afterimage
- Use that Afterimage to activate objects, trigger paths, and uncover the truth

## Controls

- Touch / drag: swim horizontally and vertically
- Swipe up / down: change depth
- Tap: speed boost
- Pause button: pause the run

## Unity version

This prototype targets Unity 2022.3 LTS (recommended: 2022.3.18f1 or newer).

## Project structure

```text
Assets/
├── Scenes/
│   ├── MainMenu
│   ├── Tutorial
│   ├── Game
│   └── Base
├── Scripts/
│   ├── Afterimage/
│   ├── Audio/
│   ├── Collectibles/
│   ├── Environment/
│   ├── Gameplay/
│   ├── Mystery/
│   ├── Player/
│   ├── Progression/
│   ├── UI/
│   └── SaveSystem/
├── Prefabs/
│   ├── Afterimage/
│   ├── Collectibles/
│   ├── Environment/
│   ├── Obstacles/
│   └── Player/
├── Materials/
├── Audio/
├── VFX/
├── UI/
├── Resources/
└── Art/
```

## How to open the project

1. Install Unity Hub and Unity 2022.3 LTS.
2. Open Unity Hub.
3. Click Open and select this repository root folder.
4. Allow Unity to generate the project files.
5. Open the `Scenes/MainMenu` scene or create a new scene from the provided structure.

## How to build for Android

1. In Unity, open `File > Build Settings`.
2. Switch platform to Android.
3. Ensure Android Build Support is installed via Unity Hub.
4. Configure the project bundle identifier, signing, and Android SDK settings.
5. Set the target scene as the main menu or game scene.
6. Click Build and select an output folder.

## Development status

This repository is a prototype scaffold and gameplay foundation for the AFTERIMAGE concept. Core gameplay systems are implemented as modular Unity scripts, but art, sound, and full balancing remain to be finalized.

## Known limitations

- Placeholder art and audio assets are used for prototyping.
- The project is structured for easy expansion, but large battle or story systems are intentionally lightweight.
- Environmental generation and puzzle logic are designed to be extensible rather than final content.
- Full Android optimization, QA, and polish remain required before release.

## Team contribution instructions

1. Create a feature branch for each task.
2. Keep scripts organized by system and namespace.
3. Prefer small, reviewable changes.
4. Name files clearly and match the project structure above.
5. Update documentation when gameplay logic or controls change.
6. Test the prototype after each major phase before moving to the next feature set.

## Suggested workflow

The repository is organized for iterative development along the following phases:

1. Main menu + player movement
2. Basic underwater environment
3. Afterimage recording
4. Afterimage playback
5. Interaction with world objects
6. Endless generation and obstacles
7. Collectibles and progression
8. Tutorial and UI
9. Save system and story events
10. Audio, VFX, and mobile polish

## Repository notes

This project intentionally avoids heavy third-party dependencies and keeps gameplay values configurable so prototype tuning remains straightforward.

## Final tagline

"You can outrun the ocean. You can't outrun your past."
