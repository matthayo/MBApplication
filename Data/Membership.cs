using System;
using System.ComponentModel.DataAnnotations;

namespace MBApplication.Data
{
    public class Membership{

        //Constructor
        public Membership() {}

        //Properties
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public int MemberId { get; set; }
        public Member Member { get; set; }
        [Required]
        public int PremiseId { get; set; }
        public Premise Premise { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string MembershipBy { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime LastModifiedDate { get; set; }
    }
    
}