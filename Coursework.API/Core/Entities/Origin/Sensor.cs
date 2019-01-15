namespace Core.Models.Origin
{
    public class Sensor : IEntity
    {
        public string Id { get; set; }
        public bool IsBroken { get; set; }
        public string PasswordHash { get; set; }
        public double DamageInPercents { get; set; }

        public string WallId { get; set; }
        public Wall Wall { get; set; }
    }
}
