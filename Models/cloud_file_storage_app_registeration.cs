using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Models
{
    public class cloud_file_storage_app_registeration
    {
        public int user_id { set; get; }
        public string cust_id { set; get; }
        public string mobile_no { set; get; }
        public string user_name { get; set; }
        public string password { set; get; }
        public string photo_id { get; set; }
        public int storage_limit_in_mb { get; set; }
        public bool block_app_access { get; set; }


        public string entry_type { set; get; }
       // public DateTime created_timestamp { set; get; }
        public string user_category { set; get; }


        public string Authkey { set; get; }
    }
}
