using Otter;

namespace OtterGameSetup.Entities
{
    public class PickupItem : Entity
    {
        public PickupItem(float x = 0, float y = 0, Graphic graphic = null, Collider collider = null, string name = "")
            : base(x, y, graphic, collider, name)
        {
            Graphic = graphic ?? Image.CreateCircle(5, Color.Green);
        }

        
    }
}