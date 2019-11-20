using Otter;
using OtterGame;
using OtterGame.Entities;
using OtterGame.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtterGameSetup.Entities
{
    class Enemy : Entity
    {
        private Entity Target { get; set; }

        public Enemy(Vector2 Size, float x = 0, float y = 0, Graphic graphic = null, Collider collider = null, string name = "") 
            : base(x, y, graphic, collider, name)
        {
            X = Global.WINDOWWIDTH /2;
            Y = -5;
            Collider = new BoxCollider((int)Size.X, (int)Size.Y, Tag.Enemy);
            Collider.CenterOrigin();
            Graphic.CenterOrigin();
        }

        public override void Update()
        {
            if (Target == null)
                return;

            base.Update();
        }

        public void AddTarget(Entity targetEntity)
        {
            Target = targetEntity;
        }
    }
}
