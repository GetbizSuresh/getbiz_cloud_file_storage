using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Models
{
    public class userapp_audit_trail_for_app_administrator
    {
        public string user_id { set; get; }
        public string action_taken_on_username { set; get; }
        public string entry_type { set; get; }
        public string created_timestamp { set; get; }
        public string entry_by_username { set; get; }
        public string user_category { set; get; }
    }
}
