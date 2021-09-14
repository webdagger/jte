using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

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
    }
}