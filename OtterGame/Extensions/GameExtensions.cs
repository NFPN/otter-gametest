using Otter;
using OtterGameSetup.Entities;

namespace OtterGameSetup.Extensions
{
    internal static class GameExtensions
    {
        public static PickupItem ChangePosition(this PickupItem item, Game currentGame)
        {
            var randPosition = Rand.IntXY(
                item.Graphic.Width, currentGame.Width - (item.Graphic.Width / 2),
                item.Graphic.Height, currentGame.Height - (item.Graphic.Height / 2));

            item.SetPosition(randPosition.X, randPosition.Y);
            return item;
        }
    }

    public enum Tag
    {
        Player,
        PickupItem,
    }
}