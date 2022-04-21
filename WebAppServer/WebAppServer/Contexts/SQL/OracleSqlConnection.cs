using System;
using System.Collections.Generic;
using System.IO;

namespace WebAppServer.Contexts.SQL
{
    public class OracleSqlConnection
    {
        public string GetConectionString()
        {
            string path = @"C:\Users\pkubo\OneDrive\Dokumenty\GitHub\_Keys\oracle_db_ConnectionString.txt";
            string connectionString = File.ReadAllText(path);
            return connectionString;
        }

    }
}
