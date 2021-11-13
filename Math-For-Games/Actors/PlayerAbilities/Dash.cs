using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;

namespace MathForGamesAssessment
{
    class Dash : Ability
    {

        public Dash(Player player, Vector4 abilityColor, float abilityScale, float abilityCollisionRadius, float abilitySpeed, float abilityTimer, float abilityDuration)
            : base(player, abilityColor, abilityScale, abilityCollisionRadius, abilitySpeed, abilityTimer, abilityDuration)
        { }

        public override void Update()
        {
            if (AbilityTimer < AbilityDuration)
            {
                Player.TimeBetweenShots = 0;
                Player.SetColor()
            }
        }


    }
}
