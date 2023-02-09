using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Markup;
using Microsoft.UI.Xaml.XamlTypeInfo;
using System;

namespace WinUITestBedNet
{
    public class App : Application, IXamlMetadataProvider
    {

        private Window m_window;        
        private XamlControlsXamlMetaDataProvider _xamlMetaDataProvider;

        public void InitializeComponent()
        {
            _xamlMetaDataProvider = new XamlControlsXamlMetaDataProvider();
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

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            Resources.MergedDictionaries.Add(new XamlControlsResources());

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
