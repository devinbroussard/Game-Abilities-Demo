using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;

namespace MathForGamesAssessment
{
    class Ability
    {
        /// <summary>
        /// Stores the player that will do the ability
        /// </summary>
        private Player _player;
        /// <summary>
        /// Stores the color the player turns during the ability
        /// </summary>
        private Vector4 _abilityColor;
        /// <summary>
        /// Stores the size the player will scale to during the ability
        /// </summary>
        private float _abilityScale;
        /// <summary>
        /// Stores the player's hitbox size during the ability
        /// </summary>
        private float _abilityCollisionRadius;
        /// <summary>
        /// Stores the speed the player will have during the ability
        /// </summary>
        private float _abilitySpeed;
        /// <summary>
        /// Stores the time the ability has been active
        /// </summary>
        private float _abilityTimer;
        /// <summary>
        /// Stores how long the ability will be active
        /// </summary>
        private float _abilityDuration;

        /// <summary>
        /// The size the player will be during the ability
        /// </summary>
        public float AbilityScale
        {
            get { return _abilityScale; }
            set { _abilityScale = value; }
        }

        /// <summary>
        /// The collision radius of the player during the ability
        /// </summary>
        public float AbilityCollisionRadius
        {
            get { return _abilityCollisionRadius; }
            set { _abilityCollisionRadius = value; }
        }

        /// <summary>
        /// The speed of the player during the ability
        /// </summary>
        public float AbilitySpeed
        {
            get { return _abilitySpeed; }
            set { _abilitySpeed = value; }
        }

        /// <summary>
        /// Allows inherriting abilities to use the player
        /// </summary>
        public Player Player
        {
            get { return _player; }
            set { _player = value; }
        }

        /// <summary>
        /// How long the ability will last
        /// </summary>
        public float AbilityDuration
        {
            get { return _abilityDuration; }
        }

        /// <summary>
        /// How long has passed since the ability started
        /// </summary>
        public float AbilityTimer
        {
            get { return _abilityTimer; }
            set { _abilityTimer = value; }
        }

        /// <param name="player">The player that will use the actor</param>
        /// <param name="color">The color the player will turn during the ability</param>
        /// <param name="duration">The duration of the ability</param>
        public Ability(Player player, Vector4 color, float duration)
        {
            _player = player;
            _abilityColor = color;
            _abilityDuration = duration;
        }

        /// <summary>
        /// Called when the ability starts
        /// </summary>
        public virtual void Start()
        {
            _player.SetColor(_abilityColor);
            _abilityTimer = 0;
        }

        /// <summary>
        /// Called every frame while the ability is active
        /// </summary>
        /// <param name="deltaTime">The time that has passed between frames</param>
        public virtual void Update(float deltaTime)
        {
        }

        /// <summary>
        /// Called at the end of the ability
        /// </summary>
        public void End() 
        {
            _player.ResetStats();
            _player.TimeBetweenAbilities = 0;
            _player.CurrentAbility = null;
        }


    }
}
