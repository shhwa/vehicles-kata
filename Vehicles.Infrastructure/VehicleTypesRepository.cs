using Vehicles.Domain;

namespace Vehicles.Infrastructure;

public class VehicleTypesRepository
{
    private List<VehicleType> _vehicleTypes;
    
    public VehicleTypesRepository()
    {
        _vehicleTypes = new List<VehicleType>();
    }


    public void Add(VehicleType vehicleType)
    {
        _vehicleTypes.Add(vehicleType);
    }

    public List<VehicleType> GetAll()
    {
        return _vehicleTypes;
    }

    public VehicleType GetByTypeName(string vehicleType)
    {
        return _vehicleTypes.Single(type => type.Name == vehicleType);
    }
}