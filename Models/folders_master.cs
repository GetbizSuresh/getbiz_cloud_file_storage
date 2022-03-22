using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace getbiz_cloud_file_storage_app.Models
{
    public class folders_master
    {
        [Key]
        public int folder_id { set; get; }

        public string mapping_id { set; get; } //newly added
        public bool is_folder { set; get; } //newly added 
         public string mapping_parent { set; get; }  // newly added 

        public string folder_name { set; get; }
        public bool multiuser_folder_access { set; get; }
        public int created_by_user_id { set; get; }
        public string created_timestamp { set; get; }
        public int folder_size { set; get; }

         [DefaultValue(false)]
        public bool deleted_status { set; get; } = false;
       
        public string cust_id { set; get; }


    }

  
      

      
}
