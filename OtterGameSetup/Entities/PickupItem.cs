using Otter;

namespace OtterGameSetup.Entities
{
    public class PickupItem : Entity
    {
        public int ItemRadius { get; private set; } = 5;

        public PickupItem(float x = 0, float y = 0, Graphic graphic = null, Collider collider = null, string name = "")
            : base(x, y, graphic, collider, name)
        {
            Graphic = graphic ?? Image.CreateCircle(ItemRadius, Color.Green);
            Collider = new CircleCollider(ItemRadius, Tag.PickupItem);

            Graphic.CenterOrigin();
            Collider.CenterOrigin();
        }

        public override void Update()
        {
            if (Collider.Overlap(X, Y, Tag.Player)) // TODO: This should be at Player for better performance
            {
                RemoveSelf();

                if (Program.Manager != null)
                    Program.Manager.AddScore(10);
            }

            base.Update();
        }

        public override void Render()
        {
            // Uncomment the following line to see the collider.
            Collider.Render();

            base.Render();
        }
    }
}