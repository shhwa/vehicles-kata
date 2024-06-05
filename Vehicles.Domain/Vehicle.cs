namespace Vehicles.Domain;

public class Vehicle
{
    public VehicleType _vehicleType;
    
    public Vehicle(VehicleType vehicleType)
    {
        _vehicleType = vehicleType;
    }
    public Terrain GetTerrain()
    {
        return _vehicleType.Terrain;
    }
    public string GetSpeed()
    {
        if (_vehicleType.SpeedType == SpeedType.knots)
            return _vehicleType.MaxSpeed.Knots();
        return _vehicleType.MaxSpeed.Mph();
    }
    public double GetSpeedByMetersPerSecond()
    {
        return _vehicleType.MaxSpeed.MetersPerSecond;
    }

    public string GetSpeed(Terrain terrain)
    {
        Speed speed =  _vehicleType.GetMaxSpeed(terrain);
        if (terrain.SpeedType == SpeedType.knots)
            return speed.Knots();
        return speed.Mph();
    }
}
// [Flags]
// public enum Terrain
// {
//     Roads = 1, 
//     Water = 2,
//     Skies = 4
// }

public class Terrain
{
    public SpeedType SpeedType { get; set; }
    public static Terrain Roads => new Terrain{SpeedType = Domain.SpeedType.mph};
    public static Terrain Water => new Terrain{SpeedType = Domain.SpeedType.knots};

}