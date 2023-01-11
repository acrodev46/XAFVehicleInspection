using System.Drawing.Printing;

namespace XAFVehicleInspection.Module.Reports {
    public partial class Report : DevExpress.XtraReports.UI.XtraReport {
        public Report() {
            InitializeComponent();
        }

        private void Report_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string language = parameterLanguage.Value as string;
            ApplyLocalization(language);
        }
        //void Report_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        //{
        //    string language = parameterLanguage.Value as string;
        //    ApplyLocalization(language);
        //}
    }
}
