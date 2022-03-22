using getbiz_cloud_file_storage_app.Models;
using getbiz_cloud_file_storage_app.Repository.User_Folders_Files;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace getbiz_cloud_file_storage_app.Controllers
{
   
    [ApiController]
  //   [Authorize]
    public class UserFoldersFilesController : ControllerBase
    {

        private IUserFoldersFilesRepository _userFoldersFilesRepository;

        public UserFoldersFilesController(IUserFoldersFilesRepository userFoldersFilesRepository)
        {
            _userFoldersFilesRepository = userFoldersFilesRepository;
        }


       //  [AllowAnonymous]
        [HttpPost]
        [Route("api/AddUserFoldersFiles")]
        public IActionResult AddUserFoldersFiles(user_folders_files obj_user_folders_files)
        {
            try
            {
                var messages = _userFoldersFilesRepository.AddUserFoldersFiles(obj_user_folders_files);
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
        [Route("api/GetUserFolderFiles")]
        public IActionResult GetUserFolderFiles(string CustId, Int64 UserId, Int64 FileOrFolderId, Int64 FileId, Int64 FolderId)
        {
            try
            {
                var messages = _userFoldersFilesRepository.GetUserFolderFiles(CustId, UserId, FileOrFolderId, FileId, FolderId);
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
        [HttpPut]
        [Route("api/UpdateUserFoldersFiles")]
        public IActionResult UpdateUserFoldersFiles(user_folders_files obj_user_folders_files)
        {
            try
            {
                var messages = _userFoldersFilesRepository.UpdateUserFoldersFiles(obj_user_folders_files);
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
