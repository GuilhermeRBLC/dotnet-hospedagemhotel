namespace DesafioHospedagemHotel
{
    public static class Tools
    {

        public static int MenuOptions(string[] options) {
            int comand = -1;

            do {
                
                foreach (string item in options)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Informe a operação: ");

                if(!int.TryParse(Console.ReadLine(), out comand) || (comand < 1 && comand > options.Length))
                {
                    comand = -1;
                }

                if(comand == -1)
                {
                    Console.Clear();
                    Console.WriteLine("Comando inválido! Tente novamente.");
                }

            } while(comand == -1);

            return comand;
        }

        public static T PromtInput<T>(string promt, T defaultValue) {
            string? input = null;
            T value = defaultValue;

            do {
                Console.Write(promt);
                input = Console.ReadLine();
                if(input == null || (input != null && input.Length == 0)) {
                    Console.WriteLine("A entrada não pode ser vazia!");
                } else {
                    try
                    {
                        value = (T)Convert.ChangeType(input, typeof(T));
                        break;
                    }
                    catch (System.Exception)
                    {
                        Console.WriteLine("Entrada inválida!");
                    }
                }
            } while(true);
            
            return value;
        }

        public static void WaitMessage(string message) {
            Console.WriteLine(message);
            Console.WriteLine("Pressione ENTER para continuar!");
            Console.ReadLine();
        }

    }
}