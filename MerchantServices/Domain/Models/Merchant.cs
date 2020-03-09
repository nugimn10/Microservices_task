using System;
namespace MerchantServices.Domain.Models
{  
    public class MerchantD
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string address { get; set; }
        public double rating { get; set; }
        public long created_at { get; set; } = Convert.ToInt64((DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime()).TotalSeconds);
        public long updated_at { get; set; } = Convert.ToInt64((DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime()).TotalSeconds);
    
    }
}