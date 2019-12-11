namespace SEP3_TIER2_API.Model
{
    public class Position
    {
        public double XCoordinate { get; set; }
        public double YCoordinate { get; set; }

        public override string ToString()
        {
            return $"XCoordinate: {XCoordinate} \n YCoordinate: {YCoordinate}";
        }
    }
}
