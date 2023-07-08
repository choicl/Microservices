﻿using CommandsService.Models;

namespace CommandsService.Data
{
    public interface ICommandRepo
    {
        bool SaveChanges();

        // Platform related
        IEnumerable<Platform> GetAllPlatforms();
        void CreatePlatform(Platform platform);
        bool PlatformExists(int platformId);

        // Commands related
        IEnumerable<Command> GetCommandsForPlatform(int platformId);
        Command GetCommand(int platformId, int commandId);
        void CreateCommand(int platformId, Command command);
    }
}
