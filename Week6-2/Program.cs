using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Reflection;

namespace Week6_2
{
    internal class Program
    {
        public class Book
        {
            //Ok, this part I know. make the variable/class, give it properties. cool.
            public string Title { get; set; }
            public string Author { get; set; }
            public int Year { get; set; }
        }
        //make a method!...
        public static void SerializeToJSON(string fileName, Book book)
            {
            //I forgot we did a whole download thing, and there wasn't anywhere to like, remind me,
            //so it took a bit to figure out what I was missing. Microsoft themselves straightened me out though.
            string json = JsonSerializer.Serialize(book);

            File.WriteAllText(fileName, json);

            //writes to the JSON file. My biggest thing with this is that I don't think of it on the fly,
            //and need some time to think and research how to go about things. This early,
            //I'm not going to be able to code JSON projects for 'an employer' for some time. Just realistically.
            }
        public static Book DeserializeFromJSON(string fileName)
        {
            //similar to serializing it, simply read the text and re-make the book object.
            string json = File.ReadAllText(fileName);
            
            Book book = JsonSerializer.Deserialize<Book>(json);
            //took me a bit to realize that the method and the calling in Main need to call on Book to work.
            //I saw tutorials using return, and it wasn't fully working right. But I got it.
            //Most of my learning experiences is finding some work and remembering what we did in class,
            //and then seeing there's an error, then working to fix that, and move on to the next.
            return book;

        }
        //and yes im not using /* for comments right now, because its like 10 at night and I'm tired

        static void Main(string[] args)
        {

            Book book = new Book();
            {
                //I don;t know books, so I used the best book. yay
                book.Title = "The Bible";
                book.Author = "God and Friends(tm)";
                book.Year = 0;
            }

            //makes json
            string fileName = "book.json";
            //calls serialze
            SerializeToJSON(fileName, book);
            //UNserialize into BOOK
            //unJSONedBook is a good nam,e. promise.
            Book unJSONedBook = DeserializeFromJSON(fileName);

            Console.WriteLine("Book Details: ");
            Console.WriteLine($"Name: { unJSONedBook.Title }");
            Console.WriteLine($"Author: {unJSONedBook.Author}");
            Console.WriteLine($"Year: {unJSONedBook.Year}");

            //then display it all! yippeee

            //Ok, realistically, sorry that the comments are a mess, but I'm tired man. This may be college, but I'm also human
            Console.ReadLine();
        }
    }
}
