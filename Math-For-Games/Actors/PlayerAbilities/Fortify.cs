using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGamesAssessment
{
    class Fortify : Ability
    {
        public Fortify(Player player, Vector4 color, float scale, float speed, float duration)
            : base(player, color, duration)
        {
            AbilityScale = scale;
            AbilitySpeed = speed;
        }

        public override void Start()
        {
            Player.ShotCooldown = 0.05f;
            base.Start();

            Player.SetScale(AbilityScale, AbilityScale, AbilityScale);
            Player.Speed = AbilitySpeed;
        }

        public override void Update(float deltaTime)
        {
            if (AbilityTimer < AbilityDuration)
            {
                AbilityTimer += deltaTime;
                return;
            }

            base.End();
        }
    }
}
