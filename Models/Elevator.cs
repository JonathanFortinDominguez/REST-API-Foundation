using System;

// All the columns we're using in the Elevator Table.

namespace Main.Models {
    public class ElevatorItems {
        public int id { get; set; }
        public string serial_number { get; set; }
        public string type_of_building { get; set; }
        public string model { get; set; }
        public int column_id { get; set; }
        public string status { get; set; }
        public DateTime activate_date { get; set; }
        public string inspection_certificat { get; set; }
    }

    public class ElevatorStatus
    {
        public int id { get; set; }
        public string status { get; set; }
    }
}