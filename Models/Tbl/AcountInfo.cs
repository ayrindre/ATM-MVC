using System;

namespace ATM_MVC.Models
{
    public class AcountInfo
    {
        public int Id { get; set; }
        
        public string AcountNumber { get; set; }
        public int UserId { get; set; }
        public string Password { get; set; }
        public int Mojodi { get; set; }
        
    }

}