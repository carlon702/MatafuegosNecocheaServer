using MatafuegosNecochea.Models.Clients;
using Microsoft.AspNetCore.Components;

namespace MatafuegosNecochea.Models.FireE
{
    public class FireExtinguisher
    {
        public int Id { get; set; }
        public required string CurrentCard { get; set; }
        public int BrandId { get; set; }
        public required Brand Brand { get; set; }
        public string? Observations { get; set; }
        public required DateTime ManufacturingYear { get; set; }
        public int CapacityId { get; set; }
        public required Capacity Capacity { get; set; }
        public int ChargeId { get; set; }
        public required Charge Charge { get; set; }
        public int? Interno { get; set; }
        public required DateTime Retire { get; set; }
        public required string RegFab { get; set; }
        public string? Notes {  get; set; }
        public required string Patent { get; set; }

        public int? ClientId { get; set; }
        public Client? Client { get; set; } = null!;

    }
}
