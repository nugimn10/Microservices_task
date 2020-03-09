using System;
namespace ProductServices.Domain.Models
{  
    public class ProductD
    {
        public int id { get; set; }
        public int merchant_id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public long created_at { get; set; } = Convert.ToInt64((DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime()).TotalSeconds);
        public long updated_at { get; set; } = Convert.ToInt64((DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime()).TotalSeconds);
    

    }
}