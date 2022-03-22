using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Models
{
    public class cloud_file_storage_users_master
    {
        public int user_id { set; get; }
        public int storage_limit_in_mb { set; get; }
        public DateTime user_app_joining_timestamp { get; set; }  
        public bool block_app_access { set; get; }

       
        public string cust_id { set; get; }
    }
}
