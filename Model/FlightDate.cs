namespace SEP3_TIER2_API.Model
{
    public class FlightDate: Timer
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public FlightDate(int Day, int Month, int Year, int Hour, int Minutes, int Seconds) : base(Seconds, Minutes, Hour)
        {
            this.Day = Day;
            this.Month = Month;
            this.Year = Year;
        }

        public override string ToString()
        {
            return $"Day: {Day}\nMonth:{Month}\nYear:{Year}\n{base.ToString()}";
        }
    }
}
