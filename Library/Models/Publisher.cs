using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Library.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Publisher 's Name")]
        public string Name { get; set; }
        public int Phone { get; set; }
        public string Details { get; set; }
        public virtual List<Book> Books { get; set; }
    }
}