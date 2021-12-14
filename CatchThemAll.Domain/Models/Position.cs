namespace CatchThemAll.Domain.Models
{
    public class Position
    {
        public Position(int xAxis, int yAxis)
        {
            XAxis = xAxis;
            YAxis = yAxis;
        }

        public int XAxis { get; set; }
        public int YAxis { get; set; }
    }
}
