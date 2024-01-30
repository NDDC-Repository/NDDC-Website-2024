using NddcWebsiteLibrary.Databases;
using NddcWebsiteLibrary.Model.Home;
using NddcWebsiteLibrary.Model.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NddcWebsiteLibrary.Data.Projects
{
    public class SqlProjects
    {
        private const string connectionStringName = "PMIS";
        private readonly ISqlDataAccess db;

        public SqlProjects(ISqlDataAccess db)
        {
            this.db = db;
        }

        public List<MyProjectModel> GetAllProjects()
        {
            return db.LoadData<MyProjectModel, dynamic>("Select Top 100 PID, ProjectName, Summary, ImageUrl From News Order By NID DESC", new { }, connectionStringName, false).ToList();
        }












    }
}
