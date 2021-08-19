﻿// unset

namespace NebulaAPI
{
    public interface IFactoryManager
    {
        IToggle IsIncomingRequest { get; }

        int PacketAuthor { get; set; }

        int TargetPlanet { get; set; }

        PlanetFactory EventFactory { get; set; }

        void AddPlanetTimer(int planetId);
    }
}