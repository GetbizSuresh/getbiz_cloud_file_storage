using getbiz_cloud_file_storage_app.Models;
using getbiz_cloud_file_storage_app.Repository.User_Apps_Data_Folder_Id;
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
    public class UserAppsDataFolderIdController : ControllerBase
    {
        private IUserAppsDataFolderIdRepository _userAppsDataFolderIdRepository;

        public UserAppsDataFolderIdController(IUserAppsDataFolderIdRepository userAppsDataFolderIdRepository)
        {
            _userAppsDataFolderIdRepository = userAppsDataFolderIdRepository;
        }

        // [AllowAnonymous]
        [HttpPost]
        [Route("api/AddUserAppsDataFolderId")]
        public IActionResult AddUserAppsDataFolderId(user_apps_data_folder_id user_apps_data_folder_id)
        {
            try
            {
                var messages = _userAppsDataFolderIdRepository.AddUserAppsDataFolderId(user_apps_data_folder_id);
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
