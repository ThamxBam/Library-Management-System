using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASSIGMENT11._2
{
    public partial class Members : Form
    {
        public Members()
        {
            InitializeComponent();
        }

        private void Members_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = FINEAPPLE; database = LibraryDB;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from Member";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            DA.Fill(ds);

            GridMember.DataSource = ds.Tables[0];

        }

        private void btnAddmbr_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtID.Text) && !string.IsNullOrEmpty(txtFName.Text) && !string.IsNullOrEmpty(txtLName.Text) &&
                !string.IsNullOrEmpty(txtNumber.Text))
            {
                int id = Convert.ToInt32(txtID.Text);
                string firstname = txtFName.Text;
                string lastname = txtLName.Text;
                int number = Convert.ToInt32(txtNumber.Text);

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = FINEAPPLE; database = LibraryDB;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "insert into Member (ID,[First Name],[Last Name],[Phone Number]) values ('" + id + "','" + firstname + "','" + lastname + "','" + number + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Member has been added!");

                RefreshData();
            }
        }
        private void RefreshData()
        {
            using (SqlConnection con = new SqlConnection("data source = FINEAPPLE; database = LibraryDB; integrated security=True"))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("select * from Member", con))
                {
                    SqlDataAdapter DA = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    DA.Fill(ds);

                    GridMember.DataSource = ds.Tables[0];
                }
            }
        }
    }
}
