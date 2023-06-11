using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_LAB_05.BL;
using OOP_LAB_05.DL;

namespace OOP_LAB_05.UI
{
    public class DegreeProgramUI
    {
        public static DegreeProgram AddDegreeProgram()
        {
            Console.WriteLine("Enter Degree program title: ");
            string title = Console.ReadLine();
            Console.WriteLine("Enter Degree program Duration: ");
            string duration = Console.ReadLine();
            DegreeProgram NewDegreeProgram = new DegreeProgram(title, duration);
            DegreeProgram FoundDegreeProgram = DegreeProgramCRUD.ProgramExists(NewDegreeProgram);
            if(FoundDegreeProgram != null)
            {
                Console.WriteLine("Program Already Exists!!!");
                Console.WriteLine("Press any key to continue.....");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Enter number of Seats in Degree Program : ");
                NewDegreeProgram.seats = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter No of Subjects in Degree Program : ");
                NewDegreeProgram.NoOfSubjects = int.Parse(Console.ReadLine());
                Console.ReadKey();
                for(int i = 0; i < NewDegreeProgram.NoOfSubjects; i++)
                {
                    Console.WriteLine("Subject no." + (i + 1));
                    Console.WriteLine("Enter Subject Code: ");
                    string Code = Console.ReadLine();
                    Console.WriteLine("Enter Subject Credit Hour: ");
                    int CreditHour = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Subject Type: ");
                    string SubjectType = Console.ReadLine();
                    Console.WriteLine("Enter Subject Fee: ");
                    int SubjectFee = int.Parse(Console.ReadLine());
                    Subject NewSubject = new Subject(Code, CreditHour, SubjectType, SubjectFee);
                    NewDegreeProgram.DegreeSubjects.Add(NewSubject); 
                }
            }

            return NewDegreeProgram;
        }
    }
}
