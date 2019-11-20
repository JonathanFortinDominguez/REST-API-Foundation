using System;

// All the columns we're using in the Customer Table.

namespace Main.Models {
    public class CustomerItems {
        public int id { get; set; }
        public string full_name { get; set; }
        public string business_name { get; set; }
        public string business_desc { get; set; }
        public string phone_number { get; set; }
        public string email { get; set; }
        public DateTime creation_date { get; set; }
    }
}