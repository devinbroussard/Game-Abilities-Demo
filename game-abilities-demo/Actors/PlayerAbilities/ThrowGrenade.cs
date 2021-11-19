using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;

namespace GameAbilitiesDemo
{
    class ThrowGrenade : Ability
    {
        public ThrowGrenade(Player player, Vector4 abilityColor, float abilityDuration)
         : base(player, abilityColor, abilityDuration)
        { }

        /// <summary>
        /// Called when the throwGrenade ability is started
        /// </summary>
        /// <param name="grenadeHoldTime">The time that the player held the ability button</param>
        public void Start(float grenadeHoldTime)
        {    
            base.Start();
            //Spawns in a new grenade and calls it's start function
            Grenade _grenade = new Grenade(5 * grenadeHoldTime, 1, Player);
            _grenade.Start();
            //Sets the player's time between shots to be 0
            Player.TimeBetweenShots = 0;
        }

        /// <summary>
        /// Called every frame
        /// </summary>
        /// <param name="deltaTime">The time between frames</param>
        public override void Update(float deltaTime)
        {
            //If the time the ability has been active is less than the ability duration...
            if (AbilityTimer < AbilityDuration)
            {
                //...add the delta time to the ability timer
                AbilityTimer += deltaTime;
            }
            //...other end the ability
            else base.End();
        }


    }
}
