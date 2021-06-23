## ABSTRACT

Run is a single player 2 - D based cross-platform infinite running game with AI based

spawning of enemies. The scripts are programmed in such a way that the enemies

or obstacles are spawned in different coordinates and player needs to bypass the

obstacles to score points and coins. This game has been developed with the help of

a game engine known as Unity. Unity is very popular cross platform game engine

developed by Unity Technologies. Different component used in this game are

scenes, scripts, sprites, physics, animation and menus. All the menus, texts and

buttons are used in a canvas according to the scenes. The mechanics of this games

is programmed in C# (C Sharp) programming language. So, the controls or actions

performed in this game is done with different scripts attached with the particular

component of the game. Animations are created with an inbuilt component of

unity known as animator. The fps of the animations is 50 - 60 based on the task that

is needed to be performed. Although this game is a cross-platform but currently it

has been launched for android devices. But all the scripts have been written in such

a way that it becomes compatible with other devices as well. Compilation and

Testing has been done in both PC as well as Android.


# RUN

A single player 2 - D based cross-platform running game.

## Overview:

It is an infinite running 2-D game. Different

components that are used for the development of this game are:

**Game Engine:** This game was designed and developed using unity engine. Unity is

a cross-platform game engine developed by Unity Technologies, first announced

and released in June 2005 at Apple Inc.'s Worldwide Developers Conference as a

Mac OS X-exclusive game engine. As of 2018, the engine had been extended to

support more than 25 platforms. The engine can be used to create three-

dimensional, two-dimensional, virtual reality, and augmented reality games, as

well as simulations and other experiences. The engine has been adopted by

industries outside video gaming, such as film, automotive, architecture,

engineering and construction.

**Scene:** Scenes contain the environments and menus of your game. Think of each

unique Scene file as a unique level.

**Scripts:** The language that's used in Unity is called C# (pronounced C-sharp). All the

languages that Unity operates with are object-oriented scripting languages. Like any

language, scripting languages have syntax, or parts of speech, and the primary parts are

called variables, functions, and classes.


**Sprites or Game Objects:** Game objects are the objects or models found in the

game. These are commonly created in Png format and can be made using

photoshop or blender or can be downloaded from open-source websites for free

or from official unity asset store. Game objects are particularly important part of

any game. This is the most important component which makes a game playable

and interactive to users. Some examples of Game objects are – Coins, guns, player,

obstacles, buttons, etc. Game objects are needed to be attached in the scene. Once

game objects in a scene stays there until it is destroyed by any script. So to respawn

any game object it must be converted into prefabs. Prefabs are basically a game

object but it is created for reusability of any game object destroyed or for spawning

a new game object after some duration of time in the current scene or canvas.

**Physics:** Different physics are applied to this game such as mass, weight, velocity,

friction, and Inertia. It helps in performing different activities while playing this

game such as jumping or shooting. Applying physics helps in giving virtual life to a

game object. Unity engine supports some physics by default such as mass and

weight. For enabling mass or weight to a Png, it must be converted to a game object

then we can set a value to mass or weight. Other than these all the other physics

are applied by writing a script using C# and then attaching it to the game object.

**Menus:** GUI based menus such as main menu, pause menu, settings, credits, and

other information regarding playability of this game is created using menus. Menus

are created by combining different game objects such as buttons and backgrounds

and texts for all other information.


**Methodology:**

The basic idea was to implement a platformer infinite running script by combining

different sub scripts attached to the sprites or game objects of the game. The

sprites are being changed to **Game objects**. The infinity run was achieved by

applying the movement or velocity in minus infinity along the x axis direction in the

background as well as the base game objects. The speed of the base is faster than

background. This was done to achieve the parallax and infinite running effect. A run

script was created and then applied to the game objects. In this script velocity was

created for the movement.

This basic idea of all the scripts written for unity –

**Monobehaviour** - MonoBehaviour is the base class from which every Unity script

derives. When we use C#, we must explicitly derive from MonoBehaviour.

**Monobehaviour.Start()** - Start is called on the frame when a script is enabled just

before any of the Update methods are called the first time.

**Monobehaviour.Update()** - Update is called every frame, if the MonoBehaviour is

enabled. Update is the most commonly used function to implement any kind of

game script. Not every Monobehaviour script needs Update.

**Monobehaviour.OnTriggerEnter2D(Collider 2D)-** Sent when object enters a trigger

collider attached to the object. Further information about the other collider is

