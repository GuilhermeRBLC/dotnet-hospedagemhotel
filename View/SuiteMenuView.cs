using DesafioHospedagemHotel.Models;

namespace DesafioHospedagemHotel.View
{
    public static class SuiteMenuView
    {

        public static void SuiteMenuListarSuite(List<Suite> suites) {
            int inicioListagem = 0;
            int finalListagem = suites.Count < 10 ? suites.Count : 10;

            Console.WriteLine("<< LISTAGEM DE SUITE >>");

            do {

                for (int i = inicioListagem; i < finalListagem; i++)
                {
                    Suite suite = suites[i];
                    Console.WriteLine($"\nSuite Nº {i + 1}");
                    Console.WriteLine($"Tipo de Suite: {suite.TipoSuite}");
                    Console.WriteLine($"Capacidade: {suite.Capacidade}");
                    Console.WriteLine($"Valor Diaria: {suite.ValorDiaria:C}");
                }

                if(finalListagem < suites.Count) {
                    int option = Tools.MenuOptions(new string[] { "1 - Listar Mais 10 items", "2 - Sair" });
                    if(option == 1) {
                        inicioListagem = finalListagem;
                        finalListagem = finalListagem + 10 > suites.Count? suites.Count : finalListagem + 10;
                    } else {
                        break;
                    }
                }

            } while(finalListagem < suites.Count);

            Tools.WaitMessage("Listagem finalisada!");
            
        }

        public static void SuiteMenuCadastrarSuite(List<Suite> suites) {
            Console.Clear();
            Console.WriteLine("<< CADASTRO DE SUITE >>");

            string tipoSuite = Tools.PromtInput<string>("Tipo de Suite: ", "");
            int capacidade = Tools.PromtInput<int>("Capacidade: ", 0);
            decimal valorDiaria = Tools.PromtInput<decimal>("Valor Diaria: ", 0M);
            
            Suite suite = new Suite(tipoSuite, capacidade, valorDiaria);
            suites.Add(suite);

            Tools.WaitMessage("Suite cadastrada com sucesso!");
        }

        public static void SuiteMenuRemoverSuite(List<Suite> suites) {
            Console.Clear();
            Console.WriteLine("<< REMOVER SUITE >>");

            int numeroSuite = Tools.PromtInput<int>("Numero da Suite: ", 0);

            if(numeroSuite > 0 && numeroSuite <= suites.Count) {
                suites.RemoveAt(numeroSuite - 1);
                Tools.WaitMessage("Suite removida com sucesso!");
            } else {
                Tools.WaitMessage("Numero de Suite inválida!");
            }
            
        }

        public static void SuiteMenu(List<Suite> suites) {
            string[] options = new string[] { "1 - Cadastrar", "2 - Listar", "3 - Remover", "4 - Voltar"};
            int comand = -1;
            do {
                Console.Clear();
                Console.WriteLine(".:Menu Suite:.");
                comand = Tools.MenuOptions(options);

                if(comand == 1) {
                    SuiteMenuCadastrarSuite(suites);
                } else if (comand == 2) {
                    SuiteMenuListarSuite(suites);
                } else if (comand == 3) {
                    SuiteMenuRemoverSuite(suites);
                } else if (comand == 4) {
                    Console.WriteLine("Encerrando o sistema!");
                    break;
                }

            } while(comand != 0);

        }

    }
}