using Otter;
using OtterGameSetup.Entities;

namespace OtterGameSetup
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var game = new GameManager().InitializeGame();
            var player = new Player(game.MainGame, name: "Collector");

            //Game Handlers
            game.GameScenes.TryGetValue("Game", out Scene scene);

            //Scene Entities
            scene.Add(player);
            foreach (var pickupItem in game.SpawnManager.PickupItems)
                scene.Add(pickupItem);

            //Scene Graphics
            scene.AddGraphic(game.UImanager.GameScore);

            //Game Start
            game.MainGame.Start(scene);
        }
    }
}