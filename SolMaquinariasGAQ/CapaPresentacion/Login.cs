using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btningresar_Click(object sender, EventArgs e)
        {
            Validacion valida = new Validacion();

            if (txtusuario.Text.Length == 0)
            {
                errorProvider1.SetError(txtusuario, "Ingrese usuario");
            }
            else
            {
                errorProvider1.SetError(txtusuario, "");

                if (txtpassword.Text.Length == 0)
                {
                    errorProvider1.SetError(txtpassword, "Ingrese password");
                }
                else
                {
                    errorProvider1.SetError(txtpassword, "");
                    valida.Negusuario = txtusuario.Text;
                    valida.NegPass = txtpassword.Text;

                    int salida = valida.validalogin();

                    if (salida == 0)
                    {
                        lblrespuesta.Text = ".......";
                        txtusuario.Text = "";
                        txtpassword.Text = "";
                        Principal mv = new Principal();
                        mv.ShowDialog();
                    }

                    if (salida == 1)
                    {
                        lblrespuesta.Text = "Usuario-Clave erróneo!!! Al tercer intento fallido su usuario se bloqueará";
                    }

                    if (salida == 2)
                    {
                        lblrespuesta.Text = "Usuario no valido!!!";
                    }

                    if (salida == 3)
                    {
                        lblrespuesta.Text = "Su usuario se encuentra bloqueado por intentos fallidos";
                    }
                }
            }
        }
    }
}
