using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookshelf.Model
{
    public class ChatMessage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "VARCHAR(30)")]
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
        [Column(TypeName = "VARCHAR(30)")]
        public User Author { get; set; }
        [Column(TypeName = "VARCHAR(30)")]
        public Chat chat { get; set; }
    }
}