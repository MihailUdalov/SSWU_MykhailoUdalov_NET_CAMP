using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task_3
{
    internal class ElectricityUsageAccounting
    {
        public int NumApartments { get; set; }
        public int NumQuarter { get; set; }
        public List<Apartment> Apartments { get; set; }
        public ElectricityUsageAccounting(string[] text)
        {
            NumApartments = int.Parse(text.First().Split(',', (char)StringSplitOptions.RemoveEmptyEntries).First());
            NumQuarter = int.Parse(text.First().Split(',', (char)StringSplitOptions.RemoveEmptyEntries).Last());
            
            InitApartments(text.Skip(1).ToArray());
        }

        private void InitApartments(string[] apartmentsData)
        {
            Apartments = new List<Apartment>();
            foreach (var apartmentData in apartmentsData)
            {
                string[] values = apartmentData.Split(',', (char)StringSplitOptions.RemoveEmptyEntries);
                Dictionary<DateTime, int> meterReading = InitMeterReadingDictionary(values.Skip(4).ToArray());
                
                Apartment apartment = new Apartment(int.Parse(values[0]), values[1].Trim(), values[2].Trim(), int.Parse(values[3]),meterReading);
                Apartments.Add(apartment);
            }
        }

        private Dictionary<DateTime, int> InitMeterReadingDictionary(string[] meterReadingData)
        {
            Dictionary<DateTime, int> value = new Dictionary<DateTime, int>();
            for (int i = 0; i < meterReadingData.Length; i+=2)
            {
                value.Add(DateTime.ParseExact(meterReadingData[i + 1].Trim(), "dd.MM.yyyy", null),
                    int.Parse(meterReadingData[i]));
            }
            return value;
        }

        public string GetReport()
        {
            StringBuilder sB =  GetReportTitle();
        
            foreach (var apartment in Apartments)
            {   
                sB.AppendLine(apartment.ToString());
            }
            return sB.ToString();
        }

        public string GetReport(int apartmentNumper)
        {
            StringBuilder sB =  GetReportTitle();

            sB.AppendLine(Apartments.First(x=> x.ApartmentNumber == apartmentNumper).ToString());

            return sB.ToString();

        }

        public string GetOwnerLastNameWithBiggestDebt()
        {
            return $"Person with a biggest debt: {Apartments.First(x=> x.AmountPerQuarter == Apartments.Max(y => y.AmountPerQuarter)).OwnerLastName}";
        }

        public string GetNumberAppartmentNoElectricityUsed()
        {
            return $"Number Appartment no electricity was used.: {Apartments.First(x => x.AmountPerQuarter == 0).ApartmentNumber}";
        }

        private StringBuilder GetReportTitle()
        {
            StringBuilder sB = new StringBuilder();

            sB.Append("Report for such months.");

            int year = DateTime.Now.Year;

            DateTime startDate = new DateTime(year, (3 * NumQuarter) - 2, 1);
            DateTime endDate = startDate.AddMonths(3).AddDays(-1);

            for (DateTime date = startDate; date <= endDate; date = date.AddMonths(1))
            {
                sB.Append(" " + date.ToString("MMMM"));
            }
            sB.AppendLine();
            sB.AppendLine($"{"Apartment Number",20} {"Owner LastName",25} {"Amount Per Quarter",30} {"Days since last reading (Current date)",50}");

            return sB;
        }
    }
}
