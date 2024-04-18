namespace Vehicles.Domain;

public class Speed
{
    public double MetersPerSecond { get; set; }
    public SpeedType SpeedType { get; set; }
    public Speed(int speed, SpeedType speedType)
    {
        SpeedType = speedType;
        if (speedType == SpeedType.mph)
            MetersPerSecond = speed / 2.2;
        else
            MetersPerSecond = speed / 1.9;
    }

    public string Knots()
    {
        return (MetersPerSecond * 1.9).ToString() + " knots";
    } public string Mph()
    {
        return (MetersPerSecond * 2.2).ToString() + " mph";
    }
}
public enum SpeedType {knots, mph}