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
        public int MembershipId { get; set; }
        [Required]
        public int AddressId { get; set; }
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
        public int Count { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime LastModifiedDate { get; set; }
    }
}