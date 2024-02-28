using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace ASSIGMENT11._2
{
    public partial class OpenLibrary : Form
    {
        BooksRepository booksRepository = new BooksRepository();
        public OpenLibrary()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnTransfer.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchTerm = txtbxSearchAPI.Text;
            var openLibaryService = new OpenLibraryService();
            var results = openLibaryService.SearchBooks(searchTerm, "title");

            if (results != null && results.Count > 0)
            {
                var filteredResults = results.Select(book => new
                {
                    ISBN = book.isbn?.FirstOrDefault(),
                    Title = book.title,
                    Author = book.author_name?.FirstOrDefault(),
                    Genre = book.subject?.FirstOrDefault()
                }).ToList();

                ResultList.DataSource = filteredResults;
            }
            else
            {
                MessageBox.Show("No results found.");
            }
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            if (ResultList.SelectedRows != null && ResultList.SelectedRows.Count > 0)
            {

                if (ResultList.SelectedRows[0].DataBoundItem is Doc selectedBook)
                {
                    if (selectedBook != null)
                    {
                        var newBook = new Book_Inventory
                        {
                            ISBN = Convert.ToDecimal(selectedBook.isbn?.FirstOrDefault()),
                            Title = selectedBook.title,
                            Author = selectedBook.author_name?.FirstOrDefault(),
                            Genre = selectedBook.subject?.FirstOrDefault(),
                        };
                        booksRepository.AddBook(newBook);
                        MessageBox.Show("Book has been transfered to your library");
                    }
                    
                    Dashboard dashboard = new Dashboard();
                    dashboard.ShowDialog();
                }

            }
        }

        private void ResultList_SelectionChanged(object sender, EventArgs e)
        {
            btnTransfer.Visible = ResultList.SelectedRows.Count > 0;
        }
    }
}
