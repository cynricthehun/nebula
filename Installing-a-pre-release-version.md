# Installing and testing a pre-release version of the mod

1. Install [BepInEx](https://docs.bepinex.dev/articles/user_guide/installation/index.html) into your game install directory
   - Default install location is: `C:\Program Files (x86)\Steam\steamapps\common\Dyson Sphere Program`
2. Download the latest version zip of the [pre-release version](https://github.com/hubastard/nebula/releases) that you want to use. For example: `Nebula_vX.X.X.X.zip`
3. Unzip it and move the `Nebula` folder into the `Dyson Sphere Program/BepInEx/plugins` folder
4. Run the game
5. If you see a `Multiplayer` button in the main menu it means that the mod installation worked! Have fun!

### Side Notes:
- Default port used to connect to the host is `8469`
- This means that the host most port forward the port `8469` for others to be able to connect to the game. 
    - You can follow this [Minecraft port forwarding tutorial](https://www.youtube.com/watch?v=X75GbRaGzu8&ab_channel=TroubleChute) if you have no idea how to do that, just remember to use the port `8469`. Please note that we use **TCP** - not UDP, so you only need to open the ports for TCP.
