using Otter;

namespace OtterGame.Utils
{
    public class CustomScene : Scene
    {
        public Music SceneBGM { get; private set; }

        public CustomScene(string bgmFilePath = null, int width = Global.WINDOWWIDTH, int height = Global.WINDOWHEIGHT)
            : base(width, height)
        {
            if (!string.IsNullOrWhiteSpace(bgmFilePath))
            {
                SceneBGM = new Music(bgmFilePath);
                SceneBGM.Play();
            }
        }
    }
}