using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.LIB
{
    public class Connexion : IConnexion
    {
        private IDbConnection cnx;
        private IDbCommand cmd;
        public Connexion()
        {
            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=ENSATDB;Trusted_Connection=True;";
            cnx = new SqlConnection(connectionString);
            cmd = cnx.CreateCommand();
        }
        public void Connect()
        {
            if (cnx.State != ConnectionState.Open)
                cnx.Open();
        }
        public void Dispose()
        {
            if (cmd != null)
                cmd.Dispose();
            if (cnx != null && cnx.State == ConnectionState.Open)
                cnx.Close();
        }
        public int iud(string sql, Dictionary<string, object> parameters = null)
        {
            cmd.CommandText = sql;
            cmd.Parameters.Clear();
            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    var p = cmd.CreateParameter();
                    p.ParameterName = param.Key;
                    p.Value = param.Value ?? DBNull.Value;
                    cmd.Parameters.Add(p);
                }
            }
            Connect();

            return cmd.ExecuteNonQuery();
        }
        public IDataReader select(string sql, Dictionary<string, object> parameters = null)
        {
            cmd.CommandText = sql;
            cmd.Parameters.Clear();
            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    var p = cmd.CreateParameter();
                    p.ParameterName = param.Key;
                    p.Value = param.Value ?? DBNull.Value;
                    cmd.Parameters.Add(p);
                }
            }
            Connect();
            return cmd.ExecuteReader();
        }
    }
}

