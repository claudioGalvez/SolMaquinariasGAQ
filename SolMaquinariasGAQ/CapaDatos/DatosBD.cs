using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class DatosBD
    {

        public string Datosusuario { get; set;}
        public string Datospass { get; set; }

        Conexion objBD = new Conexion();


        public Boolean existeusuario()
        {
            SqlCommand comando = new SqlCommand("SELECT * FROM USUARIO WHERE RUT='" + Datosusuario + "' AND  CLAVE='" + Datospass + 
                "' ", objBD.AbrirCon());
            SqlDataReader leer = comando.ExecuteReader();
            Boolean res = leer.Read();
            objBD.CerrarCon();
            return res;
        }

        public int intentosconexion()
        {
            int res = 0;
            SqlCommand comando = new SqlCommand("SELECT * FROM USUARIO WHERE RUT='" + Datosusuario + "' ", objBD.AbrirCon());
            SqlDataReader leer = comando.ExecuteReader();
            if (leer.Read() == true)
            {
                res = Convert.ToInt32(leer["INTENTO_CONEXION"]);
            }
            objBD.CerrarCon();
            return res;
        }

        public Boolean buscarut()
        {
            SqlCommand comando = new SqlCommand("SELECT * FROM USUARIO WHERE RUT='" + Datosusuario + "' ", objBD.AbrirCon());
            SqlDataReader leer = comando.ExecuteReader();
            Boolean resbuscarut = leer.Read();
            objBD.CerrarCon();
            return resbuscarut;
        }


        public Boolean actualizaintentocero()
        {
            Boolean res = true;
            SqlCommand comando = new SqlCommand("UPDATE USUARIO SET INTENTO_CONEXION=0 WHERE RUT = '" + Datosusuario + 
                "' ", objBD.AbrirCon());
            comando.ExecuteNonQuery();
            objBD.CerrarCon();
            return res;
        }

        public Boolean actualizaintentootro()
        {
            Boolean res = true;
            SqlCommand comando = new SqlCommand("UPDATE USUARIO SET INTENTO_CONEXION=INTENTO_CONEXION +1 WHERE RUT = '" + Datosusuario +
                "' ", objBD.AbrirCon());
            comando.ExecuteNonQuery();
            objBD.CerrarCon();
            return res;
        }
    }
}
