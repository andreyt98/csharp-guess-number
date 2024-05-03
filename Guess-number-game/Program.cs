using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guess_number_game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inicial = "";
            int val =-1;
            do
            {
                Console.WriteLine("Indique el valor incial");
                 inicial = Console.ReadLine();
                

            } while (string.IsNullOrEmpty(inicial) || !int.TryParse(inicial,out val) );

            string final = "";
            do
            {
                Console.WriteLine("Indique el valor final");
                final = Console.ReadLine();

                while(string.Compare(final, inicial) < 0 || string.Compare(final, inicial) == 0)
                {
                    Console.WriteLine("el valor final debe mayor que el inicial");
                    final = Console.ReadLine();
                }
            } while (string.IsNullOrEmpty(final) || !int.TryParse(final, out val)) ;


            int CHANCES = 5;

            List<int> numbers = new List<int>();
           
            for (int i = int.Parse(inicial); i <= int.Parse(final); i++)
            {                
                numbers.Add(i);               
            }

            Console.WriteLine("\n\n");
            Console.WriteLine("LISTA DE ELEMENTOS PARA EL JUEGO\n");

            foreach (int numero in numbers)
            {
                Console.WriteLine(numero);
            }

            // Generar un índice aleatorio dentro de los numeros de la lista para que dependiendo del
            //indice seleccione el numero que esta en ese indice
            Random rnd = new Random();
            int randomIndex = rnd.Next(0, numbers.Count());

           // Console.WriteLine($"\n\nel indice seleccionado es numbers[{randomIndex}] por lo que el numero a adivinar es {numbers[randomIndex]}\n\n");

            string play = "";

            while(CHANCES > 0)
            {
                do
                {
                    Console.WriteLine($"Indique su jugada, debe ser un numero del  {inicial}  al {final} " );
                    Console.WriteLine($"LE QUEDAN {CHANCES} OPORTUNIDADES ");

                    play = Console.ReadLine();

                    while (string.Compare(play, inicial) < 0 || string.Compare(play, final) > 0)
                    {
                        if(!int.TryParse(play, out val))
                        {
                          Console.WriteLine($"debe escribir un numero no una letra");
                        }
                        else
                        {

                        Console.WriteLine($"el numero debe estar dentro del rango,{inicial} al {final} ");
                        }
                        play = Console.ReadLine();
                    }
                } while (string.IsNullOrEmpty(play) || !int.TryParse(play, out val));

                if(int.Parse(play) == numbers[randomIndex])
                {
                    CHANCES = 0;
                    Console.WriteLine("\n\nADIVINO EL NUMERO - U WIN!! :)\n\n");
                }
                else
                {
                    CHANCES -= 1;

                    if(CHANCES == 0)
                    {
                        Console.WriteLine("\n\nNO ADIVINO EL NUMERO - GAME OVER\n");
                    }

                }
            }

        }
    }
}
