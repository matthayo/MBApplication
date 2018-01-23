using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MBApplication.Data
{
    public class Membership
    {

        //Constructor
        public Membership() { }

        //Properties
        [Required]
        public int Id { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string MembershipBy { get; set; }
        [Required]
        public int PremiseId { get; set; }
        [Required]
        public int MemberId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime LastModifiedDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime MembershipDate { get; set; }

        [ForeignKey("MemberId")]
        public virtual Member Member { get; set; }

        [ForeignKey("PremiseId")]
        public virtual Premise Premise { get; set; }
    }

}