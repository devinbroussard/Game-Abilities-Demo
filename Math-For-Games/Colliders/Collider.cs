using System;
using System.Collections.Generic;
using System.Text;

namespace MathForGamesAssessment
{
    /// <summary>
    /// Stores the different types of colliders
    /// </summary>
    enum ColliderType
    {
        CIRCLE,
        AABB
    }

    abstract class Collider
    {
        private Actor _owner;
        private ColliderType _colliderType;

        /// <summary>
        /// Actor that the collider is attached to
        /// </summary>
        public Actor Owner 
        {
            get { return _owner; }
            set { _owner = value; }
        }
        
        /// <summary>
        /// Type of collider that this is
        /// </summary>
        public ColliderType ColliderType
        {
            get { return _colliderType; }
            set { _colliderType = value; }
        }


        /// <param name="owner">Actor that the collider is attached to</param>
        /// <param name="colliderType">Type of collider that this is</param>
        public Collider(Actor owner, ColliderType colliderType)
        {
            _owner = owner;
            _colliderType = colliderType;
        }

        /// <summary>
        /// Checks for collision with another collider
        /// </summary>
        /// <param name="other">The other collider</param>
        /// <returns>True or false depending on whether or not a collision occured</returns>
        public bool CheckCollision(Actor other)
        {
            if (other.Collider.ColliderType == ColliderType.CIRCLE)
                return CheckCollisionCircle((CircleCollider)other.Collider);

            else if (other.Collider.ColliderType == ColliderType.AABB)
                return CheckCollisionAABB((AABBCollider)other.Collider);

            return false;
        }

        /// <summary>
        /// Checks for collision with a circle collider
        /// Made virtual because the process is different depending on what type of collider it is
        /// </summary>
        /// <param name="other">The circle collider</param>
        /// <returns>False by default so other classes can inherit</returns>
        public virtual bool CheckCollisionCircle(CircleCollider other)
        { return false; }

        /// <summary>
        /// Checks for collision with an AABB collider
        /// Made virtual because the process is different depending on what type of collider it is
        /// </summary>
        /// <param name="other">The circle collider</param>
        public virtual bool CheckCollisionAABB(AABBCollider other)
        { return false; }
    }
}
