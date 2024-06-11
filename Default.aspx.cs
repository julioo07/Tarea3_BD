using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using System.Data.SqlTypes;
using System.Web.Services.Description;
using System.Security.Cryptography;

namespace Proyecto3BD
{
    public partial class _Default : Page
    {
         protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {


            }
        }

        protected void btnRegresar_Click(Object sender, EventArgs e)
        {
            pnlMenuPrincipal.Visible = true;
            pnlSeleccionEmpleado.Visible = false;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SPSFiltrarFacturas"; // Utiliza el procedimiento almacenado de filtro
                cmd.Connection = conn;

                cmd.Parameters.AddWithValue("@Entrada", TextBoxSearch.Text.Trim());

                // Agregar parámetro de salida
                SqlParameter outParameter = new SqlParameter("@OutResulTCode", SqlDbType.Int);
                outParameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outParameter);

                conn.Open();

                // Ejecuta el SP y obtiene los resultados en un SqlDataReader
                using (SqlDataReader reader = cmd.ExecuteReader())
                {

                    if (reader.HasRows)
                    {
                        // Si hay filas, enlaza el resultado al GridView
                        GridView1.DataSource = reader;
                        GridView1.DataBind();
                    }
                    else
                    {
                        // Si ningun empleado coincide con el filtro que se puso
                        Response.Write("No se encontraron resultados.");
                    }
                }

                // Después de ejecutar el comando, puedes obtener el valor del parámetro de salida
                int resultado = (int)cmd.Parameters["@OutResulTCode"].Value;
                // Hacer algo con el valor de resultado si es necesario
                if (resultado == 1)
                {
                   
                }
                else
                {
                    
                }
            }
        }


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Accion")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                pnlMenuPrincipal.Visible = false;
                pnlSeleccionEmpleado.Visible = true;

                GridViewRow selectedRow = GridView1.Rows[index];
                
                string IdPuesto = selectedRow.Cells[0].Text;
                lblIdFactura.Text = IdPuesto;

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connDB"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SPSFactura"; // Utiliza el procedimiento almacenado de filtro
                    cmd.Connection = conn;

                    cmd.Parameters.AddWithValue("@Entrada", IdPuesto);

                    // Agregar parámetro de salida
                    SqlParameter outParameter = new SqlParameter("@OutResulTCode", SqlDbType.Int);
                    outParameter.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outParameter);

                    conn.Open();

                    // Ejecuta el SP y obtiene los resultados en un SqlDataReader
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        if (reader.HasRows)
                        {
                            // Si hay filas, enlaza el resultado al GridView
                            GridView2.DataSource = reader;
                            GridView2.DataBind();
                        }
                        else
                        {
                            // Si ningun empleado coincide con el filtro que se puso
                            Response.Write("No se encontraron resultados.");
                        }
                    }
                }
            }
        }
    }
}