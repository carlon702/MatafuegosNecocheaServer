using MatafuegosNecochea.Models.FireE;
using Microsoft.AspNetCore.Components;
using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations;

namespace MatafuegosNecochea.Models.Clients
{
    public class Client
    {
        public int Id { get; set; }
        [Required, MaxLength(128)]
        public required string Name { get; set; }
        public required int Age { get; set; }
        public required string Phone { get; set; }
        public string? Phone2 { get; set; }
        public int AddressId { get; set; }
        public required Address Address { get; set; }
        public required string Cuit { get; set; }
        public string? Detail { get; set; }
        public required string Email { get; set; }
        public int IvaId { get; set; }
        public required Iva Iva { get; set; }
        public string? Notes { get; set; }
        public Boolean Active { get; set; }
        public ICollection<FireExtinguisher> FireExtinguishers { get; } = new List<FireExtinguisher>();

    }
}
