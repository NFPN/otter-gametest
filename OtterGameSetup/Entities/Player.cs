using Otter;

namespace OtterGameSetup.Entities
{
    public class Player : Entity
    {
        public int MoveSpeed { get; private set; } = 5;

        //Base Player, Letting x & y empty will make the player spaw at the center of screen
        public Player(Game currentGame, float posX = 0, float posY = 0, Graphic graphic = null, Collider collider = null, string name = "")
            : base(posX, posY, graphic, collider, name)
        {
            X = posX == 0 ? currentGame.HalfWidth : 0;
            Y = posY == 0 ? currentGame.HalfHeight : 0;
            Graphic = graphic ?? Image.CreateRectangle(25, Color.Blue);
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

            //TODO: call pickupitem ChangePosition on collision, and AddScore

            base.Update();
        }
    }
}