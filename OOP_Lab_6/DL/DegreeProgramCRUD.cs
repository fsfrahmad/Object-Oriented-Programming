using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_LAB_05.BL;
using OOP_LAB_05.UI;
using System.IO;

namespace OOP_LAB_05.DL
{
    public class DegreeProgramCRUD
    {
        public static List<DegreeProgram> DegreeProgramsList = new List<DegreeProgram>();
        public static DegreeProgram ProgramExists(DegreeProgram NewDegreeProgram)
        {
            foreach (DegreeProgram Degree in DegreeProgramsList)
            {
                if ((NewDegreeProgram.title == Degree.title) && (NewDegreeProgram.duration == Degree.duration))
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
            foreach (DegreeProgram d in DegreeProgramsList)
            {
                Console.WriteLine(d.title);
            }
        }
        public static void StoreIntoFile(string path, DegreeProgram d)
        {
            StreamWriter NewFile = new StreamWriter(path, true);
            string SubjectNames = "";
            for (int x = 0; x < d.DegreeSubjects.Count - 1; x++)
            {
                SubjectNames = SubjectNames + d.DegreeSubjects[x].Code + ";";
            }
            SubjectNames = SubjectNames + d.DegreeSubjects[d.DegreeSubjects.Count - 1].Code;
            NewFile.WriteLine(d.title + "," + d.duration + "," + d.seats + "," + SubjectNames);
            NewFile.Flush();
            NewFile.Close();
        }
        public static bool readFromFile(string path)
        {
            StreamReader f = new StreamReader(path); string record;
            if (File.Exists(path))
            {
                while ((record = f.ReadLine()) != null)
                {
                    string[] splittedRecord = record.Split(',');
                    string degreeName = splittedRecord[0];
                    string degreeDuration = splittedRecord[1];
                    int seats = int.Parse(splittedRecord[2]);
                    string[] splittedRecordForSubject = splittedRecord[3].Split(';');
                    DegreeProgram d = new DegreeProgram(degreeName, degreeDuration, seats);
                    for (int x = 0; x < splittedRecordForSubject.Length; x++)
                    {
                        Subject s = SubjectCRUD.SubjectExists(splittedRecordForSubject[x]);
                        if (s != null)
                        {
                            d.AddSubjectToList(s);
                        }
                        AddDegreeProgramToList(d);
                        
                    }
                }
                f.Close();
                return true;
            }
            else
            {
                    f.Close();
                    return false;
            }
        }
    }
}
