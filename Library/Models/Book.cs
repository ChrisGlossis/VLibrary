using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;


namespace Library.Models
{
   
    public class Book
    {
        
        [Key]
        [Required]
        //[RegularExpression("^((?=(?:[0-9]+[-\\s]){3})[-\0-9X]{13}$|(?=(?:[0-9]+[-\\s]){4})[-\\s0-9]{17}$)(?:97[89][-\\s ]?)?[0-9]{1,5}[-\\s]?[0-9]+[-\\s]?[0-9]+[-\\s]?[0-9X]$")]
        public string ISBN { get; set; }
        [Required]
        public string Title { get; set; }
        public string Lang { get; set; }
        [RegularExpression ("[0-9]{4}")]
        public int Year { get; set; }
        public string Description { get; set; }
        public string Classification { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        [DisplayName("Author")]
        public int AuthorId { get; set; }
        [Required]
        [DisplayName ("Publisher")]
        public int PublisherId { get; set; }
        public virtual Author Author { get; set; }
        public virtual Publisher Publisher { get; set; }
       

    }
}