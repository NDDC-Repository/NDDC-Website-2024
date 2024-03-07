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
        [BindProperty]
        public MyProjectModel Project { get; set; }

        public SearchResultsModel(IProjectsData proj)
        {
            this.proj = proj;
        }
        public async void OnGet(string projName, int sid, int pcid)
        {
            Projects = proj.GetProjectsAdhocAsync(projName, sid, pcid);
        }
        //public async Task<IActionResult> OnPost()
        //{
        //   Projects = proj.GetProjectsAdhocAsync(Project.ProjectName, Project.SID, Project.PCID);
        //   return Projects;
        //}
    }
}
