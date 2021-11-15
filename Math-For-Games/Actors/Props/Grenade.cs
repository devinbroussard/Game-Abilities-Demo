using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;

namespace MathForGamesAssessment
{
    class Grenade : Actor
    {
        private float _speed;
        private Actor _owner;
        private Vector3 _moveDirection;
        private Vector3 _velocity;
        private Vector3 _gravity = new Vector3(0, -0.05f, 0);
        private float _throwHeight;

        public Grenade(float speed, float throwHeight, Actor owner)
           : base(owner.WorldPosition, Shape.SPHERE, Color.BLACK, "Grenade")
        {
            _speed = speed;
            _moveDirection = new Vector3(owner.Forward.X, 0, owner.Forward.Z);
            _owner = owner;
            _throwHeight = throwHeight;
            Engine.CurrentScene.AddActor(this);
        }

        public override void Start()
        {
            SetScale(0.3f, 0.3f, 0.3f);
            CircleCollider grenadeCollider = new CircleCollider(0.3f, this);

            _velocity = new Vector3(0, _throwHeight, 0);
            Translate(0, 0.6f, 0);

            base.Start();
        }

        /// <summary>
        /// Called every frame to update the bullet
        /// </summary>
        /// <param name="deltaTime"></param>
        public override void Update(float deltaTime)
        {
            _velocity = _moveDirection.Normalized * _speed * deltaTime + new Vector3(0, _velocity.Y, 0);
            ApplyGravity();
        
            base.Translate(_velocity.X, _velocity.Y, _velocity.Z);

            base.Update(deltaTime);


            if (WorldPosition.Y <= -1)
                End();


        }

        public void ApplyGravity()
        {
            if (!IsGrounded())
            {
                _velocity += _gravity;
            }
            else
            {
                _velocity = new Vector3(_velocity.X, 0, _velocity.Z);
            }
        }
        public bool IsGrounded()
        {
            if (WorldPosition.Y > -10)
                return false;
            else return true;
        }

        public override void End()
        {
            GrenadeExplosion grenadeExplosion = new GrenadeExplosion(this, 10);
            Engine.CurrentScene.AddActor(grenadeExplosion);
            DestroySelf();
        }
    }
}
