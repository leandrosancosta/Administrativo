using MySql.Data.Entity;
using System.Data.Entity;
using Core.Acesso;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Repository.Context
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class ApplicationIdentityDbContext : IdentityDbContext<User>
    {
        public ApplicationIdentityDbContext()
            : base("dbMyApp")
        {

        }
        static ApplicationIdentityDbContext()
        {
            Database.SetInitializer<ApplicationIdentityDbContext>(new IdentityDbInit());
        }

        public static ApplicationIdentityDbContext Create()
        {
            return new ApplicationIdentityDbContext();
        }

        public class IdentityDbInit : DropCreateDatabaseIfModelChanges<ApplicationIdentityDbContext>
        {
        }
    }
}
