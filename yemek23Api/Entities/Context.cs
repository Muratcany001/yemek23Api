using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yemek23Api.Entities.appEntities;

namespace yemek23Api.Entities
{
    internal class Context : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<restaurant> restaurants { get; set; }
        public object Users { get; internal set; }

        private readonly IMongoDatabase _database;

        public Context(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }


    }
}
