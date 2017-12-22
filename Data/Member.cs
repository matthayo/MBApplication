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
        public string FirstName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public char Gender { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string MaritalStatus { get; set; }
        [Required]
        public int MemberCount { get; set; }
        [Required]
        public int OrgID { get; set; }
        [Required]
        public int AddressID { get; set; }
        [Required]
        public int MembershipID { get; set; }
        [Required]
        public int FamilyID { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime LastModifiedDate { get; set; }
    }
}