reported in the Collider2D parameter passed during the call.

This message is sent to the trigger Collider2D and the Rigidbody2D (if any) that the


trigger Collider2D belongs to, and to the Rigidbody2D (or the Collider2D if there is

no Rigidbody2D) that touches the trigger.

**Monobehaviour.OnTriggerExit2D(Collider 2D)-** Sent when object exits a trigger

collider attached to the object. Further information about the other collider is

reported in the Collider2D parameter passed during the call.

This message is sent to the trigger Collider2D and the Rigidbody2D (if any) that the

trigger Collider2D belongs to, and to the Rigidbody2D (or the Collider2D if there is

no Rigidbody2D) that touches the trigger.

Here is the pseudo code of the run script:

public class Run

{ _//Creating the object of material class used for rendering._

Material m;

public float x;

public static bool Dead = false;

_// Start is called before the first frame update_

void Start()

{

_//Using the component of the game object in which script is applied_.

m = GetComponent<Renderer>().material;

}

_// Update is called once per frame_

void Update()

{

if (Dead == false)

_// For moving the game object along the direction of x axis in realtime_


m.mainTextureOffset += new Vector2(x, 0) * Time.deltaTime;

else

```
// For pausing the game object in realtime
```
m.mainTextureOffset += new Vector2(0, 0) * Time.deltaTime;

}

}

```
Inspector of Background and Base game object attached with Run Script
```
The above Image shows the Position, Rotation and Scale of the game objects in X,

Y and Z coordinates. X axis represents horizontal transformation, Y axis represents


the vertical transformation and Z axis in 2-D represents the depth or overlapping

transformation.

**Spawning Prefabs inside scene.**

Once the user presses the play button a character is spawned and the run script is

executed to the Background and Base game object. The spawning is done by

converting a game object to a prefab. This prefab needs to be attached to a

particular GameObject which is not destroyed till the end of the playing scene. So,

a Game Object has been created. Let’s assume this game object as a Master game

object for further reference.

In this master game object a script is attached for the actions and spawn of the

main character just after the scene is executed. As we can see in the below image

a Object Script is attached which contains different values and Game Object with

variable name as Player and value is a Ninja game object. This Ninja game object is

executed when the scene starts. This is done with a predefined function

Instantiate() written in the Object Script. One line code for this is -

Instantiate(player, new Vector3(-6.26f, -0.62f, 0),

Quaternion.identity);

Vector3(x,y,z) – This represents the coordinates where the player needs to be

spawned.


_Master GameObject Inspector with Object.cs attached._

All the values achieved inside Object script is just by creating a public data members

like this –

public float randomX;

public GameObject[] spawn;
public GameObject coin;

public int randomSpawnObjects;

public float seconds =1.0f;
public float canSpawn = 0.0f;

public float timer = 0f;

public float y;
public GameObject[] lifeGem;

public GameObject player;

Here GameObject is inbuilt class of unity. So making this public we can attach any

prefab or gameobject inside this.


Similarly all other game objects are spawned in the scene. Here is the full code of

Object.cs for spawning different prefabs-

**The code spawns all the enemies as well as player in the game. The enemies are**

**spawned randomly with the help of AI. Then by observing the graph the**

**coordinates are mathematically calculated so the player jumping or flying don’t**

**collide with the enemies. The concepts of Linear algebra and graphs is used here**

**for the calculation of the coordinates.**

