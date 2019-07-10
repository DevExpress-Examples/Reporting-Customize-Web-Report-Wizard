using System;

namespace WebFormsWizardCustomization {
    public partial class RemovePageSection : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
			Utils.BindToData(ASPxReportDesigner3);
		}
    }
}
