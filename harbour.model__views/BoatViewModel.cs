namespace harbour.model__views
{
    public class BoatViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Speed { get; set; }
    }
    
    public class WeatherViewModel
    {
        public string CountryCode { get; set; }
        public string City { get; set; }
     
    }
    public class WeatherViewModelService
    {
        public WindViewModel Wind { get; set; }
    }
    public class WindViewModel
    {
        public double Speed { get; set; }
        public double Deg { get; set; }
       
    }
}
