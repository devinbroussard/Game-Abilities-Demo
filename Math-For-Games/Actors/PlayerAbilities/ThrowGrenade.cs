using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;

namespace MathForGamesAssessment
{
    class ThrowGrenade : Ability
    {
        Grenade _grenade;

        public ThrowGrenade(Player player, Vector4 abilityColor, float abilityDuration)
         : base(player, abilityColor, abilityDuration)
        { }

        public override void Start()
        {    
            base.Start();
            _grenade = new Grenade(50, 1, Player);
            _grenade.Start();
            Player.TimeBetweenShots = 0;


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
