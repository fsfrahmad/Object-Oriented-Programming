using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_LAB_05.BL;
using OOP_LAB_05.UI;

namespace OOP_LAB_05.DL
{
    public class DegreeProgramCRUD
    {
        public static List<DegreeProgram> DegreeProgramsList = new List<DegreeProgram>();
        public static DegreeProgram ProgramExists(DegreeProgram NewDegreeProgram)
        {
            foreach (DegreeProgram Degree in DegreeProgramsList)
            {
                if((NewDegreeProgram.title == Degree.title) && (NewDegreeProgram.duration == Degree.duration))
                {
                    return Degree;
                }
            }
            return null;
        }
        public static void AddDegreeProgramToList(DegreeProgram NewDegreeProgram)
        {
            DegreeProgramsList.Add(NewDegreeProgram);
        }
        public static void ViewAllDegreeProgram()
        {
            Console.WriteLine("Available Degree Programs ");
            foreach(DegreeProgram d in DegreeProgramsList)
            {
                Console.WriteLine(d.title);
            }
        }
    }
}
