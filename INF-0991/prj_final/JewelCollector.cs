/// <summary>
/// This class is the principal, it has the entry point of the program.
/// Creates the map, the robot and catch the 
/// </summary>
public class JewelCollector {
    delegate void Move (char move);
    static event Move OnMove;

    /// <summary>
    /// Entry point of the program
    /// </summary>
    public static void Main () {

        int width = 10, height = 10, level = 1;

        while (true) {
            Console.WriteLine ($"Level: {level}");
            Map map = new Map (width, height, level);

            Robot robot = new Robot (map);

            try {
                bool Result = true;
                Result = Run (robot, level);

                if (Result) {
                    width++;
                    height++;
                    level++;
                } else {
                    Environment.Exit (0);
                }
            } catch (Exception e) {
                Console.WriteLine ("Robot without energy!");
            }

        }

    }

    private static bool Run (Robot robot, int level) {

        OnMove += robot.Move;

        do {

            if (!robot.HasEnergy ()) {
                Console.WriteLine ("The Game is over because you're without energy!");
                Environment.Exit (0);
            }

            robot.PrintRobot (level);

            Console.WriteLine ("Please, type a direction to move: ");
            ConsoleKeyInfo command = Console.ReadKey (true);

            switch (command.Key.ToString ()) {
                case "W":
                    OnMove ('w');
                    break;
                case "S":
                    OnMove ('s');
                    break;
                case "D":
                    OnMove ('d');
                    break;
                case "A":
                    OnMove ('a');
                    break;
                case "G":
                    robot.Get ();
                    break;
                case "Escape":
                    return false;
                default:
                    Console.WriteLine (command.Key.ToString ());
                    break;
            }

        } while (!robot.map.Finished ());

        return true;

    }

}