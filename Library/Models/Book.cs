using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class Book
    {
        public int Id { get; set; }
        public String Title { get; set; }

        public string ISBN { get; set; }

        public String Lang { get; set; }

        public DateTime Year { get; set; }

        public String Description { get; set; }

        public int AuthorId { get; set; }

        public int PublisherId { get; set; }

        public virtual Author Author  { get; set; }

        public virtual Publisher Publisher { get; set; }


    }
}