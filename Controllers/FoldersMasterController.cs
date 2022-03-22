using getbiz_cloud_file_storage_app.Models;
using getbiz_cloud_file_storage_app.Repository.Folders_Master;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace getbiz_cloud_file_storage_app.Controllers
{
    // [Route("api/[controller]")]
    [ApiController]
 //    [Authorize]
    public class FoldersMasterController : ControllerBase
    {

        private IFoldersMasterRepository _foldersmasterrepository;

        public FoldersMasterController(IFoldersMasterRepository foldersmasterrepository)
        {
            _foldersmasterrepository = foldersmasterrepository;
        }

        // [AllowAnonymous]

        [HttpPost]
        [Route("api/AddFoldersMaster")]
        public IActionResult AddFoldersMaster(folders_master obj_folders_master)
        {
            try
            {
                var messages = _foldersmasterrepository.AddFoldersmaster(obj_folders_master);
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

        [HttpDelete]
        [Route("api/DeleteFoldersMaster")]
        public IActionResult DeleteFoldersMaster(folders_master obj_folders_master)
        {
            try
            {
                var messages = _foldersmasterrepository.DeleteFoldersMaster(obj_folders_master);
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
        [Route("api/GetAllFolderMaster")]
        public IActionResult GetAllFolderMaster(string CustId, Int64 UserId)
        {
            try
            {
                var messages = _foldersmasterrepository.GetAllFolderMaster(CustId, UserId);
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
        [Route("api/UpdateFolderMaster")] 
        public IActionResult UpdateFolderMaster(folders_master obj_folders_master)
        {
            try
            {
                var messages = _foldersmasterrepository.UpdateFolderMaster(obj_folders_master);
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
        [Route("api/FolderRename")]
        public IActionResult FolderRename(folders_master obj_folders_master)
        {
            try
            {
                var messages = _foldersmasterrepository.FolderRename(obj_folders_master);
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
        [Route("api/GetFolderActivityLogCopy")]
        public IActionResult GetFolderActivity(string CustId, Int64 FolderId)
        {
            try
            {
                var messages = _foldersmasterrepository.GetFolderActivity(CustId, FolderId);
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


        // ////////////////////////////27112021


        [HttpGet]
        [Route("api/GetAllFoldersByParentFieldBased")]
        public IActionResult GetAllFoldersByParentFieldBased(string CustId)
        {
            try
            {
                var messages = _foldersmasterrepository.GetAllFoldersByParentFieldBased(CustId);
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
        //

        [HttpGet]
        [Route("api/GetAllFoldersByParentFieldBasedById")]
        public IActionResult GetAllFoldersByParentFieldBasedById(string CustId,Int64 UserId)
        {
            try
            {
                var messages = _foldersmasterrepository.GetAllFoldersByParentFieldBasedById(CustId, UserId);
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



        // //////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpGet]
        [Route("api/GetAllFolderFilesViewDetails")]
        public IActionResult GetAllFolderFilesViewDetails(string CustId, Int64 UserId, string MappingId, Int64 FromUserId)
        {
            try
            {
                var messages = _foldersmasterrepository.GetAllFolderFilesViewDetails(CustId, UserId, MappingId, FromUserId);
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
        [Route("api/UpdateFolderDeletedStatus")]
        public IActionResult UpdateFolderDeletedStatus(folders_master obj_folders_master)
        {
            try
            {
                var messages = _foldersmasterrepository.UpdateFolderDeletedStatus(obj_folders_master);
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
        [Route("api/DeleteFolderPermanently")]
        public IActionResult DeleteFolderPermanently(string CustId, Int64 FolderId, Int64 UserId, string MappingId)
        {
            try
            {
                var messages = _foldersmasterrepository.DeleteFolderPermanently(CustId, FolderId, UserId, MappingId);
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
