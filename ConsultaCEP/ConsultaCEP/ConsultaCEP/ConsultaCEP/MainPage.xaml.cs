using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ConsultaCEP.Servico.Modelo;
using ConsultaCEP.Servico;

namespace ConsultaCEP
{
	public partial class MainPage : ContentPage
	{
        public static String NewLine { get; }
        public MainPage()
		{
			InitializeComponent();

            BOTAO.Clicked += BuscarCEP;
		}

        private void BuscarCEP(object sender, EventArgs args)
        {         
        
            string cep = CEP.Text.Trim();

            if (isValidCEP(cep))
            {
                try
                {
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCep(cep);

                    if (end != null)
                    {
                        RESULT.Text =
                            string.Format("Cep: {5}{6}Cidade: {0} {1}UF: {2}{3}Logradouro: {4}",
                            end.localidade, Environment.NewLine,
                            end.uf, Environment.NewLine,
                            end.logradouro, end.cep, Environment.NewLine);
                    }
                    else
                    {
                        DisplayAlert("ERRO", "CEP não Encontrado!", "OK");
                    }               
                }catch(Exception e)
                {
                    DisplayAlert("ERRO", "AlGO DEU ERRADO, POR FAVOR TENTE MAIS TARDE!", "ok");
                }
            }                       
        }

        private bool isValidCEP(string cep)
        {
            bool valido = true;
            if(cep.Length != 8)
            {
                DisplayAlert("ERRO", "CEP INVALIDO", "OK");
                valido = false;
            }
            int NovoCEP = 0;
            if (!int.TryParse(cep, out NovoCEP))
            { 
                DisplayAlert("ERRO", "O CEP DEVE CONTER APENAS NÚMEROS ", "OK");
                valido = false;
            }
            return valido;            
        }
	}
}
