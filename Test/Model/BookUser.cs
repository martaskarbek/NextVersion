using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookshelf.Model
{
    public class BookUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "VARCHAR(30)")]
        public Guid Id { get; set; }
        [Column(TypeName = "VARCHAR(30)")]
        public Book Book { get; set; }
        [Column(TypeName = "VARCHAR(30)")]
        public User User { get; set; }
        [Column(TypeName = "VARCHAR(30)")]
        public User Borrower { get; set; }
    }
}