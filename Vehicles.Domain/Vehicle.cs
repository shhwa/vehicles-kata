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
}
public enum Terrain {Roads, Water}