using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Markup;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using Microsoft.UI.Xaml.XamlTypeInfo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;

namespace WinUITestBedNet
{
    public class App : Application, IXamlMetadataProvider
    {

        private Window m_window;
        private bool _contentLoaded = false;
        private XamlControlsXamlMetaDataProvider _xamlMetaDataProvider;

        public void InitializeComponent()
        {
            if (_contentLoaded)
                return;

            _contentLoaded = true;
            _xamlMetaDataProvider = new XamlControlsXamlMetaDataProvider();

            global::System.Uri resourceLocator = new global::System.Uri("ms-appx:///App.xaml");
            global::Microsoft.UI.Xaml.Application.LoadComponent(this, resourceLocator);

        }

        public IXamlType GetXamlType(Type type)
        {
            return _xamlMetaDataProvider.GetXamlType(type);
        }

        public IXamlType GetXamlType(string fullName)
        {
            return _xamlMetaDataProvider.GetXamlType(fullName);
        }

        public XmlnsDefinition[] GetXmlnsDefinitions()
        {
            return _xamlMetaDataProvider.GetXmlnsDefinitions();
        }
        public App()
        {
            this.InitializeComponent();
        }

        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            m_window = new MainWindow();
            m_window.Activate();
        }

        public static void Main(string[] args)
        {
            WinRT.ComWrappersSupport.InitializeComWrappers();
            global::Microsoft.UI.Xaml.Application.Start((p) => {
                var context = new global::Microsoft.UI.Dispatching.DispatcherQueueSynchronizationContext(
                    global::Microsoft.UI.Dispatching.DispatcherQueue.GetForCurrentThread());
                global::System.Threading.SynchronizationContext.SetSynchronizationContext(context);
                new App();
            });
        }

    }
}
