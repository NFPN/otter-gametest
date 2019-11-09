using Otter;
using OtterGameSetup.Managers;
using System.Collections.Generic;

namespace OtterGameSetup
{
    public class GameManager
    {
        public Game MainGame { get; private set; }
        public Dictionary<string, Scene> GameScenes { get; private set; }
        public PickupItemSpawnManager SpawnManager { get; private set; }

        public int Score { get; private set; }

        public UIManager UImanager { get; private set; }

        public GameManager InitializeGame(int sizeX = 800, int sizeY = 600)
        {
            MainGame = new Game("The Collector", sizeX, sizeY);
            SpawnManager = new PickupItemSpawnManager(MainGame);
            UImanager = new UIManager(MainGame);
            GameScenes = new Dictionary<string, Scene>()
            {
                { "Menu",new Scene() },
                { "Game",new Scene() },
            };

            return this;
        }

        public void AddScore(int value)
        {
            Score += value;
            UImanager.ChangeScoreText(Score.ToString());
        }
    }

    public enum Tag
    {
        Player,
        PickupItem,
    }
}