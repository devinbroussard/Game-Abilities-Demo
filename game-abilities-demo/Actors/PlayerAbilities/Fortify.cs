using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace GameAbilitiesDemo
{
    class Fortify : Ability
    {
        public Fortify(Player player, Vector4 color, float scale, float speed, float duration)
            : base(player, color, duration)
        {
            AbilityScale = scale;
            AbilitySpeed = speed;
        }

        /// <summary>
        /// Called when this ability starts
        /// </summary>
        public override void Start()
        {
            Player.ShotCooldown = 0.05f;
            base.Start();

            Player.SetScale(AbilityScale, AbilityScale, AbilityScale);
            Player.Speed = AbilitySpeed;
        }

        /// <summary>
        /// Called every frame while this ability is active
        /// </summary>
        /// <param name="deltaTime"></param>
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
