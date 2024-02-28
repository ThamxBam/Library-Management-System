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
    public partial class AddBooks : Form
    {
        BooksRepository booksRepository = new BooksRepository();
        public AddBooks()
        {
            InitializeComponent();
        }

        private void btnSvBk_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtISBN.Text) && !string.IsNullOrEmpty(txtTitle.Text) && !string.IsNullOrEmpty(txtAuthor.Text)
                && !string.IsNullOrEmpty(txtGenre.Text))
            {
                var newBook = new Book_Inventory();
                newBook.ISBN = decimal.Parse(txtISBN.Text);
                newBook.Title = txtTitle.Text;
                newBook.Author = txtAuthor.Text;
                newBook.Genre = txtGenre.Text;
                booksRepository.AddBook(newBook);
                MessageBox.Show("New Book Added!");
                Dashboard dashboard = new Dashboard();
                dashboard.ShowDialog();
                this.Close();
            }
        }

        private void AddBooks_Load(object sender, EventArgs e)
        {

        }

        private void btnCnclBk_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
