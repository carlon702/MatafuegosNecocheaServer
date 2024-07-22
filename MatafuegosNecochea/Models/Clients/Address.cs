namespace MatafuegosNecochea.Models.Clients
{
    public class Address
    {
        public int Id {  get; set; }
        public required string City { get; set; }
        public required string AdministrativeArea { get; set; }
        public required string Street {  get; set; }
        public required int Number { get; set; }

    }
}