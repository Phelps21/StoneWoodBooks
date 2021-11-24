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
    public partial class MyCart : Page
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
                "BookCategories.CategoryDescription, Book.ISBN FROM Books, Author, BookCategories, OrderItem WHERE " +
                "Author.AID = BookAuthored.AID AND Books.ISBN = BookAuthored.ISBN AND Books.ISBN = " +
                "Books_BookCategories.ISBN AND BookCategories.CategoryCode = Books_BookCategories.CategoryCode" +
                "AND OrderItem.OrderID = null AND OrderItem.CustomerID = " + Cache.Get("Username") + ";";

            // Open the connection and execute the command
            // store the returned data in a SqlDataReader object
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            // If there is data in the SqlDataReader object
            // then loop through each record to build the table to display the books
            if (reader.HasRows)
            {
                Table tblBooks = Page.FindControl("tblBooks") as Table;
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

                    Button btnRemove = new Button();
                    btnRemove.Text = "-";
                    btnRemove.Click += btnRemove_Click;
                    tr.Cells[5].Controls.Add(btnRemove);

                    tblBooks.Rows.Add(tr);
                    row++;
                }
            }
            conn.Close();
        }

        protected void ConfirmOrder(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            DateTime rn = DateTime.Now;

            conn.Open();
            cmd.CommandText = "Insert into Orders(OrderDate, CustomerID)" +
                "Values (" + rn + ", " + Cache.Get("Username") + "');";
            cmd.ExecuteReader();

            double total = 0;
            Table tblBooks = Page.FindControl("tblBooks") as Table;

            // Here we update OrderItems to connect them to an order ID and find OrderValue with total
            foreach (TableRow tr in tblBooks.Rows)
            {
                cmd.CommandText = "Update OrderItem set OrderID (Select MAX(OrderID) From Orders Where " +
                "Orders.CutomerID = '" + Cache.Get("Username") + "') Where ItemNumber = (Select Max(ItemNumber) " +
                "From OrderItem Where OrderItem.ISBN = " + tr.Cells[4].Text + "And OrderItem.CustomerID = " + 
                Cache.Get("Username") + " and OrderID = null);";
                cmd.ExecuteReader();

                total += double.Parse(tr.Cells[2].Text);
            }

            cmd.CommandText = "Update Orders OrderValue = " + total + " Where CustomerID = " + 
                Cache.Get("Username") + "AND Orders.OrderDate = " + rn + ";";


            // Open the connection and execute the command
            // store the returned data in a SqlDataReader object
            cmd.ExecuteReader();
            conn.Close();
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}