using DesafioHospedagemHotel.Models;

namespace DesafioHospedagemHotel.View
{
    public static class MainMenuView
    {
        
        public static void MainMenu() {
            List<Suite> suites = new List<Suite>();
            List<Reserva> reservas = new List<Reserva>();

            string[] options = new string[] { "1 - Suite", "2 - Reserva", "3 - Sair"};
            int comand = -1;
            do {
                Console.Clear();
                Console.WriteLine(".:Menu Principal:.");
                comand = Tools.MenuOptions(options);

                if(comand == 1) {
                    SuiteMenuView.SuiteMenu(suites);
                } else if (comand == 2) {
                    ReservaMenuView.ReservaMenu(reservas);
                } else if (comand == 3) {
                    Console.WriteLine("Encerrando o sistema!");
                    break;
                }

            } while(comand != 0);

        }


    }
}