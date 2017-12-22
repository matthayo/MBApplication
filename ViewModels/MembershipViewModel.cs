using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MBApplication.ViewModels
{
    [JsonObject(MemberSerialization.OptOut)]
    public class MembershipViewModel
    {
        // Constructor
        public MembershipViewModel() { }

        // Attributes
        public int Id { get; set; }
        public int MembershipId { get; set; }
        public int AddressId { get; set; }
        public string Type { get; set; }
        [JsonIgnore]
        public int Count { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}