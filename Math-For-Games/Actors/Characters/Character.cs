using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGamesAssessment
{
    class Character : Actor
    {
        private float _speed;
        private Vector3 _velocity;
        private Vector3 _gravity = new Vector3(0, -0.1f, 0);
        private int _health;

        /// <summary>
        /// A speed variable that the character's velocity is scaled by
        /// </summary>
        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }
        /// <summary>
        /// The vector3 that the character will be translated by
        /// </summary>
        public Vector3 Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }

        /// <summary>
        /// The health of the character
        /// </summary>
        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        /// <summary>
        /// The gravity that will be applied to the character
        /// Is constantly applied on the character's velocity
        /// </summary>
        public Vector3 Gravity
        {
            get { return _gravity; }
            set { _gravity = value; }
        }

        /// <summary>
        /// Applies gravity to the character
        /// </summary>
        public void ApplyGravity()
        {
            //If the character is not grounded..
            if (!IsGrounded())
            {
                //Add gravity the the player's current velocity
                Velocity += Gravity;
            }
            else
            {
                //otherwise, set the player's downward velocity to be 0
                Velocity = new Vector3(Velocity.X, 0, Velocity.Z);
            }
        }

        public Character(float x, float y, float z, float speed, int health, Color color, string name = "Character", Shape shape = Shape.SPHERE)
             : base(x, y, z, shape, color, name)
        {
            _health = health;
            _speed = speed;
            Velocity = new Vector3(0, 0, 0);
        }

        /// <summary>
        /// Determines whether or not the character is on the ground.
        /// </summary>
        /// <returns>True or false depending if the character is on the ground or not.</returns>
        public bool IsGrounded()
        {
            //If the player's position on the world transform is less than or equal to 1.5, return true
            if (WorldPosition.Y <= 1.5)
                return true;
            else return false;
        }
    }
}
