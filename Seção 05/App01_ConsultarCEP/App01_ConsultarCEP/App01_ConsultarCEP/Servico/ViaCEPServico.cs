using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App01_ConsultarCEP.Servico.Modelo;
using Newtonsoft.Json;

namespace App01_ConsultarCEP.Servico
{
    public class ViaCEPServico
    {
        private static string EnderecoURL = "http://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            string NovoEnderecoURL = string.Format(EnderecoURL, cep); //Recebe a nova URL com o CEP desejado (o cep substitui {0} na URL)
            WebClient wc = new WebClient();
            string Conteudo = wc.DownloadString(NovoEnderecoURL); //Faz o download da informação da nova URL e armazena
            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo); //Converte a informação de Conteudo e retorna um objeto do tipo Endereco

            if(end.cep == null) return null;

            return end; //Retorna a informação da Web convertida para o tipo Endereco
        }
    }
}
