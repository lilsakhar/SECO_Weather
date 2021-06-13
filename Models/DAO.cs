namespace SECO_Weather.Models
{
    public class DAO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public DAOCoord coord { get; set; }
    }

    public class DAOCoord
    {
        public float lon { get; set; }
        public float lat { get; set; }
    }

}
