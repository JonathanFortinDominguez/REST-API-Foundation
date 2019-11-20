using System;

// All the columns we're using in the Lead Table.

namespace Main.Models {
    public class LeadItems {
        public int id { get; set; }
        public DateTime created_at { get; set; }
        public int? customer_id { get; set; }
        public string fullname { get; set; }
        public string businessName { get; set; }
        public string departement { get; set; }
        public string email { get; set; }
        public string projectName { get; set; }
    }
}