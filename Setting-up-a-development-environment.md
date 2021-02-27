# Development Setup

## Repo Setup
1. Fork the repository to your own Github account.
2. Pull git repository locally (pass `--recursive` to `git clone` to init and clone submodules)
   - `git clone https://github.com/your-github-name/nebula.git --recursive`
3. Initialize git submodule(s) by running the following command:
   - `git submodule update --init --recursive` This command can also be used to fetch and update changes.

## Nebula setup
1. Get the most up-to-date version of Dyson Sphere Program from Steam.
2. Load `Nebula.sln` inside Visual Studio
3. Install BepInEx inside the Dyson Sphere Program Steam installation folder.
   - For example: `C:\Program Files (x86)\Steam\steamapps\common\Dyson Sphere Program\BepInEx`
4. Run the game once to activate BepInEx
5. Add a `Nebula` folder inside the `BepInEx\Plugins` folder
6. Build entire solution to generate binaries.
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