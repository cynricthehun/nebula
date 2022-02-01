# Mod Installation

## Installing Dependencies
---
You will need to begin this process with Dyson Sphere Program not installed.

### Configure & Install correct Dyson Sphere Program version
1. Open your Steam Library and select Dyson Sphere Program.
2. Open properties by right-clicking Dyson Sphere Program in games and select Properties.
3. Open the **BETAS** tab
4. Select Beta version 0.8.x
5. Install Dyson Sphere Program.

## Mod Installation Options

### Mod Manager (Recommended)
---
You can install Nebula from [Thunderstore](https://dsp.thunderstore.io/package/nebula/NebulaMultiplayerMod/) using a mod manager such as [R2ModMan](https://dsp.thunderstore.io/package/ebkr/r2modman/) or [Thunderstore Mod Manager](https://www.overwolf.com/app/Thunderstore-Thunderstore_Mod_Manager)

See [DSP-Wiki](https://dsp-wiki.com/Modding:Getting_Started#Using_the_Mod_Manager) for more specific instructions on how to use it.

### Manual MOD Installation
---
1. Open your Steam library and select Dyson Sphere Program.
2. Open Dyson Sphere Program installation directory by right-clicking Dyson Sphere Program -> Manage -> Browse Local Files.
3. Download [BepInEx](https://github.com/BepInEx/BepInEx/releases/latest) from the assets section. The 64-bit is recommended (`BepInEx_x64_<version>.zip`).
4. Copy everything from the downloaded `BepInEx` zip file into the Dyson Sphere Program install directory you openned in step 2.
5. Launch Dyson Sphere Program from Steam Library.
        - This step will create a folder named, `'plugins'` inside the BepInEx directory you recently copied into DSP Installation directory.
6. Close Dyson Sphere Program.
7. Download compiled [Nebula](https://github.com/hubastard/nebula/releases/latest) from assets section. Should be labeled `Nebula_x.x.x.zip`.
8. Copy contents from `Nebula` zip into the recently created plugins folder (`Dyson Sphere Program/BepInEx/plugins`) inside BepInEx directory.
9. Launch Dyson Sphere Program from Steam Library again.
10. Select `Multiplayer` option that should now be present in your main menu.

## Extras

### Server Accessibility
---
Server Accessibility is beyond the scope of this tutorial, but it's worth notifying you of the subject matter in case you need some exposure to key terms for research purposes.

### Port Forwarding
---
The host will need to ensure that `tcp port 8469` is open on their personal network in order for others to connect to their server. You can check out [Minecraft port forwarding tutorial](https://www.youtube.com/watch?v=X75GbRaGzu8&ab_channel=TroubleChute) if you aren't familiar with this subject matter. 

### Firewall Settings
---
The host will need to review their computers firewall settings to ensure they're are allowing network traffic access to the game.

### Public IP Distribution
---
The host will need to have their public ip address for distribution. `https://whatsmyip.com/` among many other websites are a great way to get this information.
