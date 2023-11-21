using NddcWebsiteLibrary.Databases;
using NddcWebsiteLibrary.Model.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NddcWebsiteLibrary.Data.Home
{
    public class SqlHome : IHomeData
    {
        private const string connectionStringName = "SqlDb";
        private readonly ISqlDataAccess db;

        public SqlHome(ISqlDataAccess db)
        {
            this.db = db;
        }

        public List<MyNewsModel> DisplaySlides()
        {
            return db.LoadData<MyNewsModel, dynamic>("Select Top 2 NID, Subject, Summary, ImageUrl From News Order By NID DESC", new { }, connectionStringName, false).ToList();
        }
        public List<MyNewsModel> AllNews()
        {
            return db.LoadData<MyNewsModel, dynamic>("select ROW_NUMBER() OVER (ORDER BY NID DESC) As SrNo, NID, Subject, Summary, ImageUrl, PublishDate, ExpiryDate, Views, Clicks, Type, SetAsSlide from News Order By NID DESC", new { }, connectionStringName, false).ToList();
        }
        public List<MyNewsModel> ListHomePageNews()
        {
            return db.LoadData<MyNewsModel, dynamic>("select top 3 ROW_NUMBER() OVER (ORDER BY NID DESC) As SrNo, NID, Subject, Summary, ImageUrl, PublishDate, ExpiryDate, Views, Clicks, Type, SetAsSlide from News Order By NID DESC", new { }, connectionStringName, false).ToList();
        }
    }
}
