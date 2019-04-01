using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classesAndGenerics
{
    class Program
    {
        static void Main(string[] args)
        {
            testLibrary testche = new testLibrary();
            testche.Count = 3;
            testche.Booooks = null;
            testche.addAllBooks();
            testche.printall();
            testche.searchAndDelete(Console.ReadLine());
            testche.printall();
            Console.ReadKey();
        }
    }
    class library
    {
        private List<book> books = new List<book>();
        public List<book> Ts
        {
            get { return this.books; }
        }
        public library()
        {
            this.books = new List<book>();
        }
        public void addBook(book newBook)
        {
            newBook.Title = Console.ReadLine();
            newBook.Author = Console.ReadLine();
            newBook.Manuf = Console.ReadLine();
            newBook.Year = int.Parse(Console.ReadLine());
            newBook.ISBN = int.Parse(Console.ReadLine());
            books.Add(newBook);
            
        }
        public void search(string author)
        {
            Console.WriteLine("Book with author {0}:{1}",author,books.Find(x => x.Author.Equals(author)).Title);
        }
        public void print(int index)
        {
            Console.WriteLine("Author:" + books[index].Author + "\nTitle:" + books[index].Title);
        }
        public void deleteBook(int index)
        {
            books.Remove(books[index]);
        }
    }
    class book
    {
        private string title;
        private string author;
        private string manuf;
        private int year;
        private int isbn;
        public book()
        {

        }
        public string Title
        {
            get { return this.title; }
            set { this.title = value; }
        }
        public string Author
        {
            get { return this.author; }
            set { this.author = value; }
        }
        public string Manuf
        {
            get { return this.manuf; }
            set { this.manuf = value; }
        }
        public int Year
        {
            get { return this.year; }
            set { this.year = value; }
        }
        public int ISBN
        {
            get { return this.isbn; }
            set { this.isbn = value; }
        }
    }
    class testLibrary
    {
        private library lib1 = new library();
        private book[] boooooks = new book[3];
        private int count;
        public int Count
        {
            get { return this.count; }
            set { this.count = value; }
        }
        public book Booooks
        {
            set
            {
                
                for(int i=0;i<this.count;i++)
                {
                    this.boooooks[i] = new book();
                }
            }
        }
        public void addAllBooks()
        {
            for (int i = 0; i < count; i++)
                lib1.addBook(boooooks[i]);
        }
        public void searchAndDelete(string author)
        {
            for(int i=0;i<3;i++)
            {
                if (this.lib1.Ts.Find(x => x.Author.Equals(author)).Title == author)
                {
                    lib1.deleteBook(i);
                    this.count--;
                }
            }
        }
        public void printall()
        {
            for(int i=0;i<this.count;i++)
            {
                lib1.print(i);
            }
        }
    }
}
