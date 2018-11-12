using DawnOfHistoryManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DOHMTests.Utility
{
    class InMemoryContextFactory
    {
        public static DbContextOptions<GameContext> GetContextOptions(string databaseName)
        {
            return new DbContextOptionsBuilder<GameContext>()
                .UseInMemoryDatabase(databaseName: databaseName)
                .Options;
        }
    }
}
