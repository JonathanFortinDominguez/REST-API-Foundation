using System;

// All the columns we're using in the Quote Table.

namespace Main.Models {
    public class QuoteItems {
        public int id { get; set; }
        public DateTime created_at { get; set; } 
        public string Full_Name { get; set; }
        public string Business_Name { get; set; }
        public string Project_Name { get; set; }
        public string Email_Address { get; set; }
        public string Phone_Number { get; set; }
        public string buildingType { get; set; }
        public string quality { get; set; }
        public DateTime updated_at { get; set; }
    }
}