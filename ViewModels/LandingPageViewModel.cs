using System.Collections.Generic;
using System.Reactive;
using ReactiveUI;
using Avalonia.Controls;
using JTE.Views;

namespace JTE.ViewModels
{
    public class LandingPageViewModel : ReactiveObject
    {
        public LandingPageViewModel()
        {
            OpenFileDialogCommand = ReactiveCommand.Create((() =>
            {
                new OpenFileDialog()
                {
                    Title = "Select a Novel Scraper Chapters.json file",
                    Filters = GetFilters()
                }.ShowAsync(MainWindow.Instance);
            }));
        }

        public ReactiveCommand<Unit, Unit> OpenFileDialogCommand { get;  }

        List<FileDialogFilter> GetFilters()
        {
            return new List<FileDialogFilter>
            {
                new FileDialogFilter
                {
                    Name = "Json File", Extensions = new List<string> {"json"}
                }
            };
        }
    }
}