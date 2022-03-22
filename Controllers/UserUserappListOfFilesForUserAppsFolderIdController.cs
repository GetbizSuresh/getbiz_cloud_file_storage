using getbiz_cloud_file_storage_app.Models;
using getbiz_cloud_file_storage_app.Repository.User_Userapp_List_Of_Files_For_User_Apps_Folder_Id;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  //  [Authorize]
    public class UserUserappListOfFilesForUserAppsFolderIdController : ControllerBase
    {

        public readonly IUserUserappListOfFilesForUserAppsFolderIdRepository _userUserappListOfFilesForUserAppsFolderIdRepository;

        private IConfiguration configuration;

        public UserUserappListOfFilesForUserAppsFolderIdController(IUserUserappListOfFilesForUserAppsFolderIdRepository userUserappListOfFilesForUserAppsFolderIdRepository, IConfiguration _configuration)
        {
            _userUserappListOfFilesForUserAppsFolderIdRepository = userUserappListOfFilesForUserAppsFolderIdRepository;

            configuration = _configuration;
        }


        [HttpPost]
        [Route("api/AddUserappFolderDetailsForBusinessApps")]
        public async Task<IActionResult> AddUserUserappListOfFilesForUserAppsFolderIdAddUserUserappListOfFilesForUserAppsFolderId([FromForm] userapp_files_details_for_business_apps obj_userapp_files_details_for_business_apps)
        {
            try
            {

                userapp_files_details_for_business_apps mainobj = new userapp_files_details_for_business_apps();

                string Serverpath = configuration.GetSection("Serverpath").Value;
                string LiveServerpath = configuration.GetSection("LiveServerpath").Value;

                if (obj_userapp_files_details_for_business_apps.Choose_file != null && obj_userapp_files_details_for_business_apps.choose_photo == null)
                {

                      var Custidpath = LiveServerpath + obj_userapp_files_details_for_business_apps.cust_id;
                  //  var Custidpath = Serverpath + obj_userapp_files_details_for_business_apps.cust_id;

                    if (!(Directory.Exists(Custidpath)))
                    {
                        Directory.CreateDirectory(Custidpath);

                         var UserIdpath = LiveServerpath + obj_userapp_files_details_for_business_apps.cust_id + "\\" + obj_userapp_files_details_for_business_apps.uploaded_created_by_user_id;
                        // var UserIdpath = Serverpath + obj_userapp_files_details_for_business_apps.cust_id + "\\" + obj_userapp_files_details_for_business_apps.uploaded_created_by_user_id;
                        if (!(Directory.Exists(UserIdpath)))
                        {
                            Directory.CreateDirectory(UserIdpath);
                            if (obj_userapp_files_details_for_business_apps.Choose_file.Length <= 0) return BadRequest();
                            var filePath = Path.Combine(UserIdpath, obj_userapp_files_details_for_business_apps.Choose_file.FileName);


                            using (var stream = new FileStream(filePath, FileMode.Create))                                  // create directory here 
                            {
                                await obj_userapp_files_details_for_business_apps.Choose_file.CopyToAsync(stream);
                            }

                            mainobj.file_storage_url = obj_userapp_files_details_for_business_apps.Choose_file.FileName; // assign filename
                        }
                        else
                        {
                            if (obj_userapp_files_details_for_business_apps.Choose_file.Length <= 0) return BadRequest();
                            var filePath = Path.Combine(UserIdpath, obj_userapp_files_details_for_business_apps.Choose_file.FileName);
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await obj_userapp_files_details_for_business_apps.Choose_file.CopyToAsync(stream);
                            }

                            mainobj.file_storage_url = obj_userapp_files_details_for_business_apps.Choose_file.FileName; // assign filename
                        }
                    }
                    else
                    {

                          var UserIdpath = LiveServerpath + obj_userapp_files_details_for_business_apps.cust_id + "\\" + obj_userapp_files_details_for_business_apps.uploaded_created_by_user_id;

                     //   var UserIdpath = Serverpath + obj_userapp_files_details_for_business_apps.cust_id + "\\" + obj_userapp_files_details_for_business_apps.uploaded_created_by_user_id;
                        if (!(Directory.Exists(UserIdpath)))
                        {
                            Directory.CreateDirectory(UserIdpath);
                            if (obj_userapp_files_details_for_business_apps.Choose_file.Length <= 0) return BadRequest();
                            var filePath = Path.Combine(UserIdpath, obj_userapp_files_details_for_business_apps.Choose_file.FileName);
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await obj_userapp_files_details_for_business_apps.Choose_file.CopyToAsync(stream);
                            }
                            mainobj.file_storage_url = obj_userapp_files_details_for_business_apps.Choose_file.FileName; // assign filename
                        }
                        else
                        {
                            if (obj_userapp_files_details_for_business_apps.Choose_file.Length <= 0) return BadRequest();

                            var filePath = Path.Combine(UserIdpath, obj_userapp_files_details_for_business_apps.Choose_file.FileName);
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await obj_userapp_files_details_for_business_apps.Choose_file.CopyToAsync(stream);
                            }

                            mainobj.file_storage_url = obj_userapp_files_details_for_business_apps.Choose_file.FileName; //assign filename
                        }
                    }

                }


                else
                {
                       var Custidpath = LiveServerpath + obj_userapp_files_details_for_business_apps.cust_id;
                   // var Custidpath = Serverpath + obj_userapp_files_details_for_business_apps.cust_id;

                    if (!(Directory.Exists(Custidpath)))
                    {
                        Directory.CreateDirectory(Custidpath);

                        var UserIdpath = LiveServerpath + obj_userapp_files_details_for_business_apps.cust_id + "\\" + obj_userapp_files_details_for_business_apps.uploaded_created_by_user_id;
                       //  var UserIdpath = Serverpath + obj_userapp_files_details_for_business_apps.cust_id + "\\" + obj_userapp_files_details_for_business_apps.uploaded_created_by_user_id;
                        if (!(Directory.Exists(UserIdpath)))
                        {
                            byte[] imageBytes = Convert.FromBase64String(obj_userapp_files_details_for_business_apps.choose_photo);
                            string file_name = obj_userapp_files_details_for_business_apps.file_name + ".jpg";

                            Directory.CreateDirectory(UserIdpath);
                            //  if (obj_file_master.choose_photo.Length <= 0) return BadRequest();

                            var filePath = Path.Combine(UserIdpath, file_name);
                            System.IO.File.WriteAllBytes(filePath, imageBytes);


                            mainobj.file_storage_url = file_name; // assign filename
                        }
                        else
                        {
                            byte[] imageBytes = Convert.FromBase64String(obj_userapp_files_details_for_business_apps.choose_photo);
                            string file_name = obj_userapp_files_details_for_business_apps.file_name + ".jpg";

                            Directory.CreateDirectory(UserIdpath);
                            //  if (obj_file_master.choose_photo.Length <= 0) return BadRequest();

                            var filePath = Path.Combine(UserIdpath, file_name);
                            System.IO.File.WriteAllBytes(filePath, imageBytes);



                            mainobj.file_storage_url = file_name; // assign filename
                        }
                    }
                    else
                    {
                        //   var UserIdpath = LiveServerpath + obj_userapp_files_details_for_business_apps.cust_id;

                        var UserIdpath = LiveServerpath + obj_userapp_files_details_for_business_apps.cust_id + "\\" + obj_userapp_files_details_for_business_apps.uploaded_created_by_user_id;
                        // var UserIdpath = Serverpath + obj_userapp_files_details_for_business_apps.cust_id;


                        if (!(Directory.Exists(UserIdpath)))
                        {
                            byte[] imageBytes = Convert.FromBase64String(obj_userapp_files_details_for_business_apps.choose_photo);
                            string file_name = obj_userapp_files_details_for_business_apps.file_name + ".jpg";

                            Directory.CreateDirectory(UserIdpath);
                            var filePath = Path.Combine(UserIdpath, file_name);
                            System.IO.File.WriteAllBytes(filePath, imageBytes);

                            mainobj.file_storage_url = file_name; // assign filename
                        }
                        else
                        {
                            byte[] imageBytes = Convert.FromBase64String(obj_userapp_files_details_for_business_apps.choose_photo);
                            string file_name = obj_userapp_files_details_for_business_apps.file_name + ".jpg";

                            Directory.CreateDirectory(UserIdpath);
                            var filePath = Path.Combine(UserIdpath, file_name);
                            System.IO.File.WriteAllBytes(filePath, imageBytes);

                            mainobj.file_storage_url = file_name; // assign filename
                        }
                    }
                }
                         
                var messages = _userUserappListOfFilesForUserAppsFolderIdRepository.AddUserUserappListOfFilesForUserAppsFolderId(obj_userapp_files_details_for_business_apps, mainobj);
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
        [Route("api/GetAllUserappFilesDetailsForBusinessApps")]
        public IActionResult GetAllUserappFilesDetailsForBusinessApps(string Cust_Id, Int64 User_Id, int App_Id, int User_Apps_Data_Folder_Id, string Mapping_Id)
        {
            try
            {
                var messages = _userUserappListOfFilesForUserAppsFolderIdRepository.GetAllUserappFilesDetailsForBusinessApps(Cust_Id, User_Id, App_Id, User_Apps_Data_Folder_Id, Mapping_Id);
       
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
        [Route("api/DeleteUserUserappListOfFilesForUserAppsFolderId")]
        public IActionResult DeleteUserUserappListOfFilesForUserAppsFolderId(string Cust_Id, Int64 User_Id, Int64 App_Id, Int64 User_Apps_Data_Folder_Id, Int64 File_Id)
        {
            try
            {
                var messages = _userUserappListOfFilesForUserAppsFolderIdRepository.DeleteUserUserappListOfFilesForUserAppsFolderId( Cust_Id,  User_Id,  App_Id,  User_Apps_Data_Folder_Id, File_Id);
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
