using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{
    public class Conexion
    {
        SqlConnection cn;

        String cadena = "Data Source=CRISTINA;Initial Catalog=eTata;Integrated Security=True";

        public void AbrirConexion()
        {

            cn = new SqlConnection(cadena);
            cn.Open();

        }

        public SqlConnection Obtenerconexion()
        {

            return this.cn;


        }
        public void Cerrarconecion()
        {

            cn.Close();
        }

    }
}