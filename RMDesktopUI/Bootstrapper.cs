using Caliburn.Micro;
using RMDesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RMDesktopUI
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            // Start ShellViewModel on startup, which will then launch the ShellView.xaml as our base view
            // (based upon CaliburnMicro wiring those two things together),
            // since we deleted MainWindow.xaml and adjusted App.xaml
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}
