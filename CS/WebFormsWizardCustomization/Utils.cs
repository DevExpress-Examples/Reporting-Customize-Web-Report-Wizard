using DevExpress.DataAccess.Sql;
using DevExpress.XtraReports.Web;

namespace WebFormsWizardCustomization {
	public class Utils {
		public static void BindToData(ASPxReportDesigner reportDesigner) {
			// Create a SQL data source with the specified connection string.
			SqlDataSource ds = new SqlDataSource("NorthwindConnectionString");

			// Create a SQL query to access the Products data table.
			SelectQuery query = SelectQueryFluentBuilder.AddTable("Products").SelectAllColumnsFromTable().Build("Products");
			ds.Queries.Add(query);
			ds.RebuildResultSchema();

			// Add the created data source to the list of default data sources. 
			reportDesigner.DataSources.Add("Northwind", ds);
		}
	}
}
