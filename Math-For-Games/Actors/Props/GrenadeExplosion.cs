using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;

namespace MathForGamesAssessment
{
    class GrenadeExplosion : Actor
    {
        private float _blastRadius;
        private Actor[] _grenadeSmoke;
        private float _smokeTransparency;
        private Color _smokeColor;
        private float _smokeTimer;

        public GrenadeExplosion(Grenade owner, float blastRadius)
            :base(owner.WorldPosition, Shape.NULL, Color.BLANK, "Grenade Explosion")
        {
            _blastRadius = blastRadius;
        }

        public override void Start()
        {
            base.Start();
            CircleCollider blastRadius = new CircleCollider(_blastRadius, this);

            Actor grenadeSmoke = new Actor(new Vector3(WorldPosition.X, WorldPosition.Y + 2, WorldPosition.Z + 2), Shape.SPHERE, _smokeColor, "Smoke", ActorTag.SMOKE);
            grenadeSmoke.SetScale(_blastRadius, _blastRadius, _blastRadius);
            AddChild(grenadeSmoke);
            Engine.CurrentScene.AddActor(grenadeSmoke);
        }

        public override void Update(float deltaTime)
        {


            base.Update(deltaTime);
        }

        public override void Draw()
        {
            Raylib.DrawCircle3D(new System.Numerics.Vector3(WorldPosition.X, WorldPosition.Y, WorldPosition.Z), 
                _blastRadius, new System.Numerics.Vector3(0, 0, 0), 0, Raylib.ColorAlpha(Color.LIGHTGRAY, 0.7f));
        }

        public override void OnCollision(Actor actor)
        {
            if (actor.Tag == ActorTag.PLAYER)
            {
                actor.DestroySelf();

                UIText loseText = new UIText(300, 75, 10, Shape.CUBE, "Lose Text", Color.WHITE, 200, 200, 50, "You lose!");
                Engine.CurrentScene.AddUIElement(loseText);
                DestroySelf();
            }
            else if (actor.Tag == ActorTag.ENEMY)
            {
                Enemy enemy = (Enemy)actor;

                enemy.End();
                actor.DestroySelf();

                //If the enemy count is 0...
                if (Enemy.EnemyCount <= 0)
                {
                    //Create winText UI showing the player that they beat the game...
                    UIText winText = new UIText(Raylib.GetMonitorWidth(1) / 2, Raylib.GetMonitorHeight(1) / 2, 0, Shape.NULL, "Win Text", Color.WHITE, 200, 200, 50, "You won!");
                    //...and add the UI to the scene
                    Engine.CurrentScene.AddUIElement(winText);
                }

                DestroySelf();
            }      
            
        }
    } 
}
