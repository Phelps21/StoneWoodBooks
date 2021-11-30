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
    public partial class Reviews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String Isbn = (String)Cache.Get("ISBN");
            int isbn = Int32.Parse(Isbn);
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM BookReviews WHERE ISBN = "+isbn+";";
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TableRow tr = new TableRow();
                    TableCell tc = new TableCell();
                    tc.Text = reader["ISBN"].ToString();
                    tr.Cells.Add(tc);

                    tc = new TableCell();
                    tc.Text = reader["Username"].ToString();
                    tr.Cells.Add(tc);

                    tc = new TableCell();
                    tc.Text = reader["Description"].ToString();
                    tr.Cells.Add(tc);

                    tc = new TableCell();
                    tc.Text = reader["NumStars"].ToString();
                    tr.Cells.Add(tc);

                    tblReviews.Rows.Add(tr);
                }
            }
            conn.Close();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            String username = (string)Cache.Get("Username");
            String Isbn = (String)Cache.Get("ISBN");
            int isbn = Int32.Parse(Isbn);
            

            if(ddlStars.SelectedValue != null)
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "INSERT INTO BookReviews VALUES(" + isbn + ", '" + username
                    + "', '" + txtDescription.Text + "'," + Int32.Parse(ddlStars.SelectedValue) + ");";

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                Page_Load(sender, e);
            }
        }
    }
}