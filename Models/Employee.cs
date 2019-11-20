using System;

// All the columns we're using in the Employee Table.

namespace Main.Models {
    public class EmployeeItems {
        public int id { get; set; }
        public DateTime created_at { get; set; }
        public string lastname { get; set; }
        public string name { get; set; }
        public string function { get; set; }
        public string email { get; set; }

    }
}