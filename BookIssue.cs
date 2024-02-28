using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace ASSIGMENT11._2
{
    public partial class BookIssue : Form
    {
        public BookIssue()
        {
            InitializeComponent();
        }

        private void BookIssue_Load(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = FINEAPPLE; database = LibraryDB;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from IssueBook";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            DA.Fill(ds);

            GridIssue.DataSource = ds.Tables[0];

            grpbxUpdate.Visible = false;

        }

        private void btnSearchBI_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIDSearch.Text))
            {
                string id = txtIDSearch.Text;

                using (SqlConnection conn = new SqlConnection("data source = FINEAPPLE; database = LibraryDB; integrated security=True"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("select * from Member where ID = @ID", conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        using (SqlDataAdapter DA = new SqlDataAdapter(cmd))
                        {
                            DataSet DS = new DataSet();
                            DA.Fill(DS);

                            if (DS.Tables[0].Rows.Count != 0)
                            {
                                txtFNBI.Text = DS.Tables[0].Rows[0][1].ToString();
                                txtLNBI.Text = DS.Tables[0].Rows[0][2].ToString();

                            }
                            else
                            {
                                txtTBI.Clear();
                                txtABI.Clear();
                                MessageBox.Show("Invalid Member");
                            }
                        }
                    }
                }
            }

            if (!string.IsNullOrEmpty(txtISBNSearch.Text))
            {
                string isbn = txtISBNSearch.Text;

                using (SqlConnection conn = new SqlConnection("data source = FINEAPPLE; database = LibraryDB; integrated security=True"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("select * from [Book Inventory] where ISBN = @ISBN", conn))
                    {
                        cmd.Parameters.AddWithValue("@ISBN", isbn);
                        using (SqlDataAdapter DA = new SqlDataAdapter(cmd))
                        {
                            DataSet DS = new DataSet();
                            DA.Fill(DS);

                            if (DS.Tables[0].Rows.Count != 0)
                            {
                                txtTBI.Text = DS.Tables[0].Rows[0][1].ToString();
                                txtABI.Text = DS.Tables[0].Rows[0][2].ToString();
                            }
                            else
                            {
                                txtFNBI.Clear();
                                txtLNBI.Clear();
                                MessageBox.Show("Invalid Book ISBN");
                            }
                        }
                    }
                }
            }
        }

        private void btnIssueBk_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFNBI.Text) && !string.IsNullOrEmpty(txtLNBI.Text)
                && !string.IsNullOrEmpty(txtTBI.Text) && !string.IsNullOrEmpty(txtABI.Text))
            {
                decimal ISBN = decimal.Parse(txtISBNSearch.Text);
                if (BookInUse(ISBN))
                {
                    MessageBox.Show("Book is currently checked out, Please choose a different book.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                decimal ID = decimal.Parse(txtIDSearch.Text);
                string fname = txtFNBI.Text;
                string lname = txtLNBI.Text;
                string title = txtTBI.Text;
                string author = txtABI.Text;
                DateTime issuedate = dateTimeIssue.Value;
                DateTime returndate = dateTimeReturn.Value;


                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "data source = FINEAPPLE; database = LibraryDB; integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = cmd.CommandText = "insert into IssueBook (mbrID, Fname, Lname, ISBN, bTitle, bAuthor, [Issue Date], [Return Date] ) values (" + ID + ", '" + fname + "', '" + lname + "', " + ISBN + ", '" + title + "', '" + author + "', '" + issuedate + "', '" + returndate + "')";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                conn.Close();

                RefreshData();

            }

        }
        private bool BookInUse(decimal ISBN)
        {
            foreach (DataGridViewRow row in GridIssue.Rows)
            {
                if (row.Cells["ISBN"].Value != null && (decimal)row.Cells["ISBN"].Value == ISBN)
                {
                    return true;
                }
            }
            return false;
        }

        

        private void GridIssue_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0 && e.RowIndex < GridIssue.Rows.Count)
            {
                DataGridViewRow row = GridIssue.Rows[e.RowIndex];

                if (row.Cells[0].Value != null)
                {
                    grpbxUpdate.Tag = int.Parse(row.Cells[0].Value.ToString());

                    // Populate TextBoxes with data from the selected row
                    txtFNUpdate.Text = row.Cells["Fname"].Value.ToString();
                    txtLNUpdate.Text = row.Cells["Lname"].Value.ToString();
                    txtTUpdate.Text = row.Cells["bTitle"].Value.ToString();
                    txtAUpdate.Text = row.Cells["bAuthor"].Value.ToString();
                    dateTimeReturn.Value = Convert.ToDateTime(row.Cells["Return Date"].Value);
                }
            }
            grpbxUpdate.Visible = true;
            
        }
        private void RefreshData()
        {
            using (SqlConnection con = new SqlConnection("data source = FINEAPPLE; database = LibraryDB; integrated security=True"))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("select * from IssueBook", con))
                {
                    SqlDataAdapter DA = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    DA.Fill(ds);

                    GridIssue.DataSource = ds.Tables[0];
                }
            }
        }
        private void updatereturn_Click(object sender, EventArgs e)
        {
            int mbrID = (int)grpbxUpdate.Tag;
                string fname = txtFNUpdate.Text;
                string lname = txtLNUpdate.Text;
                string title = txtTUpdate.Text;
                string author = txtAUpdate.Text;
                DateTime returndate = dateReturnUpdate.Value;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "data source = FINEAPPLE; database = LibraryDB; integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "update IssueBook set [Return Date] = @returndate where mbrID = @mbrID";
            cmd.Parameters.AddWithValue("@returndate", returndate);
            cmd.Parameters.AddWithValue("@mbrID", mbrID);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            RefreshData();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (GridIssue.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = GridIssue.SelectedRows[0];

                // Ensure the correct column index for "mbrID"
                int mbrIDColumnIndex = 0;

                if (selectedRow.Cells[mbrIDColumnIndex].Value != null &&
                    decimal.TryParse(selectedRow.Cells[mbrIDColumnIndex].Value.ToString(), out decimal mbrID))
                {
                    using (SqlConnection conn = new SqlConnection("data source = FINEAPPLE; database = LibraryDB; integrated security=True"))
                    {
                        conn.Open();

                        using (SqlCommand cmd = new SqlCommand("DELETE FROM IssueBook WHERE mbrID = @mbrID", conn))
                        {
                            cmd.Parameters.AddWithValue("@mbrID", mbrID);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    RefreshData();
                }
            }
        }
    }
}


