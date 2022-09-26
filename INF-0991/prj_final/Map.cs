/// <summary>
/// This one of the most principal class of the program.
/// Print the map.
/// Creates a fixed map in the first level and random maps in the next levels.
/// Update the map.
/// </summary>/
public class Map {

    private Entity[, ] Matrix;
    /// <summary>
    /// Height is pulic beucause it's used everywhere in the class.
    /// </summary>
    /// <value>its value is incremented by one if the player win the level.</value>
    public int height { get; private set; }
    /// <summary>
    /// Width is pulic beucause it's used everywhere in the class.
    /// </summary>
    /// <value>its value is incremented by one if the player win the level.</value>
    public int width { get; private set; }
    /// <summary>
    /// The map is fixed if the level is one
    /// The other levels are incremented by one if the player wins and it's a random map.
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="level"></param>
    public Map (int width = 10, int height = 10, int level = 1) {

        this.width = width < 31 ? width : 30;
        this.height = height < 31 ? height : 30;

        Matrix = new Entity[width, height];

        for (int i = 0; i < Matrix.GetLength (0); i++) {
            for (int j = 0; j < Matrix.GetLength (1); j++) {
                Matrix[i, j] = new Empty ();
            }
        }

        if (level == 1) {
            FixedMap ();
        } else {
            RandomMap (level);
        }

    }
    /// <summary>
    /// Just clear the screen, sleep and print the map.
    /// </summary>
    public void PrintMap () {
        Console.Clear ();
        Thread.Sleep (100);
        for (int i = 0; i < Matrix.GetLength (0); i++) {
            for (int j = 0; j < Matrix.GetLength (1); j++) {
                Console.Write (Matrix[i, j]);
            }
            Console.Write ("\n");
        }
    }

    private void FixedMap () {
        Console.Clear ();
        this.InsertEntity (new JewelRed (), 1, 9);
        this.InsertEntity (new JewelRed (), 8, 8);
        this.InsertEntity (new JewelGreen (), 9, 1);
        this.InsertEntity (new JewelGreen (), 7, 6);
        this.InsertEntity (new JewelBlue (), 3, 4);
        this.InsertEntity (new JewelBlue (), 2, 1);
        this.InsertEntity (new Water (), 5, 0);
        this.InsertEntity (new Water (), 5, 1);
        this.InsertEntity (new Water (), 5, 2);
        this.InsertEntity (new Water (), 5, 3);
        this.InsertEntity (new Water (), 5, 4);
        this.InsertEntity (new Water (), 5, 5);
        this.InsertEntity (new Water (), 5, 6);
        this.InsertEntity (new Tree (), 5, 9);
        this.InsertEntity (new Tree (), 3, 9);
        this.InsertEntity (new Tree (), 8, 3);
        this.InsertEntity (new Tree (), 2, 5);
        this.InsertEntity (new Tree (), 1, 4);
    }

    private void RandomMap (int level) {

        Random random = new Random (1);

        for (int x = 0; x < 3; x++) {
            int xRandom = random.Next (0, width);
            int yRandom = random.Next (0, height);

            this.InsertEntity (new JewelBlue (), xRandom, yRandom);
        }

        for (int x = 0; x < 3; x++) {
            int xRandom = random.Next (0, width);
            int yRandom = random.Next (0, height);

            this.InsertEntity (new JewelGreen (), xRandom, yRandom);

        }

        for (int x = 0; x < 3; x++) {
            int xRandom = random.Next (0, width);
            int yRandom = random.Next (0, height);

            this.InsertEntity (new JewelRed (), xRandom, yRandom);

        }
        for (int x = 0; x < 3; x++) {
            int xRandom = random.Next (0, width);
            int yRandom = random.Next (0, height);

            this.InsertEntity (new Tree (), xRandom, yRandom);

        }
        for (int x = 0; x < 6; x++) {
            int xRandom = random.Next (0, width);
            int yRandom = random.Next (0, height);

            this.InsertEntity (new Water (), xRandom, yRandom);

        }

        if (level >= 2) {
            for (int x = 0; x < 3; x++) {
                int xRandom = random.Next (0, width);
                int yRandom = random.Next (0, height);

                this.InsertEntity (new Radioactive (), xRandom, yRandom);

            }
        }

    }
    /// <summary>
    /// Clear the console, throws an exeption if the height or width is not respected and updates the map.
    /// </summary>
    /// <param name="x_old">The old x position.</param>
    /// <param name="y_old">The old y position.</param>
    /// <param name="x">The new x position.</param>
    /// <param name="y">The new y position.</param>
    public void UpdateMap (int x_old, int y_old, int x, int y) {
        Console.Clear ();
        if (x < 0 || y < 0 || x > this.width - 1 || y > this.height - 1) {
            throw new Exception ();
        }

        if (IsAllowed (x, y)) {
            Matrix[x, y] = Matrix[x_old, y_old];
            Matrix[x_old, y_old] = new Empty ();
        } else {
            throw new Exception ();
        }

    }
    /// <summary>
    /// Insert entities in the map receveis three parameters.
    /// </summary>
    /// <param name="Entity">Receives the type of the entity.</param>
    /// <param name="x">Receives the x of the entity.</param>
    /// <param name="y">Receives the y of the entity.</param>
    public void InsertEntity (Entity Entity, int x, int y) {
        Matrix[x, y] = Entity;
    }
    /// <summary>
    /// Is used to catch the jewels in the map and return them.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns>return the nearer jewels of the robot.</returns>
    public List<Jewel> GetJewels (int x, int y) {

        List<Jewel> NearJewels = new List<Jewel> ();

        int[, ] Coordenates = GenerateCoordenates (x, y);

        for (int i = 0; i < Coordenates.GetLength (0); i++) {

            Jewel? jewel = GetJewel (Coordenates[i, 0], Coordenates[i, 1]);

            if (jewel is not null) {
                NearJewels.Add (jewel);
            }

        }

        return NearJewels;

    }

    private Jewel? GetJewel (int x, int y) {

        if (Matrix[x, y] is Jewel jewel) {
            Matrix[x, y] = new Empty ();
            return jewel;
        }

        return null;
    }

    /// <summary>
    /// Is used to catch the rechargeable elements in the map and return them.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public Rechargeable? GetRechargeable (int x, int y) {

        int[, ] Coordenates = GenerateCoordenates(x, y);

        for (int i = 0; i < Coordenates.GetLength (0); i++)
            if (Matrix[Coordenates[i, 0], Coordenates[i, 1]] is Rechargeable rechargeable) {
                return rechargeable;
            }

        return null;

    }

    private int[, ] GenerateCoordenates (int x, int y) {
        int[, ] Coordenates = new int[4, 2] { 
            { x, y + 1 < width - 1 ? y + 1 : width - 1 }, 
            { x, y - 1 > 0 ? y - 1 : 0 }, 
            { x + 1 < height - 1 ? x + 1 : height - 1, y }, 
            { x - 1 > 0 ? x - 1 : 0, y }
        };

        return Coordenates;
    }

    private bool IsAllowed (int x, int y) {
        if (Matrix[x, y] is Empty) {
            return Matrix[x, y] is Empty;
        } else {
            return Matrix[x, y] is Radioactive;
        }

    }
    /// <summary>
    /// Verify if the map has jewels.
    /// </summary>
    /// <returns>return true or false</returns>
    public bool Finished () {
        for (int i = 0; i < Matrix.GetLength (0); i++) {
            for (int j = 0; j < Matrix.GetLength (1); j++) {
                if (Matrix[i, j] is Jewel) {
                    return false;
                }
            }
        }
        return true;
    }

}