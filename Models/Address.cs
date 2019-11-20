using System;

// All the columns we're using in the Address Table.

namespace Main.Models {
    public class AddressItems {
        public int id { get; set; }
        public string status { get; set; }
        public string address_type { get; set; }
        public string entity { get; set; }
        public string street_number { get; set; }
        public string apt_number { get; set; }
        public string city { get; set; }
        public string zip_code { get; set; }
        public string country { get; set; }
    }
}