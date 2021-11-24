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
    public partial class AuthorsTable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            onLoad2(sender, e);
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM Author";
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TableRow tr = new TableRow();
                    TableCell tc = new TableCell();
                    tc.Text = reader["AID"].ToString();
                    tr.Cells.Add(tc);

                    tc = new TableCell();
                    tc.Text = reader["Fname"].ToString();
                    tr.Cells.Add(tc);

                    tc = new TableCell();
                    tc.Text = reader["Lname"].ToString();
                    tr.Cells.Add(tc);

                    tc = new TableCell();
                    tc.Text = reader["Gender"].ToString();
                    tr.Cells.Add(tc);

                    tc = new TableCell();
                    tc.Text = reader["DOB"].ToString();
                    tr.Cells.Add(tc);

                    tblAuthor.Rows.Add(tr);
                }
            }
            conn.Close();
        }

        protected void btnQueryAuthor_Click(object sender, EventArgs e)
        {
            //capture text from txtbox and query authors table
            OnLoad1(sender,e);
            
        }
        
        protected void OnLoad1(object sender,EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            if (!txtAuthors.Text.Equals(""))
            {
                cmd.CommandText = txtAuthors.Text;
            }
            else
            {
                cmd.CommandText = "SELECT * FROM Author";
            }
            while (tblAuthor.Rows.Count > 1)
                tblAuthor.Rows.RemoveAt(1);

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
                
            cmd.Connection = conn;
                
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
                        tc.Text = reader["AID"].ToString();
                        tr.Cells.Add(tc);

                        tc = new TableCell();
                        tc.Text = reader["Fname"].ToString();
                        tr.Cells.Add(tc);

                        tc = new TableCell();
                        tc.Text = reader["Lname"].ToString();
                        tr.Cells.Add(tc);

                        tc = new TableCell();
                        tc.Text = reader["Gender"].ToString();
                        tr.Cells.Add(tc);

                        tc = new TableCell();
                        tc.Text = reader["DOB"].ToString();
                        tr.Cells.Add(tc);

                        tblAuthor.Rows.Add(tr);
                    }
                }
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sorry, something went wrong.')", true);
            }
            conn.Close();
        }

        protected void onLoad2(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            if (!txtBooks_Authored.Text.Equals(""))
            {
                cmd.CommandText = txtBooks_Authored.Text;
            }
            else
            {
                cmd.CommandText = "SELECT * FROM Books_Authored";
            }
            while (tblBooks_Authored.Rows.Count > 1)
                tblBooks_Authored.Rows.RemoveAt(1);

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
                
            cmd.Connection = conn;
                
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
                        tc.Text = reader["ISBN"].ToString();
                        tr.Cells.Add(tc);

                        tc = new TableCell();
                        tc.Text = reader["AID"].ToString();
                        tr.Cells.Add(tc);

                        tblBooks_Authored.Rows.Add(tr);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sorry, something went wrong.')", true);
            }
            conn.Close();
        }
        protected void btnQueryBooksAuthored_Click(object sender, EventArgs e)
        {
            onLoad2(sender, e);
        }
    }
}