using System.ComponentModel.DataAnnotations;

namespace Pharmacy.Entities
{
    public class MedicalDrugsEntity
    {
        [Key]
        public long Id { get; set; }

        public string Brand { get; set; }

        public string Name { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set;} = DateTime.Now;
    }
}
