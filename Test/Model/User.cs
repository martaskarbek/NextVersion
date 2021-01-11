using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookshelf.Model
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "VARCHAR(30)")]
        public Guid Id { get; set; }
        [Column(TypeName = "VARCHAR(30)")]
        [Required]
        public string UserName { get; set; }
        [Column(TypeName = "VARCHAR(30)")]
        public string FirstName { get; set; }
        [Column(TypeName = "VARCHAR(30)")]
        public string Surname { get; set; }
        [Column(TypeName = "VARCHAR(30)")]
        [Required]
        public string EMail { get; set; }
        [Column(TypeName = "VARCHAR(30)")]
        [Required]
        public string Password { get; set; }
        [Required]
        public bool IsPublic { get; set; }
        [Column(TypeName = "VARCHAR(30)")]
        public string City { get; set; }
        public bool IsActive { get; set; }
        [Column(TypeName = "VARCHAR(100)")]
        public string Photo { get; set; }
        [Column(TypeName = "VARCHAR(30)")]
        public Role Role { get; set; }
    }
}