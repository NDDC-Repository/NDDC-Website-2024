using NddcWebsiteLibrary.Databases;
using NddcWebsiteLibrary.Model.Home;
using NddcWebsiteLibrary.Model.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NddcWebsiteLibrary.Data.Projects
{
	public class SqlProjects : IProjectsData
	{
		private const string connectionStringName = "PMIS";
		private readonly ISqlDataAccess db;

		public SqlProjects(ISqlDataAccess db)
		{
			this.db = db;
		}

		public List<MyProjectModel> GetLatestProjects()
        {
			return db.LoadData<MyProjectModel, dynamic>("SELECT TOP(6) Projects.PID, Projects.ProjectName, ProjectLocation.Location, ProjectCategory.CatName FROM  Projects INNER JOIN ProjectCategory ON Projects.PCID = ProjectCategory.PCID LEFT OUTER JOIN ProjectLocation ON Projects.LID = ProjectLocation.PLID ORDER BY Projects.PID DESC", new { }, connectionStringName, false).ToList();
		}
		public int CountRoadProjects()
		{
			return db.LoadData<int, dynamic>("Select Count(PID) As ProjCount From Projects Where PCID = 1", new { }, connectionStringName, false).FirstOrDefault();
		}
		public List<MyProjectModel> ViewRoadsAndBridgesProjects()
		{
			return db.LoadData<MyProjectModel, dynamic>("SELECT Projects.ProjectName, State.StateName, ProjectLocation.Location FROM Projects INNER JOIN ProjectLocation ON Projects.PLID = ProjectLocation.PLID CROSS JOIN State Where PCID = 1 Order By NID DESC", new { }, connectionStringName, false).ToList();
		}
        public List<MyStateModel> GetStates()
        {
            return db.LoadData<MyStateModel, dynamic>("SELECT SID, StateName From State Where StateType = 'NDDC'", new { }, connectionStringName, false).ToList();
        }
        public List<MyProjectCategoryModel> GetProjectCategories()
        {
            return db.LoadData<MyProjectCategoryModel, dynamic>("SELECT PCID, CatName From ProjectCategory", new { }, connectionStringName, false).ToList();
        }
		public List<MyProjectModel> GetProjectsAdhocAsync(string projectName, int sid, int pcid)
		{

			//MyPayRollListModel reportModel;
			List<MyProjectModel> Projects = new List<MyProjectModel>();
			//List<Task<decimal>> tasks = new List<Task<decimal>>();

			bool toggle = false;
			string glSchema = "";

			if (projectName != "")
			{
				if (toggle == true)
				{
					glSchema = $"Projects.ProjectName Like '%{projectName}%'";
				}
				else
				{
					glSchema = $"Where Projects.ProjectName Like '%{projectName}%'";
					toggle = true;
				}
			}

			if (sid != 0)
			{
				if (toggle == true)
				{
					glSchema = $"{glSchema} And Projects.SID = {sid}";
				}
				else
				{
					glSchema = $"Where Projects.SID = {sid}";
					toggle = true;
				}
			}
			if (pcid != 0)
			{
				if (toggle == true)
				{
					glSchema = $"{glSchema} And Projects.PCID = {pcid}";
				}
				else
				{
					glSchema = $"Where Projects.PCID = {pcid}";
					toggle = true;
				}
			}
			
			string SQL = "SELECT ROW_NUMBER() OVER (ORDER BY Employees.Id DESC) As SrNo, Employees.Id, Employees.BasicSalary, Employees.EmployeeCode, Employees.FirstName, Employees.Gender, Employees.SecretarialAllow, Employees.CooperativeDed, Employees.VoluntaryPension, Employees.BankCode, Employees.AccountNumber, Banks.BankName, Employees.EntertainmentAllow, Employees.NewspaperAllow, Employees.Arreas, " +
				"Employees.LastName, Employees.Email, Employees.Category, (TransportAllow) As TransportAllowance, (HousingAllow) As HousingAllowance, (FurnitureAllow) As FurnitureAllowance, (MealAllow) As MealAllowance, (UtilityAllow) As UtilityAllowance, " +
				"(EducationAllow) As EducationAllowance, (DomesticServantAllow) As DomesticServantAllowance, (DriverAllow) As DriversAllowance, (VehicleAllow) As VehicleMaintenanceAllowance, (HazardAllow) As HazardAllowance, (Tax) As TaxDeduction, (NHF) As NHFDeduction, (JSA) As JSADeduction, (SSA) As SSADeduction, TotalEarnings, TotalDeductions, " +
				"NetPay, (Pension) As PensionDeduction, (MedicalAllow) As MedicalAllowance, (SecurityAllow) As SecurityAllowance, GradeLevel.GradeLevel, Departments.DepartmentName, Employees.EntertainmentAllow, Employees.NewspaperAllow, Employees.LeaveAllow FROM Employees LEFT JOIN GradeLevel ON Employees.GradeLevelId = " +
				"GradeLevel.Id LEFT JOIN Departments ON Employees.DepartmentId = Departments.Id LEFT JOIN JobTitles ON Employees.JobTitleId = " +
				$"JobTitles.Id LEFT JOIN Banks On Employees.BankCode = Banks.Code {glSchema} ORDER BY Employees.Id DESC";

			string SQL2 = $"SELECT Top 50 Projects.PID, Projects.ProjectName, ProjectLocation.Location, ProjectCategory.CatName FROM  Projects INNER JOIN ProjectCategory ON Projects.PCID = ProjectCategory.PCID LEFT OUTER JOIN ProjectLocation ON Projects.LID = ProjectLocation.PLID {glSchema} ORDER BY Projects.PID DESC";

			Projects = db.LoadData<MyProjectModel, dynamic>(SQL2, new { }, connectionStringName, false).ToList();

			return Projects;
		}












	}
}
