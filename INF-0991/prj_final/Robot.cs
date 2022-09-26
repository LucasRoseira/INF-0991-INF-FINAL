public class Robot : Entity {
    /// <summary>
    ///  This is parent class from entity, the robot has four arguments
    /// the map, x position, y position and his energy
    /// </summary>
    public Robot (Map map, int x = 0, int y = 0, int energy = 5) : base ("ME ") {
        this.map = map;
        this.x = x;
        this.y = y;
        this.energy = energy;

        this.map.InsertEntity (this, x, y);
    }

    /// <summary>
    /// this variable is used to store the robot energy in the program
    /// </summary>
    /// <value></value>
    public int energy { get; set; }
    /// <summary>
    /// we craete  a map in the robot because he is intereacting with it all the time
    /// </summary>
    /// <value></value>
    public Map map { get; private set; }
    private int x, y;
    private List<Jewel> Bag = new List<Jewel> ();

    /// <summary>
    ///Is used to select the movement of the robot and call TryToMove function that is going to move the robot 
    /// </summary>
    /// <param name="move"></param>
    public void Move (char move) {

        if (move == 'w') {
            TryToMove (move, this.x - 1, this.y);
        } else if (move == 's') {
            TryToMove (move, this.x + 1, this.y);
        } else if (move == 'd') {
            TryToMove (move, this.x, this.y + 1);
        } else if (move == 'a') {
            TryToMove (move, this.x, this.y - 1);
        }

    }

    private void TryToMove (char move, int posX, int posY) {

        try {

            this.energy--;
            if (move == 'w') {
                map.UpdateMap (this.x, this.y, posX, posY);
                this.x--;
            } else if (move == 's') {
                map.UpdateMap (this.x, this.y, posX, posY);
                this.x++;
            } else if (move == 'd') {
                map.UpdateMap (this.x, this.y, posX, posY);
                this.y++;
            } else if (move == 'a') {
                map.UpdateMap (this.x, this.y, posX, posY);
                this.y--;
            }

        } catch (Exception e) {
            Console.WriteLine ($"Position is prohibit.");
            Thread.Sleep (1000);
        }
    }

    /// <summary>
    /// Get entities in the map, is used to get jewels or to recharge the robot
    /// </summary>
    public void Get () {
        Console.Clear ();
        Rechargeable? RechargeEnergy = map.GetRechargeable (this.x, this.y);

        RechargeEnergy?.Recharge (this);
        List<Jewel> NearJewels = map.GetJewels (this.x, this.y);

        foreach (Jewel jewel in NearJewels) {
            Bag.Add (jewel);

        }

    }

    private (int, int) GetBag () {
        int Points = 0;
        foreach (Jewel jewel in this.Bag)
            Points += jewel.Points;

        return (this.Bag.Count, Points);

    }

    /// <summary>
    /// Print the robot in the map and also print the status of the game
    /// </summary>
    /// <param name="level"></param>
    public void PrintRobot (int level) {
        map.PrintMap ();

        (int ItensBag, int TotalPoints) = this.GetBag ();
        Console.WriteLine ($"Itens in the Bag: {ItensBag} \nTotal Points: {TotalPoints} ");
        Console.WriteLine ($"Energy: {this.energy} \nLevel: {level}");
    }
    
    /// <summary>
    /// verify if the robot has energy
    /// </summary>
    /// <returns>True or false</returns>
    public bool HasEnergy () {
        return this.energy > 0;
    }

}