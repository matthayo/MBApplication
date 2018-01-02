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
        public int MemberId { get; set; }
        public List<Member> Members { get; set; }
        // public Address Address { get; set; }
        public string HeadOfHousehold { get; set; }
        [JsonIgnore]
        public int Count { get; set; }

    }
}