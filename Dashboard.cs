using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASSIGMENT11._2
{
    public partial class Dashboard : Form
    {
        BooksRepository booksRepository;
        public Doc selectedBook {  get; set; }
        public Dashboard()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addBook_Click(object sender, EventArgs e)
        {
            AddBooks abs = new AddBooks();
            abs.ShowDialog();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            booksRepository = new BooksRepository();
            GridView.DataSource = booksRepository.GetAllBooks();
            grpBx.Visible = false;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var id = Convert.ToDecimal(txtISBNdsh.Text);
            var bookupdate = booksRepository.FindBook(id);
            bookupdate.Title = txtTitledsh.Text;
            bookupdate.Author = txtAuthordsh.Text;
            bookupdate.Genre = txtGenredsh.Text;
            booksRepository.UpdateBook(id, bookupdate);
            MessageBox.Show("Book has been updated");

            GridView.DataSource = booksRepository.GetAllBooks();
        }

        float grpbox;
        private void GridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < GridView.Rows.Count)
            {
                DataGridViewRow row = GridView.Rows[e.RowIndex];

                if (row.Cells[0].Value != null)
                {
                    grpbox = float.Parse(row.Cells[0].Value.ToString());

                    // Populate TextBoxes with data from the selected row
                    txtISBNdsh.Text = row.Cells["ISBN"].Value.ToString();
                    txtTitledsh.Text = row.Cells["Title"].Value.ToString();
                    txtAuthordsh.Text = row.Cells["Author"].Value.ToString();
                    txtGenredsh.Text = row.Cells["Genre"].Value.ToString();

                }
            }

            grpBx.Visible = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var id = GridView.CurrentRow.Cells[0].Value;
            var bookdelete = booksRepository.FindBook((decimal)id);
            booksRepository.DeleteBook(bookdelete);
            MessageBox.Show("Book has been deleted");

            GridView.DataSource = booksRepository.GetAllBooks();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtISBNdsh.Clear();
            txtTitledsh.Clear();
            txtAuthordsh.Clear();
            txtGenredsh.Clear();
        }

        private void addMbr_Click(object sender, EventArgs e)
        {
            Members members = new Members();
            members.ShowDialog();
        }

        private void issueBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookIssue bkIssue = new BookIssue();
            bkIssue.ShowDialog();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenLibrary openlibrary = new OpenLibrary();
            openlibrary.ShowDialog();
        }
    }
}
