using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGamesAssessment
{
    class Player : Character
    {
        private float _timeBetweenShots;
        private float _cooldownTime;
        private float _lastHitTime;
        private float _jumpForce;
        private Vector2 mouseOrigin = new Vector2(Raylib.GetMonitorWidth(1)/2, Raylib.GetMonitorHeight(1)/2);
        private float horizontalSens = 2f;
        private float verticalSens = 1.25f;
        private float _timeBetweenDashes = 100;
        private Vector4 _baseColor;
        private float _baseSpeed;

        public float LastHitTime
        {
            get { return _lastHitTime; }
            set { _lastHitTime = value; }
        }

        public Player(float x, float y, float z, float speed, int health, float cooldownTime, Color color, string name = "Player", Shape shape = Shape.CUBE)
            : base(x, y, z, speed, health, color, name, shape)
        {
            Speed = speed;
            _cooldownTime = cooldownTime;
            Tag = ActorTag.PLAYER;
            _baseColor = new Vector4(color.r, color.g, color.b, color.a);
            _baseSpeed = speed;
        }

        public override void Start()
        {
            SetScale(1, 1, 1);
            _jumpForce = 1;
            CircleCollider playerCollider = new CircleCollider(1, this);
            Raylib.SetMousePosition(Raylib.GetMonitorWidth(1) / 2, Raylib.GetMonitorHeight(1) / 2);
            base.Start();
        }

        public override void Update(float deltaTime)
        {
            _lastHitTime += deltaTime;

            GetAbilityInput(deltaTime);
            GetTranslationInput(deltaTime);
            GetRotationInput(deltaTime);
            GetFiringInput(deltaTime);

            base.Update(deltaTime);
        }

        public void GetRotationInput(float deltaTime)
        {
            Vector2 mousePosition = new Vector2(Raylib.GetMouseX(), Raylib.GetMouseY());
            Vector2 mouseDelta = mousePosition - mouseOrigin;

            float angle = MathF.Atan2(mouseDelta.Y, mouseDelta.X);

            if (mouseDelta.Magnitude > 0)
                base.Rotate(MathF.Sin(angle) * deltaTime * verticalSens, -MathF.Cos(angle) * deltaTime * horizontalSens, 0);
            Raylib.SetMousePosition(Raylib.GetMonitorWidth(1) / 2, Raylib.GetMonitorHeight(1) / 2);
        }

        public void GetTranslationInput(float deltaTime)
        {
            //Gets the forward and side inputs of the player
            int forwardDirection = Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_W))
                - Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_S));
            int sideDirection = Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_A))
                - Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_D));

            Velocity = ((forwardDirection * Forward) + (sideDirection * Right)).Normalized * Speed * deltaTime + new Vector3(0, Velocity.Y, 0);
            ApplyGravity();

            if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE) && IsGrounded())
                Velocity = new Vector3(Velocity.X, _jumpForce, Velocity.Y);

            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT_SHIFT))
                Velocity = new Vector3(Velocity.X * 6, Velocity.Y, Velocity.Z * 6);

            base.Translate(Velocity.X, Velocity.Y, Velocity.Z);
        }

        public void GetFiringInput(float deltaTime)
        {
            //Adds deltaTime to time between shots
            _timeBetweenShots += deltaTime;

            int isFiring = Convert.ToInt32(Raylib.IsMouseButtonDown(MouseButton.MOUSE_LEFT_BUTTON));

            if ((isFiring > 0) && (_timeBetweenShots >= _cooldownTime))
            {
                _timeBetweenShots = 0;
                Bullet bullet = new Bullet(LocalPosition, 50, "Player Bullet", Forward, this, Color.YELLOW);
            }
        }

        public void GetAbilityInput(float deltaTime)
        {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_LEFT_CONTROL))
                _timeBetweenDashes = 0;

            DoDashAbility(deltaTime);
        }

        public bool DoDashAbility(float deltaTime)
        {
            if (_timeBetweenDashes < 0.5)
            {
                _timeBetweenShots = _cooldownTime - 0.1f;
                Vector4 dashColor = new Vector4(ShapeColor.r, ShapeColor.g, ShapeColor.b, 100);
                Speed = 30;
                SetColor(dashColor);
                _timeBetweenDashes += deltaTime;
                CircleCollider dashCollider = new CircleCollider(0, this);
                return true;
            }
            ResetStats();
            return false;
        }

        public void TakeDamage()
        {
            Health--;
        }

        public override void OnCollision(Actor actor)
        {
            Console.WriteLine("Collision");

        }

        public override void Draw()
        {
            System.Numerics.Vector3 endPos = new System.Numerics.Vector3(WorldPosition.X + Forward.X * 20, WorldPosition.Y + Forward.Y * 20, WorldPosition.Z + Forward.Z * 20);

            Raylib.DrawSphere(endPos, 0.3f, new Color(100, 255, 100, 100));

            base.Draw();
            //Collider.Draw();
        }

        public void ResetStats()
        {
            CircleCollider defaultCollider = new CircleCollider(1, this);
            Speed = _baseSpeed;
            SetColor(_baseColor);
        }
    }
}
