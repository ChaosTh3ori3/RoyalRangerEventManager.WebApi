using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using RangerEventManager.Persistence.Entities.Camp;

namespace RangerEventManager.Persistence.Entities.Base
{
    public abstract class BasePersonEntity
    {
        public long PersonId { get; set; }
        public string? Title { get; set; }
        [Required]
        public string Surename { get; set; }
        [Required]
        public string Forname { get; set; }
        public int? TroopNumber { get; set; }
        public string? TroopName { get; set; }
        public string Mail { get; set; }
    }
}
