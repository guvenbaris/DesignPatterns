using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Momento
{
    class Program
    {
        static void Main(string[] args)
        {
            // Bir nesne değişikliğe uğradıktan sonra arzu edilirse 
            // değişikliğe uğramamış haline dönüşüm sağlar.
            Book book = new Book
            {
                Isbn = "12345",
                Title = "Sefiller",
                Author = "Victor Hugo"
            };
            book.ShowBook();
            CareTaker history = new CareTaker();
            history.Memento = book.CreateUndo();

            book.Isbn = "54321";
            book.Title = "VICTOR HUGO";
            book.ShowBook();

            book.RestoreFromUndo(history.Memento);
            book.ShowBook();
            Console.ReadLine();
        }
    }
    class Book 
    {
        private string _title;
        private string _author;
        private string _Isbn;
        private DateTime _lastEdited;
        // backing field 
        public string Title
        {
            get { return _title; }
            set 
            { 
                _title = value;
                SetLastEdited();
            }
        }
        public string Author
        {
            get { return _author; }
            set 
            {
                _author = value;
                SetLastEdited();
            }
        }
        public string Isbn
        {
            get { return _Isbn; }
            set 
            { 
                _Isbn = value;
                SetLastEdited();
            }
        }
        private void SetLastEdited()
        {
            _lastEdited = DateTime.UtcNow;
        }

        public Memento CreateUndo()
        {
            return new Memento(_Isbn,_title,_author,_lastEdited);
        }

        public void RestoreFromUndo(Memento memento)
        {
            _title = memento.Title;
            _author = memento.Author;
            _Isbn = memento.Isbn;
            _lastEdited = memento.LastEdited;
        }
        public void ShowBook()
        {
            Console.WriteLine("{0},{1},{2}, edited : {3}", Isbn, Title, Author, _lastEdited);
        }
    }
    class Memento
    {
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime LastEdited { get; set; }

        public Memento(string isbn ,string title,string author,DateTime lastEdited)
        {
            Isbn = isbn;
            Title = title;
            Author = author; 
            LastEdited = lastEdited;
        }
    }

    class CareTaker
    {
        public Memento Memento { get; set; }
    }
}
