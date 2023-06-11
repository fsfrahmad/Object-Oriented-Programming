using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab_03.BL
{
    class students
    {
        public students()
        {
            sname = "Saad";
            matricmarks = 1100F;
            fscmarks = 1100F;
            ecatmarks = 400F;
            aggregate = 100;
        }
        public students(string n)
        {
            sname = n;
        }
        public students(string sname, float matricmarks, float fscmarks, float ecatmarks, float aggregate)
        {
            this.sname = sname;
            this.matricmarks = matricmarks;
            this.fscmarks = fscmarks;
            this.ecatmarks = ecatmarks;
            this.aggregate = aggregate;
        }
        public string sname;
        public float matricmarks;
        public float fscmarks;
        public float ecatmarks;
        public float aggregate;
    }
    class clockType
    {
        public clockType()
        {
            hours = 0;
            minutes = 0;
            seconds = 0;
        }
        public clockType(int hours)
        {
            this.hours = hours;
        }
        public clockType(int hours, int minutes)
        {
            this.hours = hours;
            this.minutes = minutes;
        }
        public clockType(int hours, int minutes, int seconds)
        {
            this.hours = hours;
            this.minutes = minutes;
            this.seconds = seconds;
        }
        public void incrementSeconds()
        {
            seconds++;
        }
        public void incrementminutes()
        {
            minutes++;
        }
        public void incrementHours()
        {
            hours++;
        }
        public void PrintTime()
        {
            Console.WriteLine("Hours : " + hours + " Minutes : " + minutes + " Seconds : " + seconds);
        }
        public bool IsEqual(int h, int m, int s)
        {
            if (hours == h && minutes == m && seconds == s)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsEqual(clockType temp)
        {
            if (hours == temp.hours && minutes == temp.minutes && seconds == temp.seconds)
            {
                return true;
            }    
            else
            {
                return false;
            }
        }
        public clockType CalculateElapsedTime()
        {
            clockType ElapsedTime = new clockType();
            ElapsedTime.hours = hours - 0;
            ElapsedTime.minutes = minutes - 0;
            ElapsedTime.seconds = seconds - 0;
            return ElapsedTime;
        }
        public clockType CalculateRemainingTime()
        {
            clockType RemainingTime = new clockType(24,0,0);
            if(seconds > RemainingTime.seconds)
            {
                if(minutes > RemainingTime.minutes)
                {
                    RemainingTime.hours--;
                    RemainingTime.minutes = 60;
                    RemainingTime.minutes--;
                    RemainingTime.seconds = 60;
                    RemainingTime.hours = RemainingTime.hours - hours;
                    RemainingTime.minutes = RemainingTime.minutes - minutes;
                    RemainingTime.seconds = RemainingTime.seconds - seconds;
                }
                else
                {
                    RemainingTime.minutes--;
                    RemainingTime.seconds = 60;
                    RemainingTime.hours = RemainingTime.hours - hours;
                    RemainingTime.minutes = RemainingTime.minutes - minutes;
                    RemainingTime.seconds = RemainingTime.seconds - seconds;
                }
            }
            else
            {
                if (minutes > RemainingTime.minutes)
                {
                    RemainingTime.hours--;
                    RemainingTime.minutes = 60;
                    RemainingTime.hours = RemainingTime.hours - hours;
                    RemainingTime.minutes = RemainingTime.minutes - minutes;
                    RemainingTime.seconds = RemainingTime.seconds - seconds;
                }
                else
                {
                    RemainingTime.hours = RemainingTime.hours - hours;
                    RemainingTime.minutes = RemainingTime.minutes - minutes;
                    RemainingTime.seconds = RemainingTime.seconds - seconds;
                }
            }
            return RemainingTime;
        }
        public clockType CalculateDifference(clockType Time)
        {
            clockType Difference = new clockType();
            if (Time.hours > hours)
            {
                if(seconds > Time.seconds)
                {
                    if(minutes > Time.minutes)
                    {
                        Time.hours--;
                        Time.minutes += 60;
                        Time.minutes--;
                        Time.seconds += 60;
                        Difference.hours = Time.hours - hours;
                        Difference.minutes = Time.minutes - minutes;
                        Difference.seconds = Time.seconds - seconds;
                    }
                    else
                    {
                        Time.minutes--;
                        Time.seconds += 60;
                        Difference.hours = Time.hours - hours;
                        Difference.minutes = Time.minutes - minutes;
                        Difference.seconds = Time.seconds - seconds;
                    }
                }
                else
                {
                    if (minutes > Time.minutes)
                    {
                        Time.hours--;
                        Time.minutes += 60;
                        Difference.hours = Time.hours - hours;
                        Difference.minutes = Time.minutes - minutes;
                        Difference.seconds = Time.seconds - seconds;
                    }
                    else
                    {
                        Difference.hours = Time.hours - hours;
                        Difference.minutes = Time.minutes - minutes;
                        Difference.seconds = Time.seconds - seconds;
                    }
                }
            }
            else
            {
                if (Time.seconds > seconds)
                {
                    if(Time.minutes > minutes)
                    {
                        hours--;
                        minutes += 60;
                        minutes--;
                        seconds += 60;
                        Difference.hours = hours - Time.hours;
                        Difference.minutes = minutes - Time.minutes;
                        Difference.seconds = seconds - Time.seconds;   
                    }
                    else
                    {
                        minutes--;
                        seconds += 60;
                        Difference.hours = hours - Time.hours;
                        Difference.minutes = minutes - Time.minutes;
                        Difference.seconds = seconds - Time.seconds;
                    }
                }
                else
                {
                    if (Time.minutes > minutes)
                    {
                        hours--;
                        minutes += 60;
                        Difference.hours = hours - Time.hours;
                        Difference.minutes = minutes - Time.minutes;
                        Difference.seconds = seconds - Time.seconds;
                    }
                    else
                    {
                        Difference.hours = hours - Time.hours;
                        Difference.minutes = minutes - Time.minutes;
                        Difference.seconds = seconds - Time.seconds;
                    }
                }
            }
            return Difference;
        }

        public int hours;
        public int minutes;
        public int seconds;
    }
    class product
    {
        public product()
        {
            name = "";
            category = "";
            price = 0;
            quantity = 0;
            MinQuantity = 0;
        }
        public void AddProduct()
        {
            Console.Write("Enter Product Name: ");
            name = Console.ReadLine();
            Console.Write("Enter Product Category: ");
            category = Console.ReadLine();
            Console.Write("Enter Product Price: ");
            price = float.Parse(Console.ReadLine());
            Console.Write("Enter Stock Quantity: ");
            quantity = int.Parse(Console.ReadLine());
            Console.Write("Enter Min Stock Quantity: ");
            MinQuantity = int.Parse(Console.ReadLine());
        }
        public float CalculateTax()
        {
            float tax;
            if(category == "groceries" || category == "Groceries")
            {
                tax = (price * 10) / 100;
            }
            else if (category == "fruits" || category == "Fruits")
            {
                tax = (price * 5)/ 100;
            }
            else
            {
                tax = (price * 15 )/ 100;
            }
            return tax;
        }
        public bool OrderProduct()
        {
            return true;
        }
        public string name;
        public string category;
        public float price;
        public int quantity;
        public int MinQuantity;
    }
}