public class Object : MonoBehaviour
{
// Start is called before the first frame update
public static float speed =9.3f;
public static bool notMove = false;
public float randomX;
public GameObject[] spawn;
public GameObject coin;
public int randomSpawnObjects;
int i = 100; public static float x = 0.2f;
public static bool reset = false;
public float seconds =1.2f;
public float canSpawn = 0.0f;
public float timer = 0f;
public float y;
float birdY = 0.0f;
public GameObject[] lifeGem;
public GameObject player;
public static bool RootcanSpawn = false;
public static bool enemiesCanMove = false;

void Start()
{
Instantiate(player, new Vector3(-6.26f, -0.62f, 0), Quaternion.identity);
}
// Update is called once per frame
void Update()
{
if (RootcanSpawn == true)
{
if (UI.score % i == 0 && UI.score >= i && UI.score <= 500)
{
//Creating velocity for enemies in 60 FPS
speed += (float)0.45f * Time.deltaTime;
//Changing the x axis according the score collected
x += (float)0.01f * Time.deltaTime;
}
else if (UI.score % i == 0 && UI.score >= 500 && UI.score <= 1300f)


{
if(UI.score>=900)
enemiesCanMove = true;
//Creating velocity for enemies in 60 FPS
speed += (float)0.4f * Time.deltaTime;
//Changing the x axis according the score collected
x += (float)0.01f * Time.deltaTime;

}
timer += Time.deltaTime;
if (timer >= canSpawn && notMove == false)
{
//Random.Range returns the AI based random values in certain
//coordinates passed inside function parameter.
randomSpawnObjects = Random.Range(0, spawn.Length);
//switch case is used for spawning different game objects at a
//time. For which the y coordinate is calculated and entered
//for a particular random spawn objects.
switch (randomSpawnObjects)
{
case 0:
y = -2.69f;
break;
case 1:
y = -2.58f;
break;
case 2:
y = -2.67f;
break;
case 3:
y = -2.35f;
break;
case 4:
y = -2.11f;
break;
case 5:
y = -2.53f;
break;
case 6:
y = 0.0f;
birdY = -3.23f;
break;
case 7:
y = -2.03f;
break;
case 8:
y = -1.98f;
break;
case 9:
y = -2.03f;
break;
}


//Random.Range returns the AI based random values in certain
//coordinates passed inside function parameter
randomX = Random.Range(22.50f, 27.0f) + x;
Instantiate(spawn[randomSpawnObjects], new Vector3(randomX, y,
0), Quaternion.identity);
if (randomSpawnObjects == 6)
{
int randomLifeGem = Random.Range(0, lifeGem.Length);
Instantiate(lifeGem[randomLifeGem], new Vector3(randomX,
1.24f, 0), Quaternion.identity);

Instantiate(coin, new Vector3(randomX, birdY + 1.24f, 0),
Quaternion.identity);

}
else
Instantiate(coin, new Vector3(randomX, 1.24f, 0),
Quaternion.identity);
birdY = 0.0f;
canSpawn += seconds;
}
}
}
}

**Canvas**

Next a **canvas** was created for some of the in-game activities that was needed to

be performed such as pause/resume, score updates, coin updates, and other game

objects that is needed to be viewed in the scene. Basically, **canvas** is predefined

game object by unity. In this many different game objects and texts can be

attached. Unity follows a hierarchical based approach for attachment of any game

object inside another game object or prefabs. So all the prefabs and game objects

created manually are pushed to the canvas and rearranged in the scene by

transforming the coordinates of the game objects. Below is the snap shot of the


Canvas and different game object attached. This objects cannot attached

standalone so we have created a UI script for attachment.

_Canvas, game objects and scripts attached in the canvas._


The Game objects inside the Canvas are :

1. Text: The text are being changed at different frames in the game according

to the collectables and actions performed by the user playing this game.

2. Panel: Panel contains all the interactive menu buttons for in-game activity

such as resume, restart, exit, revive and main menu. All these buttons are

also game objects and are arranged in in hierarchal manner and shows up

according to the actions performed by the users. All these actions take place

according to the scripts attached in the canvas. (The detailed overviews of all

the script is written further in this documentation). Here is the snapshot of

panel and hierarchy of the game objects inside panel game object.

```
Panel game object attached in the Canvas
```
The other game objects used are coins, gems, pause, kunai, and different buttons

for interaction.


This Canvas contains the scripts of the mechanics used in the game. The mechanics

and the actions are performed with the help of scripts written in C#. Once the

frames are being updated, the script attached is executed. Here is the snapshot of

the inspector used for the Canvas.


The different component of the canvas are:

**Rect Transform** : The Rect Transform component is the 2D layout counterpart of

the Transform component. Where Transform represents a single point, Rect

Transform represent a rectangle that a UI element can be placed inside. If the

parent of a Rect Transform is also a Rect Transform, the child Rect Transform can

also specify how it should be positioned and sized relative to the parent rectangle.

**Canvas:** The Canvas is the area that all UI elements should be inside. The Canvas is

a Game Object with a Canvas component on it, and all UI elements must be children

of such a Canvas.

**Canvas Scaler:** The Canvas Scaler component is used for controlling the overall

scale and pixel density of UI elements in the Canvas. This scaling affects everything

under the Canvas, including font sizes and image borders.

**Canvas Group:** The Canvas Group can be used to control certain aspects of a whole

group of UI elements from one place without needing to handle them each

