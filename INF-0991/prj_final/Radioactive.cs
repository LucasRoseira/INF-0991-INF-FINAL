/// <summary>
/// Is a parent class that generates a radioactive obstacle in the map.
/// </summary>
public class Radioactive : Obstacle, Rechargeable {
    public Radioactive () : base ("!! ") { }
        public void Recharge(Robot robot) 
    {
        robot.energy-= 30;
    }

}