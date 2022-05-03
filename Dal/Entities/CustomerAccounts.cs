using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    
    public class CustomerAccounts
    {
        
        public int AccountID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Address3 { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        //String conString = "Data Source=DESKTOP-LT2MA59;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    }
    
    
}
