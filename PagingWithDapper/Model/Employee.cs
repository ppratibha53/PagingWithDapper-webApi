namespace PagingWithDapper.Model
{
    public class Employee
    {
        public int id { get; set; }
        public string frist_name { get; set; }
        public string last_name { get; set; }
        public DateTime date_of_birth { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public string phoneNumber { get; set; }
        public string department { get; set; }
        public decimal salary { get; set; }
    }
}
