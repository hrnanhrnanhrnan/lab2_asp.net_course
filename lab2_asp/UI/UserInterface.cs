using System;
using System.Collections.Generic;
using System.Text;
using Data.Utilities;

namespace lab2_asp.UI
{
    public class UserInterface
    {
        public void RunUserInterface()
        {
            var menuOptions = new string[] { "Hämta alla lärare som undervisar i 'programmering 1'", 
                "Hämta alla elever med deras lärare", 
                "Hämta alla elever som läser 'programmering 1' med deras lärare ", 
                "Editera ett ämne från 'programmering 2' till 'OOP'", 
                "Uppdatera en elevs lärare i 'programmering 1' från Anas till Reidar", 
                "Avsluta"};
            bool run = true;
            while (run)
            {
                int userInput = UtilityMethods.DisplayMenuAndGetUserChoice(menuOptions);
                switch (userInput)
                {
                    case 1:
                        //Hämta alla lärare
                        break;
                    case 2:
                        //Hämta alla elever + lärare
                        break;
                    case 3:
                        //Hämta alla elever som läser programmering 1 + lärare
                        break;
                    case 4:
                        //Editera från programmering 2 till oop
                        break;
                    case 5:
                        //Uppdatera en elevs lärare i programmering 1 från anas till reidar
                        break;
                    case 6:
                        //avsluta
                        Console.WriteLine("Nu avslutas programmet, tryck på enter för att avsluta programmet!");
                        Console.ReadLine();
                        run = false;
                        break;
                }
            }
        }
    }
}
