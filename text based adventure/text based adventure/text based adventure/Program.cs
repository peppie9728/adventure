using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text_based_adventure
{
    class Program
    {   
        static void Main(string[] args)
        {
            string cover = "_____________¶____¶___________________________________________¶¶____¶¶_________________________________________¶¶¶___¶¶¶_________________________________________¶¶¶___¶¶¶_________________________________________¶¶___¶¶¶__________________________________________¶¶___¶¶___________________________________________¶¶_¶¶_____________________________________________¶¶¶________________________________________________¶¶_________________________________________________888¶¶____________________________________________¶¶¶_8¶¶___________________________________________¶¶¶¶_88¶___________________________________________¶¶¶8_88¶__________________________________________8¶¶¶8_88¶__________________________________________¶¶¶¶__888_________________________________________¶¶¶¶¶_88¶8_________________________________________¶¶¶¶¶_88¶8_________________________________________¶¶¶¶8_88¶8________________________________________¶¶¶¶¶__88¶_________________________________________¶¶¶¶¶_88¶_________________________________________¶¶¶¶¶¶_88¶_______________________________________¶¶¶¶¶¶¶8_88¶____________________________________8¶88¶88¶¶¶8_¶8¶___________________________________¶¶_8¶¶¶¶¶¶¶_8¶8¶8_________________________________8¶8_8¶¶¶¶¶¶¶8¶¶8¶¶_________________________________¶¶_8¶¶8¶¶¶¶88¶¶8¶¶8____________________________8888¶¶¶¶¶88¶¶8¶88¶¶¶¶8_________________________8888_88¶¶¶¶¶¶¶¶¶¶8¶__¶¶¶_________________________8_8888__¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶________________________8_888_888___888¶¶¶¶¶¶¶¶¶¶________________________8__8¶8__¶¶8_____88¶¶¶¶¶¶8________________________¶¶8888888__8888____8¶¶¶¶¶¶8______________________¶¶¶¶¶¶88¶8___8¶¶88_8¶¶¶¶¶8¶8______________________¶¶¶¶¶¶¶¶¶¶___8¶¶¶¶¶¶¶¶¶¶8__________________________¶¶¶8¶¶¶¶8__888¶¶888¶¶¶¶¶¶__________________________¶¶¶¶888¶8_88¶¶¶¶¶¶¶¶¶¶¶¶¶__________________________¶¶¶¶888¶¶¶¶¶8¶¶¶¶¶¶¶¶¶¶¶¶_________________________¶¶¶¶¶¶¶¶¶¶¶8___¶¶¶¶8¶¶¶¶¶¶_______________________8¶¶¶¶¶¶¶¶¶¶______¶88¶¶¶¶¶¶¶¶8_____________________¶8¶¶¶¶¶¶¶¶8______¶¶¶¶¶¶8888¶¶8___________________8¶8¶¶¶8¶¶¶¶________¶¶¶888__8888¶8________________8¶¶¶¶¶8¶¶¶¶¶________8¶8__88____888¶8_____________88_88¶¶¶¶¶¶¶__________88__888______88¶8__________88______888¶____________8____88________8¶8______";

            StartGame(cover);
            
        }
      

        private static void StartGame(string picture)
        {
            WritePicture(picture,50);
            Console.WriteLine("Welcome to the economical challenged survival game");
            Console.WriteLine("Press ENTER to start the game");
            int start = 0;

            while (start == 0) {
                
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    start = 1;
                }
            }
            

            if (start == 1)
            {

                game _Game = new game();
                //UI _UI = new UI();

                //start our game loop - we keep running this function until the player quits.
                while (_Game.isRunning == true)
                {
                    _Game.Update();
                    //_UI.UiStart(_Game);
                }
                
            }
            else if (start == 2)
            {
                Console.WriteLine(" Goodbye!!!");
            }
        } 
            public static void WritePicture(string picture, int count)
        {
            int length = picture.Length;
            int repeatVert = length / count;
            int startWrite = 0;
            for (int i = 0; i < repeatVert; i++)
            {
                Console.WriteLine(picture.Substring(startWrite, count));
                startWrite = startWrite + count;
            }
        }

    }
}
