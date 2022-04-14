using lab2_asp.UI;

namespace lab2_asp
{
    class Program
    {
        static void Main(string[] args)
        {
            //---- RUN THIS METHODS TO POPULATE THE DATABASE ------

            //Data.Utilities.UtilityMethods.CreateClasses();
            //Data.Utilities.UtilityMethods.CreateStudents();
            //Data.Utilities.UtilityMethods.CreateTeachers();
            //Data.Utilities.UtilityMethods.CreateCourses();
            //Data.Utilities.UtilityMethods.CreateClassCourses();
            //Data.Utilities.UtilityMethods.CreateStudentCourses();
            //Data.Utilities.UtilityMethods.CreateTeacherCourses();

            //-----------------------------------------------------


            //---- RUN THIS TO RUN THE APPLICATION ----
            var userInterface = new UserInterface();
            userInterface.RunUserInterface();
        }
    }
}