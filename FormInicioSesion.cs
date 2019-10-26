/*
************************************************************************
Nombre del software: SALBA
Software creado por: ADSI 1993441
Fecha de creación del proyecto: 23/10/2019
Versión del programa:  2.0
Formulario creado por: Bryan Stiven Cometa Perdomo
Formulario modificado por: Bryan Stiven Cometa Perdomo
Fecha de última modificación: 24/10/2019 
Hora de última modificación: 9:49 am
*********************************************************************
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SALBA_FULL
{
    public partial class FormInicioSesion : Form
    {
        public FormInicioSesion()
        {
            InitializeComponent();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnMinimizar_Click(object sender, EventArgs e)
        { 
            WindowState= FormWindowState.Minimized;
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            //Validación en caso qué los campos esten vacios.
            if(txtUsuario.Text.Trim()=="" || txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Debe completar todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    //Identifica si el usuario esta registrado y tiene las credenciales correctas.
                    SqlConnection con = ConexionBD.obtenerConexion();
                    SqlCommand coman = new SqlCommand("inicioSesion", con);
                    coman.CommandType = CommandType.StoredProcedure;
                    SqlParameter paramUsuario = new SqlParameter("@doc",SqlDbType.VarChar);
                    paramUsuario.Value = txtUsuario.Text.Trim();
                    coman.Parameters.Add(paramUsuario);
                    SqlParameter paramPass = new SqlParameter("@contra",SqlDbType.VarChar);
                    paramPass.Value = txtPassword.Text.Trim();
                    coman.Parameters.Add(paramPass);
                    SqlDataReader leer = coman.ExecuteReader();
                    con.Close();
                    //Valida si el registro existe.
                    if (leer.Read())
                    {
                        
                        MessageBox.Show("Bienvenido a SALBA", "ADSI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Hide();
                        //El objeto registro abre el formulario de menuPrincipal una vez el usuario ingreso con sus credenciales.
                        FormMenuPrincipal menuPrincipal = new FormMenuPrincipal();
                        menuPrincipal.Show();

                    }
                    else
                    {
                        MessageBox.Show("Sus credenciales son invalidas", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtPassword.Text = "";
                    }
                }
                catch (Exception)
                {

                } 
            }
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            Hide();
            //Permite abrir el formulario de registro para que el usuario pueda registrarse.
            FormRegistro registro = new FormRegistro();
            registro.Show();
        }

        private void FormInicioSesion_Load(object sender, EventArgs e)
        {

        }

        private void TxtUsuario_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
