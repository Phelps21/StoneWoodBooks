using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;

namespace StoneWoodBooks
{
    public partial class ChangeOrder : Page
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = WebConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            cmd.Connection = conn;

            cmd.CommandText = "SELECT MAX(Books.Title) as Title, MAX(Author.Lname) as Lname, MAX(OrderItem.ItemPrice) as ItemPrice, " +
                "MAX(BookCategories.CategoryDescription) as CategoryDescription, Max(OrderItem.ISBN) as ISBN FROM Books, Author, Books_Authored, " +
                "BookCategories, OrderItem, Book_And_Category WHERE Books_Authored.ISBN = OrderItem.ISBN " +
                "AND Author.AID = Books_Authored.AID AND BookCategories.CategoryID = Book_And_Category.CategoryID " +
                "AND Books.ISBN = OrderItem.ISBN AND OrderItem.Username = '" + Cache.Get("Username") + "' " +
                "AND OrderItem.OrderID = '" + Cache.Get("OrderID") + "' GROUP by OrderItem.ItemNumber;";

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                int row = 0;
                int numofrows = 0;
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
                    tc.Text = reader["ItemPrice"].ToString();
                    tr.Cells.Add(tc);

                    tc = new TableCell();
                    tc.Text = reader["CategoryDescription"].ToString();
                    tr.Cells.Add(tc);

                    tc = new TableCell();
                    tc.Text = reader["ISBN"].ToString();
                    tr.Cells.Add(tc);

                    tblOrders.Rows.Add(tr);
                    numofrows++;
                }
                reader.Close();


                foreach (TableRow tr in tblOrders.Rows)
                {
                    if (tr == tblOrders.Rows[row])
                        continue;

                    row++;
                    TableCell tblcell = new TableCell();
                    Button btnRemove = new Button();
                    btnRemove.Text = "-";

                    cmd.CommandText = "Select Top 1 ItemNumber from OrderItem where OrderID = " + Cache.Get("OrderID") +
                        " and ISBN = " + tr.Cells[4].Text + ";";

                    SqlDataReader reader2 = cmd.ExecuteReader();
                    string itemnum = "-1";
                    if (reader2.Read())
                        itemnum = reader2["ItemNumber"].ToString();

                    reader2.Close();
                    btnRemove.Click += (s, ev) => btnRemove_Click(btnRemove, ev, itemnum, (string)Cache.Get("OrderID"));
                    tblcell.Controls.Add(btnRemove);
                    tr.Cells.Add(tblcell);
                }
            }
            conn.Close();
        }


        protected void btnRemove_Click(object sender, EventArgs e, string ItemNumber, string OrderID)
        {
            conn.Open();
            cmd.CommandText = "Delete From OrderItem Where ItemNumber = " + ItemNumber + ";";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "Select Sum(ItemPrice) as total From OrderItem Where OrderID = '" + OrderID + "';";
            SqlDataReader reader = cmd.ExecuteReader();
            double total = 0;

            while (reader.Read())
                double.TryParse(reader["total"].ToString(), out total);

            reader.Close();
            if (total > 0)
            {
                cmd.CommandText = "Update Orders set OrderValue = " + total + " where OrderID = '" + OrderID + "';";
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("ChangeOrder.aspx");
            }


            else
            {
                cmd.CommandText = "Delete From Orders Where OrderID = '" + OrderID + "';";
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("MyOrders.aspx");
            }
        }
    }
}