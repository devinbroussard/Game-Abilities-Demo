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
        /// Stores the player's base scale
        /// </summary>
        private float _baseScale;

        private float _baseShotCooldown;

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
        private bool _grenadeWasPressed;
        private float _grenadeHoldTime;
        
        /// <summary>
        /// Stores the time since an ability was last used
        /// </summary>
        public float TimeBetweenAbilities
        {
            set { _timeBetweenAbilities = value; }
        }

        /// <summary>
        /// Stores the time a player must wait between shots
        /// </summary>
        public float ShotCooldown
        {
            get { return _shotCooldown; }
            set { _shotCooldown = value; }
        }

        /// <summary>
        /// Stores the ability the player is currently using
        /// </summary>
        public Ability CurrentAbility
        {
            set { _currentAbility = value; }
        }

        /// <summary>
        /// Stores the time since a shot was last fired
        /// </summary>
        public float TimeBetweenShots
        {
            get { return _timeBetweenShots; }
            set { _timeBetweenShots = value; }
        }

        /// <summary>
        /// Stores the time since a player was last hit by an enemy-
        /// </summary>
        public float LastHitTime
        {
            get { return _lastHitTime; }
            set { _lastHitTime = value; }
        }

        /// <param name="x">The local x position of the player</param>
        /// <param name="y">The local y position of the player</param
        /// <param name="z">The local z position of the player</param>
        /// <param name="speed">The speed of the player</param>
        /// <param name="health">How much health the player will have</param>
        /// <param name="shotCooldown">The time the player will have to wait between shots</param>
        /// <param name="scale">The value the player will be scaled by</param>
        /// <param name="color">The color the player will be</param>
        public Player(float x, float y, float z, float speed, int health, float shotCooldown, float scale, Color color)
            : base(x, y, z, speed, health, color, "Player", Shape.SPHERE)
        {
            Speed = speed;
            _shotCooldown = shotCooldown;
            Tag = ActorTag.PLAYER;
            _baseColor = new Vector4(color.r, color.g, color.b, color.a);
            _baseSpeed = speed;
            _baseScale = scale;
            _baseShotCooldown = shotCooldown;
        }

        /// <summary>
        /// Called on the player's start. Initializes the player's variables and abilities.
        /// </summary>
        public override void Start()
        {
            _timeBetweenAbilities = 50;
            _abilityCooldown = 2;
            SetScale(_baseScale, _baseScale, _baseScale);
            _jumpForce = 1;
            CircleCollider playerCollider = new CircleCollider(1, this);
            Raylib.SetMousePosition(Raylib.GetMonitorWidth(1) / 2, Raylib.GetMonitorHeight(1) / 2);

            Dash dash = new Dash(this, new Vector4(ShapeColor.r, ShapeColor.g, ShapeColor.b, 100), 1, 0, 50, 0.3f);
            Fortify fortify = new Fortify(this, new Vector4(0, 255, 0, 100), 1.3f, 0.5f, 2);
            ThrowGrenade throwGrenade = new ThrowGrenade(this, new Vector4(ShapeColor.r, ShapeColor.g, ShapeColor.b, ShapeColor.a), _shotCooldown);

            _abilities = new Ability[] { dash, throwGrenade, fortify };

            base.Start();
        }

        /// <summary>
        /// Called every frame. Gets the user's input and updates the player's position.
        /// </summary>
        /// <param name="deltaTime">How much time has passed between frames</param>
        public override void Update(float deltaTime)
        {
            _lastHitTime += deltaTime;

            GetAbilityInput(deltaTime);
            GetTranslationInput(deltaTime);
            GetRotationInput(deltaTime);
            GetFiringInput(deltaTime);

            base.Update(deltaTime);
        }

        /// <summary>
        /// Gets the player's mouse position and uses that to rotate the player.
        /// </summary>
        /// <param name="deltaTime">How much time has passed between frames</param>
        public void GetRotationInput(float deltaTime)
        {
            //Gets the user's position and stores the difference between that position and the mouse origin
            Vector2 mousePosition = new Vector2(Raylib.GetMouseX(), Raylib.GetMouseY());
            Vector2 mouseDelta = mousePosition - mouseOrigin;
            //Uses the difference to get an angle
            float angle = MathF.Atan2(mouseDelta.Y, mouseDelta.X);

            //Uses that angle to rotate the player and then sets the mouse position back to the origin
            if (mouseDelta.Magnitude > 0)
                base.Rotate(MathF.Sin(angle) * deltaTime * verticalSens, -MathF.Cos(angle) * deltaTime * horizontalSens, 0);
            Raylib.SetMousePosition(Raylib.GetMonitorWidth(1) / 2, Raylib.GetMonitorHeight(1) / 2);
        }

        /// <summary>
        /// Gets user input and calculates the player's position accordingly
        /// </summary>
        /// <param name="deltaTime">How much time has passed between frames</param>
        public void GetTranslationInput(float deltaTime)
        {
            //Gets the forward and side inputs from the user
            int forwardDirection = Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_W))
                - Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_S));
            int sideDirection = Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_A))
                - Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_D));

            //Calculates the player's velocity and then applies gravity to it
            Velocity = ((forwardDirection * Forward) + (sideDirection * Right)).Normalized * Speed * deltaTime + new Vector3(0, Velocity.Y, 0);
            ApplyGravity();

            //Jumps if the user presses the jump key and the player is grounded
            if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE) && IsGrounded())
                Velocity = new Vector3(Velocity.X, _jumpForce, Velocity.Y);

            //Translates the player based on the given velocity
            base.Translate(Velocity.X, Velocity.Y, Velocity.Z);
        }

        /// <summary>
        /// Gets the player's firing input and spawns bullets accordingly
        /// </summary>
        /// <param name="deltaTime">How much time has passed between frames</param>
        public void GetFiringInput(float deltaTime)
        {
            _timeBetweenShots += deltaTime;

            bool isFiring = (Raylib.IsMouseButtonDown(MouseButton.MOUSE_LEFT_BUTTON));

            if (isFiring && (_timeBetweenShots >= _shotCooldown))
            {
                _timeBetweenShots = 0;
                Bullet bullet = new Bullet(50, this);
            }
        }

        /// <summary>
        /// Gets the player's input and uses abilities accordingly
        /// </summary>
        /// <param name="deltaTime">How much time has passed between frames</param>
        public void GetAbilityInput(float deltaTime)
        {
            //Activates the dash ability if the ctrl key was pressed
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_LEFT_CONTROL) && _timeBetweenAbilities >= _abilityCooldown)
            {
                _timeBetweenAbilities = 0;
                _currentAbility = _abilities[0];
                _currentAbility.Start();
            }
            
            //Activates the throw grenade ability when the one key is held and released
            //The throw speed scales with how long the user holds down the key
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_ONE) && _timeBetweenAbilities >= _abilityCooldown)
            {
                _grenadeWasPressed = true;
                _grenadeHoldTime += 0.2f;
                Console.WriteLine(_grenadeHoldTime);

            }
            if (Raylib.IsKeyReleased(KeyboardKey.KEY_ONE) && _grenadeWasPressed)
            {
                _timeBetweenAbilities = 0;
                _currentAbility = _abilities[1];

                ThrowGrenade grenade = (ThrowGrenade)_currentAbility;
                grenade.Start(_grenadeHoldTime);

                _grenadeWasPressed = false;
                _grenadeHoldTime = 0;
            }

            //Activates the fortify ability when the two key is pressed
            else if (Raylib.IsKeyPressed(KeyboardKey.KEY_TWO) && _timeBetweenAbilities >= _abilityCooldown)
            {
                _timeBetweenAbilities = 0;
                _currentAbility = _abilities[2];
                _currentAbility.Start();
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
            ShotCooldown = _baseShotCooldown;
            SetScale(_baseScale, _baseScale, _baseScale);
            CircleCollider defaultCollider = new CircleCollider(1, this);
            Speed = _baseSpeed;
            SetColor(_baseColor);
        }
    }
}
