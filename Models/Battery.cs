using System;

// All the columns we're using in the Battery Table.

namespace Main.Models {
    public class BatteryItems {
        public int id { get; set; }
        public string status { get; set; }
        public int building_id { get; set; }
        public string type_of_building { get; set; }
        public DateTime operational_date { get; set; }
    }
}