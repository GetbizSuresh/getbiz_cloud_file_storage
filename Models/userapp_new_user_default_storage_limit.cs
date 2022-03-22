using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Models
{
    public class userapp_new_user_default_storage_limit
    {
       
       [Key]
         public int id { set; get; }
        public int new_user_storage_limit { get; set; }
        public string cust_id { get; set; }
        public int user_id { get; set; }
       
    }
}
