using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace multipage_application
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class helloPage : ContentPage
    {
        public helloPage()
        {
            InitializeComponent();
        }

        public async void SayHelloButton_OnClicked(object sender, EventArgs e)
        {
            var name = NameEntry.Text;
            await DisplayAlert("Greeting", $"Hello {name}!!","G'day");
        }
    }
}
