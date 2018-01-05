using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MBApplication.Data
{
    public class Family
    {
        public Family() { }
        [Required]
        public int Id { get; set; }
        [Required]
        public string FamilyName { get; set; }
        [Required]
        public string House { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public int Zip { get; set; }

        public virtual List<Member> Members { get; set; }
    }

}