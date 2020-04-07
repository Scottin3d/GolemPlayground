# Coding Adventure

## Place holder for gif  

## Overview  
The player is a golem that rolls around the level trying to cover itself in moss before the other players.  This is a development log for the player creation using a script and
the player controller.  A golem is a rock-troll like creature.  Various versions can be found in games of all genres.

<img src="https://vignette.wikia.nocookie.net/clashofclans/images/c/c2/Golem_info.png/revision/latest/scale-to-width-down/340?cb=20170927231256" alt="Clash of Clans Golem" width="200"/>
<img src="https://pokemon.gameinfo.io/images/pokemon-go/076-00.png" alt="Pokemon Golem" width="200"/>
<img src="https://www.gamehiker.com/wiki/images/thumb/f/f1/Goron.jpg/200px-Goron.jpg" alt="Goron Legend of Zelda" width="200"/>

## Player Generation

### Generating the basic player

First, I started by using a basic geosphere model imported from 3ds Max.  Eventually, I would like this to be scripted for more percise control over the exact size and number of segments.
Then, a prefab model is instantiated on the vertices of the the geohphere.  The geosphere acts as the parent model with all of the physicals related components and will not be rendered.

### Parent Geosphere
<img>  
In order to get the spawn vertices for the instantiated objects, first I needed to get the meshfilter off of the reference model and then add the vertices to a list.  

```C#
	// get mesh
    var MeshFilter = BaseModel.GetComponent<MeshFilter>();
    // get verticies to spawn instance meshes
    Vector3[] vertices1 = MeshFilter.sharedMesh.vertices;
```

### Instantiated Prefab 

After getting a list of vertices, I could now loop through them and instantiate an object at each point.  I ran into a couple errors, but I quickly figured out what was happening.  

```C#
// spawn isntance meshes
for (int i = 0; i < vertices1.Length; i++) {
	// set a random rotation
	Vector3 Rotation = new Vector3(Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f));
	// set position
	Vector3 Position = vertices1[i];
	var GolInstance = Instantiate(GolPrefab, Position, Quaternion.identity);
}
```
If I did not take into account the current position of the player when spawned, it would place them at the vertex location of the reference model at a world space of (0,0,0).  
To fix this, I just added transform.position to the vertex.  

```C#
// add player position
Vector3 Position = transform.position + vertices1[i];
```
After instantiating the object, I set the parent to the player, adjusted the local scale of the object, and set a random rotation so that they all do not face the same orientation.  

```C#
GolInstance.transform.parent = transform;
GolInstance.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
GolInstance.transform.Rotate(Rotation);
```

Finally, I added the material to the instantiated object.  

```C#
// add rock material to instance
GolInstance.GetComponent<MeshRenderer>().material = Texture;
```
### Working Prototype
<img>  

```C#  
	
```

## Game Logic  

### Color Change  
The objective of the game is to roll around and collect moss on you player.  To protoype a simplistic version of the mechanic, I just kept track of a float and incremented when the player pressed WASD.  

```C#
if (Input.GetKey(KeyCode.W)) {
  FillLevel += FillSpeed;
  UpdateColor();
}
```
At first, it changed all of the objects at once.  In order to only change one at a time, I needed to keep track of the number of instances and the current index.  
```C# 
void UpdateColor() {
  ObjCount = GScript.ObjCount;
  if (FillLevel >= 1.0f) {
    ObjFillIndex++;
    FillLevel = 0f;
  }
  GScript.GolemPieces[ObjFillIndex].GetComponent<Renderer>().material.color = Color.Lerp(StartColor, EndColor, FillLevel);
 }
 ```
 
 As another game play mechanic, the player will be able to jump and when they land, send a shockwave out that will effect other players.  This however comes at a cost.
 Each jump will cost the player a certain amount of their collected moss (about one stone worth).  
 ```C#
if (Input.GetKeyDown(KeyCode.Space)) {
  FillLevel -= JumpCost;
  UpdateColor();
  ObjFillIndex--;
}
```

## Conclusion 