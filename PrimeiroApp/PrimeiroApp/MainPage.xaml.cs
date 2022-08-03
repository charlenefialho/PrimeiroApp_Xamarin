using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Globalization;

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
            if (await DisplayAlert("Pergunta", "Deseja realmente limpar a tela?", "Yes", "No"))
            {
                txtNome.Text = string.Empty;
                btnCliqueAqui.Text = "Clique Aqui";
                Count = 0;
            }
        }

        private void btnTrocar_Clicked(object sender, EventArgs e)
        {

            Random rnd = new Random();

            fundo.BackgroundColor = Color.FromRgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));

        }

        private async void btnInformarDataNascimento_Clicked(object sender, EventArgs e)
        {
            try
            {
                string dataDigitada = await DisplayPromptAsync("Info", "Digite a data de nascimento", "Ok");
                DateTime dataConvertida;
                bool converteu = DateTime.TryParse(dataDigitada, new CultureInfo("pt-BR"), DateTimeStyles.None, out dataConvertida);

                //if(!converteu) ! -> .NAO.
                if (converteu == false)
                {
                    throw new Exception("Esta data não é valida");
                }
                else
                {
                    //convercao explicita
                    lblDataNascimento.Text = string.Format("{0:dd/MM/yyyy}", dataConvertida);
                    int diasVividos = (int)DateTime.Now.Subtract(dataConvertida).TotalDays;
                    await DisplayAlert("Info", $"você já viveu {diasVividos} dias.", "Ok");
                     
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message + ex.InnerException, "Ok");
            }
        }

        private async void btnOpcoes_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(lblDataNascimento.Text))
                    throw new Exception("Informe a data de nascimento");
                else
                {
                    //DateTime dtNascimento = Convert.ToDateTime(lblDataNascimento.Text);
                    DateTime dtNascimento = Convert.ToDateTime(lblDataNascimento.Text, new CultureInfo("pt-BR"));

                    string resposta = await
                        DisplayActionSheet("Selecionar uma opção:",
                        "Cancelar",
                        "Voltar",
                        "Saber o dia da semana",
                        "Saber o dia do mês",
                        "Saber o dia do ano");

                    if(resposta == "Saber o dia da semana")
                    {
                        string diaSemana = String.Empty;

                        switch(dtNascimento.DayOfWeek)
                        {
                            case DayOfWeek.Friday:
                                diaSemana = "Sexta";
                                break;
                            case DayOfWeek.Monday:
                                diaSemana = "Segunda";
                                break;
                            case DayOfWeek.Saturday:
                                diaSemana = "Sábado";
                                break;
                            case DayOfWeek.Tuesday:
                                diaSemana = "Terça";
                                break;
                            case DayOfWeek.Sunday:
                                diaSemana = "Domingo";
                                break;
                            case DayOfWeek.Wednesday:
                                diaSemana = "Quarta";
                                break;
                            case DayOfWeek.Thursday:
                                diaSemana = "Quinta";
                                break;

                            
                        }
                        string msg = $"Você nasceu no(a) {diaSemana}";
                        await DisplayAlert("Info", msg, "Ok");
                    }

                    else if (resposta == "Saber o dia do mês")
                    {
                        string msg = $"Você nasceu no(a) {dtNascimento.Day}° dia do mês";
                        await DisplayAlert("Info", msg, "Ok");
                    }

                    else if(resposta == "Saber o dia do ano")
                    {
                        string msg = $"Você nasceu no {dtNascimento.DayOfYear}° dia do ano";
                        await DisplayAlert("Info", msg, "Ok");
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message + ex.InnerException, "Ok");
            }

        }
    }
}
