using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIM.DB
{
    internal class User
    {
        private readonly MySqlConnection _connection;

        public User(string connectionString)
        {
            this._connection = new MySqlConnection(connectionString);
        }

        p
    }
}
