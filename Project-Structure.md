My philosophy is make it work first, then make it clean. So you will probably see lots of janky code and refactors. But overtime, once the project matures, I will make sure to keep it clean.

## Project Structure

The Solution is currently separated into 5 main projects.
- `NebulaPatcher`
   - This project contains the entry point `NebulaPlugin.ts` for the mod.
   - It also contains all of the Harmony patches and transpilers.
- `NebulaHost`
   - This project includes all the networking code for the Master Client (Host).
   - This project has access to all the host game code.
   - This project is responsible for processing incoming packets received from remote clients.
- `NebulaClient`
   - This project includes all the networking code for the remote clients.
   - This project has access to all of the client game code.
   - This project is responsible for processing incoming packets received from the host.
- `NebulaModel`
   - This project contains all the data model that are shared between all projects.
   - This project shouldn't have any reference to the actual game code
- `NebulaWorld`
   - This project should includes all the code that interact with the actual game world.
   - This project contains at its core the `SimulatedWorld` class which is used to manipulate the world and keep track of all the temporary entities that were created during a multiplayer session.
