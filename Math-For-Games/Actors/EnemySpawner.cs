using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;


namespace MathForGamesAssessment
{
    class EnemySpawner : Actor
    {
        private float _timeBetweenSpawns;
        private Player _player;

        public EnemySpawner(Player player)
            : base(0, 0, 10, Shape.NULL, Color.BLANK)
        {
            _player = player;
        }

        public override void Update(float deltaTime)
        {
            if (Enemy.EnemyCount == 0)
            {
                _timeBetweenSpawns += deltaTime;
            }

            if (_timeBetweenSpawns >= 5)
            {
                Enemy enemy = new Enemy(0, 1, 30, 2, 3, _player, 40, 2, Color.MAROON);
                Engine.CurrentScene.AddActor(enemy);
                _timeBetweenSpawns = 0;
            }

            base.Update(deltaTime);
        }
    }
}
