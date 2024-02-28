using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASSIGMENT11._2
{
    interface CRUD
    {
        void AddBook(Book_Inventory newBook);
        void DeleteBook(Book_Inventory Book);
        ICollection<Book_Inventory> GetAllBooks();
        void UpdateBook(decimal ISBN, Book_Inventory book);
        decimal GetISBN();
        Book_Inventory FindBook(decimal ISBN);
        ICollection <Member> GetMembers();
    }
    internal class BooksRepository : CRUD
    {
        public static LibraryDBEntities Entities = new LibraryDBEntities();
        public void AddBook(Book_Inventory newBook)
        {
            Entities.Book_Inventories.Add(newBook);
            Entities.SaveChanges();
        }

        public void DeleteBook(Book_Inventory Book)
        {
            Entities.Book_Inventories.Remove(Book);
            Entities.SaveChanges();
        }

        public Book_Inventory FindBook(decimal ISBN)
        {
            return Entities.Book_Inventories.Find(ISBN);
        }

        public ICollection<Book_Inventory> GetAllBooks()
        {
            return Entities.Book_Inventories.ToList();
        }

        public decimal GetISBN()
        {
            return Entities.Book_Inventories.Max(x => x.ISBN);
        }

        public ICollection<Member> GetMembers()
        {
            return Entities.Members.ToList();
        }

        public void UpdateBook(decimal ISBN, Book_Inventory book)
        {
            var bookupdate = Entities.Book_Inventories.Find(ISBN);
            bookupdate.ISBN = book.ISBN;
            bookupdate.Title = book.Title;  
            bookupdate.Author = book.Author;    
            bookupdate.Genre = book.Genre;
            Entities.SaveChanges();
        }
    }
}
