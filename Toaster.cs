using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FlyingToaster
{
    class Toaster
    {
        private string toaster_name;    //Nur der Name
        private int toaster_farbe;      //Nur die Farbe als Int
        private int toaster_zeit;       //Wie Lange getoastet wird
        private int toaster_watt;       //Wie viel Watt der Toaster zieht (mit der Dauer kann das lustige ergebnisse haben)

        private int toast_zustand;      //Wie "fertig" ist der Toast, oder verbrannt

        private int anzahl_schaechte;   //Wieviele Toasts man einlegen kann
        private int anzahl_toasts;      //Wieviele Toasts eingelegt werden


        //##################################################################################################


        ///Get-Set Methoden
        public string toaster_Name { get { return toaster_name; } set { toaster_name = value; } }
        public int toaster_Farbe { get { return toaster_farbe; } set { toaster_farbe = value; } }
        public int toaster_Zeit { get { return toaster_zeit; } set { toaster_zeit = value;} }
        public int toaster_Watt { get { return toaster_watt; } set { toaster_watt = value;} }
        public int toast_Zustand { get { return toast_zustand; } set { toast_zustand = value; } }
        public int anzahl_Schaechte { get { return anzahl_schaechte; } set { anzahl_schaechte = value; } }
        public int anzahl_Toasts { get { return anzahl_toasts; } set { anzahl_toasts = value; } }


        //################################################################################################## Toast reintun


        public static void toast_reintun(Toaster T1)
        {
            int z = 0;
            bool enter = false;
            while (enter == false)
            {
                Console.SetCursorPosition(6, 2);
                Console.Write("Wie viele Toasts sollen getoastet werden ? < " + z + " > ");

                ConsoleKeyInfo switchkey = Console.ReadKey(true);

                switch (switchkey.Key)
                {
                    case ConsoleKey.LeftArrow:
                        {
                            if (z > 0) { z--; }
                            break;
                        }

                    case ConsoleKey.RightArrow:
                        {
                            if (z < T1.anzahl_Schaechte) { z++; }
                            break;
                        }

                    case ConsoleKey.Enter:
                        {
                            enter = true; //Beendet die Schleife

                            T1.anzahl_Toasts = z;

                            break;
                        }
                }//Switch
            }//While 
        }


        //################################################################################################## Toasten


        public static void toasten(Toaster T1)
        {
            //Toaster Watt und die Zeit werden verrechnet und durch 1000 geteilt um einen Zustandswert für den Toast zu bekommen
            T1.toast_Zustand = (T1.toaster_Watt * T1.toaster_Zeit) / 1000;

            Console.Clear();
            UI.ToasterSprite(T1);
            Thread.Sleep(200);
            UI.ToastEinlegenAnim(T1);
            Thread.Sleep(555);

            if(T1.toaster_Zeit == 0)
            {
                T1.toast_Zustand = 0;
                toast_auswerfen(T1);
            }

            UI.Toaster_smoke_anim(T1);
            UI.Toaster_smoke_anim(T1);

            if (T1 is SuperToaster)
            {
                int temp = SuperToaster.Temp_Messen(T1);    //Temperatur messen falls T1 der Klasse "SuperToaster" angehört

                if (temp > 500)
                {
                    UI.writeAt(10, 2, "ERROR!  Der Toaster ist zu heiß geworden!");
                    UI.writeAt(18, 4, "Toastvorgang abgebrochen!");

                    Thread.Sleep(1500);
                    Program.MainMenu(T1);
                }
            }

            UI.Toaster_smoke_anim(T1);
            UI.Toaster_smoke_anim(T1);

            T1.toast_Zustand = (T1.toaster_Watt * T1.toaster_Zeit) / 1000;   //Basierend auf der Annahme, das ein normaler Toaster 1000 Watt hat !

            toast_auswerfen(T1);

        }


        //################################################################################################## Toast auswerfen


        public static void toast_auswerfen(Toaster T1)
        {
            Console.Clear();

            //Easter-Egg, der Toaster kann explodieren, wenn es kein SuperToaster ist, die Wattzahl über 3000 und für mehr als 30 Sek. getoastet wird
            if (T1 is not SuperToaster & T1.toaster_Watt > 2800 & T1.toaster_Zeit > 30)
            {
                UI.Toaster_Explode_Anim();

                UI.writeAt(16, 2, "Der Toaster ist explodiert...");
                UI.writeAt(8, 4, "Du musst dir einen neuen Toaster erstellen.");
                T1 = null;

                UI.writeAt(14, 8, "Drücke >ENTER< um fortzufahren"); //Zurück ins Menü
                Console.ReadLine();
                Program.MainMenu(T1);
            }

            UI.Toaster_Auswerfen_Anim(T1);
            Console.Clear();
            UI.ToasterSprite(T1);

            if(T1.toast_Zustand == 0)                              //Wenn der Toast ungetoastet ist
            {
                UI.writeAt(16, 2, "Der Toast ist ungetoastet.");
                UI.writeAt(5, 4, "Warum kann man den Toaster auf 0 Zeit einstellen?");                
            }
            else if(T1.toast_Zustand > 1 & T1.toast_Zustand <= 15) //Leicht getoastet
            {
                UI.writeAt(14, 2, "Der Toast ist leicht getoastet.");
            }
            else if(T1.toast_Zustand > 15 & T1.toast_Zustand < 30) //Stark getoastet
            {
                UI.writeAt(14, 2, "Der Toast ist stark getoastet.");
            }
            else if(T1.toast_Zustand >= 30)                        //Verbrannt
            {
                UI.writeAt(17, 2, "Der Toast ist verbrannt.");
            }
            
            UI.writeAt(14, 8, "Drücke >ENTER< um fortzufahren"); //Zurück ins Menü
            Console.ReadLine();
            Program.MainMenu(T1);
        }


        //################################################################################################## Zeit einstellen


        public static void toast_zeiteinstellen(Toaster T1)
        {
            int z1 = 0;
            bool enter1 = false;

            while (enter1 == false)
            {
                Console.SetCursorPosition(6, 4);
                Console.Write("Wie lange soll getoastet werden ? < " + z1 + " > ");

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
                            if (z1 < 35) { z1++; }
                            break;
                        }

                    case ConsoleKey.Enter:
                        {
                            enter1 = true; //Beendet die Schleife

                            T1.toaster_Zeit = z1; //Legt die Zeit fest, wie lange getoastet werden soll

                            break;
                        }
                }//Switch
            }//While 
        }


        //################################################################################################## Konstruktor für den Toaster


        public Toaster(string Name, int Farbe, int Watt, int Schaechte)
        {
            toaster_Name = Name;
            toaster_Farbe = Farbe;
            toaster_Watt = Watt;
            anzahl_Schaechte = Schaechte;
        }

        public Toaster() //Ein leerer Konstruktor für die Main() Methode (Um Probleme zu umgehen)
        {

        }

    }


    //################################################################################################## Super Toaster


    class SuperToaster : Toaster
    {
        private int tempsens;
        public int Tempsens { get { return tempsens; } set { tempsens = value; } }

        public static int Temp_Messen(Toaster T1)
        {
            int temperatur = (T1.toaster_Watt / 60) * T1.toaster_Zeit;
            return temperatur;
        }

        public SuperToaster(string Name, int Farbe, int Schaechte, int Watt, int Temperatur) : base(Name, Farbe,  Watt, Schaechte)
        {
            Tempsens = Temperatur;
        }
    }
}
