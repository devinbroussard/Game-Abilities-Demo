using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;

namespace MathForGamesAssessment
{
    class Dash : Ability
    {

        public Dash(Player player, Vector4 abilityColor, float abilityScale, float abilityCollisionRadius, float abilitySpeed, float abilityDuration)
            : base(player, abilityColor, abilityScale, abilityCollisionRadius, abilitySpeed, abilityDuration)
        { }

        public override void Update(float deltaTime)
        {
            if (AbilityTimer < AbilityDuration)
            {
                Player.TimeBetweenShots = 0;
                AbilityTimer += deltaTime;
                return;
            }

            End();
        }


    }
}
