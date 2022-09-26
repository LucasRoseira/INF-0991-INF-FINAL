 /// <summary>
///  This is an abstract class used to help to generate jewels in the map and create point for them
/// </summary>
public abstract class Jewel : 
Entity {
    public int Points { get; private set; }
    public Jewel (string Symbol, int Points) : base (Symbol) {
        this.Points = Points;
    }

}