**Devin Broussard**  
s218014  
[Github Repository](https://github.com/devinbroussard/Math-For-Games-Assessment)

# I. Requirements 

1.  **Description of a Problem**   
    **Name:**  
    Game Abilities Demo   
    **Problem Statement:**  
    Create maths classes implementing Vector and Matrix objects for use in real-time applications.  
    **Problem Specifications:**  
# II. Design
1.  ***System Architecture***  

2. ***Object Information***  
    * **File Name:** Character.cs
        * *Inherits from*: Actor.cs
        * *Name:*  _speed(float)  
            * Description: The speed that the character's movement will be scaled by
            * Visibility: private
        * *Name:* _velocity(Vector3)
            * *Description:*  The vector3 that the character will be translated by
            * *Visibility:*  private
        * *Name:* _gravity(Vector3)
            * *Description:*  The vector3 that will be added to the player's velocity to simulate gravity
            * *Visibility:*  private
        * *Name:* _health(int)
            * *Description:*  The character's health
            * *Visibility:*  private
        * *Name:* Speed(float)
            * *Description:*  public property used to read and set the _speed variable
            * *Visibility:*  Public
        * *Name:* Velocity(Vector3)
            * *Description:* Property used to read and set the _velocity variable 
            * *Visibility:*  public
        * *Name:* Gravity(Vector3)
            * *Description:* property used to read and set the _gravity variable
            * *Visibility:*  
        * *Name:* ApplyGravity(void)
            * *Description:*  Adds gravity to the character's velocity if they are off the ground
            * *Visibility:*  public
            * *Arguments:*  none
        * *Name:* Character(constructor)
            * *Description:*  Takes in the base actor and character's stats and sets them
            * *Visibility:*  public
            * *Arguments:*  float x, float y, float z, float speed, int health, Color color, string name = "Character", Shape shape = Shape.SPHERE)
             : base(x, y, z, shape, color, name)
        * *Name:* IsGrounded(bool)
            * *Description:*  Determines whether or not the character is on the ground.
            * *Visibility:*  public
            * *Arguments:*  none
    * **File Name:**  Enemy.cs  
        * *Inherits from:* Characters.cs
        * *Name:* _actorToChase(Actor)
            * *Description:* The actor that the enemy will target   
            * *Visibility:*  private
        * *Name:*   EnemyCount(int)
            * *Description:*  The amount of enemies that are currently in the scene  
            * *Visibility*:  public static
        * *Name:*   EnemiesKilled(int)
            * *Description:*   The number of enemies that the player has killed
            * *Visibility*:  public static
        * *Name:*   _timeBetweenShots(float)
            * *Description:*   The time that has passed since a shot was taken 
            * *Visibility*:  private
        * *Name:*   _cooldownTime(float)
            * *Description:*    The time that the enemy will wait between shooting
            * *Visibility*:  private
        * *Name:* Enemy(constructor)  
            * *Description:* Takes in the base actor and enemy's stats and sets them 
            * *Visibility:* public
            * *Arguments:*   (float x, float y, float z, float speed, int health, Actor actor, float cooldownTime,
            Color color, string name = "Enemy", Shape shape = Shape.SPHERE)
            : base(x, y, z, speed, health, color, name, shape)
        * *Name:* Start(void)  
            * *Description:*  Called whenever the enemy is added to the scene. Initializes stats that the constructor doesn't
            * *Visibility:*  override public
            * *Arguments:*  none
        * *Name:* Update(void)  
            * *Description:* Called every frame to update the enemy's position and choices 
            * *Visibility:* public
            * *Arguments:*   float deltaTime
        * *Name:* End(void)  
            * *Description:* Called whenever an enemy is removed from the scene; decreases static enemycount variable 
            * *Visibility:* override public
            * *Arguments:*   none
        * *Name:* IsTargetNear(bool) 
            * *Description:* Checks to see if the actor to chase is near the enemy
            * *Visibility:* public
            * *Arguments:*   none
        * *Name:* OnCollision(void)  
            * *Description:* Called on collision with another actor
            * *Visibility:* public override
            * *Arguments:*   Actor actor
    * **File:** Player.cs
        * *Inherits from:* Character.cs
        * *Name:* _timeBetweenShots(float) 
            * *Description:* Stores the time that has
            me that has passed since the player took damage
            * *Visibility:* private
        * *Name:* _jumpForce(float) 
            * *Description:* Stores the center position of the screen  
            * *Visibility:* private
        * *Name:* _mouseOrigin(Vector2)
            * *Description:* Stores the center position of the screen
            * *Visibility:* private
        * *Name:* _horizontalSens(float) 
            * *Description:* Stores the horizontal sensitivity of the mouse
            * *Visibility:* private
        * *Name:* _verticalSens(float) 
            * *Description:* Stores the vertical sensitivity of the mouse
            * *Visibility:* private
        * *Name:* _baseColor(Vector4) 
            * *Description:* Stores the player's base color 
            * *Visibility:* private
        * *Name:* _baseSpeed(float) 
            * *Description:* Stores the player's base speed 
            * *Visibility:* private
        * *Name:* _baseScale(float)
            * *Description:* Stores the player's base scale
            * *Visibility:* private
        * *Name:* _baseShotCooldown(float) 
            * *Description:* stores the base time a player must wait between shots 
            * *Visibility:* private
        * *Name:* _abilities(Ability[]) 
            * *Description:* Stores all of the player's usable abilities
            * *Visibility:* private
        * *Name:* _currentAbility(Ability) 
            * *Description:* Stores the ability the player is currently using
            * *Visibility:* private
        * *Name:* _timeBetweenAbilities(float)
            * *Description:* Stores the time that has passed since an ability last ended
            * *Visibility:* private
        * *Name:* _abilityCooldown(float)
            * *Description:* The time the player must wait between using abilities
            * *Visibility:* private
        * *Name:* _grenadeWasPressed(bool)
            * *Description:* Stores whether or not the player pressed the throw grenade ability button
            * *Visibility:* private
        * *Name:* TiemBetweenAbilities(float)
            * *Description:* property that gets the _timeBetweenAbilities value
            * *Visibility:* public
        * *Name:* ShotCooldown(float)
            * *Description:* property that gets the _shotCooldown value
            * *Visibility:* public
        * *Name:* CurrentAbility(Ability)
            * *Description:* property that sets the _currentAbility variable
            * *Visibility:* public
        * *Name:* TimeBetweenShots(float)
            * *Description:* property that allows getting and setting the _timeBetweenShots variable
            * *Visibility:* public
        * *Name:* LastHitTime(float)
            * *Description:* property that allows getting and settings the _lastHitTime variable
            * *Visibility:* public
        * *Name:* Player(constructor)
            * *Description:* Allows for setting the player's base stats and actor stats
            * *Visibility:* public
        * *Name:* Start(void)
            * *Description:* Called on the player's start. Initializes the player's variables and abilities
            * *Visibility:* public override
            * *Arguments:* none 
        * *Name:* Update(void)
            * *Description:* Called every frame. Gets the user's input and updates the player's position
            * *Visibility:* public override
            * *Arguments:* float deltaTime
        * *Name:* GetRotationInput(float deltaTime)
            * *Description:* Gets the player's mouse position and uses that to rotate the player
            * *Visibility:* public
            * *Arguments:* float deltaTime 
        * *Name:* GetTranslationInput(void)
            * *Description:* Gets user input and calculates the player's position accordingly
            * *Visibility:* public
            * *Arguments:* float deltaTime
        * *Name:* GetFiringInput(void)
            * *Description:* Gets the player's firing input and spawns bullets accordingly
            * *Visibility:* public
            * *Arguments:* float deltaTime 
        * *Name:* GetAbilityInput(void)
            * *Description:* Gets the player's input and uses abilities accordingly
            * *Visibility:* public
            * *Arguments:* float deltaTime 
        * *Name:* OnCollision(void)
            * *Description:* Gets called on collision with another actor
            * *Visibility:* public override
            * *Arguments:* Actor actor 
        * *Name:* TakeDamage(void)
            * *Description:* Makes the player take damage, and sets their last hit time to 0
            * *Visibility:* public
            * *Arguments:* none 
        * *Name:* Draw(void)
            * *Description:* Draw's the player and the player's crosshair to the screen
            * *Visibility:* public override
            * *Arguments:* none 
        * *Name:* ResetStates()
            * *Description:* Resets the player's stats back to their default
            * *Visibility:* public
            * *Arguments:* none 
    * **File:** Actor.cs
        * *Name:* ActorTag(enum)
            * *Description:* Tag applied to an actor to determine what ind of actor it is
            * *Visibility:* public
        * *Name:* Shape(enum)
            * *Description:* Shape applied to an actor to determine what to draw the screen
            * *Visibility:* public
        * *Name:* _name(string)
            * *Description:* Stores the actor's name
            * *Visibility:* private
        * *Name:* _started(bool)
            * *Description:* Stores whether or not the actor's start function has been called
            * *Visibility:* private
        * *Name:* _tag(ActorTag)
            * *Description:* Stores the actor's ActorTag
            * *Visibility:* private
        * *Name:* _collider(Collider)
            * *Description:* Stores the actor's collider
            * *Visibility:* private
        * *Name:* _globalTransform(Matrix4)
            * *Description:* Stores the matrix4 that will be used to draw to the screen
            * *Visibility:* private
        * *Name:* _localTransform(Matrix4)
            * *Description:* Stores the actor's position relative to it's parent
            * *Visibility:* private
        * *Name:* _translation(Matrix4)
            * *Description:* Stores the actor's relative translation from its parent actor
            * *Visibility:* private
        * *Name:* _rotation(Matrix4)
            * *Description:* Stores the actor's relative rotation from its parent actor
            * *Visibility:* private
        * *Name:* _scale(Matrix4)
            * *Description:* Stores the actor's relative scale from its parent actor
            * *Visibility:* private
        * *Name:* _children(Actor[])
            * *Description:* Stores the actor's children
            * *Visibility:* private
        * *Name:* _parent(Actor)
            * *Description:* Stores the actor's parent
            * *Visibility:* private
        * *Name:* _shape(Shape)
            * *Description:* Stores the shape that the actor will be drawn as
            * *Visibility:* private
        * *Name:* _color(Color)
            * *Description:* Stores the color that the actor's shape will be drawn as
            * *Visibility:* private
        * *Name:* Collider(Collider)
            * *Description:* a property that gets and sets the _collider variable
            * *Visibility:* public
        * *Name:* ShapeColor(Color)
            * *Description:* a property that get the _color variable
            * *Visibility:* public
        * *Name:* Tag(ActorTag)
            * *Description:* a property that gets and sets the _tag variable
            * *Visibility:* public
        * *Name:* Forward(Vector3)
            * *Description:* The actor's forward direction on the global axis
            * *Visibility:* public
        * *Name:* Right(Vector3)
            * *Description:* The actor's right position on the global axis
            * *Visibility:* public
        * *Name:* Upwards(Vector3)
            * *Description:* The actor's upward position on the global axis
            * *Visibility:* public
        * *Name:* ScaleX(float)
            * *Description:* The magnitude of the actor's X scale
            * *Visibility:* public
        * *Name:* ScaleY(float)
            * *Description:* The magnitude of the actor's Y scale
            * *Visibility:* public
        * *Name:* ScaleZ(float)
            * *Description:* The magnitude of the actor's Z scale
            * *Visibility:* public
        * *Name:* Start(bool)
            * *Description:* True if the start function has been called for this actor
            * *Visibility:* public
        * *Name:* LocalPosition(Vector3)
            * *Description:* The actor's position on their local transform
            * *Visibility:* public
        * *Name:* WorldPosition(Vector3)
            * *Description:* The actor's position on the global transform
            * *Visibility:* public
        * *Name:* GlobalTransform(Matrix4)
            * *Description:* property that allows getting and private setting of the _globalTransform variable
            * *Visibility:* public
        * *Name:* LocalTransform(Matrix4)
            * *Description:* property that allows getting and private settings of the _localTransform variable
            * *Visibility:* public
        * *Name:* Parent(Actor)
            * *Description:* property that allows getting and setting of the _parent variable
            * *Visibility:* public
        * *Name:* Children(Actor[])
            * *Description:* a property that gets and sets the _children variable
            * *Visibility:* public
        * *Name:* Actor(constructor)
            * *Description:* allows setting of the actor's stats; takes in an x, y, and z, variable instead of a vector3 and passes them into the other constructor
            * *Visibility:* public
            * *Arguments:* (float x, float y, float z, Shape shape, Color color, string name = "Actor", ActorTag tag = ActorTag.GENERIC) :
            this(new Vector3 { X = x, Y = y, Z = z}, shape, color, name, tag) 
        * *Name:* Actor(constructor)
            * *Description:* allows setting of the actor's stats
            * *Visibility:* public
            * *Arguments:* (Vector3 position, Shape shape, Color color, string name = "Actor", ActorTag tag = ActorTag.GENERIC ) 
        * *Name:* Actor(constructor)
            * *Description:* creates a new, blank, actor
            * *Visibility:* public
            * *Arguments:* none
        * *Name:* UpdateTransforms(void)
            * *Description:* Updates the locan and global transforms of the acotr
            * *Visibility:* public
            * *Arguments:* none
        * *Name:* AddChild(void)
            * *Description:* Adds an actor to the actor's children array and sets the child's parent
            * *Visibility:* public
            * *Arguments:* Actor child
        * *Name:* RemoveChild(bool) 
            * *Description:* Removes an actor from the children array and sets the child's parent
            * *Visibility:* public
            * *Arguments:* Actor child
        * *Name:* Start(void)
            * *Description:* Called on start; marks started variable as true
            * *Visibility:* publc virtual
            * *Arguments:* none
        * *Name:* Update(void)
            * *Description:* Called every frame to update the actor
            * *Visibility:* public virtual
            * *Arguments:* float deltaTime
        * *Name:* Draw(void)
            * *Description:* Draws the actor to the screen
            * *Visibility:* public virtual
            * *Arguments:* none 
        * *Name:* End(void)
            * *Description:* Called when an actor is removed from a scene
            * *Visibility:* public virtual
            * *Arguments:* none
        * *Name:* DestroySelf(void)
            * *Description:* Removes the actor from the current scene
            * *Visibility:* public
            * *Arguments:* none
        * *Name:* Oncollision(void)
            * *Description:* Is called on collision with another actor
            * *Visibility:* public virtual
            * *Arguments:* Actor actor
        * *Name:* CheckForCollision(bool)
            * *Description:* Checks if this actor collided with another actor
            * *Visibility:* public virtual
            * *Arguments:* (Actor other)
        * *Name:* SetTranslation(void)
            * *Description:* Sets the position of the actor
            * *Visibility:* public
            * *Arguments:* float translationX, float translationY, float translationZ
        * *Name:* Translate(void)
            * *Description:* Applies the given values to the current translation
            * *Visibility:* public
            * *Arguments:* float translationX, float translationY, float translationZ    
        * *Name:* SetRotation(void)
            * *Description:* Set the rotation of the actor
            * *Visibility:* public
            * *Arguments:* float radiansX, float radiansY, float radiansZ
        * *Name:* Rotate(void)
            * *Description:* Adds a rotation to the current transform's rotation
            * *Visibility:* public
            * *Arguments:* float radiansX, float radiansY, float radiansZ         
        * *Name:* SetScale(void)
            * *Description:* Chagnes the scale of the actor
            * *Visibility:* public
            * *Arguments:* flaot x, float y, float z
        * *Name:* Scale(void)
            * *Description:* Scales the actor by the given amoutn
            * *Visibility:* public
            * *Arguments:* float x, float y, float z
        * *Name:* LookAt(void)
            * *Description:* Changes the actor's forward position to face the given position
            * *Visibility:* public
            * *Arguments:* (Vector3 position)       
        * *Name:* SetColor(void)
            * *Description:* Sets the actor's color
            * *Visibility:* public
            * *Arguments:* Color color             
        * *Name:* SetColor(void)
            * *Description:* Sets the actor's color
            * *Visibility:* public
            * *Arguments:* Vector4 colorValue              
    * **FILE:** Camera
        * *Inherits from:* Actor
        * *Name:* _camera3D(Camera3D)
            * *Description:* The raylib camera that this actor will use
            * *Visibility:* private  
        * *Name:* _targetActor(Actor)
            * *Description:* The actor the target will focus
            * *Visibility:* private  
        * *Name:* Camera3D(Camera3D)
            * *Description:* A variable containing the camera that is used in the engine
            * *Visibility:* public 
        * *Name:* Camera(constructor)
            * *Description:* Initializes a new camera
            * *Visibility:* public
            *  *Arguments:* (Actor targetActor) :base() 
        * *Name:* Start(void)
            * *Description:* Called when the camera is added to the scene
            * *Visibility:* public override
            *  *Arguments:* none
        * *Name:* Update(void)
            * *Description:* Called every frame to update the camera's position
            * *Visibility:* public override 
            *  *Arguments:* float deltaTime 
    * **File:** EnemySpawner
        * *Inherits from:* Actor
        * *Name:* _timeBetweenSpawns(float)
            * *Description:* The time that has passed between enemy spawns
            * *Visibility:* private   
        * *Name:* _timeBetweenSpawns(float)
            * *Description:* The time that has passed between enemy spawns
            * *Visibility:* private   
        * *Name:* _player(Player)
            * *Description:* The player that the enemies will target
            * *Visibility:* private   
        * *Name:* EnemySpawner(constructor)
            * *Description:* passes default stats into the base actor class
            * *Visibility:* public
        * *Name:* Update(void)
            * *Description:* Called every frame
            * *Visibility:* public override    
            * *Arguments:* float deltaTime  
    * **FILE:** Ability  
        * *Name:* _player(Player)
            * *Description:* Stores the player that will do the ability
            * *Visibility:* private  
        * *Name:* _abilityColor(Vector4)
            * *Description:* Stores the color the player turns during teh ability
            * *Visibility:* private  
        * *Name:* _abilityScale(float)
            * *Description:* Stores the size the player will scale to during the ability
            * *Visibility:* private  
        * *Name:* _abilityCollisionRadius(float)
            * *Description:* Stores the palyer's hitbox size during the ability
            * *Visibility:* private  
        * *Name:* _abilitySpeed(float)
            * *Description:* Stores the speed the player will have during the ability
            * *Visibility:* private  
        * *Name:* _abilityTimer(float)
            * *Description:* Stores the time the ability has been activbey
            * *Visibility:* private  
        * *Name:* _abilityDuration(float)
            * *Description:* Stores how long the ability will be active
            * *Visibility:* private  
        * *Name:* AbilityScale(float)
            * *Description:* property that gets and sets the _abilityScale variable
            * *Visibility:* public    
        * *Name:* AbilityCollisionRadius(float)
            * *Description:* property that gets adn sets the _abilityCollisionRadius variable
            * *Visibility:* public 
        * *Name:* AbilitySpeed(float)
            * *Description:* property that gets and sets the _abilitySpeed variable
            * *Visibility:* public  
        * *Name:* Player(Player)
            * *Description:* gets and returns the _player variable
            * *Visibility:* public  
        * *Name:* AbilityDuration(float)
            * *Description:* property that gets and sets the _abilityDuration variable
            * *Visibility:* public  
        * *Name:* AbilityTimer(float)
            * *Description:* how long has passed since the ability started
            * *Visibility:*public  
        * *Name:* Ability(constructor)
            * *Description:* assigns some of the ability's stats that all abilities will have 
            * *Visibility:* public
            * *Arguments:* Player player, Vector4 color, float duration     
        * *Name:* Start(void)
            * *Description:* Called when the ability starts 
            * *Visibility:* public virtual
            * *Arguments:* none     
        * *Name:* Update(void)
            * *Description:* Called every frame when the ability is active; only used in inheritting abilities 
            * *Visibility:* public virtual
            * *Arguments:* float deltaTime     
        * *Name:* End(void)
            * *Description:* Called at the end of the ability
            * *Visibility:* public virtual
            * *Arguments:* Player player, Vector4 color, float duration     
    * **FILE:** Fortify
        *Inherits from:* Ability  
        * *Name:* Fortify(constructor)
            * *Description:* takes in the stats that will be changed during this ability
            * *Visibility:* public
            * *Arguments:* (Player player, Vector4 color, float scale, float speed, float duration) : base(player, color, duration)  
        * *Name:* Start(void)
            * *Description:* Called when this ability is activated
            * *Visibility:* public override
            * *Arguments:* none       
        * *Name:* Update(void)
            * *Description:* Called every frame while this ability is active
            * *Visibility:* public override
            * *Arguments:* float deltaTime       
    * **FILE:** ThrowGrenade.cs
        *Inherits from:* Ability
        * *Name:* ThrowGrenade(constructor)
            * *Description:* Calls the base ablity's constructor
            * *Visibility:* public override
            * *Arguments:* (Player player, Vector4 abilityColor, float abilityDuration) : base(player, abilityColor, abilityDuration)    
        * *Name:* Start(void)
            * *Description:* Called when the throw grenade ability is started
            * *Visibility:* public override
            * *Arguments:* none      
        * *Name:* Update(void)
            * *Description:* Called every frame while this ability is active
            * *Visibility:* public override
            * *Arguments:* float deltaTime  
    * **FILE:** Bullet.cs
        *Inherits from:* Actor
        * *Name:* _speed(float)
            * *Description:* The speed that the bullet will travel
            * *Visibility:* private 
        * *Name:* _velocity(Vector3)
            * *Description:* The vector that the actor will be translated by
            * *Visibility:* private  
        * *Name:* _timeAlive(float)
            * *Description:* Variable used to track the time that the bullet has been in the scene
            * *Visibility:* private 
        * *Name:* _moveDirection(Vector3)
            * *Description:* the direction that the bullet travels
            * *Visibility:* private
        * *Name:* _owner(Actor)
            * *Description:* The actor that shot the bullet
            * *Visibility:* private 
        * *Name:* Owner(Actor)
            * *Description:* property that gets the owner who shot the bullet
            * *Visibility:* public 
        * *Name:* MoveDirection(Vector3)
            * *Description:* gets and sets the _moveDirection variable
            * *Visibility:* public 
        * *Name:* Bullet(constructor)
            * *Description:* initializes the bullet's stats and adds the bullet to the current scene
            * *Visibility:* public 
            * *Arguments:* ( float speed, Actor owner) : base(owner.WorldPosition, Shape.SPHERE, Color.YELLOW, "Bullet")
        * *Name:* Start(void)
            * *Description:* Called when the bullet is added to the scene
            * *Visibility:* public override
            * *Arguments:* ( float speed, Actor owner) : base(owner.WorldPosition, Shape.SPHERE, Color.YELLOW, "Bullet") 
        * *Name:* Update(void)
            * *Description:* Called every frame to update the bullets position
            * *Visibility:* public override
            * *Arguments:* float deltaTime
        * *Name:* OnCollision(void)
            * *Description:* Gets called on collision with an actor
            * *Visibility:* public override
            * *Arguments:* Actor actor
    * **FILE:** Grenade.cs
        * *Inherits from:* Actor
        * *Name:* _speed(float)
            * *Description:* speed that the grenade will move at
            * *Visibility:* private 
        * *Name:* _owner(Actor)
            * *Description:* The actor that threw the grenade
            * *Visibility:* private 
        * *Name:* _moveDirection(Vector3)
            * *Description:* the direction that the grenade moves
            * *Visibility:* private 
        * *Name:* _velocity(Vector3)
            * *Description:* the vector that the grenade will be translated by
            * *Visibility:* private 
        * *Name:* _gravity(Vector3)
            * *Description:* the vector constantly applied to the grenade while it is in the air
            * *Visibility:* private 
        * *Name:* _throwHeight(float)
            * *Description:* How high the grenade will be thrown
            * *Visibility:* private 
        * *Name:* Grenade(constructor)
            * *Description:* Gives the grenade it's stats
            * *Visibility:* public 
            * *Arguments:* (float speed, float throwHeight, Actor owner) : base(owner.WorldPosition, Shape.SPHERE, Color.BLACK, "Grenade") 
        * *Name:* Start(void)
            * *Description:* Called wyhen the grenade is added to the scene
            * *Visibility:* public override
            * *Arguments:* none 
        * *Name:* Update(void)
            * *Description:* Called every frame to update the bullet
            * *Visibility:* public override
            * *Arguments:* float deltaTime 
        * *Name:* ApplyGravity(void)
            * *Description:* Applies gravity to the grenade's velocity
            * *Visibility:* public
            * *Arguments:* none 
        * *Name:* IsGrounded(bool)
            * *Description:* Checks if the grenade is grounded
            * *Visibility:* bool
            * *Arguments:* none 
        * *Name:* End(void)
            * *Description:* Called when the grenade ends
            * *Visibility:* public override
            * *Arguments:* none 
        * *Name:* Start(void)
            * *Description:* Called wyhen the grenade is added to the scene
            * *Visibility:* public override
            * *Arguments:* none 
    * **FILE:** GrenadeExplosion
        * *Inherits from:* Actor
        * *Name:* _blastRadius(float)
            * *Description:* how big the explosion's collision radius will be
            * *Visibility:* private
        * *Name:* _smokeTimer(float)
            * *Description:* how long the explosion will last
            * *Visibility:* private
        * *Name:* GrenadeExplosion(constructor)
            * *Description:* gives the grenade its stats and calls the base actor's constructor
            * *Visibility:* public
            * *Arguments:* (Grenade owner, float blastRadius) :base(new Vector3(owner.WorldPosition.X, owner.WorldPosition.Y + 4, owner.WorldPosition.Z), Shape.SPHERE, Raylib.ColorAlpha(Color.LIGHTGRAY, 0.7f), "Grenade Explosion") 
        * *Name:* Start(void)
            * *Description:* Called when the explosion occurs
            * *Visibility:* public override
            * *Arguments:* none 
        * *Name:* Update(void)
            * *Description:* Called every frame while the explosion is happening
            * *Visibility:* public override
            * *Arguments:* float deltaTime
        * *Name:* Oncollision(void)
            * *Description:* Is called on collision with another actor
            * *Visibility:* public override
            * *Arguments:* Actor actor
    * **FILE:** AABBCollider
        * *Inherits from:* Collider
        * *Name:* _width(float)
            * *Description:* the width of the collider
            * *Visibility:* private    
        * *Name:* _height(float)
            * *Description:* the height of the collider
            * *Visibility:* private    
        * *Name:* _length(float)
            * *Description:* the length of the collider
            * *Visibility:* private    
        * *Name:* Width(float)
            * *Description:* property that allows getting and setting of the _width variable
            * *Visibility:* public     
        * *Name:* Height(float)
            * *Description:* property that allows getting and setting of the _height variable
            * *Visibility:*public    
        * *Name:* Length(float)
            * *Description:* property that allows getting and setting of the _length variable
            * *Visibility:* public     
        * *Name:* Left(float)
            * *Description:* The farthest left x position of this collider
            * *Visibility:* public  
        * *Name:* Right(float)
            * *Description:* The farthest right x position of this collider
            * *Visibility:* public        
        * *Name:* Top(float)
            * *Description:* the highest y position of this collider
            * *Visibility:* public     
        * *Name:* Bottom(float)
            * *Description:* The lowest y position of this collider
            * *Visibility:* public     
        * *Name:* Front(float)
            * *Description:* the highest z position of this collider
            * *Visibility:* public     
        * *Name:* Back(float) 
            * *Description:* the lowest z position of this collider
            * *Visibility:* public     
        * *Name:* AABBCollider(constructor)
            * *Description:* sets the collider's stats
            * *Visibility:* public    
            * *Arguments:*  (float width, float height, float length, Actor owner) : base(owner, ColliderType.AABB) 
        * *Name:* CheckCollisionAABB(bool)
            * *Description:* Checks to see if a collision occured with another AABB collider
            * *Visibility:* public override
            * *Arguments:*  AABBCollider other
        * *Name:* CheckCollisionCircle(bool)
            * *Description:* checks to see if a collision occured with a circle collider
            * *Visibility:* public override
            * *Arguments:*  CircleCollider other 
    * **FILE:** CircleCollider
        * *Inherits from:* Collider
        * *Name:* _collisionRadius(float)
            * *Description:* The the collider's radius
            * *Visibility:* private
        * *Name:* CollisionRadius(float)
            * *Description:* Allows getting and setting of the collision radius
            * *Visibility:* public    
        * *Name:* CircleCollider(constructor)
            * *Description:* Sets the collider's stats
            * *Visibility:* public    
            * *Arguments:*  float collisionRadius, Actor owner
        * *Name:* CheckCollisionCircle(bool)
            * *Description:* Checks for collision with another circle collider
            * *Visibility:* public override   
            * *Arguments:*  CircleCollider other 
        * *Name:* CheckCollisionAABB(bool)
            * *Description:* Checks for collision with an AABB collider
            * *Visibility:* public override   
            * *Arguments:*  AABBCollider other
    * **FILE:** Collider.cs
        * *Name:* ColliderType(enum)
            * *Description:* Stores the different types of colliders
            * *Visibility:* public
        * *Name:* _owner(Actor)
            * *Description:* The actor this collider is attached to
            * *Visibility:* private  
        * *Name:* _colliderType(ColliderType)
            * *Description:* The type of collider that this is
            * *Visibility:* private 
        * *Name:* ColliderType(ColliderType)
            * *Description:* allows getting and setting of the _colliderType variable
            * *Visibility:* public  
        * *Name:* Owner(Actor)
            * *Description:* allows getting and setting of thie _owner variable
            * *Visibility:* public  
        * *Name:* Collider(constructor)
            * *Description:* initializes the collider's stats
            * *Visibility:* public  
            * *Arguments:*  Actor owner, ColliderType colliderType
        * *Name:* CheckCollision(bool)
            * *Description:* Checks collision with another collider
            * *Visibility:* public  
            * *Arguments:*  Actor other 
        * *Name:* CheckCollisionCircle(bool)
            * *Description:* Checks for collision with another circle collider
            * *Visibility:* public virtual 
            * *Arguments:*  CircleCollider other      
        * *Name:* CheckCollisionAABB(bool)
            * *Description:* Checks for collision with an AABB collider
            * *Visibility:* public virtual   
            * *Arguments:*  AABBCollider other
    * **FILE:** Engine.cs
        * *Name:* _applicationShouldClose(bool)
            * *Description:* Controls whether or not the main game loops keeps getting called
            * *Visibility:* private static  
        * *Name:* _currentSceneIndex(int)
            * *Description:* Controls the current scene
            * *Visibility:* private static  
        * *Name:* _scenes(Scene[])
            * *Description:* contains all of the game's scenes
            * *Visibility:* private
        * *Name:* _stopwatch
            * *Description:* Stopwatch used to track deltaTime
            * *Visibility:* private
        * *Name:* CurrentScene(Scene)
            * *Description:* The current game scene
            * *Visibility:* public static    
        * *Name:* Camera(Camera)
            * *Description:* The game's camera
            * *Visibility:* public static  
        * *Name:* Run(void)
            * *Description:* Called to begin the application
            * *Visibility:* public
            * *Arguments:* none  
        * *Name:* Start(void)
            * *Description:* Called when the aplpication starts
            * *Visibility:* private
            * *Arguments:* none  
        * *Name:* Draw(void)
            * *Description:* Called every time the game loops to update visuals
            * *Visibility:* private
            * *Arguments:* none  
        * *Name:* End(void)
            * *Description:* Called when the application exits
            * *Visibility:* private
            * *Arguments:* none  
        * *Name:* AddScene(int))
            * *Description:* Adds a scene to the engine's scene array
            * *Visibility:* public
            * *Arguments:* Scene scene 
        * *Name:* SetCurrentScene(void)
            * *Description:* Adds and sets the current scene to the scene given
            * *Visibility:* public
            * *Arguments:* Scene scene 
        * *Name:* InitializeWindow(void)
            * *Description:* Initializes the winow that raylib will use during the game
            * *Visibility:* public
            * *Arguments:* none    
        * *Name:* CloseApplication(void)
            * *Description:* A function that can be used globally to end the application
            * *Visibility:* public static
            * *Arguments:* none  
    * **FILE:** Program.cs
        * *Name:* Main(void)
            * *Description:* Calls the application's run function
            * *Visibility:* static
            * *Arguments:* none  
    * **FILE:** Scene.cs
        * *Name:* _actors(Actor[])
            * *Description:* Array that stores all actors in the scene
            * *Visibility:* private   
        * *Name:* _UIElements(Actor[])
            * *Description:* Array that stores UI stuff only
            * *Visibility:* private   
        * *Name:* SceneOneActors(Actor[])
            * *Description:* contains all of the actors that scene one uses
            * *Visibility:* public static  
        * *Name:* SceneOneUIElements(Actor[])
            * *Description:* contains all of the UI elements that scene one uses
            * *Visibility:* public static 
        * *Name:* Scene(constructor)
            * *Description:* initializes arrays
            * *Visibility:* public 
        * *Name:* Actors(Actor[])
            * *Description:* gets the _actors array
            * *Visibility:* public 
        * *Name:* Start(void)
            * *Description:* Contains a virtual start fucntion that c an be used by inerriting classes
            * *Visibility:* public virtual
            * *Arguments:* none
        * *Name:* Update(void)
            * *Description:* Calls update for every actor in the scene, checks for collision, and start
            * *Visibility:* public virtual 
            * *Arguments:* float deltaTime
        * *Name:* UpdateUI(void)
            * *Description:* Updates all of the sccene's UI elements and starts them if they have not already been started
            * *Visibility:* public virtual 
            * *Arguments:* float deltaTime
        * *Name:* Draw(void)
            * *Description:* Calls all of the scene's actor's draw functions.
            * *Visibility:* public virtual 
            * *Arguments:* none
        * *Name:* DrawUI(void)
            * *Description:* Calls all of the scene's UI element's draw functions
            * *Visibility:* public virtual
            * *Arguments:* none
        * *Name:* End(void)
            * *Description:* Called at the end of a scene; removes all actors
            * *Visibility:* public virtual      
            * *Arguments:* none  
        * *Name:* SceneOneActors(Actor[])
            * *Description:* contains all of the actors that scene one uses
            * *Visibility:* public static  
            * *Arguments:* none
        * *Name:* InitializeActors(void)
            * *Description:* Initializes all actors for all scenes and stores them inside static arrays
            * *Visibility:* public static  
            * *Arguments:* none   
        * *Name:* AddActor(void)
            * *Description:* Adds an actor to the scenes list of actors
            * *Visibility:* public
            * *Arguments:* Actor actor
        * *Name:* AddActor(void)
            * *Description:* Adds an array of actors to the scenes list of actors
            * *Visibility:* public  
            * *Arguments:* Actor[] actors
        * *Name:* AddUIElement(void)
            * *Description:* Adds an array of actors to the UI elements array
            * *Visibility:* public  
            * *Arguments:* Actor[] Actor 
        * *Name:* AddUIElement(void)
            * *Description:* Adds an array of actors to the UI elements array
            * *Visibility:* public  
            * *Arguments:* Actor[] Actor 
        * *Name:* RemoveUIElement(bool)
            * *Description:* Removes an actor from the scene list of actors
            * *Visibility:* public  
            * *Arguments:* UIText Actor  '
        * *Name:* RemoveActor(bool)
            * *Description:* Removes an actor from the scene lists of actors
            * *Visibility:* public  
            * *Arguments:* Actor Actor  
    * **FILE:** UIText.cs
        * *Inherits from:* Actor
        * *Name:* Text(string)
            * *Description:* The text that will be drawn to the screen
            * *Visibility:* public    
        * *Name:* Width(int)
            * *Description:* How wide the text box will be
            * *Visibility:* public   
        * *Name:* Height(int)
            * *Description:* How tall the text box will be 
            * *Visibility:* public   
        * *Name:* FontSize(int)
            * *Description:* The size of the text that will be drawn
            * *Visibility:* public   
        * *Name:* Font(Font)
            * *Description:* The font that the text will be
            * *Visibility:* public   
        * *Name:* FontColor(Color)
            * *Description:* The color of the text
            * *Visibility:* public   
        * *Name:* UIText(constructor)
            * *Description:* Sets the starting values for the text box
            * *Visibility:* public  
            * *Arguments:*  (float x, float y, float z, Shape shape, string name, Color color, int width, int height, int fontSize, string text = "") : base(x, y, z, shape, color, name)
        * *Name:* Draw(void)
            * *Description:* Draws the text to the screen
            * *Visibility:* public override  
            * *Arguments:*  none
    * **FILE:** Matrix3.cs
        * *Name:* M00, M01, M02, M10, M11, M12, M20, M21, M22(float)
            * *Description:* holds the matrix's values
            * *Visibility:* public  
        * *Name:* Matrix3(constructor)
            * *Description:* Assigns the values of the matrix to the input given
            * *Visibility:* public
            * *Arguments:* float m00, float m01, float m02, float m10, float m11, float m12, float m20, float m21, float m22 
        * *Name:* Identity(Matrix3)
            * *Description:* Stores an identity matrix
            * *Visibility:* public static  
        * *Name:* CreateRotation(Matrix3)
            * *Description:* Creates a new matrix that has been rotated by the given value in radians
            * *Visibility:* public static 
            * *Arguments:* float radians    
        * *Name:* CreateTranslation(Matrix3)
            * *Description:* Creates a new matrix that has been translated by the given value
            * *Visibility:* public static 
            * *Arguments:* float x, float y
        * *Name:* CreateTranslation(Matrix3)
            * *Description:* Creates a new matrix that has been rotated by the given value in radians
            * *Visibility:* public static 
            * *Arguments:* Vector2 translation 
        * *Name:* CreateScale(Matrix3)
            * *Description:* Creates a new matrix that has been scaled by the given values
            * *Visibility:* public static 
            * *Arguments:* float x, float y     
        * *Name:* + (Matrix3)
            * *Description:* Adds two matrices together
            * *Visibility:* public static 
            * *Arguments:* Matrix3 lhs, Matrix3 rhs
        * *Name:* -(Matrix3)
            * *Description:* Subtracts one matrix from another
            * *Visibility:* public static 
            * *Arguments:* Matrix3 lhs, Matrix3 rhs
        * *Name:* *(Matrix3)
            * *Description:* Multiplies two matrices together
            * *Visibility:* public static 
            * *Arguments:* Matrix3 lhs, Matrix3 rhs       
        * *Name:* M00, M01, M02, M03, M10, M11, M12, M13, M20, M21, M22, M23, M30, M31, M32, M33(float)
            * *Description:* Stores the values of the matrix
            * *Visibility:* public     
        * *Name:* Matrix4(constructor)
            * *Description:* Assigns the values of the matrix to the input given
            * *Visibility:* public 
            * *Arguments:* float m00, float m01, float m02, float m03, float m10, float m11, float m12, float m20, float m21, float m22, float m23, float m30, float m31, float m32, float m33   
        * *Name:* Identity(Matrix4)
            * *Description:* Variable created to store an identity matrix
            * *Visibility:* public static 
        * *Name:* CreateRotationX(Matrix4)
            * *Description:* creates a new matrix that has been rotated on the x axis by the given value in radians
            * *Visibility:* public static 
            * *Arguments:* float radians    
        * *Name:* CreateRotationY(Matrix4)
            * *Description:* creates a new matrix that has been rotated on the Y axis by the given value in radians
            * *Visibility:* public static
            * *Arguments:* float radians     
        * *Name:* CreateRotationZ(Matrix4)
            * *Description:* creates a new matrix that has been rotated on the Z axis by the given value in radians
            * *Visibility:* public static
            * *Arguments:* float radians          
        * *Name:* CreateTranslation(Matrix4)
            * *Description:* Creates a new matrix that has been translated by the given values
            * *Visibility:* public static
            * *Arguments:* float x, float y, float z     
        * *Name:* CreateScale(Matrix4)
            * *Description:* Creates a new matrix that has been scaled by the given values
            * *Visibility:* public static
            * *Arguments:* float x, float y, float z
        * *Name:* +(Matrix4)
            * *Description:* adds two matrices
            * *Visibility:* public static
            * *Arguments:* matrix lhs, matrix rhs
        * *Name:* -(Matrix4)
            * *Description:* subtracts one matrix from another
            * *Visibility:* public static
            * *Arguments:* Matrix4 lhs, Matrix4 rhs
    * **FILE:** Vector2
        * *Name:* x(float)
            * *Description:* stores the x value of the vector
            * *Visibility:* public   
        * *Name:* y(float)
            * *Description:* stores the y value of the vector
            * *Visibility:* public   
        * *Name:* Vector2(constructor)
            * *Description:* sets the x and y values of the vector
            * *Visibility:* public 
            * *Arguments:* float x, float y  
        * *Name:* Magnitude(float)
            * *Description:* Gets the length of the vector
            * *Visibility:* public   
        * *Name:* Normalized(Vector2)
            * *Description:* property that returns the normalized value of the vector2
            * *Visibility:* public   
         * *Name:* Normalize(Vector2)
            * *Description:* changes this vector to have a magnitude of one
            * *Visibility:* public 
            * *Arguments:* none     
        * *Name:* GetDotProduct(float)
            * *Description:* returns the dot product of the first vector onto the second
            * *Visibility:* public static
            * *Arguments:* vector2 lhs, vector2 rhs     
        * *Name:* GetDistance(float)
            * *Description:* gets the distance between two vectors
            * *Visibility:* public static 
            * *Arguments:* vector2 lhs, vector2 rhs
        * *Name:* +(Vector2)
            * *Description:* adds two vectors
            * *Visibility:* public static
            * *Arguments:* vector2 lhs, vector2 rhs
        * *Name:* -(Vector2)
            * *Description:* subtracts the the rhs vector from the lhs vector
            * *Visibility:* public static
            * *Arguments:* vector2 lhs, vector2 rhs    
        * *Name:* /(vector2)
            * *Description:* divides a vector by a scalar
            * *Visibility:* public static
            * *Arguments:* vector2 vec2, float scalar              
        * *Name:* ==(bool)
            * *Description:* checks to see if two vectors are equal to each other
            * *Visibility:* public static
            * *Arguments:* vector2 lhs, vector2 rhs
        * *Name:* != (bool)
            * *Description:* Checks to see if two vectors are not equal to each other
            * *Visibility:* public static
            * *Arguments:* vector2 lhs, vector2 rhs         
    * **FILE:** Vector3
        * *Name:* X, Y, Z(float)
            * *Description:* The values of the vector
            * *Visibility:* public 
        * *Name:* Vector3(constructor)
            * *Description:* Sets the values of the vector
            * *Visibility:* public 
            * *Arguments:*  float x, float y, float z
        * *Name:* Magnitude(float)
            * *Description:* Gets the length of the vector
            * *Visibility:* public     
        * *Name:* Normalized(Vector3)
            * *Description:* returns the normalized value of the vector2
            * *Visibility:* public      
        * *Name:* Normalize(Vector3)
            * *Description:* changes this vector to have a magnitude that is equal to one
            * *Visibility:* public 
            * *Arguments:* none    
        * *Name:* DotProduct(float)
            * *Description:* returns the dot product of this first vector onto the second
            * *Visibility:* public static
            * *Arguments:* (vector3 lhs, vector3 rhs)    
        * *Name:* CrossProduct(vector3)
            * *Description:* stores the x value of the vector
            * *Visibility:* public static
            * *Arguments:* Vector3 lhs, vector3 rhs
        * *Name:* GetDistance(float)
            * *Description:* returns the distance between two vectors
            * *Visibility:* public static
            * *Arguments:* vector3 lhs, vector3 rhs
        * *Name:* +(vector3)
            * *Description:* adds two vectors
            * *Visibility:* public static
            * *Arguments:* Vector3 lhs, vector3 rhs       
        * *Name:* -(Vector3)
            * *Description:* subtracts one vector from another
            * *Visibility:* public static
            * *Arguments:* vector3 lhs, vector3 rhs         
        * *Name:* *(vector3)
            * *Description:* multilies the vector's x and y values by the scalar
            * *Visibility:* public static
            * *Arguments:* vector3 vec3, float scalar
        * *Name:* *(float)
            * *Description:* multilies the vector's x and y values by the scalar
            * *Visibility:* public static
            * *Arguments:* float scalar, vector3 vec3   
        * *Name:* /(float)
            * *Description:* divides the vector's x and y values by the scalar
            * *Visibility:* public static
            * *Arguments:* vector3 vec3, float scalar
        * *Name:* /(float)
            * *Description:* divides the vector by the scalar
            * *Visibility:* public static
            * *Arguments:* float scalar, vector3 vec3      
    * **FILE:** Vector4.cs
        * *Name:* X, Y, Z, W(float)
            * *Description:* The values of the matrix
            * *Visibility:* public
        * *Name:* Vector4(constructor)
            * *Description:* sets the vector's values
            * *Visibility:* public
            * *Arguments:* float x, float y, float z, float w
        * *Name:* Magnitude(float)
            * *Description:* gets the length of the vector
            * *Visibility:* public
        * *Name:* Normalized(Vector4)
            * *Description:* property that returns the normalized value of the vector2
            * *Visibility:* public
        * *Name:* Normalize(Vector4)
            * *Description:* changes this vector to have a magnitude that is equal to one
            * *Visibility:* public
            * *Arguments:* none
        * *Name:* CrossProduct(Vector4)
            * *Description:* gets the cross product of one vector onto another
            * *Visibility:* public static
            * *Arguments:* Vector4 lhs, Vector4 rhs
        * *Name:* DotProduct(float)
            * *Description:* returns the dot product of the first vector onto the second
            * *Visibility:* public static
            * *Arguments:* vector4 lhs, vector4 rhs
        * *Name:* GetDistance(Vector4 lhs, Vector4 rhs)
            * *Description:* returns the distance between two vectors
            * *Visibility:* public static
            * *Arguments:* Vector4 lhs, Vector4 rhs
        * *Name:* +(Vector4)
            * *Description:* adds the x and y vlaues of the second vector onto the first
            * *Visibility:* public static
            * *Arguments:* Vector4 lhs, vector4 rhs               

                      