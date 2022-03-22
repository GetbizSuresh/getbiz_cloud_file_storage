using getbiz_cloud_file_storage_app.Models;
using getbiz_cloud_file_storage_app.Repository.Cloud_File_Storage_Users_Master;
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
    public class CloudFileStorageUsersMasterController : ControllerBase
    {
        private ICloudFileStorageUsersMasterRepository _cloudFileStorageUsersMasterRepository;

        public CloudFileStorageUsersMasterController(ICloudFileStorageUsersMasterRepository cloudFileStorageUsersMasterRepository)
        {
            _cloudFileStorageUsersMasterRepository = cloudFileStorageUsersMasterRepository;
        }

       
        [HttpPost]
        [Route("api/AddCloudFileStorageUsersMaster")]
        public IActionResult AddCloudFileStorageUsersMaster(cloud_file_storage_users_master obj_cloud_file_storage_users_master)
        {
            try
            {
                var messages = _cloudFileStorageUsersMasterRepository.AddCloudFileStorageUsersMaster(obj_cloud_file_storage_users_master);
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
        [Route("api/GetAllCloudFileStorageUsersMaster")]
        public IActionResult GetAllCloudFileStorageUsersMaster(string CustId, int UserId)
        {
            try
            {
                var messages = _cloudFileStorageUsersMasterRepository.GetAllCloudFileStorageUsersMaster(CustId, UserId);
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


            [HttpDelete]
            [Route("api/DeleteCloudFileStorageUsersMaster")]
            public IActionResult DeleteCloudFileStorageUsersMaster(string CustId, int UserId)
            {
                try
                {
                    var messages = _cloudFileStorageUsersMasterRepository.DeleteCloudFileStorageUsersMaster(CustId, UserId);
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



        [HttpPut]
        [Route("api/UpdateCloudFileStorageUsersMaster")]
        public IActionResult UpdateCloudFileStorageUsersMaster(cloud_file_storage_users_master obj_cloud_file_storage_users_master)
        {
            try
            {
                var messages = _cloudFileStorageUsersMasterRepository.UpdateCloudFileStorageUsersMaster(obj_cloud_file_storage_users_master);
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
    }
    
}
