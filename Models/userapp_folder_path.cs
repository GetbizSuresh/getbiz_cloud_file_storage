using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Models
{
    public class userapp_folder_path
    {
        [Key]
        public int Id { get; set; }
        public string cust_id { get; set; }
        public Int64 user_id { get; set; }
        public string folder_path { get; set; }
    }
}
