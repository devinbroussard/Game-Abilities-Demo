using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;


namespace GameAbilitiesDemo
{
    class EnemySpawner : Actor
    {
        private float _timeBetweenSpawns;
        private Player _player;

        /// <param name="player">The player that the enemies spawned will target</param>
        public EnemySpawner(Player player)
            : base(0, 0, 10, Shape.NULL, Color.BLANK)
        {
            _player = player;
        }

        /// <summary>
        /// Called every frame
        /// </summary>
        /// <param name="deltaTime">The time that has passed between frames</param>
        public override void Update(float deltaTime)
        {
            //If the enemy count is 0...
            if (Enemy.EnemyCount == 0)
            {
                //Starts adding to the time between spawns
                _timeBetweenSpawns += deltaTime;
            }
            //If the time between spawns is above five seconds...
            if (_timeBetweenSpawns >= 5)
            {
                //Creates a new enemy, adds it to the scene, and sets the time between spawns back to zero.
                Enemy enemy = new Enemy(0, 1, 30, 4, 3, _player, 1, Color.MAROON);
                Engine.CurrentScene.AddActor(enemy);
                _timeBetweenSpawns = 0;
            }
            
            //Calls the base actor's update function
            base.Update(deltaTime);
        }
    }
}
