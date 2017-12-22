using System;
using System.ComponentModel.DataAnnotations;


namespace MBApplication.Data
{
    public class Family{
        public Family() {}

        [Required]
        public int Id { get; set; }
        [Required]
        public int MemberId { get; set; }
        [Required]
        public int AddressId { get; set; }
        [Required]
        public string HeadOfHousehold { get; set; }
    }
    
}