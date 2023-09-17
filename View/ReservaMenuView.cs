using DesafioHospedagemHotel.Models;

namespace DesafioHospedagemHotel.View
{
    public static class ReservaMenuView
    {

        public static void ReservaMenuListarReserva(List<Reserva> reservas) {
            int inicioListagem = 0;
            int finalListagem = reservas.Count < 5 ? reservas.Count : 5;

            Console.WriteLine("<< LISTAGEM DE RESERVA >>");

            int option = 0;

            do {

                if(option == 1) {
                    inicioListagem = finalListagem;
                    finalListagem = finalListagem + 5 > reservas.Count? reservas.Count : finalListagem + 5;
                } else if(option == 2) {
                    break;
                }

                for (int i = inicioListagem; i < finalListagem; i++)
                {
                    Reserva reserva = reservas[i];
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine($"Reserva Nº {i + 1}");
                    Console.WriteLine($"Dias Reservados: { reserva.DiasReservados }");
                    
                    Console.WriteLine($"Tipo de Suite: {reserva.Suite.TipoSuite}");
                    Console.WriteLine($"Capacidade: {reserva.Suite.Capacidade}");
                    Console.WriteLine($"Valor Diaria: {reserva.Suite.ValorDiaria:C}");

                    Console.WriteLine("Hóspedes:");
                    foreach (Pessoa pessoa in reserva.Hospedes)
                    {
                        Console.WriteLine(pessoa.NomeCompleto);
                    }
                    Console.WriteLine("---------------------------------------------");
                }

                if(finalListagem < reservas.Count) {
                    option = Tools.MenuOptions(new string[] { "1 - Listar Mais 5 items", "2 - Sair" });
                }

            } while(finalListagem < reservas.Count);

            Tools.WaitMessage("Listagem finalisada!");
            
        }

        public static void ReservaMenuCadastroPessoas(List<Pessoa> pessoas) {
            string[] options = new string[] { "1 - Adicionar", "2 - Listar", "3 - Remover", "4 - Voltar"};
            int comand = -1;
            do {
                Console.Clear();
                Console.WriteLine("<< CADASTRO DE RESERVA >>");
                Console.WriteLine(".:Menu Pessoas:.");
                comand = Tools.MenuOptions(options);

                if(comand == 1) {
                    string nome = Tools.PromtInput<string>("Nome: ", "");
                    string sobrenome = Tools.PromtInput<string>("Sobrenome: ", "");
                    pessoas.Add(new Pessoa(nome, sobrenome));
                } else if (comand == 2) {
                    for (int i = 0; i < pessoas.Count; i++)
                    {
                        Pessoa p = pessoas[i];
                        Console.WriteLine($"{i + 1} -> { p.NomeCompleto }");
                    }
                    Tools.WaitMessage("Listagem finalisada!");
                } else if (comand == 3) {
                    int numeroPessoa = Tools.PromtInput<int>("Número da Pessoa: ", 0);

                    if(numeroPessoa > 0 && numeroPessoa <= pessoas.Count) {
                        pessoas.RemoveAt(numeroPessoa - 1);
                        Tools.WaitMessage("Pessoa removida com sucesso!");
                    } else {
                        Tools.WaitMessage("Número de Pessoa inválida!");
                    }
                } else if (comand == 4) {
                    Console.Clear();
                    break;
                }
            } while(comand != 0);
        }

        public static void ReservaMenuCadastrarReserva(List<Suite> suites, List<Reserva> reservas) {
            Console.Clear();
            Console.WriteLine("<< CADASTRO DE RESERVA >>");

            int diasReservados = Tools.PromtInput<int>("Dias Reservados: ", 0);

            int numeroSuite = Tools.PromtInput<int>("Número da Suite: ", 0);
            if(numeroSuite < 0 || numeroSuite > suites.Count) {
                Tools.WaitMessage("Número de Suite inválida!");
                return;
            }

            List<Pessoa> pessoas = new List<Pessoa>();
            ReservaMenuCadastroPessoas(pessoas);
            
            Reserva reserva = new Reserva(diasReservados);
            reserva.CadastrarSuite(suites[numeroSuite - 1]);
            reserva.CadastrarHospedes(pessoas);
            reservas.Add(reserva);

            Console.WriteLine("");
            Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
            Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria():C}");

            Tools.WaitMessage("Reserva cadastrada com sucesso!");
        }

        public static void ReservaMenuRemoverReserva(List<Reserva> reservas) {
            Console.Clear();
            Console.WriteLine("<< REMOVER RESERVA >>");

            int numeroReserva = Tools.PromtInput<int>("Numero da Reserva: ", 0);

            if(numeroReserva > 0 && numeroReserva <= reservas.Count) {
                reservas.RemoveAt(numeroReserva - 1);
                Tools.WaitMessage("Reserva removida com sucesso!");
            } else {
                Tools.WaitMessage("Número de Reserva inválida!");
            }
            
        }
        
        public static void ReservaMenu(List<Suite> suites, List<Reserva> reservas) {
            string[] options = new string[] { "1 - Cadastrar", "2 - Listar", "3 - Remover", "4 - Voltar"};
            int comand = -1;
            do {
                Console.Clear();
                Console.WriteLine(".:Menu Reserva:.");
                comand = Tools.MenuOptions(options);

                if(comand == 1) {
                    ReservaMenuCadastrarReserva(suites, reservas);
                } else if (comand == 2) {
                    ReservaMenuListarReserva(reservas);
                } else if (comand == 3) {
                    ReservaMenuRemoverReserva(reservas);
                } else if (comand == 4) {
                    break;
                }

            } while(comand != 0);

        }

    }
}