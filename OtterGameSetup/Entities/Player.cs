using Otter;

namespace OtterGameSetup.Entities
{
    public class Player : Entity
    {
        public int MoveSpeed { get; private set; } = 5;
        public Vector2 PlayerSize { get; private set; } = new Vector2(25, 25);

        private BoxCollider playerCollider { get; set; }

        //Base Player, Instancing with x & y empty will make the player spaw at the center of screen
        public Player(Game currentGame, float posX = 0, float posY = 0, Graphic graphic = null, Collider collider = null, string name = "")
            : base(posX, posY, graphic, collider, name)
        {
            var pX = (int)PlayerSize.X;
            var pY = (int)PlayerSize.Y;

            X = posX == 0 ? currentGame.HalfWidth : 0;
            Y = posY == 0 ? currentGame.HalfHeight : 0;

            Collider = new BoxCollider(pX, pY, Tag.Player);
            Graphic = graphic ?? Image.CreateRectangle(pX, pY, Color.Blue);

            Graphic.CenterOrigin();
            Collider.CenterOrigin();
        }

        public override void Update()
        {
            if (Input.KeyDown(Key.W) && !Input.KeyDown(Key.S)) //Inverse Y value
                Y -= MoveSpeed;
            if (Input.KeyDown(Key.S) && !Input.KeyDown(Key.W))
                Y += MoveSpeed;
            if (Input.KeyDown(Key.D) && !Input.KeyDown(Key.A))
                X += MoveSpeed;
            if (Input.KeyDown(Key.A) && !Input.KeyDown(Key.D))
                X -= MoveSpeed;

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