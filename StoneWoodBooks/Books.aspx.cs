using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace StoneWoodBooks
{
    public partial class Books : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Make a new SQL connection and select the necessary elements
            // to display on the Books page
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "SELECT Books.Title, Author.LastName, Books.Price, " +
                "BookCategories.CategoryDescription, Book.ISBN FROM Books, Author, BookCategories WHERE " +
                "Author.AID = BookAuthored.AID AND Books.ISBN = BookAuthored.ISBN AND Books.ISBN = " +
                "Books_BookCategories.ISBN AND BookCategories.CategoryCode = Books_BookCategories.CategoryCode";

            // Open the connection and execute the command
            // store the returned data in a SqlDataReader object
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            // If there is data in the SqlDataReader object
            // then loop through each record to build the table to display the books
            if (reader.HasRows)
            {
                int row = 0;
                // Build the table 
                while (reader.Read())
                {
                    TableRow tr = new TableRow();
                    TableCell tc = new TableCell();
                    tc.Text = reader["Title"].ToString();
                    tr.Cells.Add(tc);

                    tc = new TableCell();
                    tc.Text = reader["LastName"].ToString();
                    tr.Cells.Add(tc);

                    tc = new TableCell();
                    tc.Text = reader["Price"].ToString();
                    tr.Cells.Add(tc);

                    tc = new TableCell();
                    tc.Text = reader["CategoryDescription"].ToString();
                    tr.Cells.Add(tc);

                    tc = new TableCell();
                    tc.Text = reader["ISBN"].ToString();
                    tr.Cells.Add(tc);

                    Button addBtn = new Button();
                    addBtn.Text = "+";
                    addBtn.Click += (s, ev) => AddBtn_Click(sender, e, row);
                    tr.Cells[5].Controls.Add(addBtn);

                    tblBooks.Rows.Add(tr);
                    row++;
                }
            }
            conn.Close();
        }

        void AddBtn_Click(Object sender, EventArgs e, int row)
        {
            string isbn = tblBooks.Rows[row].Cells[4].Text;
            
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "Insert into OrderItem(ItemPrice, ISBN, CustomerID)" +
                "Values ((Select Price From Books Where ISBN = " + isbn + "), " +
                isbn + ", " + Cache.Get("Username") + ");";

            conn.Open();
            cmd.ExecuteReader();
            conn.Close();
        }
    }
}