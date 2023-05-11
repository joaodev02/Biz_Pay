using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIM.DB
{
    static class Conn
    {

        static private string host = "localhost";
        static private string database = "holerite_pim";
        static private string user = "root";
        static private string password = "elielgomes123";
        static public string stringConnection = $"server={host};User Id={user}; database={database}; password={password}";

    }
}
