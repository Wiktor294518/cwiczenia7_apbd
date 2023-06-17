namespace Cw7.DTOs
{
    public class TripsGetAllResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int MaxPeople { get; set; }
        public IEnumerable<TripsGetAllResponseCountry> Countries { get; set; }
        public IEnumerable<TripsGetAllResponseClient> Clients { get; set; }

    }

    public class TripsGetAllResponseCountry
    {
        public string Name { get; set; }
    }
    public class TripsGetAllResponseClient
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
