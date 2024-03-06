using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NddcWebsiteLibrary.Data.Projects;
using NddcWebsiteLibrary.Model.Projects;

namespace NDDC_Website_2024.Pages.Services.ProjectDatabase
{
    public class SearchResultsModel : PageModel
    {
        private readonly IProjectsData proj;
        public List<MyProjectModel> Projects { get; set; }

        public SearchResultsModel(IProjectsData proj)
        {
            this.proj = proj;
        }
        public async void OnGet(string projName, int sid, int pcid)
        {
            Projects = proj.GetProjectsAdhocAsync(projName, sid, pcid);
        }
    }
}
