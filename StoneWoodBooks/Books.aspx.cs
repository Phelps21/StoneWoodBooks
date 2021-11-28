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

            cmd.CommandText = "SELECT Books.Title, Author.Lname, Books.Price, BookCategories.CategoryDescription, Books.ISBN, Books.PublicationDate FROM Books, Author," +
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

                    tc = new TableCell();
                    tc.Text = reader["PublicationDate"].ToString();
                    tr.Cells.Add(tc);
                    tblBooks.Rows.Add(tr);
                }

                foreach(TableRow tr in tblBooks.Rows)
                {
                    
                    if (tr == tblBooks.Rows[0])
                        continue;

                    row++;
                    TableCell tblcell = new TableCell();

                    Button addBtn = new Button();
                    addBtn.Text = "+";
                    int btnrow = row; 
                    addBtn.Click += (s, ev) => AddBtn_Click(sender, e, btnrow);

                    tblcell.Controls.Add(addBtn);
                    tr.Cells.Add(tblcell);

                    //code to add button for reviews
                    TableCell newCell = new TableCell();
                    Button reviewsButton = new Button();
                    reviewsButton.Text = "Reviews";
                    int newBtnRow = row;
                    reviewsButton.Click += (s, ev) => ReviewsBtn_Click(sender, e, newBtnRow);
                    newCell.Controls.Add(reviewsButton);
                    tr.Cells.Add(newCell);
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
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        void ReviewsBtn_Click(Object sender, EventArgs e, int row)
        {
            Session["ISBN"] = tblBooks.Rows[row].Cells[4].Text;
            Cache.Insert("ISBN", Session["ISBN"]);
            Response.Redirect("Reviews.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            if (txtBookSearch.Equals(""))
            {
                cmd.CommandText = "SELECT Books.Title, Author.Lname, Books.Price, BookCategories.CategoryDescription, Books.ISBN, Books.PublicationDate FROM Books, Author," +
                    " BookCategories, Book_And_Category, Books_Authored WHERE Books.ISBN = Books_Authored.ISBN AND Books.ISBN = Book_And_Category.ISBN " +
                    "AND Book_And_Category.CategoryID = BookCategories.CategoryID AND Books_Authored.AID = Author.AID;";
            }
            else
            {
                //uses pattern matching and a bunch of ORs to filter by keyword
                cmd.CommandText = "SELECT * FROM(SELECT Books.Title, Author.Lname, Books.Price, BookCategories.CategoryDescription, Books.ISBN, Books.PublicationDate FROM Books, Author," +
                    " BookCategories, Book_And_Category, Books_Authored WHERE Books.ISBN = Books_Authored.ISBN AND Books.ISBN = Book_And_Category.ISBN " +
                    "AND Book_And_Category.CategoryID = BookCategories.CategoryID AND Books_Authored.AID = Author.AID) WHERE Books.Title = '" +%txtBookSearch.Text%"' ""OR Author.Fname ;";
            }
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
                
                cmd.Connection = conn;

                /*cmd.CommandText = "SELECT Books.Title, Author.Lname, Books.Price, BookCategories.CategoryDescription," +
                    " Books.ISBN FROM Books, Author, BookCategories WHERE Author.AID = Books_Authored.AID AND Books.ISBN = " +
                    "Books_Authored.ISBN AND Books.ISBN = Book_BookCategories.ISBN AND BookCategories.CategoryID =" +
                    " Book_BookCategories.CategoryID";*/

                cmd.CommandText = "SELECT Books.Title, Author.Lname, Books.Price, BookCategories.CategoryDescription, Books.ISBN, Books.PublicationDate FROM Books, Author," +
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

                        tc = new TableCell();
                        tc.Text = reader["PublicationDate"].ToString();
                        tr.Cells.Add(tc);
                        tblBooks.Rows.Add(tr);
                    }
                }
            }
        }
    }
}