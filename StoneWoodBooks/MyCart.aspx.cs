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
    public partial class MyCart : System.Web.UI.Page
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
                "Books_BookCategories.ISBN AND BookCategories.CategoryCode = Books_BookCategories.CategoryCode" +
                "AND OrderItem.OrderID = null AND ";

            throw new Exception("Find out how to incorporate customers here");


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

                    Button btnRemove = new Button();
                    btnRemove.Text = "+";
                    btnRemove.Click += btnRemove_Click;
                    tr.Cells[5].Controls.Add(btnRemove);

                    //tblBooks.Rows.Add(tr);
                    row++;
                }
            }
            conn.Close();
        }

        protected void ConfirmOrder(object sender, EventArgs e)
        {
            // Make a new SQL connection and Insert the book into
            // 
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            
            cmd.CommandText = "Insert into Orders(OrderDate, CustomerID)" +
                //"Values (" + DateTime.Now + ", " +  + "');";  // I need to figure out how to get the customerID

            cmd.ExecuteReader();

            double total = 0;
            /*foreach (TableRow tr in tblBooks.Rows)
            {
                cmd.CommandText = "Insert into OrderItem(OrderID)" +
                //"Values (Select MAX(OrderID) From Orders Where Orders.CutomerID = '" +  + "')" +
                "Where ItemNumber = (Select Max(ItemNumber) From OrderItem Where OrderItem.ISBN = " + tr.Cells[4].Text +
                "And OrderID = null);";
                cmd.ExecuteReader();

                total += double.Parse(tr.Cells[2].Text);
            }*/

            cmd.CommandText = "Insert into Orders(OrderValue)" +
                "Values (" + total + ") Where CustomerID = ";




            // Open the connection and execute the command
            // store the returned data in a SqlDataReader object
            conn.Open();
            cmd.ExecuteReader();
            conn.Close();
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {

        }
    }
}