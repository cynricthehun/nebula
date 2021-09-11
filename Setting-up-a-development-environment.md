# Development Setup

## Repo Setup
1. Fork the repository to your own Github account.
2. Pull git repository locally (pass `--recursive` to `git clone` to init and clone submodules)
   - `git clone https://github.com/your-github-name/nebula.git --recursive`
3. Initialize git submodule(s) by running the following command:
   - `git submodule update --init --recursive` This command can also be used to fetch and update changes.

## Nebula setup
1. Get the most up-to-date version of Dyson Sphere Program from Steam.
2. Install [BepInEx](https://github.com/BepInEx/BepInEx/releases) inside the Dyson Sphere Program Steam installation folder.
   - Download `BepInEx_x64_<version>.zip`
   - Unzip the content to `C:\Program Files (x86)\Steam\steamapps\common\Dyson Sphere Program\BepInEx`
3. Run the game once to activate BepInEx (new subfolders should appears in the BepInEx folder)
4. Add a `Nebula` folder inside the `BepInEx\Plugins` folder
5. Load `Nebula.sln` inside Visual Studio
6. Add NuGet to Visual Studio package sources.
   - In the toolbar open Tools -> Options, then find NuGet Package Manager -> Package Sources
   - Create a new source with name NuGet and url https://api.nuget.org/v3/index.json
7. If your game installation is not at the default location `C:\Program Files (x86)\Steam\steamapps\common\Dyson Sphere Program` a `DevEnv.targets` file should have been generated at the root of your copy of the Nebula repo. You can change the path to your game installation location.
8. Build entire solution to generate binaries.
   - Nebula uses Visual Studio build events to automatically copy the mod binaries to the `BepInEx\Plugins\Nebula` folder.

## Verify Setup
1. Make sure that you have built the entire solution without errors
2. Start the game using `Steam`
3. From the game main menu, you should now see a `Multiplayer` button

## How to run 2 game instances on the same computer
There are two options for running multiple instances:

### Remove Single Instance
Edit `Dyson Sphere Program\DSPGAME_Data\boot.config`, removing the `single-instance=` line from the file.  
If you would like to keep the instances settings separate then Sandboxie might be preferred.

### Sandboxie
1. Install [Sandboxie Plus](https://github.com/sandboxie-plus/Sandboxie/releases)
2. Launch Sandboxie Plus
3. Right Click on `DefaultBox` and choose `Run -> Run Program`
4. In the popup window browse to select the `Steam.exe` from your Steam installation location.
5. Make sure to check the `Run As UAC Administrator` and click `OK`
6. Also start steam normally
7. You should now have 2 Steam apps running at once.
8. Start `Dyson Sphere Program` on both of them.
9. You should now have 2 Dyson Sphere Program running at once.

## Recommended Tools
I highly recommend you to use the very useful plugin [RuntimeUnityEditor](https://github.com/ManlyMarco/RuntimeUnityEditor/releases). Once installed, you only need to press `F12` while in-game to open it and you will be able to inspect any Unity GameObjects, Components and it has a runtime console to run some code at runtime.

You just need to download and unzip its content and put it in the `BepInEx\Plugins\RuntimeUnityEditor` folder next to where the Nebula plugin is.