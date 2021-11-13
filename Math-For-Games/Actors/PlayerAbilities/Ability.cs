using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;

namespace MathForGamesAssessment
{
    class Ability
    {
        private Player _player;
        private Vector4 _abilityColor;
        private float _abilityScale;
        private float _abilityCollisionRadius;
        private float _abilitySpeed;
        private float _abilityTimer;
        private float _abilityDuration;

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
        }

        public Ability(Player player, Vector4 abilityColor, float abilityScale, float abilityCollisionRadius, float abilitySpeed, float abilityTimer, float abilityDuration)
        {
            _player = player;
            _abilityColor = abilityColor;
            _abilityScale = abilityScale;
            _abilityCollisionRadius = abilityCollisionRadius;
            _abilitySpeed = abilitySpeed;
            _abilityTimer = abilityTimer;
            _abilityDuration = abilityDuration;
        }

        public void Start()
        {
            _player.SetColor(_abilityColor);
            _player.Speed = _abilitySpeed;
            _player.SetScale(_abilityScale, _abilityScale, _abilityScale);
            _abilityTimer = 0;
        }

        public virtual void Update()
        {
        }

        public void End() { }


    }
}
