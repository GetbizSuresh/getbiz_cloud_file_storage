using getbiz_cloud_file_storage_app.Models;
using getbiz_cloud_file_storage_app.Repository.Cloud_File_Storage_App_Registeration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Controllers
{

  //  [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CloudFileStorageAppRegisterationController : ControllerBase
    {
        private ICloudFileStorageAppRegisterationRepository _cloudFileStorageAppRegisterationRepository;

        public CloudFileStorageAppRegisterationController(ICloudFileStorageAppRegisterationRepository cloudFileStorageAppRegisterationRepository)
        {
            _cloudFileStorageAppRegisterationRepository = cloudFileStorageAppRegisterationRepository;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/CloudFileStorageAppRegisteration")]
        public IActionResult CloudFileStorageAppRegisteration(cloud_file_storage_app_registeration obj_cloud_file_storage_app_registeration)
        {
            try
            {
                var messages = _cloudFileStorageAppRegisterationRepository.CloudFileStorageAppRegisteration(obj_cloud_file_storage_app_registeration);
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
        [Route("api/GetAllCloudFileStorageAppRegisteration")]
        public IActionResult GetAllCloudFileStorageAppRegisteration(string CustId)
        {
            try
            {
                var messages = _cloudFileStorageAppRegisterationRepository.GetAllCloudFileStorageAppRegisteration(CustId);
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
