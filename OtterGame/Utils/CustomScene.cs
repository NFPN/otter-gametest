using Otter;

namespace OtterGameSetup.Utils
{
    public class CustomScene : Scene
    {
        public Music SceneBGM { get; set; }

        public CustomScene(string bgmFileName = null, int width = Global.WINDOWWIDTH, int height = Global.WINDOWHEIGHT)
            : base(width, height)
        {
            if (!string.IsNullOrWhiteSpace(bgmFileName))
            {
                SceneBGM = new Music(bgmFileName);
                SceneBGM.Play();
            }
        }
    }
}