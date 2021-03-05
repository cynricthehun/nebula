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
5. Next, you will need to copy the following DLLs to the `/Libs` folder of the Nebula repo.
   - From `Dyson Sphere Program\BepInEx\core\` copy `0Harmony.dll`, `BepInEx.dll` and `BepInEx.Harmony.dll`
   - From `Dyson Sphere Program\DSPGAME_Data\Managed\` copy `Assembly-CSharp.dll` and all the DLLs that starts with `Unity`
6. **IMPORTANT!!** Once all the DLLs are copied to the `/Libs` folder, you need to select all the Unity DLLs and drag them on the `DowngradeDll.exe`
7. Load `Nebula.sln` inside Visual Studio
8. Build entire solution to generate binaries.
   - Nebula uses Visual Studio build events to automatically copy the mod binaries to the `BepInEx\Plugins\Nebula` folder.

## Verify Setup
1. Make sure that you have built the entire solution without errors
2. Start the `NebulaServer` app from within VisualStudio (or from the built .exe at `Nebula\NebulaServer\bin\<target>\netcoreapp3.1\NebulaServer.exe`)
3. Start the game using `Steam`
4. From the game main menu, you should now see a `Multiplayer` button
5. Click `Multiplayer`
6. If the server is not running on your machine, you will need specify the ip and port in the `host` input
   - For example: `127.0.0.1:8469` (If the NebulaServer uses the default port `8469`, you can omit the port in the input field) 
7. Click `Join Game`
8. You should now see in your server prompt that a new connection was made

## How to run 2 game instances on the same computer
1. Install [Sandboxie Plus](https://github.com/sandboxie-plus/Sandboxie/releases)
2. Launch Sandboxie Plus
3. Right Click on `DefaultBox` and choose `Run -> Run Program`
4. In the popup window browser to select the `Steam.exe` from your Steam installation location.
5. Make sure to check the `Run As UAC Administrator` and click `OK`
6. Also start steam normally
7. You should now have 2 Steam apps running at once.
8. Start `Dyson Sphere Program` on both of them.
9. You should now have 2 Dyson Sphere Program running at once.

## Recommended Tools
I highly recommend you to use the very useful plugin [RuntimeUnityEditor](https://github.com/ManlyMarco/RuntimeUnityEditor/releases). Once installed, you only need to press `F12` while in-game to open it and you will be able to inspect any Unity GameObjects, Components and it even have a runtime console to run some code at runtime.

You just need to download and unzip its content into and put it in the `BepInEx\Plugins\RuntimeUnityEditor` folder next to where the Nebula plugin is.