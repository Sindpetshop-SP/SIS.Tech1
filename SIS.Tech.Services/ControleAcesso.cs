using Newtonsoft.Json;
using SIS.ControleAcesso.Model;
using SIS.Tech.IServices;
using SISFramework.Parameter.DerivedParameter;

namespace SIS.Tech.Services
{
    public class ControleAcesso: IControleAcesso
    {
        private readonly string ENDPOINTLogin = new LocalMachine().LerParametro("SINDPETSHOP", "Configuracoes", "ENDPOINTLogin").Valor;
        private readonly string CONTROLLERLogin = new LocalMachine().LerParametro("SINDPETSHOP", "Configuracoes", "CONTROLLERLogin").Valor;

        private readonly HttpClient _httpClient = null;

        public ControleAcesso()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(ENDPOINTLogin);
        }

        //public static UsuarioSistemaPerfilInfo ObterAcessosCliente(int idSistema, string login, string senha, string ip)
        //{
        //    AutenticacaoClient client = new wcfControleAcesso.AutenticacaoClient();

        //    return client.VerificarLoginUsuario(idSistema, login, senha, ip);
        //}

        public async Task<UsuarioSistemaPerfilInfo> LoginUsuario(int idSistema, string login, string senha, string ip)
        {
            //var retorno = bool.Parse(_configuration.GetSection("MySettings").GetSection("Parameters").GetSection("IsProduction").Value);

            var ACTION = "LoginUsuario";
            var PARAMS = "?codSistema= " + idSistema + "&nmeLoginUsuario=" + login + "&vlrSenhaUsuario=" + senha;

            HttpResponseMessage response = await _httpClient.GetAsync(ENDPOINTLogin + CONTROLLERLogin + ACTION + PARAMS);

            var jsonString = await response.Content.ReadAsStringAsync();

            var jsonObject = JsonConvert.DeserializeObject<UsuarioSistemaPerfilInfo>(jsonString);

            //if (jsonObject != null)
            //{
            //    if (jsonObject.mUsuario.msgErro != null)
            //    {
            //        return null;
            //    }
            //}

            return jsonObject;

        }
    }
}
