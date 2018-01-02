using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MBApplication.Data
{
    public class Membership{

        //Constructor
        public Membership() {}

        //Properties
        public int Id { get; set; }

        public string Status { get; set; }

        public string MembershipBy { get; set; }

        public int? PremiseId { get; set; }

        public int? MemberId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime LastModifiedDate { get; set; }


        public virtual Member Member { get; set; }
        public virtual Premise Premise { get; set; }
    }
    
}