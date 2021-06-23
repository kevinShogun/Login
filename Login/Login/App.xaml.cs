using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Login.Model;

namespace Login
{
    public partial class App : Application
    {
        public App(string filename)
        {
            InitializeComponent();

            UserRepository.Inicializador(filename);

            MainPage = new Login.Principal();
        }


        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
