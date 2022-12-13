using System.Collections.Generic;
using System.Linq;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Native;
using DevExpress.DataAccess.Web;

namespace WebFormsWizardCustomization {
	public class CustomConnectionStringsProvider : IDataSourceWizardConnectionStringsProvider {
		public Dictionary<string, string> GetConnectionDescriptions() {
			return AppConfigHelper
				.GetConnections()
				.Keys
				.Where(x=> x != "LocalSqlServer")
				.ToDictionary(x => x, x => x);
		}

		public DataConnectionParametersBase GetDataConnectionParameters(string name) {
			return AppConfigHelper.LoadConnectionParameters(name);
		}
	}
}
