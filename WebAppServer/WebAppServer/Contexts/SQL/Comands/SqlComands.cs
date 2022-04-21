using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppServer.Contexts.SQL.Comands
{
    public abstract class SqlComands<T> : OracleSqlConnection
    {
        protected virtual void Insert_T(T user)
        {
            using (OracleConnection conn = new OracleConnection(GetConectionString()))
            {
                conn.Open();
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = MakeInsertReq(user);
                    cmd.CommandType = CommandType.Text;

                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var tmp = reader.GetString("Name");
                        }
                    }
                }
                conn.Dispose();
            }
        }
        protected virtual void Delete_T()
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(GetConectionString()))
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = MakeDeleteReq();
                        cmd.CommandType = CommandType.Text;

                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var tmp = reader.GetString("Name");
                            }
                        }
                    }
                    conn.Dispose();
                }
            }
            catch (Exception eeee)
            {
                //throw;
            }
        }

        public abstract string MakeInsertReq(T user);
        public abstract string MakeDeleteReq();

    }
}
