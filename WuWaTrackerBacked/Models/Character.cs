namespace WuWaTrackerBackend.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Element { get; set; } = string.Empty;
        public string Weapon { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty; // New!
        public string Description { get; set; } = string.Empty; // New!
        public bool IsObtained { get; set; } = false;
    }
}