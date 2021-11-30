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

            cmd.CommandText = "Select * From Orders Where Username = '" +Cache.Get("Username")+ "';";

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

        protected void btnView_Click(Object sender, EventArgs e, int row)
        {
            Button btnSent = sender as Button;

            // Close the table if it is already open
            /*if (btnSent.Text.Equals("-"))
            {
                btnSent.Text = "+";
                return;
            }*/


            cmd.CommandText = "SELECT MAX(Books.Title) as Title, MAX(Author.Lname) as Lname, MAX(OrderItem.ItemPrice) as ItemPrice, " +
                "MAX(BookCategories.CategoryDescription) as CategoryDescription, Max(OrderItem.ISBN) as ISBN FROM Books, Author, Books_Authored, " +
                "BookCategories, OrderItem, Book_And_Category WHERE Books_Authored.ISBN = OrderItem.ISBN " +
                "AND Author.AID = Books_Authored.AID AND BookCategories.CategoryID = Book_And_Category.CategoryID " +
                "AND Books.ISBN = OrderItem.ISBN AND OrderItem.Username = '" +Cache.Get("Username")+ "' " +
                "AND OrderItem.OrderID = " + tblOrders.Rows[row].Cells[0].Text + " group by OrderItem.ItemNumber;";

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                int row2 = row;
                int numofrows = 0;
                // Build the table 
                while (reader.Read())
                {
                    TableRow tr = new TableRow();
                    TableCell tc = new TableCell();
                    tc.Text = "";
                    tr.Cells.Add(tc);

                    tc = new TableCell();
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

                    tblOrders.Rows.AddAt(row + 1, tr);
                    numofrows++;
                }
                reader.Close();
                bool start = false;

                
                foreach (TableRow tr in tblOrders.Rows)
                {
                    if (tr != tblOrders.Rows[row + 1] && !start)
                        continue;

                    start = true;

                    row2++;
                    TableCell tblcell = new TableCell();

                    Button btnRemove = new Button();
                    btnRemove.Text = "-";

                    cmd.CommandText = "Select Top 1 ItemNumber from OrderItem where OrderID = " + tblOrders.Rows[row].Cells[0].Text +
                        " and ISBN = " + tr.Cells[5].Text + ";";

                    SqlDataReader reader2 = cmd.ExecuteReader();
                    string itemnum = "-1";
                    if (reader2.Read())
                        itemnum = reader2["ItemNumber"].ToString();

                    reader2.Close();

                    //btnRemove.UseSubmitBehavior = true;
                    btnRemove.Click += (s, ev) => btnRemove_Click(sender, ev, itemnum, tblOrders.Rows[row].Cells[0].Text);
                    tblcell.Controls.Add(btnRemove);
                    tr.Cells.Add(tblcell);

                    // Prevent adding a button to the next Order
                    if (tr == tblOrders.Rows[row + numofrows])
                        break;
                }
            }
            //btnSent.Text = "-";
            conn.Close();
        }


        protected void btnRemove_Click(object sender, EventArgs e, string ItemNumber, string OrderID)
        {

            Response.Redirect("MyCart.aspx");
            /*conn.Open();
            cmd.CommandText = "Delete From OrderItem Where ItemNumber = " + ItemNumber + ";";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "Select * From OrderItem Where OrderID = " + OrderID + ";";
            int rowsRemain = cmd.ExecuteNonQuery();

            if (rowsRemain == 0)
            {
                cmd.CommandText = "Delete From Orders Where OrderID = " + OrderID + ";";
                cmd.ExecuteNonQuery();
            }

            //Response.Redirect("MyOrders.aspx");
            conn.Close();*/
        }

    }
}