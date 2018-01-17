using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassWorkData
{
    public class DataProcess
    {
        public Dictionary<string, List<MyClasses>> dailyClasses = new Dictionary<string, List<MyClasses>>();
        private List<MyClasses> todaysClass = new List<MyClasses>();

        public DataProcess()
        {
            GetTodaysSchedule();
        }

        public Dictionary<string, List<MyClasses>> InitialiseDailyClasses()
        {
            var monday = new List<MyClasses>
            {
                new MyClasses
                {
                    UnitCode = "EME2202",
                    UnitName = "Strenght of Materials",
                    Venue = "Admatc",
                    UnitDay = "monday",
                    Lecturer = "TTTT",
                    Time = new TimeSpan(11, 00, 00)
                }
            };


            var tuesday = new List<MyClasses>
            {
                new MyClasses
                {
                    UnitCode = "EME2202",
                    UnitName = "Strenght of Materials",
                    Venue = "Admatc",
                    UnitDay = "monday",
                    Lecturer = "TTTT",
                    Time = new TimeSpan(07, 00, 00)
                },
                new MyClasses
                {
                    UnitCode = "sma2276",
                    UnitName = "computer programming",
                    Venue = "Rc6",
                    UnitDay = "Tuesday",
                    Lecturer = "Augustus",
                    Time = new TimeSpan(13, 00, 00)
                }
            };
            var wednesday = new List<MyClasses>
            {
                new MyClasses
                {
                    UnitCode = "EME2315",
                    UnitName = "thermodynamics ",
                    Venue = "H3",
                    UnitDay = "wednesday",
                    Lecturer = "Mr Ngugi",
                    Time = new TimeSpan(07, 00, 00)
                },
                new MyClasses
                {
                    UnitCode = "SMA2271",
                    UnitName = "ode ",
                    Venue = "H3",
                    UnitDay = "wednesday",
                    Lecturer = "Emmah",
                    Time = new TimeSpan(11, 00, 00)
                },
                new MyClasses
                {
                    UnitCode = "SMA2276",
                    UnitName = "computer programming ",
                    Venue = "computer lab",
                    UnitDay = "wednesday",
                    Lecturer = "Agustus",
                    Time = new TimeSpan(13, 00, 00)
                }
            };
            var thursday = new List<MyClasses>
            {
                new MyClasses
                {
                    UnitCode = "EEE2204",
                    UnitName = "physical electronics",
                    Venue = "Analogue Lab",
                    UnitDay = "thursday",
                    Lecturer = "Gebrehiwot",
                    Time = new TimeSpan(07, 00, 00)
                },
                new MyClasses
                {
                    UnitCode = "EEE2204",
                    UnitName = "physical electronics",
                    Venue = "H1",
                    UnitDay = "thursday",
                    Lecturer = "Gebrehiwot",
                    Time = new TimeSpan(13, 00, 00)
                }
            };
            var friday = new List<MyClasses>
            {
                new MyClasses
                {
                    UnitCode = "BCM2541",
                    UnitName = "engineering management",
                    Venue = "RC12",
                    UnitDay = "friday",
                    Lecturer = "GGGG",
                    Time = new TimeSpan(07, 00, 00)
                },
                new MyClasses
                {
                    UnitCode = "EEE2205",
                    UnitName = "cnt",
                    Venue = "Rc12",
                    UnitDay = "friday",
                    Lecturer = "Ciira",
                    Time = new TimeSpan(10, 00, 00)
                },
                new MyClasses
                {
                    UnitCode = "SMA2370",
                    UnitName = "calculus",
                    Venue = "Rc6",
                    UnitDay = "friday",
                    Lecturer = "Kanyi",
                    Time = new TimeSpan(16, 00, 00)
                },
                new MyClasses
                {
                    UnitCode = "EEE2205",
                    UnitName = "cnt",
                    Venue = "analog lab",
                    UnitDay = "friday",
                    Lecturer = "Ciira",
                    Time = new TimeSpan(13, 00, 00)
                }
            };
            dailyClasses.Add("monday", monday);
            dailyClasses.Add("tuesday", tuesday);
            dailyClasses.Add("wednesday", wednesday);
            dailyClasses.Add("thursday", thursday);
            dailyClasses.Add("friday", friday);
            return dailyClasses;
        }

        public List<MyClasses> GetTodaysSchedule()
        {
            InitialiseDailyClasses();
            var today = DateTime.Today.DayOfWeek.ToString().ToLower();
            todaysClass = dailyClasses[today];
            return todaysClass;
        }

        public int GetNoOfTodaysUnits()
        {
            return todaysClass.Count;
        }

        public MyClasses GetFirstClass()
        {
            var firstClass = todaysClass.OrderBy(e => e.Time).ToList();
            return firstClass[0];
        }

        public List<MyClasses> GetMorningClass()
        {
            TimeSpan startime, endTime;
            startime = new TimeSpan(06, 00, 00);
            endTime = new TimeSpan(11, 59, 59);

            var r = todaysClass.FindAll(i => i.Time >= startime && i.Time <= endTime).ToList();
            return r;
        }

        public List<MyClasses> GetAfternoonClass()
        {
            TimeSpan startime, endTime;
            startime = new TimeSpan(12, 00, 00);
            endTime = new TimeSpan(15, 59, 59);

            var r = todaysClass.FindAll(i => i.Time >= startime && i.Time <= endTime).ToList();
            return r;
        }

        public List<MyClasses> GetClassTime(string unit)
        {
            unit.ToLower();
            var r = todaysClass.FindAll(i => i.UnitName == unit).ToList();
            return r;
        }
    }
}