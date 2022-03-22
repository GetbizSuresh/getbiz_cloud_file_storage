using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Models
{
    public class userapp_folder_details_for_business_apps
    {
        [Key]
        public int user_apps_data_folder_id { set; get; }
      
        public int app_id { set; get; }            

        public string mapping_id { set; get; } 
        public bool is_folder { set; get; } 
        public string mapping_parent { set; get; }  
        public bool file_or_folder { set; get; } 
        public int file_or_folder_id { set; get; }  


        public string folder_name { set; get; }
        public bool multiuser_folder_access { set; get; }


        public int created_by_user_id { set; get; }
        public int shared_user_id { set; get; }


        public string created_timestamp { set; get; }
        public int folder_size { set; get; }
        [DefaultValue(false)]
        public bool deleted_status { set; get; } = false;
        public string cust_id { set; get; }


    }
}
