using getbiz_cloud_file_storage_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Repository.Gps_Table
{
    public interface IGpsTableRepositoy
    {
        Response Addgps(gps_table obj_gps_table);
        Response GetALLgps();
        //Response DeleteALLgps( );
    }
}
