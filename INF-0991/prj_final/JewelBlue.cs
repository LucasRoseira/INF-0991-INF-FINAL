/// <summary>
/// This parent class is used to generate a blue jewel in the map that is rechargeable
/// </summary>
public class JewelBlue : Jewel, Rechargeable {
    /// <summary>
    /// Defines the symbol and the value of the Blue jewel
    /// </summary>
    /// <returns>Symbol JB and value 10. </returns>
    public JewelBlue () : base ("JB ", 10) {

    }
    /// <summary>
    /// Recharge the robot if he catches the jewel.
    /// </summary>
    /// <param name="robot">Energy receiveis +5</param>
    public void Recharge (Robot robot) {
         robot.energy += 5;
    }
}