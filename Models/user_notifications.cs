using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Models
{
    public class user_notifications
    {
        public int notification_for_app_id { set; get; }
        public bool user_app_or_custom_app { set; get; }
        public DateTime timestamp { get; set; }
        public bool user_sent_or_app_generated_notification { set; get; }
        public string notification_message { set; get; }

        public int sent_by_user_id { set; get; }
        public bool notification_status { set; get; }
        public string reply_messages_to_user_notification { set; get; }
        public string cust_id { set; get; }


    }
}
