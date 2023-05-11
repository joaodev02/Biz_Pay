using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIM.Database
{
    static class Connection
    {

        static private string host = "localhost";
        static private string database = "holerite_pim";
        static private string user = "root";
        static private string password = "elielgomes123";
        static public string stringConnection = $"server={host};uid={user};password={password};database={database};";
        static private MySqlConnection _connection;


        static public MySqlDataReader connectDB(string sqlCommand)
        {

            _connection = new MySqlConnection(stringConnection);
            _connection.Open();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = _connection;

            cmd.CommandText = sqlCommand;
            cmd.Prepare();

            MySqlDataReader rdr = cmd.ExecuteReader();

            return rdr;
        }

        static public void closeConnetionDB()
        {
            _connection.Close();
        }
    }
}
