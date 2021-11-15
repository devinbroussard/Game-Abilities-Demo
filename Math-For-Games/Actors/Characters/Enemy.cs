using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGamesAssessment
{
    class Enemy : Character
    {
        private Actor _actorToChase;
        private float _maxFov;
        public static int EnemyCount;
        private float _timeBetweenShots;
        private float _cooldownTime;

        public Enemy(float x, float y, float z, float speed, int health, Actor actor, float maxFov, float cooldownTime,
            Color color, string name = "Enemy", Shape shape = Shape.SPHERE)
            : base(x, y, z, speed, health, color, name, shape)
        {
            _actorToChase = actor;
            _maxFov = maxFov;
            Tag = ActorTag.ENEMY;
            _cooldownTime = cooldownTime;
        }

        public override void Start()
        {
            SetScale(1, 1, 1);
            EnemyCount++;
            CircleCollider enemyCollider = new CircleCollider(1, this);
            base.Start();
        }

        public override void Update(float deltaTime)
        {
            _timeBetweenShots += deltaTime;

            //The Enemy runs towards the player's position
            if (_actorToChase == null)
                return;
            Vector3 moveDirection = _actorToChase.LocalPosition - LocalPosition;

            //The enemy runs away from the player's position
            //Vector2 moveDirection = Position - _actorToChase.Position;

            Velocity = moveDirection.Normalized * Speed * deltaTime;

            if (IsTargetInSight())
                Translate(Velocity.X, Velocity.Y, Velocity.Z);
            else
            {
                base.Translate(Velocity.X * 0.5f, Velocity.Y * 0.5f, Velocity.Z * 0.5f);
            }
            if (_timeBetweenShots >= 1 && !IsTargetInSight())
            {
                LookAt(_actorToChase.WorldPosition);
                Vector3 directionOfBullet = (_actorToChase.LocalPosition - LocalPosition).Normalized;
                _timeBetweenShots = 0;
                Bullet bullet = new Bullet(10, this);
            }

            base.Update(deltaTime);
            
        }

        public override void End()
        {
            EnemyCount--;
        }

        public bool IsTargetInSight()
        {
            Vector3 directionOfTarget = (_actorToChase.LocalPosition - LocalPosition).Normalized;
            float distanceOfTarget = Vector3.GetDistance(_actorToChase.LocalPosition, LocalPosition);

            return (Math.Acos(Vector3.DotProduct(directionOfTarget, Forward)) * 180/Math.PI) < _maxFov
                && distanceOfTarget < 200;
        }

        public void TakeDamage()
        {
            Health--;
        }

        public override void OnCollision(Actor actor)
        { }

        public override void Draw()
        {
            base.Draw();
            //if (Collider != null)
                //Collider.Draw();
        }
    }
}
