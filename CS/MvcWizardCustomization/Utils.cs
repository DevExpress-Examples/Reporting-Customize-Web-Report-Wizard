using DevExpress.DataAccess.Sql;

namespace MvcWizardCustomization {
	public class Utils {
		public static SqlDataSource CreateDataSource() {
			// Create a SQL data source with the specified connection string.
			SqlDataSource ds = new SqlDataSource("NorthwindConnectionString");

			// Create a SQL query to access the Products data table.
			SelectQuery query = SelectQueryFluentBuilder.AddTable("Products").SelectAllColumnsFromTable().Build("Products");
			ds.Queries.Add(query);
			ds.RebuildResultSchema();

			return ds;
		}
	}
}
