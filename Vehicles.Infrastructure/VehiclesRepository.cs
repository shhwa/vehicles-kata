using Vehicles.Domain;

namespace Vehicles.Infrastructure;

public class VehiclesRepository
{
    private List<Vehicle> _vehicleList;
    
    public VehiclesRepository()
    {
        _vehicleList = new List<Vehicle>();
    }
    public void Add(Vehicle vehicle)
    {
        _vehicleList.Add(vehicle);
    }

    public List<Vehicle> GetAll()
    {
        return _vehicleList;
    }

    public IOrderedEnumerable<Vehicle> GetAllByMaxSpeed()
    {

        return _vehicleList.OrderByDescending(vehicle => vehicle.GetSpeedByMetersPerSecond());
    }
}