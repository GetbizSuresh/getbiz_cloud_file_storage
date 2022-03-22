using getbiz_cloud_file_storage_app.Getbiz_DbContext;
using getbiz_cloud_file_storage_app.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Repository.Gps_Table
{
    public class GpsTableRepositoy : IGpsTableRepositoy
    {
     

        public readonly CloudFileStorageAppDB_DbContext _DbContext;
        public GpsTableRepositoy(CloudFileStorageAppDB_DbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public Response Addgps(gps_table obj_gps_table)
        {
            Response response = new Response();
            try
            {
                if (obj_gps_table.gps_coordinate_id == 0)
                {
                    var obj = _DbContext.gps_tables.Add(obj_gps_table);
                    _DbContext.SaveChanges();
                    response.Message = "Data Saved successfully !!";
                    response.Status = true;
                }
            }
            catch (Exception ex)
            {
                response.Message = "Data Saved to failed !!";
                response.Status = false;
            }
            return response;
        }




        public Response GetALLgps()
        {
            Response response = new Response();
            try
            {
                response.Data = (from master in _DbContext.gps_tables
                                 select new
                                 {
                                     Gps_Coordinate_Id = master.gps_coordinate_id,
                                     Gps_Coordinates = master.gps_coordinates,
                                     Timestamp = master.timestamp,
                                 }).ToList();

                response.Message = "Data Fetch successfully !!";
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Message = "Error, while fetching the data !!";
                response.Status = false;
            }
            return response;
        }





        //public Response DeleteALLgps()
        //{
        //    Response response = new Response();
        //    try
        //    {
        //        var result = _DbContext.gps_tables.ToList();
        //        _DbContext.RemoveRange(result);
        //        _DbContext.SaveChangesAsync();

        //        response.Message = "Data Deleted successfully !!";
        //        response.Status = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Message = "Error, while fetching the data !!";
        //        response.Status = false;
        //    }
        //    return response;
        //}




    }
}
