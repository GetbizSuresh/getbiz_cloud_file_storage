using getbiz_cloud_file_storage_app.Repository.User_App_New_User_Default_Storage_Log;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  //  [Authorize]
    public class UserAppNewUserDefaultStorageLogController : ControllerBase
    {
        private readonly IUserAppNewUserDefaultStorageLogRepository _UserAppNewUserDefaultStorageLogRepository;

        public UserAppNewUserDefaultStorageLogController(IUserAppNewUserDefaultStorageLogRepository UserAppNewUserDefaultStorageLogRepository)
        {
            _UserAppNewUserDefaultStorageLogRepository = UserAppNewUserDefaultStorageLogRepository;
        }

        [HttpGet]
        [Route("api/GetAllUserAppNewUserDefaultStorageLog")]
        public IActionResult GetAllUserAppNewUserDefaultStorageLog(string CustId)
        {
            try
            {
                var messages = _UserAppNewUserDefaultStorageLogRepository.GetAllUserAppNewUserDefaultStorageLog(CustId);
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
        [Route("api/GetByIdUserAppNewUserDefaultStorageLog")]
        public IActionResult GetByIdUserAppNewUserDefaultStorageLog(string CustId, string UserId)
        {
            try
            {
                var messages = _UserAppNewUserDefaultStorageLogRepository.GetByIdUserAppNewUserDefaultStorageLog(CustId, UserId);
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
        [Route("api/DeleteByIdUserAppNewUserDefaultStorageLog")]
        public IActionResult DeleteByIdUserAppNewUserDefaultStorageLog(string CustId, string UserId)
        {
            try
            {
                var messages = _UserAppNewUserDefaultStorageLogRepository.DeleteByIdUserAppNewUserDefaultStorageLog(CustId, UserId);
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
