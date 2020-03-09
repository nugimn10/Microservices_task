using System;

namespace CustomerServices.Domain.Models
{
    public enum Gender
    {
            male = 1,
            female
    }
    public class CustomerD
    {
        public int id { get; set; }
        public string fullname { get; set; }
        public string username { get; set; }
        public DateTime birthdate { get; set; }
        public string passowrd { get; set; }
        public Gender gender { get; set; }
        public string kelamin { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public long created_at { get; set; } = Convert.ToInt64((DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime()).TotalSeconds);
        public long updated_at { get; set; } = Convert.ToInt64((DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime()).TotalSeconds);
    }

    
    public class Customer_Payment_Card
    {
        public int id { get; set; }
        public int customer_id { get; set; }
        public string name_no_card { get; set; }
        public string exp_month { get; set; }
        public string exp_year { get; set; }
        public int postal_code { get; set; }
        public string credit_card_number { get; set; }
        public long created_at { get; set; } = Convert.ToInt64((DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime()).TotalSeconds);
        public long updated_at { get; set; } = Convert.ToInt64((DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime()).TotalSeconds);
    

        public CustomerD customer {get; set;}
    }
}