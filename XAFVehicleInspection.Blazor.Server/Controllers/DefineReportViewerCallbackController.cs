using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.ReportsV2.Blazor;
using DevExpress.ExpressApp.ReportsV2.Blazor.Components.Models;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.Web.WebDocumentViewer.DataContracts;
using DevExpress.XtraReports.Web.WebDocumentViewer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XAFVehicleInspection.Blazor.Server.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class DefineReportViewerCallbackController : ViewController<DetailView>
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public DefineReportViewerCallbackController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
            TargetViewId = ReportsBlazorModuleV2.ReportViewerDetailViewName;
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
            View.CustomizeViewItemControl<ReportViewerViewItem>(this, CustomizeReportViewerViewItem);
        }
        private void CustomizeReportViewerViewItem(ReportViewerViewItem reportViewerViewItem)
        {
            ReportViewerViewItem.DxDocumentViewerAdapter adapter = (ReportViewerViewItem.DxDocumentViewerAdapter)reportViewerViewItem.Control;
            DxDocumentViewerCallbacksModel callbacks = adapter.CallbacksModel;
            callbacks.CustomizeMenuActions = "onCustomizeMenuActions";
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }

    public class CustomDocumentOperationService : DocumentOperationService
    {
        public override bool CanPerformOperation(DocumentOperationRequest request)
        {
            return request.CustomData == "customOperation";
        }
        public override DocumentOperationResponse PerformOperation(DocumentOperationRequest request,
            PrintingSystemBase initialPrintingSystem, PrintingSystemBase printingSystemWithEditingFields)
        {
            // place your code here
            return new DocumentOperationResponse();
        }
    }
}
