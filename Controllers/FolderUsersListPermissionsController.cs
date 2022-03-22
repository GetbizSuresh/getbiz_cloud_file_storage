using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using getbiz_cloud_file_storage_app.Repository.Folder_Users_List_Permissions;
using Microsoft.AspNetCore.Authorization;
using getbiz_cloud_file_storage_app.Models;

namespace getbiz_cloud_file_storage_app.Controllers
{

    [ApiController]
//    [Authorize]
    public class FolderUsersListPermissionsController : ControllerBase
    {
        private IFolderUsersListPermissionsRepository _folderuserslistpermissionsrepository;

        public FolderUsersListPermissionsController(IFolderUsersListPermissionsRepository folderuserslistpermissionsrepository)
        {
            _folderuserslistpermissionsrepository = folderuserslistpermissionsrepository;
        }

        [HttpPost]
        [Route("api/AddFolderPermissions")]
        public IActionResult AddFilePermissions(folder_users_list_permissions obj_folder_users_list_permissions)
        {
            try
            {
                var messages = _folderuserslistpermissionsrepository.AddFolderPermissions(obj_folder_users_list_permissions);
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
        [Route("api/UpdateFolderPermissions")]
        public IActionResult UpdateFolderPermissions(folder_users_list_permissions obj_folder_permissions)
        {
            try
            {
                var messages = _folderuserslistpermissionsrepository.UpdateFolderPermissions(obj_folder_permissions);
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
        [Route("api/GetFolderPermissions")]
        public IActionResult GetFolderPermissions(string CustId, int FolerId, int UserId)
        {
            try
            {
                var messages = _folderuserslistpermissionsrepository.GetFolderPermissions(CustId, FolerId, UserId);
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
        [Route("api/DeleteUserForFolderPermissionsById")]
        public IActionResult DeleteUserForFolderPermissionsById(string CustId, int UserId, int FolderId)
        {
            try
            {
                var messages = _folderuserslistpermissionsrepository.DeleteUserForFolderPermissionsById(CustId, UserId, FolderId);
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
