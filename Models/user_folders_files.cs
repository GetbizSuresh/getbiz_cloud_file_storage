using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace getbiz_cloud_file_storage_app.Models
{
    public class user_folders_files
    {
       

        [MaxLength(50)]
        public string user_folder_file_storage_tree_id { set; get; }
        public bool file_or_folder { set; get; }
        public int file_or_folder_id { set; get; }
        public bool is_folder { set; get; }

        [MaxLength(300)]
        public string mapping_id { set; get; }
        [MaxLength(300)]
        public string mapping_parent { set; get; }

        public int user_id { set; get; }
        public string cust_id { set; get; }


    }
}
