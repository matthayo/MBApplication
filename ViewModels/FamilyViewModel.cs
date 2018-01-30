using System;
using System.Collections.Generic;
using MBApplication.Data;
using Newtonsoft.Json;

namespace MBApplication.ViewModels
{
    [JsonObject(MemberSerialization.OptOut)]
    public class FamilyViewModel
    {
        // Constructor
        public FamilyViewModel(){ }

        // Attributes
        public int Id { get; set; }
        public string FamilyName { get; set; }
        public string AptNumber { get; set; }
        public string House { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        [JsonIgnore]
        public int Count { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}