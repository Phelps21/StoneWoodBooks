using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace StoneWoodBooks
{
    public partial class MyCart : Page
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection conn = new SqlConnection();
        double total = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Make a new SQL connection and select the necessary elements
            // to display on MyCart
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            cmd.Connection = conn;

            cmd.CommandText = "SELECT MAX(Books.Title) as Title, MAX(Author.Lname) as Lname, MAX(OrderItem.ItemPrice) as ItemPrice, " +
                "MAX(BookCategories.CategoryDescription) as CategoryDescription, Max(OrderItem.ISBN) as ISBN FROM Books, Author, Books_Authored, " +
                "BookCategories, OrderItem, Book_And_Category WHERE Books_Authored.ISBN = OrderItem.ISBN " +
                "AND Author.AID = Books_Authored.AID AND BookCategories.CategoryID = Book_And_Category.CategoryID " +
                "AND Books.ISBN = OrderItem.ISBN AND OrderItem.Username = '" + Cache.Get("Username") + "' " +
                "AND OrderItem.OrderID IS NULL group by OrderItem.ItemNumber;";

            // Open the connection and execute the command
            // store the returned data in a SqlDataReader object
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            // If there is data in the SqlDataReader object
            // then loop through each record to build the table to display the books
            if (reader.HasRows)
            {
                int row = 0;
                // Build the table dynamically
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
                    tc.Text = reader["ItemPrice"].ToString();
                    total += double.Parse(reader["ItemPrice"].ToString());
                    tr.Cells.Add(tc);

                    tc = new TableCell();
                    tc.Text = reader["CategoryDescription"].ToString();
                    tr.Cells.Add(tc);

                    tc = new TableCell();
                    tc.Text = reader["ISBN"].ToString();
                    tr.Cells.Add(tc);

                    tblBooks.Rows.Add(tr);
                }

                // For each row in the table add a button that lets you remove items
                foreach (TableRow tr in tblBooks.Rows)
                {
                    if (tr == tblBooks.Rows[0])
                        continue;

                    row++;
                    TableCell tblcell = new TableCell();

                    Button btnRemove = new Button();
                    btnRemove.Text = "-";
                    int btnrow = row;
                    btnRemove.Click += (s, ev) => btnRemove_Click(btnRemove, e, btnrow);

                    tblcell.Controls.Add(btnRemove);
                    tr.Cells.Add(tblcell);

                }

                conn.Close();
            }

            else
                Response.Redirect("Default.aspx");
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            DateTime rn = DateTime.Now;
            string formattedtime = rn.ToString("yyyy-MM-dd HH:mm:ss.fff");

            conn.Open();
            // Make a new row in Orders for the incoming items
            cmd.CommandText = "Insert into Orders(OrderDate, OrderValue, Username)" +
                "Values ('" + formattedtime + "', " + total + ", '" + Cache.Get("Username") + "');";
            cmd.ExecuteNonQuery();


            // Here we update OrderItems to connect them to an order ID
            cmd.CommandText = "Update OrderItem set OrderID = (Select MAX(OrderID) From Orders Where " +
            "Orders.Username = '" + Cache.Get("Username") + "') Where OrderItem.Username = '" + Cache.Get("Username") 
            + "' AND OrderID is null;";
            cmd.ExecuteNonQuery();
            conn.Close();

            Response.Redirect("MyCart.aspx");
        }

        // Remove items from the table
        protected void btnRemove_Click(object sender, EventArgs e, int row)
        {
            string isbn = tblBooks.Rows[row].Cells[4].Text;
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            cmd.Connection = conn;

            cmd.CommandText = "Delete From OrderItem Where ItemNumber = (Select Min(ItemNumber) From OrderItem " +
                "Where ISBN = " + isbn + " and OrderID IS Null and Username = '" + Cache.Get("Username") + "');";

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            Response.Redirect("MyCart.aspx");
        }

    }
}