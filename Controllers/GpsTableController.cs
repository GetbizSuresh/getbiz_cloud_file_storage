using getbiz_cloud_file_storage_app.Getbiz_DbContext;
using getbiz_cloud_file_storage_app.Models;
using getbiz_cloud_file_storage_app.Repository.Gps_Table;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Controllers
{
    
    [ApiController]
  //  [Authorize]
    public class GpsTableController : ControllerBase
    {
        public readonly CloudFileStorageAppDB_DbContext _DbContext;
        public readonly IGpsTableRepositoy _gpsTableRepositoy;
        public GpsTableController(IGpsTableRepositoy gpsTableRepositoy ,CloudFileStorageAppDB_DbContext DbContext)
        {
            _gpsTableRepositoy = gpsTableRepositoy;
            _DbContext = DbContext;
        }

        [AllowAnonymous]

        [HttpPost]
        [Route("api/Addgps")]
        public IActionResult AddUserAppBusinessCategories(gps_table obj_gps_table)
        {
            try
            {
                var messages = _gpsTableRepositoy.Addgps(obj_gps_table);
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpGet]
        [Route("api/GetALLgps")]
        public IActionResult GetALLgps()
        {
            try
            {
                var messages = _gpsTableRepositoy.GetALLgps();
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }





        //[HttpDelete]
        //[Route("api/DeleteALLgps")]
        //public IActionResult DeleteALLgps()
        //{
        //    try
        //    {
        //        var messages = _gpsTableRepositoy.DeleteALLgps();
        //        if (messages == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(messages);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest();
        //    }
        //}


        [HttpDelete]
        [Route("api/DeleteALLgps")]
        public async Task<IActionResult> DeleteALLgps()
        {
            try
            {
                var result = _DbContext.gps_tables.ToList();
                _DbContext.RemoveRange(result);
                await _DbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            return new JsonResult("Successfully Deleted");
        }



    }
}
