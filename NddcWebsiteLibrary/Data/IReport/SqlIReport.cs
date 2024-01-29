using NddcWebsiteLibrary.Databases;
using NddcWebsiteLibrary.Model.IReport;
using NddcWebsiteLibrary.Model.ServiceGate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NddcWebsiteLibrary.Data.IReport
{
    public class SqlIReport
    {
        private const string connectionStringName = "SqlDb";
        private readonly ISqlDataAccess db;
        public SqlIReport(ISqlDataAccess db)
        {
            this.db = db;
        }

        public void AddIReport(MyIReportModel ireport)
        {
            ireport.DateAdded = DateTime.Now;

            db.SaveData("Insert Into IReports (Type, Name, Email, Phone, Location, DateAdded, Comment, ImageUrl1, ImageUrl2, ImageUrl3, ImageUrl4) values(@Type, @Name, @Email, @Phone, @Location, @DateAdded, @Comment, @ImageUrl1, @ImageUrl2, @ImageUrl3, @ImageUrl4)", new { ireport.Type, ireport.Name, ireport.Email, ireport.Phone, ireport.Location, ireport.VideoUrl, ireport.DateAdded, ireport.Comment }, connectionStringName, false);
        }
    }
}
