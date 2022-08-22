using System;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;

namespace MyWork1
{
    public class Program
    {
       
        
        static void Main(string[] args)
        {
            try
            {


                IOrganizationService service = ConnectionFactory.GetService();
                if(service == null)
                {
                    Console.WriteLine("Erro ao conectar, verifique suas credenciais!");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                string[] arrayGames = new string[5] { "1", "2", "3", "4", "5" };
                var Name_account = "";
                long Telefone_account = 0;
                var Email_account = "";
                int Idade_account = 0;
                int GeneroGames_account = 0;
                char EscolhaCreditos = 'n';
                decimal totalcreditos_account = 0;
                decimal totaldegames_account = 0;
                var Cidade_account = "";
                var Estado_account = "";
                var Pais_account = "";
                char CriarContato = 'n';
                Regex sem_epaco = new Regex("[ \t\n\x0B\f\r]");
                bool temEspaco = false;

                string primeironomeContact = "";
                string sobrenomeContact = "";
                string ocupacaoContact = "";

                Console.WriteLine("Por favor informe o nome da Conta: ");
                Name_account = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(Name_account))
                {
                    Console.WriteLine("Atenção! Não é permitido campo com valores nulo ou branco! ");
                    Console.WriteLine("Por favor informe o nome da Conta:");
                    Name_account = Console.ReadLine();
                }
                Console.WriteLine("Informe a IdContato com 32 dígitos");;
                var value = Console.ReadLine();

                //while (string.IsNullOrWhiteSpace(value))
                //{
                //    Console.WriteLine("Atenção! Não é permitido campo com valores nulo ou branco! ");
                //    Console.WriteLine("Informe a IdContato com 28 dígitos");
                //    value = Console.ReadLine();
                //}
                while (value.Length < 32)
                {
                    Console.WriteLine("Atenção! O IdContato não pode ser menor que 32 dígitos: ");
                    Console.WriteLine("Informe a IdContato com 32 dígitos");
                    value = Console.ReadLine();
                }
               
                temEspaco = sem_epaco.IsMatch(value);
                while(temEspaco == true)
                {
                    Console.WriteLine("Não pode conter espaço em brancos.");
                    Console.WriteLine("Informe a IdContato com 32 dígitos");
                    value = Console.ReadLine();
                    temEspaco = sem_epaco.IsMatch(value);

                }
                value = value.Substring(0, 8) + '-' + value.Substring(8, 4) + '-' + value.Substring(12, 4) + '-' + value.Substring(16, 4) + '-' + value.Substring(20, 12);

                Console.WriteLine("Digite o seu Email");
                Email_account = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(Email_account))
                {
                    Console.WriteLine("Atenção! Não é permitido campo com valores nulo ou branco! ");
                    Console.WriteLine("Digite o seu Email");
                    Email_account = Console.ReadLine();
                }
                Console.WriteLine("Digite o seu Telefone no formato dd999999999 (apenas números)");
                
                while (!long.TryParse(Console.ReadLine(), out Telefone_account))
                {
                    Console.WriteLine("Insira apenas números inteiros");
                    Console.WriteLine("Digite o seu Telefone no formato dd999999999 (apenas números)");
                    Telefone_account = Console.Read();
                }
                var tel1 = Convert.ToString(Telefone_account);
                tel1 = tel1.Substring(0, 2) + '-' + tel1.Substring(2, 5) + '-' + tel1.Substring(7, 4);
            

                Console.WriteLine("Digite sua Idade: ");
                while (!int.TryParse(Console.ReadLine(), out Idade_account))
                {
                    Console.WriteLine("Insira apenas números inteiros");
                    Console.WriteLine("Informe a sua Idade: ");
                }

                Console.WriteLine("Informe Seu Genero de Games favorito: \r\n 1-FPS \r\n 2-MOBA \r\n 3-Esports \r\n 4-Simuladores \r\n 5-RPG/MMORPG ");
                while (!int.TryParse(Console.ReadLine(), out GeneroGames_account))
                {
                    Console.WriteLine("Insira apenas números");
                    Console.WriteLine("Informe Seu Genero de Games favorito: \r\n 1-FPS \r\n 2-MOBA \r\n 3-Sports \r\n 4-Simulator \r\n 5-RPG/MMORPG ");
                }
                while (GeneroGames_account > 5)
                {
                    Console.WriteLine("Opção inválida, por favor digite uma das opções abaixos");
                    Console.WriteLine("Informe Seu Genero de Games favorito: \r\n 1-FPS \r\n 2-MOBA \r\n 3-Sports \r\n 4-Simulator \r\n 5-RPG/MMORPG ");
                    GeneroGames_account = Convert.ToInt32(Console.ReadLine());

                }
                Console.WriteLine("Voce gostaria de adquirir Créditos? ");
                EscolhaCreditos = Convert.ToChar(Console.ReadLine());
                EscolhaCreditos = char.ToUpper(EscolhaCreditos);
                if (EscolhaCreditos == 'S')
                {
                    Console.WriteLine("Digite a quantidade de Créditos desejada: ");
                    totalcreditos_account = Convert.ToDecimal(Console.ReadLine());
                }
                Console.WriteLine("Quantos jogos você comprou nesse mês? ");
                while (!decimal.TryParse(Console.ReadLine(), out totaldegames_account))
                {
                    Console.WriteLine("Insira apenas números");
                    Console.WriteLine("Quantos jogos você comprou nesse mês? ");
                }
                Console.WriteLine("Informe à sua Cidade: ");
                Cidade_account = Console.ReadLine();
                Console.WriteLine("Informe o Estado: ");
                Estado_account = Console.ReadLine();
                Console.WriteLine("Informe o País que você reside: ");
                Pais_account = Console.ReadLine();
                var ValorOptional = 0;

                switch (GeneroGames_account)
                {
                    case 1:
                        ValorOptional = 809920000;
                        break;
                    case 2:
                        ValorOptional = 809920001;
                        break;
                    case 3:
                        ValorOptional = 809920002;
                        break;
                    case 4:
                        ValorOptional = 809920003;
                        break;
                    case 5:
                        ValorOptional = 809920004;
                        break;
                    default:
                        break;
                }


                Entity conta = new Entity("account");
                conta["name"] = Name_account;
                conta["telephone1"] = tel1;
                conta["work1_idade"] = Idade_account;
                conta["emailaddress1"] = Email_account;
                conta["address1_city"] = Cidade_account;
                conta["address1_stateorprovince"] = Estado_account;
                conta["address1_country"] = Pais_account;
                conta["work1_totaldecoins"] = totalcreditos_account;
                conta["work1_totaldegames"] = totaldegames_account;
                conta["work1_generopreferido"] = new OptionSetValue(ValorOptional);
                Guid Value = Guid.Parse(value);
                conta["primarycontactid"] = new EntityReference("contact", Value);
                Guid accountId = service.Create(conta);

                Console.WriteLine("Você deseja criar um contato para essa conta? (S/N)");
                CriarContato = Convert.ToChar(Console.ReadLine());
                CriarContato = char.ToUpper(CriarContato);

                while (CriarContato != 'S' && CriarContato != 'N')
                {
                    Console.WriteLine("Opção inválida! Informe os valores 'S' ou 'N'");
                    Console.WriteLine("Você deseja criar um contato para essa conta? (S/N");
                    CriarContato = Convert.ToChar(Console.ReadLine());
                    CriarContato = char.ToUpper(CriarContato);
                }
                if (CriarContato == 'S')
                {
                    Console.WriteLine("Por favor informe seu nome: ");
                    primeironomeContact = Console.ReadLine();
                    while (string.IsNullOrWhiteSpace(primeironomeContact))
                    {
                        Console.WriteLine("Atenção! Não é permitido campo com valores nulo ou branco! ");
                        Console.WriteLine("Por favor informe o seu primeiro nome:");
                        primeironomeContact = Console.ReadLine();

                    }
                    Console.WriteLine("Por favor informe o seu sobrenome: ");
                    sobrenomeContact = Console.ReadLine();
                    while (string.IsNullOrWhiteSpace(sobrenomeContact))
                    {
                        Console.WriteLine("Atenção! Não é permitido campo com valores nulo ou branco! ");
                        Console.WriteLine("Por favor informe o seu sobrenome:");
                        sobrenomeContact = Console.ReadLine();

                    }
                    Console.WriteLine("Por favor informe a sua ocupação: ");
                    ocupacaoContact = Console.ReadLine();
                    while (string.IsNullOrWhiteSpace(ocupacaoContact))
                    {
                        Console.WriteLine("Atenção! Não é permitido campo com valores nulo ou branco! ");
                        Console.WriteLine("Por favor informe a sua ocupação:");
                        ocupacaoContact = Console.ReadLine();

                    }
                    Entity contato = new Entity("contact");
                    contato["firstname"] = primeironomeContact;
                    contato["lastname"] = sobrenomeContact;
                    contato["jobtitle"] = ocupacaoContact;
                    contato["parentcustomerid"] = new EntityReference("account", accountId);
                    service.Create(contato);
                    Environment.Exit(0);

                }
                else
                {
                    Environment.Exit(0);
                }

            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }

        }
    }
}
