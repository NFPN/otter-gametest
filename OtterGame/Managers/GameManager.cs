using Otter;
using OtterGameSetup.Entities;
using OtterGameSetup.Managers;
using OtterGameSetup.Utils;
using System.Collections.Generic;

namespace OtterGameSetup
{
    public class GameManager
    {
        public Dictionary<string, Scene> GameScenes { get; private set; }
        public PickupItemSpawnManager SpawnManager { get; private set; }
        public UIManager UImanager { get; private set; }

        private Game MainGame { get; set; }
        private int Score { get; set; }

        public GameManager()
        {
            MainGame = new Game("The Collector", Global.WINDOWWIDTH, Global.WINDOWHEIGHT);
            UImanager = new UIManager(MainGame);
            SpawnManager = new PickupItemSpawnManager(MainGame);
            GameScenes = new Dictionary<string, Scene>()
            {
                { "Game",new CustomScene() },
            };

            foreach (var sceneItem in GameScenes)
                MainGame.AddScene(sceneItem.Value);

            //Setup Scenes
            SetupGameScene();
        }

        public void StartGame() => MainGame.Start();

        public void AddScore(int value)
        {
            Score += value;
            UImanager.ChangeScoreText(Score.ToString());
        }

        private void SetupGameScene()
        {
            GameScenes.TryGetValue("Game", out Scene scene);
            var player = new Player(MainGame, name: "Collector");

            //Add scene Graphics
            scene.AddGraphic(UImanager.GameScore);

            //Add scene Entities
            scene.Add(player);
            foreach (var pickupItem in SpawnManager.PickupItems)
                scene.Add(pickupItem);
        }
    }
}