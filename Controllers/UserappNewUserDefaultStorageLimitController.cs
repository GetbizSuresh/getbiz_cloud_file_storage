using getbiz_cloud_file_storage_app.Models;
using getbiz_cloud_file_storage_app.Repository.Userapp_New_User_Default_Storage_Limit;
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
    public class UserappNewUserDefaultStorageLlimitController : ControllerBase
        {

            public readonly IUserappNewUserDefaultStorageLimitRepository _userappNewUserDefaultStorageLimitRepository;
            public UserappNewUserDefaultStorageLlimitController(IUserappNewUserDefaultStorageLimitRepository userappNewUserDefaultStorageLimitRepository)
            {
                _userappNewUserDefaultStorageLimitRepository = userappNewUserDefaultStorageLimitRepository;

            }

        [HttpGet]
        [Route("api/GetUserAppNewUserDefaultStorageLimit")]
        public IActionResult GetUserAppNewUserDefaultStorageLimit(string CustId)
        {
            try
            {
                var messages = _userappNewUserDefaultStorageLimitRepository.GetUserAppNewUserDefaultStorageLimit(CustId);
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





        [HttpPost]
        [Route("api/AddUserAppNewUserDefaultStorageLimit")]
        public IActionResult UpdateUserAppNewUserDefaultStorageLimit(userapp_new_user_default_storage_limit obj_userapp_new_user_default_storage_limit)
        {
            try
            {
                var messages = _userappNewUserDefaultStorageLimitRepository.UpdateUserAppNewUserDefaultStorageLimit(obj_userapp_new_user_default_storage_limit);
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

