using System;
using System.ComponentModel.DataAnnotations;

namespace MBApplication.Data
{
    public class Premise{

        // Constructor
        public Premise(){}

        // Properties
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public Membership Membership { get; set; }
        [Required]
        public Address Address { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Telephone { get; set; }
        [Required]
        public string Email { get; set; }
        public string Website { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime LastModifiedDate { get; set; }
    }
}