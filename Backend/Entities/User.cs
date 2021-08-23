using System.Collections.Generic;

namespace AlbertslundForsyning.Entities
{
    public class User
    {
        public int UserId {get; set;}
        public string Username {get; set;}
        public string Password {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string PhoneNumber {get; set;}
        public string Email {get; set;}
        public string Zipcode {get; set;}
        public string StreetName {get; set;}
        public string StreetNumber {get; set;}
        public ICollection<DataReading> DataReadings {get; set;} = new List<DataReading>();
    }
}