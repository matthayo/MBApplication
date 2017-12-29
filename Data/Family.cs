using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace MBApplication.Data
{
    public class Family{
        public Family() {}

        [Required]
        public int Id { get; set; }
        [Required]
        public int MemberId { get; set; }
        public List<Member> Members { get; set; }
        [Required]
        public Address Address { get; set; }
        [Required]
        public string HeadOfHousehold { get; set; }
        [Required]
        public int Count { get; set; }
    }
    
}