using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using ConsultaCEP.Servico.Modelo;
using Newtonsoft.Json;


namespace ConsultaCEP.Servico
{
    public class ViaCEPServico
    {
        private static string EnderecoURL = "https://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCep(string cep)
        {
            //adiciona o cep no endereço.
            string NovoEnderecoURL = string.Format(EnderecoURL, cep);
            
            WebClient wc = new WebClient();

            //converte o resultado(json) para string e salva em uma string(conteudo).
            string Conteudo = wc.DownloadString(NovoEnderecoURL);

            //adiciona as informações do (Conteudo) nas variáveis que estão em { Endereco }.
            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);
            if (end.cep == null) return null;

            return end;
        }
    }
}
