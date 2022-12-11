using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class Conexion
    {
        SqlConnection cnn = new SqlConnection(@"Data Source=localhost;Initial Catalog=CRMCLI;Integrated Security=True");

        public SqlConnection AbrirCon()
        {
            cnn.Open();
            return cnn;
        }

        public SqlConnection CerrarCon()
        {
            cnn.Close();
            return cnn;
        }
    }
}
