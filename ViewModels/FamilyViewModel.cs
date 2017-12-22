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
        public int AddressId { get; set; }
        public string HeadOfHousehold { get; set; }
        [JsonIgnore]
        public int Count { get; set; }

    }
}