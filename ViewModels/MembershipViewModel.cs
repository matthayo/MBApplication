using System;
using System.ComponentModel.DataAnnotations;
using MBApplication.Data;
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
        public int MemberId { get; set; }
        public Member Member { get; set; }
        public int PremiseId { get; set; }
        public Premise Premise { get; set; }
        public string Status { get; set; }
        public string MembershipBy { get; set; }
        [JsonIgnore]
        public int Count { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}