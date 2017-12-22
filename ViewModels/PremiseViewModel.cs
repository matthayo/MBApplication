using System;
using Newtonsoft.Json;

namespace MBApplication.ViewModels
{
    [JsonObject(MemberSerialization.OptOut)]
    public class PremiseViewModel
    {
        // Constructor
        public PremiseViewModel() {}

        // Attributes
        public int Id { get; set; }
        public int MembershipId { get; set; }
        public int AddressId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Type { get; set; }
        [JsonIgnore]
        public int Count { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}