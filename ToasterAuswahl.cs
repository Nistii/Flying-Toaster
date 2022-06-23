using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FlyingToaster
{
    class ToasterAuswahl
    {
        public static void ToasterAuswahl_menu(Toaster T1)
        {
            Console.Clear();

            UI.writeAt(16, 2, "###~ Toaster Auswählen ~###\n\n\n");

            try
            {
                StreamReader sr_test = new StreamReader("Toaster\\Toaster.txt");  //Ließt die Textdatei aus
                sr_test.Close();
            }
            catch (Exception)
            {
                Console.Clear();

                Console.WriteLine("\n  Keine Toaster.txt Datei gefunden! ");
                Console.WriteLine("\n  Erstelle zuerst einen Toaster !");
                Console.WriteLine("\n\n  Drücke <ENTER> um fortzufahren");
                Console.ReadLine();
                
                Program.MainMenu(T1);
            }
            
            StreamReader sr = new StreamReader("Toaster\\Toaster.txt");  //Ließt die Textdatei aus

            string[] reader = sr.ReadToEnd().Split('\n'); //Splittet den String bei jeder neuen Zeile

            List<string> Liste = new List<string> { };

            int Items = 0;

            foreach (string item in reader)       //Schreibt nur die Namen aus der Textdatei raus um nacher die Menüführung zu vereinfachen 
            {
                if (item.Contains(".name"))
                {
                    int index = item.LastIndexOf(".");
                    string _item = item.Substring(0, index);
                    UI.Prompt("    [   ] - " + _item + "\n");

                    Liste.Add(_item);
                    Items++;
                }
            }

            Console.CursorVisible = false; //Versteckt den blinkenden balken "cursor" 

            int menu = 5;
            bool menuTrue = false;
            while (!menuTrue)               //Menüführung im Hauptmenü//
                                            ////////////////////////////
            {
                Console.ForegroundColor = ConsoleColor.Green;
                UI.writeAt(6, menu, "X");                      //Macht nur das Kreuz für die Auswahl Grün
                Console.ResetColor();

                ConsoleKeyInfo menuKey = Console.ReadKey(true); //Ließt den Key-press ein

                switch (menuKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            if (menu > 5)
                            { UI.writeAt(6, menu, " "); menu -= 1; }

                            break;
                        }

                    //##################################################################################################

                    case ConsoleKey.DownArrow:
                        {
                            if (menu < Items+4)
                            { UI.writeAt(6, menu, " "); menu += 1; }

                            break;
                        }

                    //##################################################################################################

                    case ConsoleKey.Enter:
                        {
                            string t_name = Liste.ElementAt(menu-5);  //Ließt die Liste aus, an der Stelle, wo der Cursor grade ist

                            bool isST = false;

                            int item_Farbe = 0;
                            int item_Schaechte = 0;
                            int item_Watt = 0;
                            int item_Temp = 0;

                            foreach (string item in reader)       
                            {
                                if (item.Contains(t_name + ".isST="))
                                {
                                    int index_Supertoaster = item.IndexOf("isST=");
                                    string item_supertoaster = item.Substring(index_Supertoaster+5);
                                    isST = true;
                                    ///Console.WriteLine("\n\n" + item_supertoaster);
                                }
                                if(item.Contains(t_name + ".schaechte="))
                                {
                                    int index_Schaechte = item.IndexOf("schaechte=");
                                    item_Schaechte = Convert.ToInt32(item.Substring(index_Schaechte + 10));
                                    ///Console.WriteLine(item_Schaechte);
                                }
                                if (item.Contains(t_name + ".farbe="))
                                {
                                    int index_Farbe = item.IndexOf("farbe=");
                                    item_Farbe = Convert.ToInt32(item.Substring(index_Farbe + 6));
                                    ///Console.WriteLine(item_Farbe);
                                }
                                if (item.Contains(t_name + ".watt="))
                                {
                                    int index_Watt = item.IndexOf("watt=");
                                    item_Watt = Convert.ToInt32(item.Substring(index_Watt + 5));
                                    ///Console.WriteLine(item_Watt);
                                }
                                if (item.Contains(t_name + ".temp="))
                                {
                                    int index_Temp = item.IndexOf("temp=");
                                    item_Temp = Convert.ToInt32(item.Substring(index_Temp + 5));
                                    ///Console.WriteLine(item_Temp);
                                }
                            }

                            if(isST == true)  
                            {
                                T1 = new SuperToaster(t_name, item_Farbe, item_Schaechte, item_Watt, item_Temp);
                            }
                            else if(isST == false)
                            {
                                T1 = new Toaster(t_name, item_Farbe, item_Watt, item_Schaechte);
                            }

                            sr.Close();

                            UI.writeAt(20, 3, "Toaster Ausgewählt !!");
                            System.Threading.Thread.Sleep(1000);

                            Program.MainMenu(T1);

                            break;
                        }
                }//Switch
            }//While(!menuTrue)
            Console.ReadLine();
        }
    }
}
