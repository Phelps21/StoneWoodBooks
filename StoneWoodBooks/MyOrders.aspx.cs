using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;

namespace StoneWoodBooks
{
    public partial class MyOrders : Page
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            cmd.Connection = conn;

            cmd.CommandText = "Select * From Orders Where Username = '" + Cache.Get("Username") + "';";

            // Open the connection and execute the command
            // store the returned data in a SqlDataReader object
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            // If there is data in the SqlDataReader object
            // then loop through each record to build the table to display the orders
            if (reader.HasRows)
            {
                int row = 0;
                // Build the table 
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

                    tblOrders.Rows.Add(tr);
                }

                // Add a button that lets you see the individual order
                foreach (TableRow tr in tblOrders.Rows)
                {
                    if (tr == tblOrders.Rows[0])
                        continue;

                    row++;
                    TableCell tblcell = new TableCell();

                    Button btnView = new Button();
                    btnView.Text = "+";
                    int btnrow = row;
                    btnView.Click += (s, ev) => btnView_Click(btnView, e, btnrow);

                    tblcell.Controls.Add(btnView);
                    tr.Cells.Add(tblcell);
                }

                conn.Close();
            }

            else
                Response.Redirect("Default.aspx");
        }

        // Redirect the user to a specific order
        protected void btnView_Click(Object sender, EventArgs e, int row)
        {
            Button btnSent = sender as Button;
            Cache.Insert("OrderID", tblOrders.Rows[row].Cells[0].Text);
            Response.Redirect("ChangeOrder.aspx");
        }
    }
}