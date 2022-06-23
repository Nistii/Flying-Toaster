using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace FlyingToaster
{
    internal class Program
    {
        public static void Main() //Die Main legt hier nur ein leeres Toasterobjekt an, da Main keine Übergaben von Objekten an nimmt, warum auch immer?!
        {

            Console.SetWindowSize(60, 25);
            Console.SetBufferSize(60, 25);

            Toaster T1 = new Toaster();
            T1 = null;
            MainMenu(T1);
        }//Main




        public static void MainMenu(Toaster T1)
        {
            Console.Clear();

            Console.SetWindowSize(60, 25);
            Console.SetBufferSize(60, 25);

            //##################################################################################################

            UI.Prompt("\n       ###~ Toaster Builder 9000 Deluxe Edition ~###");

            UI.MainMenu(); //Zeigt das Menü an

            if (T1 == null)
            {
                UI.writeAt(7, 13, "Toaster: Kein Toaster");
            }
            else
            {
                UI.writeAt(7, 13, "Toaster: " + T1.toaster_Name);
            }

            Console.CursorVisible = false; //Versteckt den blinkenden balken "cursor" 

            int menu = 4;
            bool menuTrue = false;
            while (!menuTrue)               //Menüführung im Hauptmenü//
                                            ////////////////////////////
            {
                Console.ForegroundColor = ConsoleColor.Green;
                UI.writeAt(17, menu, "X");                      //Macht nur das Kreuz für die Auswahl Grün
                Console.ResetColor();

                ConsoleKeyInfo menuKey = Console.ReadKey(true); //Ließt den Key-press ein

                switch (menuKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            if (menu > 4)
                            { UI.writeAt(17, menu, " "); menu -= 2; }

                            break;
                        }

                    //##################################################################################################

                    case ConsoleKey.DownArrow:
                        {
                            if (menu < 10)
                            { UI.writeAt(17, menu, " "); menu += 2; }

                            break;
                        }

                    //##################################################################################################

                    case ConsoleKey.Enter:
                        {
                            //Toaster Einschalten//
                            if (menu == 4) 
                            {
                                Toaster_Einschalten.ToasterAn(T1);
                            }


                            //Toaster Erstellen//
                            if (menu == 6)
                            {
                                ToasterCreate.ToasterErstellen(T1); //Geht ins Menü um einen Toaster zu erstellen
                            }


                            //Toaster Auswählen//
                            if (menu == 8) 
                            {
                                ToasterAuswahl.ToasterAuswahl_menu(T1);
                            }


                            //Exit//
                            if (menu == 10)
                            {
                                UI.writeAt(1, 1, "                                                                     ");
                                UI.writeAt(16, 4, "                                     ");
                                UI.writeAt(16, 6, "                                     ");
                                UI.writeAt(16, 8, "                                     ");
                                UI.writeAt(16, 10, "                                    ");
                                UI.writeAt(6, 13, "                                       ");

                                Environment.Exit(0);       //Eiskalt aus dem Programm geworfen                          
                            }

                            break;
                        }

                }//Switch

            }//While(!menuTrue)
        }
    }
}