using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Models
{
    public class files_master
    {
        [Key]
        public int file_id { set; get; }
        public string mapping_id { set; get; } 
        public bool is_folder { set; get; } 
        public string mapping_parent { set; get; } 

        public string file_name { set; get; }
        public bool multiuser_file_access { set; get; }
        public string  file_type { set; get; }
        public int uploaded_created_by_user_id { set; get; }

        public string uploaded_created_timestamp { set; get; }
        public string file_storage_url { set; get; }

        public string choose_photo { set; get; } 

        public IFormFile file_storage_urls { set; get; }
        public decimal file_size { set; get; }

        [DefaultValue(false)]
        public bool deleted_status { set; get; } = false;
        public string cust_id { set; get; }
    }









}
