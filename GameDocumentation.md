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
        * *Name:* Enemy(constructor)  
            * *Description:* Takes in the base actor and enemy's stats and sets them 
            * *Visibility:* public
            * *Arguments:*   (float x, float y, float z, float speed, int health, Actor actor, float cooldownTime,
        
        





