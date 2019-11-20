using System;

// All the columns we're using in the Elevator Table.

namespace Main.Models {
    public class InterventionItems {
        public int id { get; set; }
        public int? author_id { get; set; }
        public int? customer_id { get; set; }
        public int? building_id { get; set; }
        public int? battery_id { get; set; }
        public int? column_id { get; set; }
        public int? elevator_id { get; set; }
        public int? employee_id { get; set; }
        public DateTime? intervention_datetime_start { get; set; }
        public DateTime? intervention_datetime_end { get; set; }
        public string result { get; set; }
        public string report { get; set; }
        public string status { get; set; }

    }
}