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
            : base(player, abilityColor, abilityDuration)
        {
            AbilityScale = abilityScale;
            AbilityCollisionRadius = abilityCollisionRadius;
            AbilitySpeed = abilitySpeed;
        }

        /// <summary>
        /// Called at the start of the ability
        /// </summary>
        public override void Start()
        {
            base.Start();

            //Sets the player's stats for the ability
            Player.SetScale(AbilityScale, AbilityScale, AbilityScale);
            Player.Speed = AbilitySpeed;
            CircleCollider playerCollider = new CircleCollider(AbilityCollisionRadius, Player);
        }

        /// <summary>
        /// Called every frame during the ability
        /// </summary>
        /// <param name="deltaTime">The time that has passed between frames</param>
        public override void Update(float deltaTime)
        {
            //If the time that the ability has been active is less than the ability duration...
            if (AbilityTimer < AbilityDuration)
            {
                //...sets the player's timeBetweenShots variable to 0...
                Player.TimeBetweenShots = 0;
                //..Adds the abilitytimer to deltatime
                AbilityTimer += deltaTime;
            }
            //else call the ability's end function
            else base.End();
        }


    }
}
