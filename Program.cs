using ConsoleApp1;
using static System.Net.Mime.MediaTypeNames;
using System;
using System.Runtime.Versioning;

namespace graphic
{
    class Program
    {
        static void /*💚💀*/ Main(string[] args) // i love useless comments ❤️
        {
            ConsoleHelper.SetCurrentFont("Cascadia Mono SemiBold", 13);
            const int Width = 100; // standart is Width = 100; Height = 70
            const int Height = 70; // better dont touch it

            ConsoleSetSettings();
            Graphic Graphic = new Graphic();
            Rules Rules = new Rules();
            ReadingFiles ReadingFiles = new ReadingFiles();

            Rules.SetValues(Width, Height);
            Graphic.SetValues(Width, Height);
            ReadingFiles.SetValues(Width, Height);
            Rules.MakingFeld();

            while (true)
            {
                Rules.next();
                Graphic.Draw(Rules.List);
                blyat(); //comment if you love speeding
            }

            static void ConsoleSetSettings()
            {
                ConsoleHelper.SetCurrentFont("Cascadia mono SemiBold", 13);
                Console.SetWindowSize(Width * 2 - 2, Height - 2);
                Console.SetBufferSize(Width * 2 - 2, Height - 2); // linux users I feel sorry for you
            }

            void blyat()
            {
                string phrase = Console.ReadLine(); 
                if (phrase != "")
                {
                    Phrase_is(phrase);
                    blyat();
                }
            }
            void Phrase_is(string phrase) // i think i should create a new class
            {
                if (phrase == "help") Phrase_help();
                if (phrase == "feld.clear") Phrase_feldclear();
                if (phrase == "load") Phrase_load();
                if (phrase == "save") Phrase_save();
                if (phrase == "helphelp") Phrase_helphelp();
                if (phrase == "feld.restart" || phrase == "feld.remake") Phrase_feldrestart();
            }
            void Phrase_help()
            {
                Console.WriteLine("feld.clear\nsave\nload\n\"helphelp\" for more help\nfeld.restart == feld.remake\n");
            }
            void Phrase_feldclear()
            {
                Rules.Clear();
                Graphic.Draw(Rules.List);
            }
            void Phrase_save()
            {
                ReadingFiles.Save(Rules.List);
            }
            void Phrase_load()
            {
                Console.WriteLine("print file name(without \".txt\") or \"exit\" for exit");
                string phrase = Console.ReadLine();
                if (phrase != "exit")
                {
                    Rules.List = ReadingFiles.Reading(Rules.List,phrase);
                    Graphic.Draw(Rules.List);
                }
            }
            void Phrase_helphelp()
            {
                string help = ":green_heart:"+/*💚💀*/":skull:";
                Random rnd = new Random();
                if (rnd.Next(0, 5) != 0)
                    Console.WriteLine("no help for YOU");
                else Console.WriteLine(help);
            }
            void Phrase_feldrestart()
            {
                Rules.Remakefeld();
                Graphic.Draw(Rules.List);
            }
        }
    }
}