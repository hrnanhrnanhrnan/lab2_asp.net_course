using System;
using Data.Displayers;
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

        //starting point of the application, method that calls the DisplayMenuAndGetUserChoice method from the Utilities and gets the user input 
        // and runs different methods from the modelDisplayer instance depending on the user choices
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
                // get the user input through the method and send in the array of menu choices as parameter and then display it and run switch case on the user input
                int userInput = UtilityMethods.DisplayMenuAndGetUserChoice(menuOptions);
                switch (userInput)
                {
                    case 1:
                        _modelsDisplayer.DisplayAllTeachersFromCourse("Programmering 1");
                        break;
                    case 2:
                        _modelsDisplayer.DisplayAllStudentsWithTeachers();
                        break;
                    case 3:
                        _modelsDisplayer.DisplayAllStudentsWithTeachersFromCourse("Programmering 1");
                        break;
                    case 4:
                        _modelsDisplayer.UpdateCourseName("Programmering 2");
                        break;
                    case 5:
                        _modelsDisplayer.UpdateTeacherInCourse(1, 1, 2);
                        break;
                    case 6:
                        //Exit the application
                        Console.WriteLine("Nu avslutas programmet, tryck på enter för att avsluta programmet!");
                        Console.ReadLine();
                        run = false;
                        break;
                }
            }
        }
    }
}
