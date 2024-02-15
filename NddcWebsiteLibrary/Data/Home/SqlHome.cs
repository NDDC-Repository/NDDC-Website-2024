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
            return db.LoadData<MyNewsModel, dynamic>("Select Top 5 NID, Subject, Summary, ImageUrl From News Order By NID DESC", new { }, connectionStringName, false).ToList();
        }
        public List<MyNewsModel> AllNews()
        {
            return db.LoadData<MyNewsModel, dynamic>("select ROW_NUMBER() OVER (ORDER BY NID DESC) As SrNo, NID, Subject, Summary, ImageUrl, PublishDate, ExpiryDate, Views, Clicks, Type, SetAsSlide from News Order By NID DESC", new { }, connectionStringName, false).ToList();
        }
        public List<MyNewsModel> ListHomePageNews()
        {
            //list all items in home page
            return db.LoadData<MyNewsModel, dynamic>("select top 3 ROW_NUMBER() OVER (ORDER BY NID DESC) As SrNo, NID, Subject, Summary, ImageUrl, PublishDate, ExpiryDate, Views, Clicks, Type, SetAsSlide from News Order By NID DESC", new { }, connectionStringName, false).ToList();
        }

        //Photo Speak Methods

        public List<MyPhotoSpeakModel> DisplayPhotos()
        {
            return db.LoadData<MyPhotoSpeakModel, dynamic>("Select Top 40 Id, Title, Location, ImageUrl From PhotoSPeak Order By Id DESC", new { }, connectionStringName, false).ToList();
        }

        public MyUpdateModel GetImageByUpdateCategory(string updateCategory)
        {
            return db.LoadData<MyUpdateModel, dynamic>("select top 1 Id, Title, DescriptionImage from Updates Where UpdateCategory = @UpdateCategory Order By Id DESC", new { UpdateCategory = updateCategory }, connectionStringName, false).SingleOrDefault();
        }

        public List<MyVideoModel> DisplayVideos()
        {
            return db.LoadData<MyVideoModel, dynamic>("Select Top 4 Id, VideoTitle, VideoDesc, YoutubeUrl From Videos Order By Id DESC", new { }, connectionStringName, false).ToList();
        }
        public MyVideoModel DisplayMainVideo()
        {
            return db.LoadData<MyVideoModel, dynamic>("Select Top 1 Id, VideoTitle, VideoDesc, YoutubeUrl From Videos Order By Id DESC", new { }, connectionStringName, false).FirstOrDefault();
        }
        public List<MyTenderModel> ViewAllTenders()
        {
            return db.LoadData<MyTenderModel, dynamic>("Select Id, Titel, Category, DocumentUrl, AdvertDate, DeadlioneDate From Tenders Order By Id DESC", new { }, connectionStringName, false).ToList();
        }
        public List<MyTenderModel> ViewTenderDetails(int Id)
        {
            return db.LoadData<MyTenderModel, dynamic>("Select Id, Titel, Category, DocumentUrl, AdvertDate, DeadlioneDate From Tenders Where Id = @Id Order By Id DESC", new { Id }, connectionStringName, false).ToList();
        }
		public MyNewsModel GetBreakingNews()
		{
			DateTime publishDate = db.LoadData<DateTime, dynamic>("select top 1 PublishDate from News Where DisplayFormat = 'Breaking' Order By NID DESC", new { }, connectionStringName, false).SingleOrDefault();

            DateTime endDate = publishDate.AddDays(3);
            DateTime currDate = DateTime.Now;

			if (currDate < endDate)
			{
				return db.LoadData<MyNewsModel, dynamic>("Select Top 1 NID, Subject from News Where DisplayFormat = 'Breaking' Order By NID DESC", new { }, connectionStringName, false).SingleOrDefault();
			}

			return null;
		}
	}
}
