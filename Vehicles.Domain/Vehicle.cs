namespace Vehicles.Domain;

public class Vehicle
{
    private readonly SpeedType _speedType;
    public Speed _maxSpeed;
    public Terrain _terrain;
    
    public Vehicle(VehicleType carType)
    {
        _speedType = carType.SpeedType;
        _maxSpeed = carType.MaxSpeed;
        _terrain = carType.Terrain;
    }
    public Terrain GetTerrain()
    {
        return _terrain;
    }
    public string GetSpeed()
    {
        if (_speedType == SpeedType.knots)
            return _maxSpeed.Knots();
        return _maxSpeed.Mph();
    }
    public double GetSpeedByMetersPerSecond()
    {
        return _maxSpeed.MetersPerSecond;
    }
    
    public static Vehicle CreateVehicle(VehicleType vehicleType)
    {
        return new Vehicle(vehicleType);
    }
}
public enum Terrain {Roads, Water}