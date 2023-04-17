using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_3
{
    internal class Apartment
    {
        private const int kwVPricePer = 1;
        public int ApartmentNumber { get; set; }
        public string Address { get; set; }
        public string OwnerLastName { get; set; }
        public int InitialMeterReading { get; set; }
        public Dictionary<DateTime, int> MeterReading { get; set; }
        public int AmountPerQuarter { get; set; }


        public Apartment(int apartmentNumber, string address, string ownerLastName, int initialMeterReading, Dictionary<DateTime, int> meterReading)
        {
            ApartmentNumber = apartmentNumber;
            Address = address;
            OwnerLastName = ownerLastName;
            InitialMeterReading = initialMeterReading;
            MeterReading = meterReading;
            CalculateElectricityAmount();
        }

        private void CalculateElectricityAmount()
        {
            int[] readings = MeterReading.Values.ToArray();
            int firstReading = readings[0];
            int secondReading = readings[1];
            int lastReading = readings[readings.Length - 1];

            int kwV = (firstReading - InitialMeterReading) + (secondReading - firstReading) + (lastReading - secondReading);
            AmountPerQuarter = kwV * kwVPricePer;
        }

        public override string ToString()
        {
            int days = (int)(DateTime.Now - MeterReading.Last().Key).TotalDays;
            return $"{ApartmentNumber,20}{OwnerLastName,25}{AmountPerQuarter,30}{days,50}";
        }
    }
}
