using DesafioHospedagemHotel.Models;

namespace DesafioHospedagemHotel.View
{
    public static class ReservaMenuView
    {
        
        public static void ReservaMenu(List<Reserva> reservas) {
            string[] options = new string[] { "1 - Cadastrar", "2 - Listar", "3 - Remover", "4 - Voltar"};
            int comand = -1;
            do {
                Console.Clear();
                Console.WriteLine(".:Menu Reserva:.");
                comand = Tools.MenuOptions(options);

                if(comand == 1) {

                } else if (comand == 2) {

                } else if (comand == 3) {

                } else if (comand == 4) {
                    Console.WriteLine("Encerrando o sistema!");
                    break;
                }

            } while(comand != 0);

        }

    }
}