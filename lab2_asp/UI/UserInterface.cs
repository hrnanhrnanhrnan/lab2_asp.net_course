using System;
using System.Collections.Generic;
using System.Text;
using Data.Displayers;
using Data.Handlers;
using Data.Utilities;

namespace lab2_asp.UI
{
    public class UserInterface
    {
        ModelsDisplayer _modelsDisplayer;
        public UserInterface()
        {
            _modelsDisplayer = new ModelsDisplayer();
        }
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
                        _modelsDisplayer.DisplayAllTeachersFromCourse("Programmering 1");
                        break;
                    case 2:
                        //Hämta alla elever + lärare
                        _modelsDisplayer.DisplayAllStudentsWithTeachers();
                        break;
                    case 3:
                        //Hämta alla elever som läser programmering 1 + lärare
                        _modelsDisplayer.DisplayAllStudentsWithTeachersFromCourse("Programmering 1");
                        break;
                    case 4:
                        //Editera från programmering 2 till oop
                        _modelsDisplayer.UpdateCourseName("Programmering 2");
                        break;
                    case 5:
                        //Uppdatera en elevs lärare i programmering 1 från anas till reidar
                        _modelsDisplayer.UpdateTeacherInCourse(1, 1, 2);
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
