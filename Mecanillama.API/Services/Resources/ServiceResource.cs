namespace Mecanillama.API.Services.Resources;
    public class ServiceResource
    {
        public int Id { get; set; }
        public int MechanicId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Photos { get; set; }
    }