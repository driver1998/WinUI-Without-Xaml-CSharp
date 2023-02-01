using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.WebUI;

namespace WinUITestBedNet
{
    public sealed class MainWindow : Window
    {
        private Button MyButton;
        public void InitializeComponent()
        {
            MyButton = new Button
            {
                Content = "Click Me",
            };
            MyButton.Click += myButton_Click;

            this.Content = new StackPanel
            {
                Orientation = Orientation.Vertical,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Children =
                {
                    new TextBlock { Text = "Hello World" },
                    MyButton,
                    new TextBox(),
                    new RatingControl(),
                    new ColorPicker(),
                    new DatePicker()
                }
            };
        }

        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            MyButton.Content = "Clicked";
        }
    }
}
