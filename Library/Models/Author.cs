using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public String Name { get; set; }
        public String LastName  { get; set; }
        public String Details { get; set; }
        public virtual List<Book> Books { get; set; }
    }
}