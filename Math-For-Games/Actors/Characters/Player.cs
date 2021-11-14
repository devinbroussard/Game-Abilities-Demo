using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGamesAssessment
{
    class Player : Character
    {
        /// <summary>
        /// Stores the time that has passed since the player's last shot
        /// </summary>
        private float _timeBetweenShots;
        /// <summary>
        /// Stores how long the player has to wait between shots
        /// </summary>
        private float _shotCooldown;
        /// <summary>
        /// Stores the time that has passed since the player got hit last
        /// </summary>
        private float _lastHitTime;
        /// <summary>
        /// Stores the jump force of the player
        /// </summary>
        private float _jumpForce;
        /// <summary>
        /// Stores the center position of the screen
        /// </summary>
        private Vector2 mouseOrigin = new Vector2(Raylib.GetMonitorWidth(1)/2, Raylib.GetMonitorHeight(1)/2);
        /// <summary>
        /// Stores the horizontal sensitivity of the mouse
        /// </summary>
        private float horizontalSens = 2f;
        /// <summary>
        /// Stores the vertical sensitivity of the mouse
        /// </summary>
        private float verticalSens = 1.25f;
        /// <summary>
        /// Stores the player's base color
        /// </summary>
        private Vector4 _baseColor;
        /// <summary>
        /// Stores the player's base speed
        /// </summary>
        private float _baseSpeed;
        /// <summary>
        /// Stores all of the player's usable abilities
        /// </summary>
        private Ability[] _abilities;
        /// <summary>
        /// Stores the ability the player is currently using
        /// </summary>
        private Ability _currentAbility;
        /// <summary>
        /// Stores the time that has passed since an ability last ended
        /// </summary>
        private float _timeBetweenAbilities;
        /// <summary>
        /// The time the player must wait between using abilities
        /// </summary>
        private float _abilityCooldown;
        
        public float TimeBetweenAbilities
        {
            set { _timeBetweenAbilities = value; }
        }

        public Ability CurrentAbility
        {
            set { _currentAbility = value; }
        }

        public float TimeBetweenShots
        {
            get { return _timeBetweenShots; }
            set { _timeBetweenShots = value; }
        }

        public float LastHitTime
        {
            get { return _lastHitTime; }
            set { _lastHitTime = value; }
        }

        public Player(float x, float y, float z, float speed, int health, float shotCooldown, Color color, string name = "Player", Shape shape = Shape.CUBE)
            : base(x, y, z, speed, health, color, name, shape)
        {
            Speed = speed;
            _shotCooldown = shotCooldown;
            Tag = ActorTag.PLAYER;
            _baseColor = new Vector4(color.r, color.g, color.b, color.a);
            _baseSpeed = speed;
        }

        public override void Start()
        {
            _timeBetweenAbilities = 50;
            _abilityCooldown = 2;
            SetScale(1, 1, 1);
            _jumpForce = 1;
            CircleCollider playerCollider = new CircleCollider(1, this);
            Raylib.SetMousePosition(Raylib.GetMonitorWidth(1) / 2, Raylib.GetMonitorHeight(1) / 2);

            Dash dash = new Dash(this, new Vector4(ShapeColor.r, ShapeColor.g, ShapeColor.b, 100), 1, 0, 50, 0.3f);

            _abilities = new Ability[] { dash };

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

            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT_SHIFT) && Raylib.IsKeyDown(KeyboardKey.KEY_W) 
                && !Raylib.IsKeyDown(KeyboardKey.KEY_A) && !Raylib.IsKeyDown(KeyboardKey.KEY_D) && _currentAbility == null)
            {
                Velocity = new Vector3(Velocity.X * 4, Velocity.Y, Velocity.Z * 4);
                _timeBetweenShots = _shotCooldown - 0.1f;
            }

            base.Translate(Velocity.X, Velocity.Y, Velocity.Z);
        }

        public void GetFiringInput(float deltaTime)
        {
            //Adds deltaTime to time between shots
            _timeBetweenShots += deltaTime;

            int isFiring = Convert.ToInt32(Raylib.IsMouseButtonDown(MouseButton.MOUSE_LEFT_BUTTON));

            if ((isFiring > 0) && (_timeBetweenShots >= _shotCooldown))
            {
                _timeBetweenShots = 0;
                Bullet bullet = new Bullet(LocalPosition, 50, "Player Bullet", Forward, this, Color.YELLOW);
            }
        }

        public void GetAbilityInput(float deltaTime)
        {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_LEFT_CONTROL) && _timeBetweenAbilities >= _abilityCooldown)
            {
                _currentAbility = _abilities[0];
                _abilities[0].Start();
            }

            if (_currentAbility != null)
                _currentAbility.Update(deltaTime);
            else _timeBetweenAbilities += deltaTime;
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
            System.Numerics.Vector3 endPos = new System.Numerics.Vector3(WorldPosition.X + Forward.X * 30, WorldPosition.Y + Forward.Y * 30, WorldPosition.Z + Forward.Z * 30);

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
