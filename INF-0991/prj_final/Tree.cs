/// <summary>
/// Is a parent class that generates the element Tree in the map, it's an obstacle and also a rechargeable element.
/// </summary>
public class Tree : Obstacle, Rechargeable {

    public Tree() : base("$$ ") {}

    public void Recharge(Robot robot) 
    {
        robot.energy+= 3;
    }

}