using System;

namespace WebFormsWizardCustomization {
    public partial class PredefinedSettings : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
			Utils.BindToData(ASPxReportDesigner1);
		}
    }
}
