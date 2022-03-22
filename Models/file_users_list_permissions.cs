using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Models
{
    public class file_users_list_permissions
    {


  
        public int shared_user_id { set; get; }
        public int user_id { set; get; }
        public string user_added_timestamp { set; get; } // chage datetime to string
        public string user_removed_timestamp { set; get; }

        [DefaultValue(false)]
        public bool file_admin { set; get; } = false;
        [DefaultValue(false)]
        public bool edit_file { set; get; } = false;
        [DefaultValue(false)]
        public bool rename_file { set; get; } = false;
        [DefaultValue(false)]
        public bool download_file { set; get; } = false;
        [DefaultValue(false)]
        public bool copy_file { set; get; } = false;
        [DefaultValue(false)]
        public bool share_file { set; get; } = false;
        [DefaultValue(false)]
        public bool file_activity_notifications_requested { set; get; } = false;


        public string cust_id { set; get; }
        public Int64 file_id { set; get; }
    }
}
