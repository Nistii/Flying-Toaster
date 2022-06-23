using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FlyingToaster
{
    class Toaster_Einschalten
    {
        public static void ToasterAn(Toaster T1)
        {
            Console.Clear();

            if (T1 == null)
            {
                UI.writeAt(14, 1, "Es ist kein Toaster vorhanden  !!");
                UI.writeAt(18, 3, "Erstelle einen Toaster !!");
                Thread.Sleep(1000);

                Program.MainMenu(T1);
            }


            //################################################## Anzahl der Toasts in den Toaster
         
            UI.writeAt(6, 2, "Wie viele Toasts sollen getoastet werden ? <   > ");
            Toaster.toast_reintun(T1);

            //################################################## Zeit einstellen für den Toast-Vorgang


            UI.writeAt(6, 4, "Wie lange soll getoastet werden ? <   > ");
            Toaster.toast_zeiteinstellen(T1);


            //##############################################################

            //Hier bitte weiter machen, da fehlt noch was:
            //Man kann noch keinen Toaster auswählen
            //Und die Menüs und der generelle Code aufräumen !!!!


            UI.writeAt(14, 6, "Toaster wird angeschaltet: \n\n      " + T1.anzahl_Toasts + " Toasts bei " + T1.toaster_Watt + " Watt und für " + T1.toaster_Zeit + " 'Zeit'");

            Thread.Sleep(666);

            if (T1.anzahl_Toasts == 0)
            {
                UI.writeAt(11, 12, "Warum willst du 0 Toasts toasten ??? \n                 Versuch's noch einmal...");
                Thread.Sleep(1800);
                ToasterAn(T1);
            }
            else
            {
                Thread.Sleep(1200);
                Toaster.toasten(T1);
            }



            //##############################################################
        }
    }
}
