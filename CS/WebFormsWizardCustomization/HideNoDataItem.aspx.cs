using System;

namespace WebFormsWizardCustomization {
    public partial class HideNoDataItem : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
			Utils.BindToData(ASPxReportDesigner5);
		}
    }
}
