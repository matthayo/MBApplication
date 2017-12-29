using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MBApplication.Data
{
    public class Address
    {
        //Constructor
        public Address() {}

        //Properties
        [Required]
        [Key]
        public int Id { get; set; }
        public int FamilyId { get; set; }
        public List<Family> Family { get; set; }
        public int PremiseId { get; set; }
        public Premise Premise { get; set; }
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
    }

    
}