using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{
    /// <summary>
    /// Descripción breve de servicio
    /// </summary>
    [WebService(Namespace = "http://serviciocaca/",Name="RioItata")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class servicio : System.Web.Services.WebService
    {

        
        Conexion con = new Conexion();
        String sql;
        [WebMethod]
        public DataTable DatosPrensa()
        {
            sql = "SELECT TOP(25) TagPrensa.TagName,CONVERT (Char(10), FloatPrensa.DateAndTime, 103), CONVERT (Char(10), FloatPrensa.DateAndTime, 114),FloatPrensa.Val FROM FloatPrensa INNER JOIN TagPrensa ON FloatPrensa.TagIndex=TagPrensa.TagIndex ORDER BY DateAndTime desc";
            con.AbrirConexion();
            SqlDataAdapter dt = new SqlDataAdapter(sql, con.Obtenerconexion());
            DataTable da = new DataTable("da");
            dt.Fill(da);
            return da;
        }
        [WebMethod]

        public DataTable DatosCocina()
        {

            sql = "SELECT TOP(18) CamposCola.TagName,CONVERT (Char(10), MarcasCola.DateAndTime, 103), CONVERT (Char(10), MarcasCola.DateAndTime, 114), MarcasCola.Val FROM MarcasCola INNER JOIN CamposCola ON MarcasCola.TagIndex = CamposCola.TagIndex ORDER BY DateAndTime desc";
            con.AbrirConexion();
            SqlDataAdapter dt = new SqlDataAdapter(sql, con.Obtenerconexion());
            DataTable da = new DataTable("da");
            dt.Fill(da);
            return da;

        }
        [WebMethod]

        public DataTable DatosSecado()
        {
            con.AbrirConexion();
            sql = "SELECT TOP(20) TagSecado.TagName,CONVERT (Char(10), FloatSecado.DateAndTime, 103), CONVERT (Char(10),FloatSecado.DateAndTime, 114),FloatSecado.Val FROM FloatSecado INNER JOIN TagSecado ON FloatSecado.TagIndex=TagSecado.TagIndex ORDER BY DateAndTime desc";
            SqlDataAdapter dt = new SqlDataAdapter(sql, con.Obtenerconexion());
            DataTable da = new DataTable("da");
            dt.Fill(da);
            return da;

        }

        [WebMethod]
        public String Login(String rut, String contraseña)
        {
            con.AbrirConexion();
            sql = "SELECT * FROM DBO.Usuario WHERE Rut='" + rut + "' AND Contraseña='" + contraseña + "';";
            SqlDataAdapter dt = new SqlDataAdapter(sql, con.Obtenerconexion());
            DataTable da = new DataTable("da");
            dt.Fill(da);

            if (da.Rows.Count > 0)
            {
                return ("ok");
            }
            else
            {

                return ("Datos Incorrectos");
            }
        }
    }
}
