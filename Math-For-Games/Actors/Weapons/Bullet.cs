using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;

namespace MathForGamesAssessment
{
    class Bullet : Actor
    {
        private float _speed;
        private Vector3 _velocity;
        /// <summary>
        /// Variable used to track the time that the bullet has been alive in the scene
        /// </summary>
        private float _timeAlive;
        private Vector3 _moveDirection;
        private Actor _owner;

        /// <summary>
        /// The actor that fired this bullet
        /// </summary>
        public Actor Owner
        {
            get { return _owner; }
        }

        /// <summary>
        /// The direction that the bullet is moving
        /// </summary>
        public Vector3 MoveDirection
        {
            get { return _moveDirection; }
            set { _moveDirection = value; }
        }

        /// <summary>
        /// Called whenever a new instance is created
        /// </summary>
        /// <param name="speed">Sets the speed of the bullet</param>
        /// <param name="owner">Sets the owner of the bullet</param>
        public Bullet( float speed, Actor owner)
            : base(owner.WorldPosition, Shape.SPHERE, Color.YELLOW, "Bullet")
        {
            _speed = speed;
            MoveDirection = owner.Forward;
            _owner = owner;
            //Adds this bullet to the scene
            Engine.CurrentScene.AddActor(this);
        }

        /// <summary>
        /// Called whenever a new bullet is added to the scene
        /// </summary>
        public override void Start()
        {
            //Sets the scale of the bullet
            SetScale(0.3f, 0.3f, 0.3f);
            //Adds a collider to the bullet
            CircleCollider bulletCollider = new CircleCollider(0.4f, this);

            //Calls the actor's start function
            base.Start();
        }

        /// <summary>
        /// Called every frame to update the bullet
        /// </summary>
        /// <param name="deltaTime"></param>
        public override void Update(float deltaTime)
        {
            //Adds the delta time to the time that the bullet has been alive in the scene
            _timeAlive += deltaTime;

            //If the time that the bullet has been alive reaches or goes over one second...
            if (_timeAlive >= 3 || WorldPosition.Y <= -0.1f)
            {
                //...destroy the bullet...
                base.DestroySelf();
                //...and leave the function
                return;
            }

            _velocity = MoveDirection.Normalized * _speed * deltaTime;


            base.Translate(_velocity.X, _velocity.Y, _velocity.Z);

            base.Update(deltaTime);
        }

        /// <summary>
        /// Gets called on collision with an actor
        /// </summary>
        /// <param name="actor">The actor that a collision occured with</param>
        public override void OnCollision(Actor actor)
        {
            //If the actor is an enemy and is not THIS actor...
            if (actor.Tag == ActorTag.ENEMY && Owner.Tag != ActorTag.ENEMY)
            {
                //...cast the actor as an enemy...
                Enemy enemy = (Enemy)actor;

                //...If the enemy's health is above 0...
                if (enemy.Health > 0)
                    //...Tell the enemy to take damage
                    enemy.Health--;

                //...If the enemy's health is 0...
                if (enemy.Health == 0)
                {
                    Enemy.EnemiesKilled++;
                    //Decrement the static enemy count...
                    Enemy.EnemyCount--;
                    //...and destroy the enemy;
                    enemy.DestroySelf();
                }

                DestroySelf();
            }
            //Otherwise, if the actor is a player, and the owner isn't a player...
            else if (actor.Tag == ActorTag.PLAYER && Owner.Tag != ActorTag.PLAYER)
            {
                //...cast the actor as a player
                Player player = (Player)actor;

                //If the player's health is above zero
                if (player.Health > 0 && player.LastHitTime > 1)
                {
                    player.TakeDamage();
                }
                if (player.Health <= 0)
                {
                    actor.DestroySelf();
                    UIText loseText = new UIText(0, 20, 10, Shape.CUBE, "Lose Text", Color.WHITE, 200, 200, 50, "You died!");
                    Engine.CurrentScene.AddUIElement(loseText);
                }

                DestroySelf();
            }
            else if (actor.Tag == ActorTag.BULLET && Owner.Tag != actor.Tag)
            {
                DestroySelf();
            }
        }

        //public override void Draw()
        //{
        //    base.Draw();
        //    Collider.Draw();
        //}
    }
}