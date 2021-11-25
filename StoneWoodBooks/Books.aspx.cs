using System;
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

            /*cmd.CommandText = "SELECT Books.Title, Author.Lname, Books.Price, BookCategories.CategoryDescription," +
                " Books.ISBN FROM Books, Author, BookCategories WHERE Author.AID = Books_Authored.AID AND Books.ISBN = " +
                "Books_Authored.ISBN AND Books.ISBN = Book_BookCategories.ISBN AND BookCategories.CategoryID =" +
                " Book_BookCategories.CategoryID";*/

            cmd.CommandText = "SELECT Books.Title, Author.Lname, Books.Price, BookCategories.CategoryDescription, Books.ISBN FROM Books, Author," +
                " BookCategories, Book_And_Category, Books_Authored WHERE Books.ISBN = Books_Authored.ISBN AND Books.ISBN = Book_And_Category.ISBN " +
                "AND Book_And_Category.CategoryID = BookCategories.CategoryID AND Books_Authored.AID = Author.AID;";


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
                    tc.Text = reader["Lname"].ToString();
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

                    tblBooks.Rows.Add(tr);
                    row++;
                }

                foreach(TableRow tr in tblBooks.Rows)
                {
                    if (tr == tblBooks.Rows[0])
                        continue;

                    TableCell tblcell = new TableCell();

                    Button addBtn = new Button();
                    addBtn.Text = "+";
                    addBtn.Click += (s, ev) => AddBtn_Click(sender, e, row);

                    tblcell.Controls.Add(addBtn);
                    tr.Cells.Add(tblcell);
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

            cmd.CommandText = "Insert into OrderItem(ItemPrice, ISBN, Username)" +
                "Values ((Select Price From Books Where ISBN = " + isbn + "), " +
                isbn + ", '" + Cache.Get("Username") + "');";

            conn.Open();
            cmd.ExecuteReader();
            conn.Close();
        }
    }
}