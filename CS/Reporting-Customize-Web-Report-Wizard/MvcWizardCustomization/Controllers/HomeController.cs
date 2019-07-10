using MvcWizardCustomization.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MvcWizardCustomization.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }

        public ActionResult PredefinedSettings() {
            return View(CommonDeisgnerModel);
        }

		public ActionResult RemovePage() {
			return View(CommonDeisgnerModel);
		}

		public ActionResult RemovePageSection() {
			return View(CommonDeisgnerModel);
		}

		public ActionResult HideReportTypes() {
			return View(CommonDeisgnerModel);
		}

		public ActionResult HideNoDataItem() {
			return View(CommonDeisgnerModel);
		}

		public ActionResult ProhibitNewDataSourceCreation() {
			return View(CommonDeisgnerModel);
		}

		public ActionResult CustomizeColorSchemes() {
			return View(CommonDeisgnerModel);
		}

		public ActionResult SelectDataFields() {
			return View(CommonDeisgnerModel);
		}

		public ActionResult CustomizeWizardResult() {
			return View(CommonDeisgnerModel);
		}

		public ReportDesignerModel CommonDeisgnerModel {
			get {
				return new ReportDesignerModel {
					Report = new DevExpress.XtraReports.UI.XtraReport(),
					DataSource = new KeyValuePair<string, object>("Northwind", Utils.CreateDataSource())
				};
			}
		}
	}
}
