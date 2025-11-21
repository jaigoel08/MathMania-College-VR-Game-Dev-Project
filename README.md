# MathMania - College VR Game (Project)

This repository contains the MathMania Unity project. The project was developed with Unity 2019.2.17f1. The steps below explain how to open and run the project in the Unity Editor and how to run the game without a VR headset using the included mouse/keyboard fallback scripts.

## Quick Facts
- Unity version: 2019.2.17f1 (see `ProjectSettings/ProjectVersion.txt`)
- Works in the Editor for playtesting. VR hardware is optional thanks to mouse/keyboard fallbacks.

## Run in Unity (quick)
1. Install Unity Editor 2019.2.17f1 (or a compatible 2019.2.x build) and Unity Hub.
2. Open Unity Hub → Add the project and select this repository folder (`MathMania-College-VR-Game-Dev-Project`).
3. Let Unity import assets and compile scripts (this may take a few minutes).
4. Open the Scene you want to test (e.g., the main scene in `Assets/Scenes`).
5. Press Play to run the scene.

## Run without VR (mouse/keyboard fallback)
This project contains helper scripts and guides so you can play without a VR headset. The easiest method is to add the provided components to the Main Camera:

- Open `Assets/Scripts/VISUAL_SETUP_GUIDE.txt` for step-by-step screenshots/checklists and the recommended settings.
- Recommended (fast):
	1. Select the Main Camera in your scene.
	2. Add the component `SimpleMouseShooter` and assign a Bullet prefab (see the guide for where to find the prefab).
	3. Add the component `MouseLook` and set the Player Body reference.
	4. Ensure `shoot.cs` on any Gun objects has mouse shooting enabled (the inspector field is provided).
	5. Click the Game view, press Play, move the mouse to aim, and hold Left Mouse Button to shoot.

See `Assets/Scripts/VISUAL_SETUP_GUIDE.txt`, `Assets/Scripts/HOW_TO_SHOOT_WITHOUT_VR.txt` and `Assets/Scripts/MOUSE_GUN_SETUP_GUIDE.txt` for detailed instructions and troubleshooting.

## Useful checks & troubleshooting
- If scripts fail to compile:
	- Open the Console window and inspect the first error — fix the top-most error first (later errors are often caused by the first one).
	- Common causes: missing package/plugin DLLs (third-party SDKs), or scripts referencing packages not installed.
	- If you see errors related to native plugins (SALSA, MRTK, SteamVR), try these:
		- Make sure required packages are installed (if you intend to use VR features).
		- If you don't have the plugin and you only need to play without VR, check the project for any compatibility stubs in `Assets/Scripts/Utilities` or remove the plugin-prefab references temporarily.
- If the mouse does not control the camera: click inside the Game view to lock the cursor and try again.
- If bullets spawn but don't move: increase `Bullet Speed` on `SimpleMouseShooter`.

## Notes for presenting / demoing
- Mouse fallback was added so the project can be played without VR hardware — great for classroom demos.
- Follow the quick testing checklist in `Assets/Scripts/VISUAL_SETUP_GUIDE.txt` before your presentation.

## Contact / Next steps
If you run into any issues you can't resolve, open an issue or reply here with the Editor Console output and I can help debug further.

Enjoy the project!