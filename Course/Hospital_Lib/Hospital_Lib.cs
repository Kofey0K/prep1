using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hospital_Lib
{
    public abstract class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name;
        public int Age;
    }

    public class Patient : Person
    {
        public string Diagnosis;
        public string KnownTroubles { get; }
        public Patient(string name, int age, string troubles) : base(name, age)
        {
            KnownTroubles = troubles;
            Diagnosis = "Unknown";
        }
        public void SeeDoctor(Doctor dr)
        {
            dr.TakePatient(this);
        }
    }

    public class Doctor : Person
    {
        public WorkSchedule Schedule { get; }
        public string Specialty { get; }
        public List<DateTime> Appointments { get; }

        public Doctor(string name, int age, string Specialty, WorkSchedule graphic) : base(name, age)
        {
            Appointments = new List<DateTime>();
            this.Specialty = Specialty;
            Schedule = graphic;
        }
        public Doctor(string name, int age, string Specialty, int hours, TimeSpan time, DayOfWeek[] WorkDays) : base(name, age)
        {
            Appointments = new List<DateTime>();
            this.Specialty = Specialty;
            Schedule = new WorkSchedule(hours, time, WorkDays);
        }
        public Doctor(string name, int age, string Specialty, List<DateTime> appointments, WorkSchedule graphic) : base(name, age)
        {
            Appointments = new List<DateTime>();
            for (int i = 0; i < appointments.Count; i++)
            {
                Appointments.Add(appointments[i]);
            }
            this.Specialty = Specialty;
            Schedule = graphic;
        }
        public Doctor(string name, int age, string Specialty, List<DateTime> appointments, int hours, TimeSpan time, DayOfWeek[] WorkDays) : base(name, age)
        {
            Appointments = new List<DateTime>();
            for (int i = 0; i < appointments.Count; i++)
            {
                Appointments.Add(appointments[i]);
            }
            this.Specialty = Specialty;
            Schedule = new WorkSchedule(hours, time, WorkDays);
        }
        public bool IsFree()
        {
            if ((Schedule.shift == WorkSchedule.Shift.Day))
            {
                return ((DateTime.Now.TimeOfDay >= Schedule.StartOfWork) && (DateTime.Now.TimeOfDay <= Schedule.EndOfWork) && (Schedule.Contains(DateTime.Now.DayOfWeek)));
            }
            else
            {
                if ((DateTime.Now.TimeOfDay >= Schedule.StartOfWork)) return (Schedule.Contains(DateTime.Now.DayOfWeek));
                return ((DateTime.Now.TimeOfDay <= Schedule.EndOfWork) && Schedule.Contains(DateTime.Now.DayOfWeek - 1));
            }
        }
        public bool IsFree(DateTime dt)
        {
            if ((Schedule.shift == WorkSchedule.Shift.Day))
            {
                return ((dt.TimeOfDay >= Schedule.StartOfWork) && (dt.TimeOfDay <= Schedule.EndOfWork) && (Schedule.Contains(dt.DayOfWeek)));
            }
            else
            {
                if ((dt.TimeOfDay >= Schedule.StartOfWork)) return (Schedule.Contains(dt.DayOfWeek));
                return ((dt.TimeOfDay <= Schedule.EndOfWork) && Schedule.Contains(dt.DayOfWeek - 1));
            }
        }
        public void TakePatient(Patient patient)
        {
            try
            {
                if (IsFree())
                {
                    bool appointment = true;
                    for (int i = 0; i < Appointments.Count; i++)
                    {
                        if (DateTime.Now > Appointments[i] - new TimeSpan(0, 30, 0) && DateTime.Now < Appointments[i] + new TimeSpan(0, 30, 0))
                        {
                            Notify?.Invoke("The doctor has an appointment at the moment. The patient can wait in the queue.");
                            appointment =  false;
                        }
                    }
                    if (appointment)
                    {
                        Directory.CreateDirectory(@"D:\DZ\OOP\prep1\Course\Hospital_program\Cards");
                        TimeSpan time1 = DateTime.Now.TimeOfDay;
                        Console.WriteLine("Type something in if you have returned.");
                        Console.ReadLine();
                        Console.WriteLine("What was the Diagnosis?");
                        string Diagnosis = Console.ReadLine();
                        File.WriteAllText(@"D:\DZ\OOP\prep1\Course\Hospital_program\Cards\Card_" + patient.Name + "_" + DateTime.Now.Day + "_" + DateTime.Now.Month + ".txt", "Appointment card\nDcotor: " + Specialty + " " + Name + "\nPatient: " + patient.Name + "\nVisiting time: " + time1 + " - " + DateTime.Now.TimeOfDay + "\nDiagnosis: " + Diagnosis);
                        patient.Diagnosis = Diagnosis;
                    }
                }
                else
                {
                    throw new Exception("Doctor " + Name + " isn't present at the moment.");
                }
            }
            catch (Exception e)
            {
                Notify?.Invoke(e.Message);
            }
        }
        public delegate void LogHandler(string message);
        public static event LogHandler Notify = (string message) =>
        {
            Directory.CreateDirectory(@"D:\DZ\OOP\prep1\Hospital_program\Program\logs");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
            StreamWriter sw = new StreamWriter(@"D:\DZ\OOP\prep1\Course\Hospital_program\logs\logs.txt", true, Encoding.Default);
            sw.WriteLine(message + "   " + DateTime.Now.TimeOfDay);
            sw.Close();
        };
        public bool CheckTime(DateTime date)
        {
            if (IsFree(date) != true)
            {
                Notify?.Invoke(Name + " doesn't work at the chosen time of the day.");
                return false;
            }
            int i = 0;
            while (i < Appointments.Count)
            {
                if (DateTime.Now > Appointments[i])
                {
                    Appointments.RemoveAt(i);

                }
                else { i++; }
            }
            for (i = 0; i < Appointments.Count; i++)
            {
                if (date > Appointments[i] - new TimeSpan(0, 30, 0) && date < Appointments[i] + new TimeSpan(0, 30, 0))
                {
                    Notify?.Invoke("The chosen time is already taken.");
                    return false;
                }
            }

            return true;
        }
        public void BookTime(DateTime date)
        {
            if (CheckTime(date))
            {
                Appointments.Add(date);
                StreamWriter sw = new StreamWriter(@"D:\DZ\OOP\prep1\Course\Hospital_program\Doctors\" + Name + ".txt", true, Encoding.Default);
                sw.WriteLine(date);
                sw.Close();
            }
        }
        public bool CheckAppointment(DateTime date)
        {
            return Appointments.Contains(date);
        }
    }

    public class WorkSchedule
    {
        public enum Shift { Day, Night };
        public Shift shift;
        public int WorkHours { get; }
        public TimeSpan StartOfWork, EndOfWork;
        public DayOfWeek[] WorkDays;
        public WorkSchedule(int hours, TimeSpan time, DayOfWeek[] WorkDays)
        {
            this.WorkDays = new DayOfWeek[WorkDays.Length];
            this.WorkDays = WorkDays;
            shift = Shift.Day;
            WorkHours = hours;
            StartOfWork = time;
            EndOfWork = StartOfWork + new TimeSpan(WorkHours, 0, 0);
            if (EndOfWork.Days > 0)
            {
                EndOfWork -= new TimeSpan(1, 0, 0, 0);
                shift = Shift.Night;
            }

        }
        public bool Contains(DayOfWeek day)
        {
            for (int i = 0; i < WorkDays.Length; i++)
            {
                if (WorkDays[i] == day) { return true; }
            }
            return false;
        }
    }

    public class Hospital
    {
        public static List<Doctor> Doctors;
        static Hospital()
        {
            Doctors = new List<Doctor> { };
            using (StreamReader sr = new StreamReader(@"D:\DZ\OOP\prep1\Course\Hospital_program/Doctors.txt", Encoding.Default))
            {
                using (StreamReader sr2 = new StreamReader(@"D:\DZ\OOP\prep1\Course\Hospital_program/info.txt", Encoding.Default))
                {

                    string name;
                    while ((name = sr.ReadLine()) != null)
                    {
                        if (File.Exists(@"D:\DZ\OOP\prep1\Course\Hospital_program\Doctors/" + name + ".txt"))
                        {
                            using (StreamReader sr3 = new StreamReader(@"D:\DZ\OOP\prep1\Course\Hospital_program\Doctors/" + name + ".txt", Encoding.Default))
                            {
                                string dates;
                                List<DateTime> dti = new List<DateTime> { };
                                while ((dates = sr3.ReadLine()) != null)
                                {
                                    string[] dates_int = dates.Split(new char[] { ' ', '.', ':' }, StringSplitOptions.RemoveEmptyEntries);
                                    dti.Add(new DateTime(int.Parse(dates_int[2]), int.Parse(dates_int[1]), int.Parse(dates_int[0]), int.Parse(dates_int[3]), int.Parse(dates_int[4]), int.Parse(dates_int[5])));
                                }


                                string info = sr2.ReadLine();
                                string[] info_words = info.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                string[] Start_time = info_words[3].Split(new char[] { ' ', '.', ':' }, StringSplitOptions.RemoveEmptyEntries);
                                DayOfWeek[] Days = new DayOfWeek[info_words.Length - 4];
                                for (int i = 4; i < info_words.Length; i++)
                                {
                                    Days[i - 4] = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), info_words[i]);
                                }
                                Doctor test = new Doctor(name, int.Parse(info_words[0]), info_words[1], dti, int.Parse(info_words[2]), new TimeSpan(int.Parse(Start_time[0]), int.Parse(Start_time[1]), int.Parse(Start_time[2])), Days);
                                Doctors.Add(test);
                            }
                        }



                        else
                        {

                            string info = sr2.ReadLine();
                            string[] info_words = info.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            string[] Start_time = info_words[3].Split(new char[] { ' ', '.', ':' }, StringSplitOptions.RemoveEmptyEntries);
                            DayOfWeek[] Days = new DayOfWeek[info_words.Length - 4];
                            for (int i = 4; i < info_words.Length; i++)
                            {
                                Days[i - 4] = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), info_words[i]);
                            }
                            Doctor test = new Doctor(name, int.Parse(info_words[0]), info_words[1], int.Parse(info_words[2]), new TimeSpan(int.Parse(Start_time[0]), int.Parse(Start_time[1]), int.Parse(Start_time[2])), Days);
                            Doctors.Add(test);
                        }
                    }
                }

            }
        }

        private static void HireDoctor()
        {
            Console.WriteLine("What is the doctor's name?");
            string name = Console.ReadLine();
            Console.WriteLine("What is the doctor's age?");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("What is " + name + "'s specialty?");
            string Specialty = Console.ReadLine();
            Console.WriteLine("How many work hours will they have?");
            int hours = int.Parse(Console.ReadLine());
            Console.WriteLine("At what time does the doctor's work start? Example: 08:30:00");
            string[] Start_time = Console.ReadLine().Split(new char[] { ' ', '.', ':' }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine("And finally on what days will they work?");
            string[] input_Days = Console.ReadLine().Split(new char[] { ' ', '.', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
            DayOfWeek[] Days = new DayOfWeek[input_Days.Length];
            for (int i = 0; i < input_Days.Length; i++)
            {
                Days[i] = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), input_Days[i]);
            }
            Doctors.Add(new Doctor(name, age, Specialty, hours, new TimeSpan(int.Parse(Start_time[0]), int.Parse(Start_time[1]), int.Parse(Start_time[2])), Days));

            StreamWriter sw = new StreamWriter(@"D:\DZ\OOP\prep1\Course\Hospital_program/Doctors.txt", true, Encoding.Default);
            sw.WriteLine(name);
            sw.Close();
            StreamWriter sw2 = new StreamWriter(@"D:\DZ\OOP\prep1\Course\Hospital_program/info.txt", true, Encoding.Default);
            string output = age + " " + Specialty + " " + hours + " " + new TimeSpan(int.Parse(Start_time[0]), int.Parse(Start_time[1]), int.Parse(Start_time[2])) + " ";
            for (int i = 0; i < input_Days.Length; i++)
            {
                output += input_Days[i] + " ";
            }
            sw2.WriteLine(output);
            sw2.Close();

        }
        public static Doctor Doc(string name)
        {

            {
                for (int i = 0; i < Doctors.Count; i++)
                {
                    if (Doctors[i].Name == name) return Doctors[i];
                }
                return null;
            }

        }
        public static void Run()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Hello, Dear User!");
            Console.ResetColor();
            bool next = true;

            while (next)
            {
                Console.WriteLine("\nWhat should we do now? Enter:\n1 - Hire,\n2 - Check Appointment,\n3 - Doctors Info,\n4 - Check If Doctor Is Present,\n5 - Book An Appointment,\n6 - Doctor's Appointments,\n7 - Visit Doctor,\nq - Quit.");
                string a = Console.ReadLine();
                switch (a)
                {
                    case "1":
                        HireDoctor();
                        Console.WriteLine("Successfully added the doctor!");
                        break;
                    case "2":
                        Console.WriteLine("\nEnter the doctor's full name.");
                        string doctor = Console.ReadLine();
                        Console.WriteLine("\nEnter the date of the appointment. Example: 21.05.2020 15:00::00");
                        string[] dates_int = Console.ReadLine().Split(new char[] { ' ', '.', ':' }, StringSplitOptions.RemoveEmptyEntries);
                        if (Doc(doctor).CheckAppointment(new DateTime(int.Parse(dates_int[2]), int.Parse(dates_int[1]), int.Parse(dates_int[0]), int.Parse(dates_int[3]), int.Parse(dates_int[4]), int.Parse(dates_int[5]))))
                        {
                            Console.WriteLine("\nYes. There is such an appointment.");
                        }
                        else { Console.WriteLine("\nNo. There is no such appointment in our data base."); }
                        break;
                    case "3":
                        Console.WriteLine("\nHere you go.\n");
                        for (int i = 0; i < Doctors.Count; i++)
                        {
                            Console.Write(Doctors[i].Specialty + " " + Doctors[i].Name + " " + Doctors[i].Schedule.StartOfWork + " - " + Doctors[i].Schedule.EndOfWork);
                            for (int j = 0; j < Doctors[i].Schedule.WorkDays.Length; j++)
                            {
                                Console.Write(" " + Doctors[i].Schedule.WorkDays[j]);
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine();
                        break;
                    case "4":
                        Console.WriteLine("Enter the doctor's full name.");
                        string doctor4 = Console.ReadLine();
                        if (Doc(doctor4).IsFree())
                        {
                            Console.WriteLine("Yes, " + doctor4 + " is present. The patient may also see the doctor's appointments or visit the doctor.");
                        }
                        else { Console.WriteLine("No. " + doctor4 + " doesn't work today."); }
                        break;
                    case "5":
                        Console.WriteLine("Enter the doctor's full name.");
                        string doctor5 = Console.ReadLine();
                        Console.WriteLine("Enter the date of the appointment. Example: 21.05.2020 15:00::00");
                        string[] dates_int5 = Console.ReadLine().Split(new char[] { ' ', '.', ':' }, StringSplitOptions.RemoveEmptyEntries);
                        Doc(doctor5).BookTime(new DateTime(int.Parse(dates_int5[2]), int.Parse(dates_int5[1]), int.Parse(dates_int5[0]), int.Parse(dates_int5[3]), int.Parse(dates_int5[4]), int.Parse(dates_int5[5])));
                        Console.WriteLine("\nAppointment successfully booked!");
                        break;
                    case "6":
                        Console.WriteLine("Enter the doctor's full name.");
                        string doctor6 = Console.ReadLine();
                        if (Doc(doctor6).Appointments.Count == 0) { Console.WriteLine(doctor6 + " doesn't have any appointments yet!"); }
                        else
                        {
                            Console.WriteLine("Here are the doctor's appointments:");

                            for (int i = 0; i < Doc(doctor6).Appointments.Count; i++)
                            {
                                Console.WriteLine(Doc(doctor6).Appointments[i]);
                            }
                        }
                        break;
                    case "7":
                        Console.WriteLine("What are the patient's name, age and troubles?");
                        Console.Write("Name:");
                        string name = Console.ReadLine();
                        Console.Write("\nAge:");
                        int age = int.Parse(Console.ReadLine());
                        Console.Write("\nTroubles:");
                        string troubles = Console.ReadLine();
                        Patient new_patient = new Patient(name, age, troubles);
                        Console.WriteLine("\nWho does the patient want to see? Enter full name of the doctor.");
                        string doctor7 = Console.ReadLine();
                        new_patient.SeeDoctor(Doc(doctor7));
                        Console.WriteLine("Successfully created an appointment card! You can find it in the folder Cards.");
                        break;
                    case "q":
                        next = false;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nGoodbye. Have a nice day!");
                        Console.ResetColor();
                        break;
                    default:
                        Console.WriteLine("\nWrong key was pressed. Please try again.");
                        break;
                }
            }
        }
    }
}
