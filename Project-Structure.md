My philosophy is make it work first, then make it clean. So you will probably see lots of janky code and refactors. But overtime, once the project matures, I will make sure to keep it clean.

## Project Structure

The Solution is currently broken down into 4 main projects.
- `NebulaPatcher`
   - This project contains the entry point `NebulaPlugin.ts` for the mod.
   - It also contains all of the Harmony patches.
- `NebulaServer`
   - This project is the actual server code that the clients connect to.
   - This project does not have any reference to the actual game code it only handle server stuff (clients communication, server state, etc).
- `NebulaClient`
   - This project contains all the code that will do modification to the actual game code (spawning object, remote player synchronization, etc..)
   - It also contain the actual network client code to be able to connect to the server.
- `NebulaModel`
   - This project is contains all the code for the actual data model and is also shared between the NebulaServer and NebulaClient.
   - This project shouldn't have any reference to the actual game code.
