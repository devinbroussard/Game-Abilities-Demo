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
        private float _smokeTimer;

        public GrenadeExplosion(Grenade owner, float blastRadius)
            :base(new Vector3(owner.WorldPosition.X, owner.WorldPosition.Y + 4, owner.WorldPosition.Z), Shape.SPHERE, Raylib.ColorAlpha(Color.LIGHTGRAY, 0.7f), "Grenade Explosion")
        {
            _blastRadius = blastRadius;
        }

        public override void Start()
        {
            base.Start();
            SetScale(_blastRadius, _blastRadius, _blastRadius);
            CircleCollider blastRadius = new CircleCollider(_blastRadius, this);
        }

        public override void Update(float deltaTime)
        {
            _smokeTimer += deltaTime;

            if (_smokeTimer > 4)
            {
                DestroySelf();
            }

            base.Update(deltaTime);
        }

        /// <summary>
        /// Is called on collision with another actor
        /// </summary>
        /// <param name="actor">The actor that a collision was made with</param>
        public override void OnCollision(Actor actor)
        {
            //If the actor is a player...
            if (actor.Tag == ActorTag.PLAYER)
            {
                //Make the player destroy themself, and tell them that they died
                actor.DestroySelf();
                UIText loseText = new UIText(0, Raylib.GetMonitorHeight(1) - 100, 10, Shape.CUBE, "Lose Text", Color.WHITE, 800, 200, 50, "You killed yourself!");
                Engine.CurrentScene.AddUIElement(loseText);

                //Calls this actor's destroy function
                DestroySelf();
            }
            //If the actor is an enemy...
            else if (actor.Tag == ActorTag.ENEMY)
            {
                //Cast this actor as an enemy...
                Enemy enemy = (Enemy)actor;
                //...then call the actor's end function and make the actor destroy themself
                enemy.End();
                actor.DestroySelf();
                Enemy.EnemiesKilled++;

                //Calls this actor's destroy function
                DestroySelf();
            }      
            
        }
    } 
}
