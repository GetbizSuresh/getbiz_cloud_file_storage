using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Models
{
    public class folder_users_list_permissions
    {

        public int shared_user_id { set; get; }
        public int user_id { set; get; }
        public string user_added_timestamp { set; get; }
        
        public string? user_removed_timestamp  { get; set; }

        [DefaultValue(false)]
        public bool folder_admin { set; get; } = false;
        public Int64 access_recent_no_of_files { set; get; }

        [DefaultValue(false)]
        public bool upload_folder { set; get; } = false;
        [DefaultValue(false)]
        public bool rename_folder { set; get; } = false;
        [DefaultValue(false)]
        public bool download_folder { set; get; } = false;
        [DefaultValue(false)]
        public bool copy_folder { set; get; } = false;
        [DefaultValue(false)]
        public bool share_folder { set; get; } = false;
        [DefaultValue(false)]
        public bool folder_activity_notification { set; get; } = false;
        public string cust_id { set; get; }
        public Int64 folder_id { set; get; }
        public string mapping_id { set; get; }

    }
}
