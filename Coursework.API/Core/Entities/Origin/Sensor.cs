namespace Core.Models.Origin
{
    public class Sensor : IEntity
    {
        public string Id { get; set; }
        public bool IsBroken { get; set; }
        public string Password { get; set; }

        public string WallId { get; set; }
        public Wall Wall { get; set; }
    }
}
