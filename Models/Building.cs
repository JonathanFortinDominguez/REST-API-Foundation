using System;

// All the columns we're using in the Building Table.

namespace Main.Models {
    public class BuildingItems {
        public int id { get; set; }
        public long? address_id { get; set; }
        public string fullName_building_administrator { get; set; }
        public string email_building_administrator { get; set; }
        public string phone_administrator { get; set; }
        public string fullName_service_contact { get; set; }
        public string email_service_contact { get; set; }
        public string phone_service_contact { get; set; }
        public DateTime created_at { get; set; }
    }
}