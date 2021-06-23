using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.Security.Cryptography;
using Login.Model;

namespace Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Principal : ContentPage
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void BtnInsert_Clicked(object sender, EventArgs e)
        {

            
            if ((txtUsername.Text == null) || (txtEmail.Text == null) || (txtPassword.Text == null))
            {
                DisplayAlert("hola Usuario", "Rellene todos los campos", "OK");
            }
            else
            {
                string pass = txtPassword.Text;
                                
                StatusMessage.Text = string.Empty;
                UserRepository.Instancia.AddNewUser(txtUsername.Text, txtEmail.Text, StringHash(pass));
                StatusMessage.Text = UserRepository.Instancia.EstadoMensaje;
            }

            

        }

        private void BtnAllUser_Clicked(object sender, EventArgs e)
        {

            var allusers = UserRepository.Instancia.GetAllUsers();

            userList.ItemsSource = allusers;
            StatusMessage.Text = UserRepository.Instancia.EstadoMensaje;


        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {

        }

        public string StringHash(String input) {

            Console.WriteLine(input);


            SHA512 shaM = new SHA512Managed();
            // Convert the input string to a byte array and compute the hash.
            byte[] data = shaM.ComputeHash(Encoding.UTF8.GetBytes(input));
            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();
            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++) {
                sBuilder.Append(data[i].ToString("x2"));
            }
            // Return the hexadecimal string.
            input = sBuilder.ToString();
            
            
            Console.WriteLine(input);
            return (input);
        }
    }
}
