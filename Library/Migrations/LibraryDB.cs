namespace Library.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class LibraryDB : DbMigrationsConfiguration<Library.Models.LibraryDB>
    {
        public LibraryDB()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Library.Models.LibraryDB context)
        {
            
            context.Authors.AddOrUpdate(a => a.id,
                new Author() { id = 1, Name = "Author 1" },
                new Author() { id = 2, Name = "Author 2" },
                new Author() { id = 3, Name = "Author 3" },
                new Author() { id = 4, Name = "Author 4" },
                new Author() { id = 5, Name = "Author 5" }
            );

            context.Publishers.AddOrUpdate(a => a.Id,
                new Publisher() { Id = 1, Name = "Publisher 1", Phone = 123 },
                new Publisher() { Id = 2, Name = "Publisher 2", Phone = 234 },
                new Publisher() { Id = 3, Name = "Publisher 3", Phone = 345 },
                new Publisher() { Id = 4, Name = "Publisher 4", Phone = 456 },
                new Publisher() { Id = 5, Name = "Publisher 5", Phone = 567 }
            );

            context.Books.AddOrUpdate(a => a.ISBN,
                new Book() { ISBN = "2", Title = "B", Lang = "FR", Quantity = 2, AuthorId = 1, PublisherId = 1, Year = 1995 },
                new Book() { ISBN = "3", Title = "C", Lang = "GE", Quantity = 2, AuthorId = 3, PublisherId = 2, Year = 1975 },
                new Book() { ISBN = "4", Title = "D", Lang = "GR", Quantity = 2, AuthorId = 1, PublisherId = 3, Year = 2007 },
                new Book() { ISBN = "5", Title = "E", Lang = "FR", Quantity = 2, AuthorId = 1, PublisherId = 4, Year = 1965 },
                new Book() { ISBN = "6", Title = "F", Lang = "Eng", Quantity = 2, AuthorId = 5, PublisherId = 5, Year = 1932 },
                new Book() { ISBN = "7", Title = "G", Lang = "Eng", Quantity = 2, AuthorId = 3, PublisherId = 5, Year = 2004 },
                new Book() { ISBN = "8", Title = "H", Lang = "FR", Quantity = 2, AuthorId = 2, PublisherId = 1, Year = 2010 },
                new Book() { ISBN = "9", Title = "K", Lang = "Eng", Quantity = 2, AuthorId = 4, PublisherId = 3, Year = 2001 },
                new Book() { ISBN = "10", Title = "L", Lang = "FR", Quantity = 2, AuthorId = 5, PublisherId = 3, Year = 1993 },
                new Book() { ISBN = "11", Title = "M", Lang = "GE", Quantity = 2, AuthorId = 1, PublisherId = 4, Year = 1987 },
                new Book() { ISBN = "12", Title = "N", Lang = "Eng", Quantity = 2, AuthorId = 2, PublisherId = 1, Year = 2003 },
                new Book() { ISBN = "13", Title = "O", Lang = "Eng", Quantity = 2, AuthorId = 4, PublisherId = 4, Year = 2001 }
            );
        }
    }
}
