using Otter;
using OtterGameSetup.Entities;

namespace OtterGameSetup
{
    public class Program
    {
        static public GameManager Manager { get; private set; }

        private static void Main(string[] args)
        {
            //TODO: Put all logic below into a separate class

            Manager = new GameManager().InitializeGame();
            var player = new Player(Manager.MainGame, name: "Collector");

            //Game Handlers
            Manager.GameScenes.TryGetValue("Game", out Scene scene);

            //Scene Entities
            scene.Add(player);
            foreach (var pickupItem in Manager.SpawnManager.PickupItems)
                scene.Add(pickupItem);

            //Scene Graphics
            scene.AddGraphic(Manager.UImanager.GameScore);

            //Game Start
            Manager.MainGame.Start(scene);
        }
    }
}