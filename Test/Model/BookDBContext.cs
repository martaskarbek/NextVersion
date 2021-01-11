using Microsoft.EntityFrameworkCore;
using System;

namespace bookshelf.Model
{
    public class BookDBContext : DbContext
    {
        string Path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlite("Data Source=bookshelf.db");

        public BookDBContext(DbContextOptions<BookDBContext> options)
            : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<ChatMessage> Messages { get; set; }
        public DbSet<ChatUser> ChatUsers { get; set; }
        public DbSet<BookUser> BookUsers { get; set; }
    }
}