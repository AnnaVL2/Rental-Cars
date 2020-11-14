using System;

namespace MySpace
{
    public class UserDTO
    {
        public int userID { get; set; }
        public int roleID { get; set; }
        public string roleTitle { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int userIDNumber { get; set; }
        public string userName { get; set; }
        public DateTime birthDate { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string image { get; set; }
    }
}
