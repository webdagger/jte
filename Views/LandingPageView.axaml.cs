using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;
using Avalonia.Interactivity;
using JTE.Views;
using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using JTE.EpubBuilder;

namespace JTE.Views
{
 
    
  
    public class LandingPage : UserControl

    {

        public LandingPage()
        {

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            
            AvaloniaXamlLoader.Load(this);
        }
        

        private async void Button_OnClick(object? sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Filters.Add(new FileDialogFilter(){  Name = "Json File", Extensions = new List<string> {"json"} });
            var result = await dlg.ShowAsync(MainWindow.Instance);
            var item = result?.FirstOrDefault();
            if (!String.IsNullOrEmpty(item))
            {
                using (StreamReader r = new StreamReader(item))
                {
                    string json = r.ReadToEnd();

                    var build = new BuildEpub(json, item);
                    

                }
                
            }
        }


       
    }
}

