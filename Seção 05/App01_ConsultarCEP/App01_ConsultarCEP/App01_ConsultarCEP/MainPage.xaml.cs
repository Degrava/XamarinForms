using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCEP.Servico.Modelo;
using App01_ConsultarCEP.Servico;

namespace App01_ConsultarCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += BuscarCEP;


        }

        private void BuscarCEP(object sender, EventArgs args)
        {
            //TODO - Validações
            string cep = CEP.Text.Trim();


            if (isValidCEP(cep))
            {
                try
                {
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);
                    if(end != null)
                    {
                        RESULTADO.Text = string.Format("Endereço: {0} de {1} {2}, {3}", end.logradouro, end.bairro, end.localidade, end.uf);
                    }
                    else
                    {
                        DisplayAlert("ERRO", "O endereço não foi encontrado para o CEP informado: " + cep, "OK");
                    }
                }
                catch (Exception e)
                {
                    DisplayAlert("ERRO CRITÍCO", e.Message, "OK");
                }
            }

        }

        private bool isValidCEP(string cep)
        {
            bool valido = true;

            if(cep.Length != 8)
            {
                DisplayAlert("ERRO", "CEP inválido! O CEP deve contar 8 caracteres.", "OK");
                valido = false;
            }
            int NovoCep = 0;
            if(!int.TryParse(cep, out NovoCep))
            {
                DisplayAlert("ERRO", "CEP inválido! O CEP deve ser composto apenas por números.", "OK");
                valido = false;
            }

            return valido;
        }
    }
}
