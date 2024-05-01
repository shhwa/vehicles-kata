using Microsoft.VisualBasic.CompilerServices;
using Vehicles.Infrastructure;

namespace Vehicles.Domain.Tests;

public class Tests
{
    [Test]
    public void Get_max_speed_on_new_boat()
    {
        Vehicle boat = new Vehicle(new VehicleType(new Speed(110, SpeedType.knots), SpeedType.knots, Terrain.Water));
        var maxSpeed = boat.GetSpeed();
        Assert.That(maxSpeed, Is.EqualTo("110 knots"));
    }
    
    [Test]
    public void Get_max_speed_on_new_car()
    {
        var car = new Vehicle(new VehicleType(new Speed(160, SpeedType.mph), SpeedType.mph, Terrain.Roads));
        Assert.That(car.GetSpeed(), Is.EqualTo("160 mph"));
    }

    [Test]
    public void Get_all_vehicles_from_repository()
    {
        var car = new Vehicle(new VehicleType(new Speed(300, SpeedType.mph), SpeedType.mph, Terrain.Roads));
        var vehiclesRepo = new VehiclesRepository();
        vehiclesRepo.Add(car);
        var allVehicles = vehiclesRepo.GetAll();
        Assert.That(allVehicles.Count, Is.EqualTo(1) );
    }

    [Test]
    public void Get_correct_vehicle_type_from_repository()
    {
        var boat = new Vehicle(new VehicleType(new Speed(100, SpeedType.knots), SpeedType.knots, Terrain.Water));
        var car = new Vehicle(new VehicleType(new Speed(100, SpeedType.mph), SpeedType.mph, Terrain.Roads));
        var vehicleRepo = new VehiclesRepository();
        vehicleRepo.Add(car);
        vehicleRepo.Add(boat);
        var lastAdded = vehicleRepo.GetAll().Last();
        var firstAdded = vehicleRepo.GetAll().First();
        Assert.That(lastAdded.GetSpeed(), Is.EqualTo("100 knots"));
        Assert.That(firstAdded.GetSpeed(), Is.EqualTo("100 mph"));
    }
    
    [Test]
    public void Get_vehicle_type_from_repository_ordered_by_max_speed()
    {
        var boat = new Vehicle(new VehicleType(new Speed(200, SpeedType.knots), SpeedType.knots, Terrain.Water));
        var car = new Vehicle(new VehicleType(new Speed(100, SpeedType.mph), SpeedType.mph, Terrain.Roads));
        var vehicleRepo = new VehiclesRepository();
        vehicleRepo.Add(car);
        vehicleRepo.Add(boat);
        IEnumerable<Vehicle> vehiclesByMaxSpeed = vehicleRepo.GetAllByMaxSpeed();
        Assert.That(vehiclesByMaxSpeed.First().GetSpeed(), Is.EqualTo("200 knots"));
    }

    [Test]
    public void Get_terrain_of_road_from_car()
    {
        var car = new Vehicle(new VehicleType(new Speed(300, SpeedType.mph), SpeedType.mph, Terrain.Roads));
        Assert.That(car.GetTerrain(), Is.EqualTo(Terrain.Roads));
    }
    
    [Test]
    public void Get_terrain_of_water_from_boat()
    {
        var boat = new Vehicle(new VehicleType(new Speed(150, SpeedType.knots), SpeedType.knots, Terrain.Water));
        Assert.That(boat.GetTerrain(), Is.EqualTo(Terrain.Water));
    }

    [Test]
    public void Can_create_a_car_from_a_type_of_car()
    {
        var ferrariType = new VehicleType(new Speed(300, SpeedType.mph), SpeedType.mph, Terrain.Roads);
        var ferrari = new Vehicle(ferrariType);
        Assert.That(ferrari.GetSpeed(), Is.EqualTo("300 mph"));
    }
    
    [Test]
    public void Can_create_a_boat_from_a_type_of_boat()
    {
        var wayfairerType = new VehicleType(new Speed(50, SpeedType.knots), SpeedType.knots, Terrain.Water);
        var wayfairer = new Vehicle(wayfairerType);
        Assert.That(wayfairer.GetSpeed(), Is.EqualTo("50 knots"));
    }
    
    [Test]
    public void Get_all_vehicle_types_from_repository()
    {
        var ferrariType = new VehicleType(new Speed(300, SpeedType.mph), SpeedType.mph, Terrain.Roads);
        var vehiclesTypeRepo = new VehicleTypesRepository();
        vehiclesTypeRepo.Add(ferrariType);
        var allVehicleTypes = vehiclesTypeRepo.GetAll();
        Assert.That(allVehicleTypes.Count, Is.EqualTo(1) );
    }
    
    [Test]
    public void Create_a_ferrari_from_a_stored_ferrari_type()
    {
        var ferrariType = new VehicleType(new Speed(300, SpeedType.mph), SpeedType.mph, Terrain.Roads);
        var vehiclesTypeRepo = new VehicleTypesRepository();
        vehiclesTypeRepo.Add(ferrariType);
        var ferrari = new Vehicle(vehiclesTypeRepo.GetAll().First());
        Assert.That(ferrari.GetSpeed(), Is.EqualTo("300 mph"));
    }

    [Test]
    public void Create_a_ferrari_from_one_of_multiple_stored_vehicle_types()
    {
        var rollsroyceType = new VehicleType(new Speed(200, SpeedType.mph), SpeedType.mph, Terrain.Roads, "rollsroyce");
        var ferrariType = new VehicleType(new Speed(300, SpeedType.mph), SpeedType.mph, Terrain.Roads, "ferrari");
        var deloreanType = new VehicleType(new Speed(88, SpeedType.mph), SpeedType.mph, Terrain.Roads, "delorean");
        var vehiclesTypeRepo = new VehicleTypesRepository();
        vehiclesTypeRepo.Add(rollsroyceType);
        vehiclesTypeRepo.Add(ferrariType);
        vehiclesTypeRepo.Add(deloreanType);
        var ferrari = new Vehicle(vehiclesTypeRepo.GetByTypeName("ferrari"));
        Assert.That(ferrari.GetSpeed(), Is.EqualTo("300 mph"));
        var rollsroyce = new Vehicle(vehiclesTypeRepo.GetByTypeName("rollsroyce"));
        Assert.That(rollsroyce.GetSpeed(), Is.EqualTo("200 mph"));
    }

    [Test]
    public void Vehicles_fetched_from_the_repository_should_have_up_to_date_values()
    {
        var deloreanType = new VehicleType(new Speed(88, SpeedType.mph), SpeedType.mph, Terrain.Roads, "delorean");
        var vehiclesTypeRepo = new VehicleTypesRepository();
        var vehiclesrepo = new VehiclesRepository();
        vehiclesTypeRepo.Add(deloreanType);
        var delorean = new Vehicle(vehiclesTypeRepo.GetByTypeName("delorean"));
        vehiclesrepo.Add(delorean);
        Assert.That(delorean.GetSpeed(), Is.EqualTo("88 mph"));
        deloreanType.MaxSpeed = new Speed(98, SpeedType.mph);
        Assert.That(vehiclesrepo.GetAll().Single().GetSpeed(), Is.EqualTo("98 mph"));



    }
}
