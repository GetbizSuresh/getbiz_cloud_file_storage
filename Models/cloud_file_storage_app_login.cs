using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Models
{
    public class cloud_file_storage_app_login
    {
        [Key]
        
        public int id { set; get; }
        public string mobile_no { set; get; }
        public string user_name { get; set; }
        public string password { set; get; }
        public string customer_id { set; get; }
        public int user_id { set; get; }
        public string photo_id { get; set; }
        public int storage_limit_in_mb { get; set; }
        public bool block_app_access { get; set; }
        public string Authkey { set; get; }



    }
}
