## What is a Render Pipeline?
A render pipeline can be thought of as a list of steps that a game engine will go through to take a scene from what it looks like in the game engine to what a player might see on the screen. These steps can be reordered and you can even create custom render pipelines if you wish depending on need. They can also (in Unity), be split into three steps on default.

**1. Culling**<br>
Culling can be thought of as removing anything that is not necessary for the scene to load. A common example is not loading objects that don't exist in the camera view (and is often the source of many spawning/loading problems in AAA games, like Cyberpunk), or not loading things that don't exist in the current level/chunk (seen when protagonists have to squeeze through tight cracks to get to the next area; this is simply the game loading objects that were culled previously). This is to increase load and compile times. 

**2. Rendering**<br>
Once the engine has determined what objects it must load, it will then calculate and establish those objects in the scene-- this is the rendering stage. The engine will proceed to load transforms, lighting, materials, textures, scripts-- anything that you can find in the components inspector in Unity, the engine will load.

**3. Post-Processing**<br>
Just like how color-grading, contrast, etc. are done by editors after the scene has been filmed in TV/movies, the same can be said for games. After objects have been loaded in a scene, specific post-processes (basically shaders) are applied, giving the game different camera effects to change certain aspects about the scene like reflections, or skyboxes. At its most basic, it can be thought of as a form of image processing.

## Unity's Different Render Pipelines
Unity's render pipelines can be split into two types: Built in, and Scriptable (referred to from now as SRP). Essentially, SRPs can be fully customized, rearranged, and beyond; the built in pipeline cannot, but you can choose certain different paths. The SRP then has a couple pre-built pipelines: the Universal Render Pipeline (now referred to as the URP), and the High Definition Render Pipeline (now referred to as HDRP).

**1. Universal Render Pipeline/URP**<br>
The URP was previously called the Lightweight Render Pipeline, which is endemic of its use; it's meant for high degree of customization and speed. Because it also contains the 2D lighting system, 90% of 2D games would do best in the URP.

**2. High Definition Render Pipeline**<br>
The HDRP allows for incredibly high fidelity and high degree of control over a large number of materials, textures, and shaders. Post-processing (and other computation heavy processes) are also streamlined. This makes the HDRP best suited for making graphically intense and --for lack of a better word-- stereotypical AAA style games.
