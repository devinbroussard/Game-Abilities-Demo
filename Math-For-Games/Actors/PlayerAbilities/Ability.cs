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

        public Ability(Player player, Vector4 abilityColor, abilityScale, abilityCollisionRadius, abilitySpeed, abilityTimer)
        {
            _player = player;
        }

        public void Start()
        {
            _player.SetColor(_abilityColor);
            _player.Speed = _abilitySpeed;
            _player.SetScale(_abilityScale, _abilityScale, _abilityScale);
            _abilityTimer = 0;
        }

        public void Update()
        {
            if (_abilityTimer > )
        }

        public void End() { }


    }
}
