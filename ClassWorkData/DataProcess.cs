using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWorkData
{
    public class DataProcess
    {
        public Dictionary<string, List<MyClasses>>dailyClasses = new Dictionary<string, List<MyClasses>>();
        private List<MyClasses> todaysClass = new List<MyClasses>();

        public Dictionary<string, List<MyClasses>> InitialiseDailyClasses()
        {
            List<MyClasses> monday = new List<MyClasses>();

            MyClasses Calculus = new MyClasses()
            {
                UnitCode = "SMA2177",
                UnitName = "calculus",
                Venue = "Rc4",
                UnitDay = "monday",
                Lecturer = "Kanyi",
                Time = new TimeSpan(11, 00, 00)
            };
            MyClasses ODE = new MyClasses()
            {
                UnitCode = "SMA2277",
                UnitName = "ODE",
                Venue = "Rc6",
                UnitDay = "Tuesday",
                Lecturer = "Emmaah",
                Time = new TimeSpan(10,00,00)
            };
            monday.Add(Calculus);
            monday.Add(ODE);

            List<MyClasses> tuesday = new List<MyClasses>();
            MyClasses CNT = new MyClasses()
            {
                UnitCode = "SMA2177",
                UnitName = "ccnt",
                Venue = "Rc4",
                UnitDay = "monday",
                Lecturer = "Kanyi",
                Time = new TimeSpan(23, 00, 00)
            };
            MyClasses Thermodynamics = new MyClasses()
            {
                UnitCode = "SMA2277",
                UnitName = "thermodynamis",
                Venue = "Rc6",
                UnitDay = "Tuesday",
                Lecturer = "Emmaah",
                Time = new TimeSpan(16, 00, 00)
            };
            tuesday.Add(CNT);
            tuesday.Add(Thermodynamics);

            dailyClasses.Add("monday", monday);
            dailyClasses.Add("tuesday", tuesday);
            return dailyClasses;
        }
        public List<MyClasses> GetTodaysSchedule()
        {
            InitialiseDailyClasses();
            string today = DateTime.Today.DayOfWeek.ToString().ToLower();
            todaysClass = dailyClasses[today];
            return todaysClass;
        }

        public int GetTodaysUnits()
        {
            GetTodaysSchedule();
            return todaysClass.Count;
        }
        public MyClasses GetFirstClass()
        {
            GetTodaysSchedule();
            List<MyClasses> firstClass= todaysClass.OrderBy(e => e.Time).ToList<MyClasses>();
            return firstClass[0];
        }
       
    }
}
