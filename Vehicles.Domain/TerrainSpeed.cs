namespace Vehicles.Domain;

public class TerrainSpeed
{
    public TerrainSpeed(Speed speed, Terrain terrain)
    {
        SpeedType = speed.SpeedType;
        MaxSpeed = speed;
        Terrain = terrain;
    }

    public SpeedType SpeedType { get; set; }
    public Speed? MaxSpeed { get; set; }
    public Terrain Terrain { get; set; }
}