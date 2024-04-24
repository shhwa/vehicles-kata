namespace Vehicles.Domain;

public class VehicleType
{
    public SpeedType SpeedType { get; }
    public Speed MaxSpeed { get; }
    public Terrain Terrain { get; }
    public string Name { get; set; }

    public VehicleType(Speed speed, SpeedType speedType, Terrain terrain, string name)
    {
        SpeedType = speedType;
        MaxSpeed = speed;
        Terrain = terrain;
        Name = name;
    }
    
    public VehicleType(Speed speed, SpeedType speedType, Terrain terrain)
    {
        SpeedType = speedType;
        MaxSpeed = speed;
        Terrain = terrain;
    }
    
    
}