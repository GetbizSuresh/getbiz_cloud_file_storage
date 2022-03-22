using getbiz_cloud_file_storage_app.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_cloud_file_storage_app.Getbiz_DbContext
{
    public class CloudFileStorageAppDB_DbContext : DbContext
    {
        public CloudFileStorageAppDB_DbContext(DbContextOptions<CloudFileStorageAppDB_DbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public virtual DbSet<cloud_file_storage_app_login> cloud_file_storage_app_logins { get; set; }
        public virtual DbSet<gps_table> gps_tables { get; set; }
        public virtual DbSet<userapp_folder_path> userapp_folder_paths { get; set; }
        public virtual DbSet<files_master> files_master { get; set; }
        public virtual DbSet<user_login> user_login { get; set; }
        public virtual DbSet<userapp_new_user_default_storage_limit> userapp_new_user_default_storage_limits { get; set; }
    }
}
