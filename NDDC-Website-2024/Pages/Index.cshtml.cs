using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NddcWebsiteLibrary.Data.Home;
using NddcWebsiteLibrary.Model.Home;

namespace NDDC_Website_2024.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHomeData homeDb;
        public List<MyNewsModel> NewsSlide { get; set; }
        public List<MyNewsModel> NewsList { get; set; }
        public readonly string _containerUrl;

		public IndexModel(IHomeData homeDb, IConfiguration configuration)
        {
            this.homeDb = homeDb;
			_containerUrl = configuration.GetConnectionString("AWSContainerUrl");
		}

        public void OnGet()
        {
            NewsSlide = homeDb.DisplaySlides();
            NewsList = homeDb.ListHomePageNews();
        }
    }
}