using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StoneWoodBooks
{
    public partial class OrdersTable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            while (tblOrders.Rows.Count > 1)
                tblOrders.Rows.RemoveAt(1);
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM Orders";
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TableRow tr = new TableRow();
                    TableCell tc = new TableCell();
                    tc.Text = reader["OrderID"].ToString();
                    tr.Cells.Add(tc);

                    tc = new TableCell();
                    tc.Text = reader["OrderDate"].ToString();
                    tr.Cells.Add(tc);

                    tc = new TableCell();
                    tc.Text = reader["OrderValue"].ToString();
                    tr.Cells.Add(tc);

                    tc = new TableCell();
                    tc.Text = reader["Username"].ToString();
                    tr.Cells.Add(tc);

                    tblOrders.Rows.Add(tr);
                }
            }
            conn.Close();
        }

        protected void btnQueryOrders_Click(object sender, EventArgs e)
        {
            
            if (txtOrders.Text.Equals(""))
            {
                Page_Load(sender, e);
            }
            else
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = txtOrders.Text;
                while (tblOrders.Rows.Count > 1)
                    tblOrders.Rows.RemoveAt(1);
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            TableRow tr = new TableRow();
                            TableCell tc = new TableCell();
                            tc.Text = reader["OrderID"].ToString();
                            tr.Cells.Add(tc);

                            tc = new TableCell();
                            tc.Text = reader["OrderDate"].ToString();
                            tr.Cells.Add(tc);

                            tc = new TableCell();
                            tc.Text = reader["OrderValue"].ToString();
                            tr.Cells.Add(tc);

                            tc = new TableCell();
                            tc.Text = reader["Username"].ToString();
                            tr.Cells.Add(tc);

                            tblOrders.Rows.Add(tr);
                        }
                    }
                    conn.Close();
                }
                catch(Exception)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sorry, something went wrong.')", true);
                }
            }
        }
    }
}