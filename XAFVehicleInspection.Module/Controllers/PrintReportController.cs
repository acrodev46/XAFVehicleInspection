using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.ExpressApp.ReportsV2;
using XAFVehicleInspection.Module.BusinessObjects;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Data.Filtering;

namespace XAFVehicleInspection.Module.Controllers
{
    public partial class PrintReportController : ObjectViewController<ListView, Vehicle>
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        public PrintReportController()
        {
            SimpleAction printAction = new SimpleAction(this, "Inspection", PredefinedCategory.Reports);
            printAction.ImageName = "Action_Printing_Print";
            printAction.Execute += delegate (object sender, SimpleActionExecuteEventArgs e)
            {
                IObjectSpace objectSpace = ReportDataProvider.GetReportObjectSpaceProvider(Application.ServiceProvider).CreateObjectSpace(typeof(ReportDataV2));
                IReportDataV2 reportData = objectSpace.FirstOrDefault<ReportDataV2>(data => data.DisplayName == "Inspection");

                List<BaseObject> datasourceList = new List<BaseObject>();
                foreach (var c in View.SelectedObjects)
                {
                    datasourceList.Add((BaseObject)c);
                }
                IEnumerable<Guid> datasourceOids = datasourceList.Select(b => b.Oid);
                CriteriaOperator criteria = new InOperator(nameof(BaseObject.Oid), datasourceOids);

                string handle = ReportDataProvider.GetReportStorage(Application.ServiceProvider).GetReportContainerHandle(reportData);
                ReportServiceController controller = this.Frame.GetController<ReportServiceController>();

                if (controller != null)
                    controller.ShowPreview(handle, criteria);

            };
        }
    }
}
