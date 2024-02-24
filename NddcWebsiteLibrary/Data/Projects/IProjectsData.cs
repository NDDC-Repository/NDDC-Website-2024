using NddcWebsiteLibrary.Model.Projects;

namespace NddcWebsiteLibrary.Data.Projects
{
	public interface IProjectsData
	{
		int CountRoadProjects();
		List<MyProjectModel> GetLatestProjects();
        List<MyProjectCategoryModel> GetProjectCategories();
        List<MyStateModel> GetStates();
        List<MyProjectModel> ViewRoadsAndBridgesProjects();
	}
}