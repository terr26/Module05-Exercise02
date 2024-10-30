using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module07Data_Access.Services
{
    public class DatabaseConnectionService
    {
        private readonly string _connectionString;


        public DatabaseConnectionService()
        {
            _connectionString = "Server=localhost;Database=testDb;User ID=testuser;Password=Terrcode26!;";
        }

        public string GetConnectionString()

        {
            return
                _connectionString;
        }
    }
}
