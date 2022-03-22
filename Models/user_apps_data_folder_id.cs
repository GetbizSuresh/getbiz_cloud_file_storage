using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Models
{
    public class user_apps_data_folder_id
    {
        [Key]

        public int file_id { set; get; }
        [MaxLength(30)]
        public string file_name { set; get; }
        public int file_type { set; get; }

        //[Timestamp]
        //public Byte[] file_created_timestamp { get; set; }
        public DateTime file_created_timestamp { get; set; }

        [MaxLength(250)]
        public string file_storage_url { get; set; }
    }
}

