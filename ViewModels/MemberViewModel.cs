using System;
using Newtonsoft.Json;

namespace MBApplication.ViewModels
{
    [JsonObject(MemberSerialization.OptOut)]
    public class MemberViewModel
    {
        //Constructor 
        public MemberViewModel(){}

        //Attributes
        public int Id{get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; } 
        public string LastName { get; set; }
        public char Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string MaritalStatus { get; set; }
        [JsonIgnore]
        public int MemberCount { get; set; }
        public int OrgID { get; set; }
        public int AddressID { get; set; }
        public int MembershipID { get; set; }
        public int FamilyID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
  
    }
}