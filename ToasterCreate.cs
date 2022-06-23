using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace FlyingToaster
{
    class ToasterCreate
    {
        public static void ToasterErstellen(Toaster T1)
        {
            Console.Clear();
            UI.MenuCreate();

            int menu = 4;
            bool menuTrue = false;
            while (!menuTrue)               //Menüführung im Toastermenü//
                                           //////////////////////////////
            {
                Console.ForegroundColor = ConsoleColor.Green;
                UI.writeAt(16, menu, "X");
                Console.ResetColor();

                ConsoleKeyInfo menuKey = Console.ReadKey(true); //Ließt den Key-press ein

                switch (menuKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            if (menu > 4)
                            { UI.writeAt(16, menu, " "); menu -= 2; }

                            break;
                        }

                    case ConsoleKey.DownArrow:
                        {
                            if (menu < 6)
                            { UI.writeAt(16, menu, " "); menu += 2; }

                            break;
                        }

                    case ConsoleKey.Enter:
                        {
                            //Toaster Creation Wizard
                            if (menu == 4) 
                            {
                                ToasterCreationWizard();
                            }
                            //Hauptmenü
                            if (menu == 6)
                            {
                                Program.MainMenu(T1); //Geht zurück ins Hauptmenü
                            }
                            break;
                        }

                }//Switch

            }//While(!menuTrue)
        }//Toaster Erstellen


        //################################################################################################## Toaster Wizard 


        public static void ToasterCreationWizard()  //Toaster Erstellen und Sachen festlegen
        {
            Console.Clear();
            UI.writeAt(10, 1, "###~ Toaster Creation Wizard ~###");

            Console.CursorVisible = true;

            UI.writeAt(10, 4, "Toaster Name: ");    //Toaster Name einlesen
            string temp_toastername = Console.ReadLine();

            if(temp_toastername == "") //Checkt ob ein Name eingegeben wurde
            {
                UI.writeAt(10, 6, "Name kann nicht leer sein  !!");
                
                Thread.Sleep(1000);
                
                ToasterCreationWizard();
            }

            Console.CursorVisible = false;


            //################################################## Anzahl der Schächte auswählen


            int z = 1;
            bool enter = false;
            UI.writeAt(10, 6, "Anzahl der Schächte: <   >");

            while(enter == false)
            {
                Console.SetCursorPosition(33, 6);
                Console.Write(z);

                ConsoleKeyInfo switchkey = Console.ReadKey(true);

                switch (switchkey.Key)
                {
                    case ConsoleKey.LeftArrow:
                        {
                            if (z > 1) { z--; }
                            break;
                        }

                    case ConsoleKey.RightArrow:
                        {
                            if (z < 8) { z++; }
                            break;
                        }

                    case ConsoleKey.Enter:
                        {
                            enter = true; //Beendet die Schleife

                            int temp_toasterschaechte = z; //Legt die Anzahl der Schächte fest

                            break;
                        }
                }//Switch
            }//While 


            //##################################################  Farbe für den Toaster auswählen


            int z1 = 1;
            bool enter1 = false;
            UI.writeAt(10, 8, "Farbe des Toasters: <   >");

            while (enter1 == false)
            {
                Console.ForegroundColor = (ConsoleColor)z1;
                Console.SetCursorPosition(32, 8);
                Console.Write("█");
                Console.ResetColor();

                ConsoleKeyInfo switchkey = Console.ReadKey(true);

                switch (switchkey.Key)
                {
                    case ConsoleKey.LeftArrow:
                        {
                            if (z1 > 0) { z1--; }
                            break;
                        }

                    case ConsoleKey.RightArrow:
                        {
                            if (z1 < 15) { z1++; }
                            break;
                        }

                    case ConsoleKey.Enter:
                        {
                            enter1 = true; //Beendet die Schleife

                            int temp_toasterfarbe = z1;//Legt die Farbe für den Toaster fest

                            break;
                        }
                }//Switch
            }//While 


            //################################################## Wattzahl festlegen für den Toaster


            int z2 = 500;
            bool enter2 = false;
            UI.writeAt(10, 10, "Wattzahl des Toasters: <   >");

            while (enter2 == false)
            {
                Console.SetCursorPosition(10, 10);
                Console.Write("Wattzahl des Toasters: < " + z2 + " >  ");

                ConsoleKeyInfo switchkey = Console.ReadKey(true);

                switch (switchkey.Key)
                {
                    case ConsoleKey.LeftArrow:
                        {
                            if (z2 > 500) { z2-=100; }
                            break;
                        }

                    case ConsoleKey.RightArrow:
                        {
                            if (z2 < 3500) { z2+=100; }
                            break;
                        }

                    case ConsoleKey.Enter:
                        {
                            enter2 = true; //Beendet die Schleife

                            int temp_toasterwatt = z2; //Legt die Wattzahl für den Toaster fest

                            break;
                        }
                }//Switch
            }//While 


            //################################################## Festlegen, ob es ein Superotaster sein soll oder nicht <<


            bool istSuperToaster = false;
            bool enter3 = false;
            UI.writeAt(10, 12, "Temp-Sensor für Supertoaster: <   >");

            while (enter3 == false)
            {
                Console.SetCursorPosition(10, 12);
                Console.Write("Temp-Sensor für Supertoaster: < " + istSuperToaster + " >  ");

                ConsoleKeyInfo switchkey = Console.ReadKey(true);

                switch (switchkey.Key)
                {
                    case ConsoleKey.LeftArrow:
                        {
                            istSuperToaster = false;
                            break;
                        }

                    case ConsoleKey.RightArrow:
                        {
                            istSuperToaster = true;
                            break;
                        }

                    case ConsoleKey.Enter:
                        {
                            enter3 = true; //Beendet die Schleife
                            
                            break;
                        }
                }//Switch
            }//While 


            //################################################## Supertoaster in TXT Datei schreiben


            if (istSuperToaster == true)
            {
                SuperToaster T1 = new SuperToaster(temp_toastername, z1, z, z2, 500); ///SuperToaster Objekt

                string path = @"Toaster";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                StreamWriter sw = new StreamWriter("Toaster\\Toaster.txt", true);

                sw.WriteLine(T1.toaster_Name + ".name=" + T1.toaster_Name);
                sw.WriteLine(T1.toaster_Name + ".isST=TRUE");
                sw.WriteLine(T1.toaster_Name + ".schaechte=" + T1.anzahl_Schaechte);
                sw.WriteLine(T1.toaster_Name + ".farbe=" + T1.toaster_Farbe);
                sw.WriteLine(T1.toaster_Name + ".watt=" + T1.toaster_Watt);
                sw.WriteLine(T1.toaster_Name + ".temp=" + T1.Tempsens);

                sw.Close();

                UI.writeAt(10, 14, "Super-Toaster >" + T1.toaster_Name + "< erstellt  !");

                Thread.Sleep(1000);

                Program.MainMenu(T1);

            }

            //################################################## Toaster in TXT Datei schreiben

            else
            {
                Toaster T1 = new Toaster(temp_toastername, z1, z2, z); ///Toaster Objekt erstellen

                string path = @"Toaster";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                StreamWriter sw = new StreamWriter("Toaster\\Toaster.txt", true);     //Schreibt den Toaster mit den 4 Werten in eine TXT Datei

                sw.WriteLine(T1.toaster_Name + ".name=" + T1.toaster_Name);
                sw.WriteLine(T1.toaster_Name + ".schaechte=" + T1.anzahl_Schaechte);
                sw.WriteLine(T1.toaster_Name + ".farbe=" + T1.toaster_Farbe);
                sw.WriteLine(T1.toaster_Name + ".watt=" + T1.toaster_Watt);

                sw.Close();

                UI.writeAt(10, 14, "Toaster >" + T1.toaster_Name + "< erstellt  !");

                Thread.Sleep(1000);

                Program.MainMenu(T1);
            }
            
        }//ToasterWizard

    }
}
