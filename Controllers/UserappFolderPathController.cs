using getbiz_cloud_file_storage_app.Models;
using getbiz_cloud_file_storage_app.Repository.Userapp_Folder_Path;
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
 //   [Authorize]
    public class UserappFolderPathController : ControllerBase
    {
        private readonly IUserappFolderPathRepository _userappFolderPathRepository;

        public UserappFolderPathController(IUserappFolderPathRepository userappFolderPathRepository)
        {
            _userappFolderPathRepository = userappFolderPathRepository;
        }


        [HttpPost]
        [Route("api/AddUserappFolderPath")]
        public IActionResult UpdateFolderPath(userapp_folder_path obj_userapp_folder_path)
        {
            try
            {
                var messages = _userappFolderPathRepository.UpdateFolderPath(obj_userapp_folder_path);
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
        [Route("api/GetUserAppFolderPath")]
        public IActionResult GetUserAppFolderPath(string UserId)
        {
            try
            {
                var messages = _userappFolderPathRepository.GetUserAppFolderPath(UserId);
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
