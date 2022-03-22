using getbiz_cloud_file_storage_app.Models;
using getbiz_cloud_file_storage_app.Repository.User_Recent_Files;
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
    public class UserRecentFilesController : ControllerBase
    {

        private IUserRecentFilesRepository _userRecentFilesRepository;

        public UserRecentFilesController(IUserRecentFilesRepository userRecentFilesRepository)
        {
            _userRecentFilesRepository = userRecentFilesRepository;
        }



       //  [AllowAnonymous]
        [HttpPost]
        [Route("api/AddUserRecentFiles")]
        public IActionResult AddUserRecentFiles(user_recent_files user_recent_files)
        {
            try
            {
                var messages = _userRecentFilesRepository.AddUserRecentFiles(user_recent_files);
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


        //  [AllowAnonymous]
        [HttpGet]
        [Route("api/GetAllUserRecentFiles")]
        public IActionResult GetAllUserRecentFiles(string CustId, int UserId)  //, Int64 FileId
        {
            try
            {
                var messages = _userRecentFilesRepository.GetAllUserRecentFiles(CustId, UserId);  //, FileId
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
