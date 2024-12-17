using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BE_CRM;

namespace DAL_CRM
{
   public class DB : DbContext
    {
        public DB() : base("connectdatabase1")
        {

        }
        public DbSet<customer> customers { set; get; }
        public DbSet<product> products { set; get; }
        public DbSet<user> users { set; get; }
        public DbSet<reminder> reminders { set; get; }
        public DbSet<group> groups { set; get; }
        public DbSet<activityCategory> activityCategories { get; set; }
        public DbSet<activity> activities { get; set; }
        public DbSet<invoice> invoices { get; set; }
        public DbSet<userGroup> userGroups { get; set; }
        public DbSet<userAccessRole> userAccessRoles { get; set; }



    }
}
