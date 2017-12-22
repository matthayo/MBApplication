using System;
using System.ComponentModel.DataAnnotations;

namespace MBApplication.Data
{
    public class Member
    {
        //Constructor 
        public Member() { }

        //Attributes
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public int MembershipID { get; set; }
        [Required]
        public int FamilyID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string MaritalStatus { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime LastModifiedDate { get; set; }
    }
}