using getbiz_cloud_file_storage_app.Models;
using getbiz_cloud_file_storage_app.Repository.File_Users_List_Permissions;
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
  //   [Authorize]
    public class FileUsersListPermissionsController : ControllerBase
    {

        private IFileUsersListPermissionsRepository _fileUsersListPermissionsRepository;

        public FileUsersListPermissionsController(IFileUsersListPermissionsRepository fileUsersListPermissionsRepository)
        {
            _fileUsersListPermissionsRepository = fileUsersListPermissionsRepository;
        }

        [HttpPost]
        [Route("api/AddFilePermissions")]
        public IActionResult AddFilePermissions(file_users_list_permissions obj_file_permissions)
        {
            try
            {
                var messages = _fileUsersListPermissionsRepository.AddFilePermissions(obj_file_permissions);
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



        // [AllowAnonymous]
        [HttpPut]
        [Route("api/UpdateFilePermissions")]
        public IActionResult UpdateFilePermissions(file_users_list_permissions obj_file_permissions)
        {
            try
            {
                var messages = _fileUsersListPermissionsRepository.UpdateFilePermissions(obj_file_permissions);
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



        // [AllowAnonymous]
        [HttpGet]
        [Route("api/GetFilePermissions")]
        public IActionResult GetFilePermissions(string CustId,  int FileId, int UserId)
        {
            try
            {
                var messages = _fileUsersListPermissionsRepository.GetFilePermissions(CustId, FileId, UserId);
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
        [Route("api/DeleteUserForFilePermissionsById")]
        public IActionResult DeleteUserForFilePermissionsById(string CustId, int FileId,int UserId)
        {
            try
            {
                var messages = _fileUsersListPermissionsRepository.DeleteUserForFilePermissionsById(CustId, FileId, UserId);
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
