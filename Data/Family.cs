using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MBApplication.Data
{
    public class Family{
        public Family() {}

        [ForeignKey("Member")]
        public int Id { get; set; }
        public string FamilyName { get; set; }
        
        public string House { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int Zip { get; set; }


      //  public virtual Address Address { get; set; }
        public virtual List<Member> Members { get; set; }
    }
    
}