individually. The properties of the Canvas Group affect the GameObject it is on as

well as all children.

**Canvas Renderer** : The Canvas Renderer component renders a graphical UI object

contained within a Canvas.

**Creating and applying Physics in-game**

**Velocity** - The **velocity** of an object is the rate of change of its position with respect

to a frame of reference, and is a function of time. This can be achieved in unity with


the help of a function **transform.Translate().** It basically moves the transform (x,y,z

coordinates) in the direction and distance of translation. The running effect given

in this game is being done with the help of this function. Here is the code for

applying velocity in any gameobject-

transform.Translate(Vector3.left * Object.speed * Time.deltaTime);

Vector3.left is used for moving the game object in left direction along the x axis,

which is then multiplied by a variable speed which has some integer value. Then

this equation is then multiplied my Time.deltaTime. Which means the completion

time in seconds since the last frame (1frame = 1sec apx).

**Mass –** Mass can be added to a game object my adding a Rigidbody 2d component

in the Inspector of a particular came object. Steps to do this –

- Select a GameObject or a Prefab.
- In the Inspector, click on the Add component and select Rigidbody 2D.
- Now give a real number value to the Mass option in rigidbody 2d component.

**Gravity –** Gravity can be added to a game object my adding a Rigidbody 2d

component in the Inspector of a particular came object. Steps to do this –

- Select a GameObject or a Prefab.
- In the Inspector, click on the Add component and select Rigidbody 2D.
- Now give a real number value to the Gravity scale option in rigidbody 2d

component.

Same Process can be applied to **Linear Drag** and **Angular Drag.**

**Collision - Collision** , also called impact, in **physics** , the sudden, forceful coming

together in direct contact of two bodies. Collision can be applied to any game


object. With the help of a function **OnTriggerEnter2D(Collider2D <variable**

**name>).** Sent when object enters a trigger collider attached to the object. Further

information about the other collider is reported in the Collider2D parameter passed

during the call. This message is sent to the trigger Collider2D. Here is an example

code for OnCollisionEnter2D() –

void OnCollisionEnter2D(Collision2D collision)
{

if (collision.collider.tag == "base")

{
Player.a.SetBool("isJump", false);

player.GetComponent<Player>().isGround = true;

Player.isGlide = false;
}

}

**Jump and shoot script for the player.**

**Jump -**

The Basic pre-requisites for applying jumping to any game object is that the game

object should have mass and gravity scale. This is necessary so as to give a free fall

to the game object.

- Assign a Input key(for keyboard) or touch (for touchscreen devices).
- When input == true
- gameobject.velocity = Vector2.up * jumpsize;

Here is the code for Jumping –

if (Input.GetKeyDown(KeyCode.Space)&& Run.Dead == false)
{

{
if (isGround == true)

{

if (MainMenu.isSoundOn == 0)


FindObjectOfType<audioScript>().playSound("jump");

play.velocity = Vector2.up * jumpSize;
}

}

**Shoot –**

- Assign a Input key(for keyboard) or touch (for touchscreen devices).
- When input == true
- Instantiate the game object such as ammos or stones to the position from

which shooting would take place.

- Applying velocity and collision in the game object instantiated.
- Destroy the game object using Destroy(this.<gameObject>) function once

collision take place and hits the target.

Here is the code that is applied for Shooting –

if (Input.GetKeyDown(KeyCode.RightArrow)){

if (Time.time>canFire)
{

a.SetBool("isAttack", true);

Instantiate(gameobject, transform.position + new
Vector3(1, 0, 0), Quaternion.Euler(new Vector3(0, 0, -90f)));

UI.kunaiCount -= 1;
ui.updateKunai();

canFire = Time.time + 0.25f;

StartCoroutine(attack());
}

}

**Animations**

Almost every game object has some animation in this game.


These are the Prefabs used in this game. Most of them are animating. For applying

animations a animator component is needed to be attached in the game object.

This is the animator attached to the Ninja Prefab.

Here is the list of all animations applied to Ninja Prefab –

The animations are applied frame by frame to all the PNG of a single game object.

The frame timings can be adjusted using unity animator and occurrence of different

animations can also be adjusted using animator.


## References

**Assets** – Unity asset store (https://assetstore.unity.com/)

**Sprites** – Craft Prix (https://craftpix.net/freebies/)

Game art 2d (https://www.gameart2d.com/freebies.html)

Itch.io (https://itch.io/game-assets/free)


