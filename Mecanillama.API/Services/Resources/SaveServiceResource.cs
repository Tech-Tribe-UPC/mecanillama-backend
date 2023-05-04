using System.ComponentModel.DataAnnotations;

namespace Mecanillama.API.Services.Resources;
    public class SaveServiceResource
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(150)]
        public string Description { get; set; }
        
        [Required]
        public int Price { get; set; }
        
        public string Photos { get; set; }

        [Required]
        public int MechanicId { get; set; }
    }