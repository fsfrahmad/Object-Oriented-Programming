using OOP_PD4.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOP_PD4
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<Ship> Ships = new List<Ship>();
            while(true)
            {
                Console.Clear();
                int option = Menu();
                if(option == 1)
                {
                    Ship newShip = AddShip();
                    AddShipToList(Ships, newShip);
                }
                else if(option == 2)
                {
                    string SerialNumber;
                    Console.WriteLine("Enter Serial Number of Ship: ");
                    SerialNumber = Console.ReadLine();
                    Ship NewShip = new Ship(SerialNumber);
                    Ship IsAvailable = NewShip.ShipExists(Ships);
                    if (IsAvailable == null)
                    {
                        Console.WriteLine("Ship does not Exists!!!!!!");
                        Console.WriteLine("Presss Any key to continue");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Ship Longitude: " + IsAvailable.Longitude.Degree + "\u00b0" + IsAvailable.Longitude.Minute + IsAvailable.Longitude.Direction);
                        Console.WriteLine("Ship Latitude: " + IsAvailable.Latitude.Degree + "\u00b0" + IsAvailable.Latitude.Minute + IsAvailable.Latitude.Direction);
                    }
                }
                else if(option == 3)
                {
                    int LongitudeDegree;
                    float LongitudeMinute;
                    char LongitudeDirection;
                    int LatitudeDegree;
                    float LatitudeMinute;
                    char LatitudeDirection;
                Longitude:

                    Console.WriteLine("Enter Ship Longitude(0-90): ");
                    Console.WriteLine("Enter Longitude Degree:");
                    LongitudeDegree = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Longitude Minutes(0-59.9):");
                    LongitudeMinute = float.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Longitude Direction:(N/S) ");
                    LongitudeDirection = char.Parse(Console.ReadLine());

                    if ((LongitudeMinute > 59.9 || LongitudeDegree > 90) || (LongitudeMinute < 0 || LongitudeDegree < 0) || (LongitudeMinute > 59.9 && LongitudeDegree > 89) || (LongitudeDirection != 'N' && LongitudeDirection != 'S'))
                    {
                        Console.WriteLine("Enter Valid Longitude!!!!");
                        Console.WriteLine("Again");
                        goto Longitude;
                    }

                Latitude:

                    Console.WriteLine("Enter Ship Longitude: ");
                    Console.WriteLine("Enter Latitude Degree(0-180):");
                    LatitudeDegree = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Latitude Minutes(0-59.9):");
                    LatitudeMinute = float.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Latitude Direction(W/E) :");
                    LatitudeDirection = char.Parse(Console.ReadLine());

                    if ((LatitudeMinute > 59.9 || LatitudeDegree > 180) || (LatitudeMinute < 0 || LatitudeDegree < 0) || (LongitudeMinute > 59.9 || LongitudeDegree > 179) || (LatitudeDirection != 'W' && LatitudeDirection != 'E'))
                    {
                        Console.WriteLine("Enter Valid Longitude!!!!");
                        Console.WriteLine("Again");
                        goto Latitude;
                    }

                    Angle Longitude = new Angle(LongitudeDirection, LongitudeMinute, LongitudeDirection);
                    Angle Latitude = new Angle(LatitudeDegree, LatitudeMinute, LatitudeDirection);
                    Ship NewShip = new Ship(Longitude, Latitude);

                    Ship IsAvailable = NewShip.FindShipNumberByDirection(Ships);
                    if (IsAvailable == null)
                    {
                        Console.WriteLine("Ship does not Exists!!!!!!");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Ship Serial Number is: " + IsAvailable.Number);
                    }
                }
                else if(option == 4)
                {

                    int LongitudeDegree;
                    float LongitudeMinute;
                    char LongitudeDirection;
                    int LatitudeDegree;
                    float LatitudeMinute;
                    char LatitudeDirection;
                    string SerialNumber;
                    Console.WriteLine("Enter Serial Number of Ship: ");
                    SerialNumber = Console.ReadLine();
                    int ShipListIndex = FindShip(Ships,SerialNumber);
                    if(ShipListIndex != -1)
                    {
                        Console.WriteLine("Ship does not Exists!!!!!!");
                    }
                    else
                    {
                    Longitude:

                        Console.WriteLine("Enter Ship Longitude(0-90): ");
                        Console.WriteLine("Enter Longitude Degree:");
                        LongitudeDegree = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Longitude Minutes(0-59.9):");
                        LongitudeMinute = float.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Longitude Direction:(N/S) ");
                        LongitudeDirection = char.Parse(Console.ReadLine());

                        if ((LongitudeMinute > 59.9 || LongitudeDegree > 90) || (LongitudeMinute < 0 || LongitudeDegree < 0) || (LongitudeMinute > 59.9 && LongitudeDegree > 89) || (LongitudeDirection != 'N' && LongitudeDirection != 'S'))
                        {
                            Console.WriteLine("Enter Valid Longitude!!!!");
                            Console.WriteLine("Again");
                            goto Longitude;
                        }

                    Latitude:

                        Console.WriteLine("Enter Ship Latitude: ");
                        Console.WriteLine("Enter Latitude Degree(0-180):");
                        LatitudeDegree = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Latitude Minutes(0-59.9):");
                        LatitudeMinute = float.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Latitude Direction(W/E) :");
                        LatitudeDirection = char.Parse(Console.ReadLine());

                        if ((LatitudeMinute > 59.9 || LatitudeDegree > 180) || (LatitudeMinute < 0 || LatitudeDegree < 0) || (LongitudeMinute > 59.9 || LongitudeDegree > 179) || (LatitudeDirection != 'W' && LatitudeDirection != 'E'))
                        {
                            Console.WriteLine("Enter Valid Longitude!!!!");
                            Console.WriteLine("Again");
                            goto Latitude;
                        }

                        Ships[ShipListIndex].Longitude.Degree = LongitudeDegree;
                        Ships[ShipListIndex].Longitude.Minute = LongitudeMinute;
                        Ships[ShipListIndex].Longitude.Direction = LongitudeDirection;
                        Ships[ShipListIndex].Latitude.Degree = LatitudeDegree;
                        Ships[ShipListIndex].Latitude.Minute = LatitudeMinute;
                        Ships[ShipListIndex].Latitude.Direction = LatitudeDirection;
                        Console.WriteLine("Ship INFo Updated!");
                    }
                }
                else if(option == 5)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Enter Valid Option!!!!");
                }
                Console.WriteLine("Presss Any key to continue");
                Console.ReadKey();
            }
        }
        public static Ship AddShip()
        {
            string SerialNumber;
            int LongitudeDegree;
            float LongitudeMinute;
            char LongitudeDirection;
            int LatitudeDegree;
            float LatitudeMinute;
            char LatitudeDirection;

            Console.WriteLine("Enter Serial Number of Ship: ");
            SerialNumber = Console.ReadLine();

            Longitude:

            Console.WriteLine("Enter Ship Longitude: ");
            Console.WriteLine("Enter Longitude Degree(0-90):");
            LongitudeDegree = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Longitude Minutes(0-59.9):");
            LongitudeMinute = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Longitude Direction(N/S) : ");
            LongitudeDirection = char.Parse(Console.ReadLine());

            if((LongitudeMinute > 59.9 || LongitudeDegree > 90) || (LongitudeMinute < 0 || LongitudeDegree < 0) || (LongitudeMinute > 59.9 && LongitudeDegree > 89) || (LongitudeDirection != 'N' && LongitudeDirection != 'S'))
            {
                Console.WriteLine("Enter Valid Longitude!!!!");
                Console.WriteLine("Again");
                goto Longitude;
            }

            Latitude:

            Console.WriteLine("Enter Ship Longitude: ");
            Console.WriteLine("Enter Latitude Degree: ");
            LatitudeDegree = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Latitude Minutes(0-59.9): ");
            LatitudeMinute = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Latitude Direction(W/E) : ");
            LatitudeDirection = char.Parse(Console.ReadLine());

            if ((LatitudeMinute > 59.9 || LatitudeDegree > 180) || (LatitudeMinute < 0 || LatitudeDegree < 0) || (LongitudeMinute > 59.9 || LongitudeDegree > 179) || (LatitudeDirection != 'W' && LatitudeDirection != 'E'))
            {
                Console.WriteLine("Enter Valid Longitude!!!!");
                Console.WriteLine("Again");
                goto Latitude;
            }

            Angle Longitude = new Angle(LongitudeDirection, LongitudeMinute, LongitudeDirection);
            Angle Latitude = new Angle(LatitudeDegree, LatitudeMinute, LatitudeDirection);
            Ship NewShip = new Ship(SerialNumber, Longitude, Latitude);
            return NewShip;
        }
        public static int Menu()
        {
            int option;
            Console.WriteLine("1. Add Ship");
            Console.WriteLine("2. View Ship Position");
            Console.WriteLine("3. View Ship Serial Number");
            Console.WriteLine("4. Change Ship Position");
            Console.WriteLine("5. Exit");
            option = int.Parse(Console.ReadLine());
            return option;
        }
        public static void AddShipToList(List<Ship> Ships, Ship NewShip)
        {
            Ship IsAvailable = NewShip.ShipExists(Ships);
            if(IsAvailable != null)
            {
                Console.WriteLine("Ship Already Exists!!!!!!");
                Console.WriteLine("Presss Any key to continue");
                Console.ReadKey();
            }
            else
            {
                Ships.Add(NewShip);
                Console.WriteLine("Ship Added Successfully!!!!");
                Console.WriteLine("Presss Any key to continue");
                Console.ReadKey();
            }
        }
        public static int FindShip(List<Ship> Ships,string SerialNumber)
        {
            int FoundIndex = -1;
            for(int i=0; i < Ships.Count;i++)
            {
                if(SerialNumber == Ships[i].Number)
                {
                    FoundIndex = i;
                    break;
                }
            }
            return FoundIndex;
        }
    }
}
