namespace OtterGameSetup
{
    public class Program
    {
        static public GameManager Manager { get; private set; }

        private static void Main(string[] args)
        {
            Manager = new GameManager();
            Manager.StartGame();
        }
    }
}