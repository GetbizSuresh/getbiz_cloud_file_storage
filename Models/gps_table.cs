using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Models
{
    public class gps_table
    {
        [Key]
        public int gps_coordinate_id { set; get; }
        public string gps_coordinates { set; get; }
        public string  timestamp { set; get; }
    }
}
