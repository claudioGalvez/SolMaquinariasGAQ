using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    
    public class Validacion
    {
        public string Negusuario { get; set; }
        public string NegPass { get; set; }

        DatosBD datos = new DatosBD();

        public int validalogin()
        {
            datos.Datosusuario = Negusuario;
            datos.Datospass = NegPass;

            Boolean sel = datos.existeusuario();
            int retorno = 0;
            int intentos = 0;

            if (sel == true)
            {
                intentos = datos.intentosconexion();

                if (intentos > 3)
                {
                    retorno = 3;
                }
                else
                {
                    Boolean resact = datos.actualizaintentocero();
                }
            }
            else
            {
                Boolean existerut = datos.buscarut();
                if (existerut == true)
                {
                    intentos = datos.intentosconexion();
                    if (intentos > 3)
                    {
                        retorno = 3;
                    }
                    else
                    {
                        Boolean resactotro = datos.actualizaintentootro();
                        retorno = 1;
                    }
                }
                else
                {
                    retorno = 2;
                }
            }

            return retorno;
        }
    }
}
