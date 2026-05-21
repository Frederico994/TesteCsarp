namespace TesteCsarp.Models
{
    public class DragonBallCharacter
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Affiliation { get; set; } = string.Empty;
    }

    public class DragonBallCharacterDetail : DragonBallCharacter
    {
    }

    public class DragonBallCharactersResponse
    {
        public List<DragonBallCharacter>? Items { get; set; }
    }
}