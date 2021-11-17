using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGamesAssessment
{
    class Enemy : Character
    {
        private Actor _actorToChase;
        /// <summary>
        /// Stores how many enemies are in the scene
        /// </summary>
        public static int EnemyCount;
        public static int EnemiesKilled;
        /// <summary>
        /// The time that has passed since the last shot was taken
        /// </summary>
        private float _timeBetweenShots;
        /// <summary>
        /// The time the enemy will wait between shots
        /// </summary>
        private float _cooldownTime;

        public Enemy(float x, float y, float z, float speed, int health, Actor actor, float cooldownTime,
            Color color, string name = "Enemy", Shape shape = Shape.SPHERE)
            : base(x, y, z, speed, health, color, name, shape)
        {
            _actorToChase = actor;
            Tag = ActorTag.ENEMY;
            _cooldownTime = cooldownTime;
        }

        /// <summary>
        /// Called when the enemy is added to the scene
        /// </summary>
        public override void Start()
        {
            SetScale(1, 1, 1);
            EnemyCount++;
            //Assigns the enemy a collider
            CircleCollider enemyCollider = new CircleCollider(1, this);
            base.Start();
        }

        /// <summary>
        /// Called every frame
        /// </summary>
        /// <param name="deltaTime">The time that has passed between frames</param>
        public override void Update(float deltaTime)
        {
            _timeBetweenShots += deltaTime;

            //If there is no actor to chase, return
            if (_actorToChase == null)
                return;
            //Gets the direction of the actor to chase
            Vector3 moveDirection = _actorToChase.LocalPosition - LocalPosition;

            //Sets the enemy's velocity
            Velocity = moveDirection.Normalized * Speed * deltaTime;

            //If the target is near the enemy...
            if (IsTargetNear())
                //Move towards them at full speed
                Translate(Velocity.X, Velocity.Y, Velocity.Z);
            else
            {
                //otherwise move towards them at half speed
                base.Translate(Velocity.X * 0.5f, Velocity.Y * 0.5f, Velocity.Z * 0.5f);
            }
            //If the time between shots is greater than or equal to the shot cooldown, and the target is not near the enemy...
            if (_timeBetweenShots >= _cooldownTime && !IsTargetNear())
            {
                //Look at the actor, and then shoot at them
                LookAt(_actorToChase.WorldPosition);
                Vector3 directionOfBullet = (_actorToChase.LocalPosition - LocalPosition).Normalized;
                _timeBetweenShots = 0;
                Bullet bullet = new Bullet(10, this);
            }

            base.Update(deltaTime);
        }

        /// <summary>
        /// Called when an enemy ends
        /// </summary>
        public override void End()
        {
            EnemyCount--;
        }

        /// <summary>
        /// Checks to see if the actor to chase is near the enemy
        /// </summary>
        /// <returns>True or false depending if the enemy is near</returns>
        public bool IsTargetNear()
        {
            //Gets the distance of the target actor from the enemy's position
            float distanceOfTarget = Vector3.GetDistance(_actorToChase.WorldPosition, WorldPosition);

            //Returns true if the distance is less than 5
            return distanceOfTarget < 10;
        }

        //Called on collision with another actor
        public override void OnCollision(Actor actor)
        {
        }

        public override void Draw()
        {
            base.Draw();
            //if (Collider != null)
                //Collider.Draw();
        }
    }
}
