# Nebula mod API
## Setting up
1. Get the most up-to-date version of Dyson Sphere Program from Steam.
2. Install [BepInEx](https://github.com/BepInEx/BepInEx/releases) inside the Dyson Sphere Program Steam installation folder.
   - Download `BepInEx_x64_<version>.zip`
   - Unzip the content to `C:\Program Files (x86)\Steam\steamapps\common\Dyson Sphere Program\BepInEx`
   - Run the game once to activate BepInEx (new subfolders should appears in the BepInEx folder)
3. Download latest Nebula and API packages from Thunderstore.
4. Add a `nebula-NebulaMultiplayerMod` and `nebula-NebulaMultiplayerModApi` folders inside the `BepInEx\Plugins` folder
5. Install both plugins into created folders.
6. Add a reference to the [nuget.org package NebulaMultiplayerModApi](https://www.nuget.org/packages/NebulaMultiplayerModApi) to your project.  
If you use the new SDK format for your csproj you can simply add `<PackageReference Include="NebulaMultiplayerModApi" Version="1.*" PrivateAssets="all" />` to a PropertyGroup within your project's .csproj file.

## Releasing plugin with nebula support.
1. Don't add NebulaAPI dll to your Thunderstore archive.
2. Add `"nebula-NebulaMultiplayerModApi-1.0.0",` line to your dependencies in `manifest.json`
3. Don't forget to mention in your README in manual installation guide that NebulaAPI plugin is required.
4. Don't forget to mention in your README that your mod is compatible with Nebula Multiplayer Mod

## Example usage
### Mod plugin class
Implement `IMultiplayerMod` interface:
```cs
[BepInPlugin(GUID, NAME, VERSION)]
[BepInDependency(NebulaModAPI.API_GUID)]
public class YourMod : BaseUnityPlugin, IMultiplayerMod {

    public const string GUID = "your.plugin.guid";
    public const string NAME = "Example Name";
    public const string VERSION = "1.0.0";

    public string Version => VERSION;

    public bool CheckVersion(string hostVersion, string clientVersion)
    {
        // You can do more complex version checking here
        return hostVersion.Equals(clientVersion);
    }

    void Awake()
    {

        //...

        NebulaModAPI.RegisterPackets(Assembly.GetExecutingAssembly());
    }
}
```
If you need to sync mod settings on joining to server implement `IMultiplayerModWithSettings` instead of `IMultiplayerMod`. You only need to do this if your mod changes behavior drastically depending on config. 
```cs
[BepInPlugin(GUID, NAME, VERSION)]
[BepInDependency(NebulaModAPI.API_GUID)]
public class YourMod : BaseUnityPlugin, IMultiplayerModWithSettings {

    public const string GUID = "your.plugin.guid";
    public const string NAME = "Example Name";
    public const string VERSION = "1.0.0";

    public string Version => VERSION;

    public bool CheckVersion(string hostVersion, string clientVersion)
    {
        // You can do more complex version checking here
        return hostVersion.Equals(clientVersion);
    }

    void Awake()
    {

        //...

        NebulaModAPI.RegisterPackets(Assembly.GetExecutingAssembly());
    }

    public void Export(BinaryWriter w)
    {
        // Export data here
    }

    public void Import(BinaryReader r)
    {
        // Import data here
    }
}
```
### Creating packets
Create a class and follow this example:
```cs
public class YourCustomPacket
{
    // Only use auto properties here
    public int planetId { get; set; }

    // Save any primitive type here
    public int customValue { get; set; }
	
    // If you have data structures that are not primitives use Binary Reader and Writer provided by NebulaModAPI class and save data into bytearray
    public byte[] data { get; set; }
    
    public YourCustomPacket() { } //Make sure to keep default constructor

    // If you need more examples check NebulaModel/Packets subfolder
    public YourCustomPacket(int planetId, int customValue)
    {
        this.planetId = planetId;
        this.customValue = customValue;
		
	// Using Binary Writer
	using IWriterProvider p = NebulaModAPI.GetBinaryWriter();
        // Write to p.BinaryWriter here
        data = p.CloseAndGetBytes();
    }
}

[RegisterPacketProcessor] // This attribute lets Nebula know that this is the processor class for your new packet type
public class YourCustomPacketProcessor : BasePacketProcessor<YourCustomPacket>
{
    public override void ProcessPacket(YourCustomPacket packet, INebulaConnection conn)
    {
        PlanetData planet = GameMain.galaxy.PlanetById(packet.planetId);
        // Handle received packets here. If you need more examples check NebulaNetwork/PacketProcessors subfolder
		
	// Using Binary Reader
	using IReaderProvider p = NebulaModAPI.GetBinaryReader(packet.data);
            
        // Read from p.BinaryReader here
    }
}
```
### Access to some Nebula classes
You can access some classes from Nebula by using NebulaModAPI class getters. For more look at source code of Nebula API
```cs
// To know if the player is currently in a multiplayer game
NebulaModAPI.IsMultiplayerActive

// To send a packet to the server / clients
NebulaModAPI.MultiplayerSession.Network.SendPacket()

// All the information relative to the current local player
NebulaModAPI.MultiplayerSession.LocalPlayer
```

### Sending packets
When sending packets you need to know on which side (client or server) your code is running. To do that you can use LocalPlayer class in your code. Also note that packet processors already have a `IsHost` and `IsClient` property.
```cs
ILocalPlayer localPlayer = NebulaModAPI.MultiplayerSession.LocalPlayer;
INetworkProvider network = NebulaModAPI.MultiplayerSession.Network;

// Send packet to host (If running on client)
network.SendPacket(new YourCustomPacket(planetId, yourData));

// Send packet to all players within one star system
network.SendPacketToStar(new YourCustomPacket(planetId, yourData), GameMain.galaxy.PlanetById(planetId).star.id);
```

### Sync custom Factory Data
If your mod adds custom data that exists for each planet or star you can listen to events in NebulaModAPI and send packets accordingly:
```cs
// This is request packet, clients will send it when they need to load a planet
public class CustomFactoryLoadRequest
{
    public int planetId { get; set; }

    public CustomFactoryLoadRequest() { }
    public CustomFactoryLoadRequest(int planetId)
    {
        this.planetId = planetId;
    }
}

[RegisterPacketProcessor]
public class CustomFactoryLoadRequestProcessor : BasePacketProcessor<CustomFactoryLoadRequest>
{
    public override void ProcessPacket(CustomFactoryLoadRequest packet, INebulaConnection conn)
    {
        if (IsClient) return;

        PlanetData planet = GameMain.galaxy.PlanetById(packet.planetID);
        PlanetFactory factory = GameMain.data.GetOrCreateFactory(planet);

        using IWriterProvider p = NebulaModAPI.GetBinaryWriter();
        
        // Write to p.BinaryWriter here
		
        conn.SendPacket(new CustomFactoryData(packet.planetID, p.CloseAndGetBytes()));
    }
}

// This is a response packet from server with requested data
public class CustomFactoryData
{
    public int planetId { get; set; }
    public byte[] binaryData { get; set; }

    public CustomFactoryData() { }
    public CustomFactoryData(int id, byte[] data)
    {
        planetId = id;
        binaryData = data;
    }
}

[RegisterPacketProcessor]
public class CustomFactorDataProcessor : BasePacketProcessor<CustomFactoryData>
{
    internal static Dictionary<int, byte[]> pendingData = new Dictionary<int, byte[]>();
    
    public override void ProcessPacket(CustomFactoryData packet, INebulaConnection conn)
    {
        if (IsHost) return;

	// We need to wait due to how Nebula works
	// Note that for star packets you can process the packet here
        pendingData.Add(packet.planetId, packet.binaryData);
    }

    // This is actual place where we process the packet
    public static void ProcessBytesLater(int planetId)
    {
        if (!NebulaModAPI.IsMultiplayerActive || NebulaModAPI.MultiplayerSession.LocalPlayer.IsHost) return;
        if (!pendingData.TryGetValue(planetId, out byte[] bytes)) return;
        pendingData.Remove(planetId);
        
        using IReaderProvider p = NebulaModAPI.GetBinaryReader(bytes);
        PlanetFactory factory = GameMain.galaxy.PlanetById(planetId).factory;
        
	// Read from p.BinaryReader here
    }
}

// In your Plugin Awake call

NebulaModAPI.OnPlanetLoadRequest += planetId =>
{
    NebulaModAPI.MultiplayerSession.Network.SendPacket(new CustomFactoryLoadRequest(planetId));
};

NebulaModAPI.OnPlanetLoadFinished += CustomFactorDataProcessor.ProcessBytesLater;
```
