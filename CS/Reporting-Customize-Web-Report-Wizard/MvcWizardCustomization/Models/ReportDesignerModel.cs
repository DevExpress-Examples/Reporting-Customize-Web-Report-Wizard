using DevExpress.XtraReports.UI;
using System.Collections.Generic;

namespace MvcWizardCustomization.Models {
	public class ReportDesignerModel {
		public KeyValuePair<string, object> DataSource { get; set; }
		public XtraReport Report { get; set; }
	}
}
