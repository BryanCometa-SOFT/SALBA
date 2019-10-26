/*
************************************************************************
Nombre del software: SALBA
Software creado por: ADSI 1993441
Fecha de creación del proyecto: 23/10/2019
Versión del programa:  2.0
Formulario creado por: Bryan Stiven Cometa Perdomo
Formulario modificado por: Bryan Stiven Cometa Perdomo
Fecha de última modificación: 24/10/2019 
Hora de última modificación:  9:49 am
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
    public partial class FormRegistro : Form
    {
        public FormRegistro()
        {
            InitializeComponent();
        }

        private void FormRegistro_Load(object sender, EventArgs e)
        {

        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            //Validación para identificar que todos los campos esten completos.
            if(txtNombre.Text.Trim()=="" || txtNumDoc.Text.Trim() == "" || txtCorreo.Text.Trim() == "" || txtPassword.Text.Trim() == "" || txtConfirmarPassword.Text.Trim() == "")
            {
                MessageBox.Show("Debe completar todos los campos", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Text = "";
                txtConfirmarPassword.Text = "";
            }
            else
            {
                //Validación para identificar si la contraseña es igual en los dos campos
                if (txtPassword.Text.Trim() == txtConfirmarPassword.Text.Trim())
                {
                    try
                    {
                        //Permite guardar el nuevo usuario en la base de datos
                        SqlConnection con = ConexionBD.obtenerConexion();
                        SqlCommand coman = new SqlCommand("registrarUsuario", con);
                        coman.CommandType = CommandType.StoredProcedure;
                        SqlParameter paramNombre = new SqlParameter("@nom", SqlDbType.VarChar);
                        paramNombre.Value = txtNombre.Text;
                        coman.Parameters.Add(paramNombre);
                        SqlParameter paramDocumento = new SqlParameter("@doc", SqlDbType.VarChar);
                        paramDocumento.Value = txtNumDoc.Text;
                        coman.Parameters.Add(paramDocumento);
                        SqlParameter paramCorreo = new SqlParameter("@correo", SqlDbType.VarChar);
                        paramCorreo.Value = txtCorreo.Text;
                        coman.Parameters.Add(paramCorreo);
                        SqlParameter paramContraseña = new SqlParameter("@contra", SqlDbType.VarChar);
                        paramContraseña.Value = txtPassword.Text;
                        coman.Parameters.Add(paramContraseña);
                        coman.ExecuteNonQuery();
                        con.Close();

                        Close();
                        //Permite abrir el inicio de sesión 
                        FormInicioSesion inicioSesion = new FormInicioSesion();
                        inicioSesion.Show();

                    }
                    catch (Exception)
                    {

                    }
                   
                }
                else
                {
                    MessageBox.Show("Las contraseñas no coinciden  ", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Text = "";
                    txtConfirmarPassword.Text = "";
                }
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Close();
            //Permite abrir el inicio de sesión  
            FormInicioSesion inicioSesion = new FormInicioSesion();
            inicioSesion.Show();
        }

        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void FlowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FlowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TxtCorreo_TextChanged(object sender, EventArgs e)
        {

        }

        private void FlowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
