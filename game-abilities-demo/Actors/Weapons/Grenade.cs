using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;

namespace GameAbilitiesDemo
{
    class Grenade : Actor
    {
        private float _speed;
        private Actor _owner;
        private Vector3 _moveDirection;
        private Vector3 _velocity;
        //The gravity that is applied to the grenade
        private Vector3 _gravity = new Vector3(0, -0.05f, 0);
        /// <summary>
        /// How high the grenade will be thrown
        /// </summary>
        private float _throwHeight;

        public Grenade(float speed, float throwHeight, Actor owner)
           : base(owner.WorldPosition, Shape.SPHERE, Color.BLACK, "Grenade")
        {
            _speed = speed;
            _moveDirection = new Vector3(owner.Forward.X, 0, owner.Forward.Z);
            _owner = owner;
            _throwHeight = throwHeight;
            //Adds the grenade to the current scene
            Engine.CurrentScene.AddActor(this);
        }

        /// <summary>
        /// Called when the grenade is added to the scene
        /// Initializes variables and calls the base start function
        /// </summary>
        public override void Start()
        {

            SetScale(0.3f, 0.3f, 0.3f);

            //Sets the velocity's Y axis the be the throw height
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
            //Sets the velocity to be the the last velocity and then applies gravity every frame
            _velocity = _moveDirection.Normalized * _speed * deltaTime + new Vector3(0, _velocity.Y, 0);
            ApplyGravity();
            
            //If the grenade touches the ground, call its end function
            if (WorldPosition.Y <= -1)
                End();

            //Translates the gravity by the velocity and updates its position
            base.Translate(_velocity.X, _velocity.Y, _velocity.Z);
            base.Update(deltaTime);
        }

        /// <summary>
        /// Applies gravity to the grenade's velocity
        /// </summary>
        public void ApplyGravity()
        {
            //If the grenade is not on the ground, apply gravity to it's velocity...
            if (!IsGrounded())
                _velocity += _gravity;
            //...otherwise set it's velocity on the y axis to be zero
            else _velocity = new Vector3(_velocity.X, 0, _velocity.Z);
           
        }

        /// <summary>
        /// Checks if the grenade is grounded
        /// </summary>
        /// <returns>Returns true if the grenade is grounded</returns>
        public bool IsGrounded()
        {
            if (WorldPosition.Y > -1)
                return false;
            else return true;
        }

        /// <summary>
        /// Called when the grenade ends
        /// </summary>
        public override void End()
        {
            //Creates a new grenade explosion, adds it to the scene, and deletes the grenade
            GrenadeExplosion grenadeExplosion = new GrenadeExplosion(this, 5);
            Engine.CurrentScene.AddActor(grenadeExplosion);
            DestroySelf();
        }
    }
}
