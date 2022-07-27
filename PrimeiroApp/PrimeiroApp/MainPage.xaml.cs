using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PrimeiroApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        
        }

       

        int Count = 0;
        
        private void Button_Clicked(object sender, EventArgs e)
        {
            Count++;
            ((Button)sender).Text = "Você clicou " + Count.ToString() + " Vezes";
        }

        private void btnVerificar_Clicked(object sender, EventArgs e)
        {
            string texto = $"O nome tem {txtNome.Text.Length} caracteres";
            DisplayAlert("Mensagem", texto, "Ok");     
        }

        private async void btnLimpar_Clicked(object sender, EventArgs e)
        {
            if(await DisplayAlert("Pergunta", "Deseja realmente limpar a tela?", "Yes", "No"))
            {
                txtNome.Text = string.Empty;
                btnCliqueAqui.Text = "Clique Aqui";
                Count = 0;
            }
        }
    }
}
