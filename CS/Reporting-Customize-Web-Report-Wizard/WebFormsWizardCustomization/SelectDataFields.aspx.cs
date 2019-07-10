using System;

namespace WebFormsWizardCustomization {
    public partial class SelectDataFields : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
			Utils.BindToData(ASPxReportDesigner8);
		}
    }
}
