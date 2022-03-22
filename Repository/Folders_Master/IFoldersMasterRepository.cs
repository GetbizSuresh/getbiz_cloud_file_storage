using getbiz_cloud_file_storage_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Repository.Folders_Master
{
    public interface IFoldersMasterRepository
    {
        Response AddFoldersmaster(folders_master obj_folders_master);
        Response DeleteFoldersMaster(folders_master obj_folders_master);

        Response FolderRename(folders_master obj_folders_master);
        Response GetAllFolderMaster(string CustId, Int64 UserId);
        Response UpdateFolderMaster(folders_master obj_folders_master);

        Response GetFolderActivity(string CustId, Int64 FolderId);

        // //////////////////////////////////////////////27112021
        Response GetAllFoldersByParentFieldBased(string CustId);


        Response GetAllFoldersByParentFieldBasedById(string CustId, Int64 UserId);
        Response GetAllFolderFilesViewDetails(string CustId, Int64 UserId, string MappingId, Int64 FromUserId);



        Response UpdateFolderDeletedStatus(folders_master obj_folders_master);


        Response DeleteFolderPermanently(string CustId, Int64 FolderId, Int64 UserId, string MappingId);
    }
}
