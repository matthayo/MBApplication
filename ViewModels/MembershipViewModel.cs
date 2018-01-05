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
        public string Status { get; set; }
        public string MembershipBy { get; set; }
        public int PremiseId { get; set; }
        public int MemberId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime LastModifiedDate { get; set; }
        [JsonIgnore]
        public int Count { get; set; }
    }
}