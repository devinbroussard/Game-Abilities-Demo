using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;

namespace MathForGamesAssessment
{
    class GrenadeExplosion : Actor
    {
        private Grenade _grenade;
        private float _blastRadius;

        public GrenadeExplosion(Grenade owner, float blastRadius)
            :base(owner.WorldPosition, Shape.NULL, Color.BLANK, "Grenade Explosion")
        {
            _grenade = owner;
            _blastRadius = blastRadius;
        }

        public override void Start()
        {
            Color smokeColor = Raylib.ColorAlpha(Color.GRAY, 0.5f);
            base.Start();
            CircleCollider blastRadius = new CircleCollider(_blastRadius, this);
            Actor grenadeSmoke = new Actor(new Vector3(WorldPosition.X + 1, WorldPosition.Y + 5, WorldPosition.Z), Shape.SPHERE, smokeColor);
            AddChild(grenadeSmoke);

            Engine.CurrentScene.AddActor(grenadeSmoke);
        }

    }
}
