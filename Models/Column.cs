using System;

// All the columns we're using in the Column Table.

namespace Main.Models {
    public class ColumnItems {
        public int id { get; set; }
        public string status { get; set; }
        public int battery_id { get; set; }
        public string type_of_building { get; set; }
        public DateTime created_at { get; set; }
    }
}