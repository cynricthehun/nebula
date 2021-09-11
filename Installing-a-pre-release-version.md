# Installing and testing a pre-release version of the mod

## Mod Manager (Recommended)
You can install Nebula from [Thunderstore](https://dsp.thunderstore.io/package/nebula/NebulaMultiplayerMod/) using a mod manager such as [R2ModMan](https://dsp.thunderstore.io/package/ebkr/r2modman/) or [Thunderstore Mod Manager](https://www.overwolf.com/app/Thunderstore-Thunderstore_Mod_Manager)

See [DSP-Wiki](https://dsp-wiki.com/Modding:Getting_Started#Using_the_Mod_Manager) for more specific instructions on how to use it.

## Manual Installation
1. Install [BepInEx](https://github.com/BepInEx/BepInEx/releases/latest) inside the Dyson Sphere Program Steam installation folder.
   - Download `BepInEx_x64_<version>.zip` from the link above
   - Unzip the contents of the zip to `C:\Program Files (x86)\Steam\steamapps\common\Dyson Sphere Program\` (or wherever you have installed Dyson Sphere Program to)
   - Run the game once to activate BepInEx (new subfolders should appears in the BepInEx folder)
2. Download the latest version of the [pre-release version](https://github.com/hubastard/nebula/releases/latest) that you want to use. For example: `Nebula_vX.X.X.X.zip`
3. Unzip the contents of the zip into the `Dyson Sphere Program/BepInEx/plugins` folder
4. Run the game
5. If you see a `Multiplayer` button in the main menu it means that the mod installation worked! Have fun!

### Side Notes:
- Default port used to connect to the host is `8469`
- This means that the host most port forward the port `8469` for others to be able to connect to the game. 
    - You can follow this [Minecraft port forwarding tutorial](https://www.youtube.com/watch?v=X75GbRaGzu8&ab_channel=TroubleChute) if you have no idea how to do that, just remember to use the port `8469`. Please note that we use **TCP** - not UDP, so you only need to open the ports for TCP.
