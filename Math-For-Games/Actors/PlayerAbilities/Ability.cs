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
        /// Stores how long the ability will be 
        /// </summary>
        private float _abilityDuration;

        /// <summary>
        /// Allows inherriting abilities to use the player
        /// </summary>
        public Player Player
        {
            get { return _player; }
            set { _player = value; }
        }

        public float AbilityDuration
        {
            get { return _abilityDuration; }
        }

        public float AbilityTimer
        {
            get { return _abilityTimer; }
            set { _abilityTimer = value; }
        }

        public Ability(Player player, Vector4 abilityColor, float abilityScale, float abilityCollisionRadius, float abilitySpeed, float abilityDuration)
        {
            _player = player;
            _abilityColor = abilityColor;
            _abilityScale = abilityScale;
            _abilityCollisionRadius = abilityCollisionRadius;
            _abilitySpeed = abilitySpeed;
            _abilityDuration = abilityDuration;
        }

        public void Start()
        {
            _player.SetColor(_abilityColor);
            _player.Speed = _abilitySpeed;
            _player.SetScale(_abilityScale, _abilityScale, _abilityScale);
            _abilityTimer = 0;
        }

        public virtual void Update(float deltaTime)
        {
        }

        public void End() 
        {
            _player.ResetStats();
            _player.TimeBetweenAbilities = 0;
            _player.CurrentAbility = null;
        }


    }
}
