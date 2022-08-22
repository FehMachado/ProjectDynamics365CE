using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Tooling.Connector;
using Microsoft.Xrm.Sdk;

namespace MyWork1
{
    public class ConnectionFactory
    {
        public static IOrganizationService GetService()
        {

            try
            {
                string email = "";
                string password = "";
                Console.WriteLine("Bem vindo ao Work1!");
                Console.WriteLine("Para prosseguir, por favor informe seu email utilizado no dynamics365: ");
                email = Console.ReadLine();
                Console.WriteLine("Por favor, digite a sua senha para realizar conexão ao serviço:");
                password = Console.ReadLine();


                string connectionstring =
                    "AuthType=OAuth;" +
                    $"Username={email};" +
                    $"Password={password};" +
                    "Url=https://org1e5e578f.crm2.dynamics.com;" +
                    "AppId=e022a66c-3e20-43ce-898d-25044e02dd5f;" +
                    "RedirectUri=app://58145B91-0c36-4500-8554-080854F2AC97;";

                CrmServiceClient crmServiceClient = new CrmServiceClient(connectionstring);
                if (!string.IsNullOrEmpty(crmServiceClient.CurrentAccessToken))
                {
                    Console.WriteLine("Você foi logado com sucesso!");
                }
                return crmServiceClient.OrganizationWebProxyClient;

            } catch (Exception e)
            {
                
                return null;
            }    

        }
    }
}
