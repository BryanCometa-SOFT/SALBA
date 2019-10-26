/*
************************************************************************
Nombre del software: SALBA
Software creado por: ADSI 1993441
Fecha de creación del proyecto: 23/10/2019
Versión del programa:  2.0
Formulario creado por: Bryan Stiven Cometa Perdomo
Formulario modificado por: Bryan Stiven Cometa Perdomo
Fecha de última modificación: 23/10/2019 
Hora de última modificación:  10:35 pm
*********************************************************************
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SALBA_FULL
{
    class ConexionBD
    {
        private static SqlConnection con;

        private ConexionBD()
        {

        }

        public static SqlConnection obtenerConexion()
        {
            if (con == null)
            {
                con = new SqlConnection(Properties.Settings.Default.cadena);
            }
            return con;
        }
    }
}
