using System; 

// All the columns we're using in the User Table.

namespace Main.Models {
    public class UserItems {
        public int id { get; set; }
        public DateTime created_at { get; set; }  
        public string email { get; set; }
        
    }
}