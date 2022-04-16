# Studio Creative Tutorials - Shader Graph
 
**Date**: TBD<br>
**Location**: TBD<br>
**Instructor(s)**: TBD
 
### Resources
* Slides Coming Soon
* Video Coming Soon
 
### Topics Covered
* [Shaders](#shaders)
  * [What is a shader?](#what-is-a-shader)
  * [What can shaders do?](#what-can-shaders-do)
  * [When should I use a shader?](#when-should-i-use-a-shader)
  * [How do I make and use shaders in Unity?](#how-do-i-make-and-use-shaders-in-unity)
* [Shader Graph](#shader-graph)
  * [Setup](#setup)
  * [Creating a Shader](#creating-the-simplest-shader-possible)
  * [UV Coordinates](#uv-coordinates)
 
### What You'll Need
<details>
 <summary>Unity version 2020.3.33f1</summary>
 <ul>
  <li>Other 2020 versions, as well as newer versions, should also work.</li>
  <li>Note that in 2021 versions, shaders generated with Shader Graph are not compatible with UI components, unlike 2020 versions.</li>
 </ul>
</details>
<details>
 <summary>Universal Render Pipeline (URP) package</summary>
 <ul><li>Other scriptable render pipelines (such as HDRP) should also work, although they may require more setup not covered in this tutorial.</li></ul>
</details>
<details>
 <summary>Shader Graph package</summary>
 <ul><li>This is included in the URP and HDRP packages, but can also be installed separately.</li></ul>
</details>

Detailed setup instructions are covered [below](#setup).

---

## Shaders
### What is a shader?
The term **shader** is often used to refer to several related concepts, but in the broadest sense a shader is a program that runs on the GPU instead of the CPU. This includes compute shaders and ray tracing shaders, but for the purposes of this tutorial, we are interested in graphics pipeline shaders which determines the color of pixels, or in other words, determine what you see on the screen.

For the rest of this tutorial, we will use shader to refer to this type of graphics pipeline shader specifically, unless otherwise noted, but you can read more about these other kinds of shaders at the links provided in [Additional Resources](#additional-resources) below. These graphics pipeline shaders run during the rendering step of Unity's graphics pipelines, which you can learn more about [here](https://github.com/uclaacm/studio-creative-tutorials/blob/fall-21/Post%20Processing/Dictionary/Render%20Pipelines.md).

A shader is composed of two parts: a **vertex shader** and a **fragment shader**. The vertex shader runs first, and does computations for each **vertex** in the mesh a object being rendered is composed of. Vertex shaders can run computations including moving the position of vertices to distort the mesh (and thus its appearance), and running calculations to produce data that will be used by the fragment shader, such as determining the distance to a specific point at each vertex. After the vertex shader runs, the GPU does some processing to interpolate the output of the vertex shader between the vertices, and rasterizes the object being rendered to produce **fragments**. (You can think of fragments as the pixels on the screen, although they're not actually equivalent.) Finally, the fragment shader does computations for each fragment to determine what color it should be.

#### Materials
<img src="./Sprite%20Tinted.png" width=325 align="right" alt="material using default shader but tinted blue"/>
<img src="./Sprite%20Untinted.png" width=325 align="right" alt="material using default shader but untinted"/>

Unity also has assets called **materials**, which are different but related to shaders. In essence, a material is a collection of textures, numbers, and other values used by the material's shader as inputs. Thus, you can create multiple materials that use the same shader, but have different values, to create different graphics while reusing the shader.

<img src="./Sprite%20Materials.png" width=325 align="right" alt="studio logo, one untinted and the other tinted blue"/>

For example, the images to the right show two materials which both use the `Sprites/Default` shader, but one of them is set to be tinted blue, while the other is untinted. When applied to a sprite with the ACM Game Studio logo, the tinted material causes the logo to be tinted blue, even though both materials use the same shader.

<details>
 <summary>An Aside About MaterialPropertyBlocks</summary>
 All objects which use the same material will share the same values for the parameters. This can be very helpful if you need to create a bunch of objects which look identical, but if you need to modify the parameters at runtime for individual instances instead of all of the objects, you can use <a href="https://docs.unity3d.com/ScriptReference/MaterialPropertyBlock.html">MaterialPropertyBlocks</a>. Unfortunately, MaterialPropertyBlocks don't work with UI components, so the other workaround for those is to create a material for each instance you want to modify separately.
</details>

### What can shaders do?
At the very basic level, shaders let your game actually display things - Unity provides a plethora of built-in shaders that do just that. However, shaders can also be used to do much, much more! Here are a few images illustrating what shaders can do, with links to guides/tutorials on recreating them:

| <img src="https://i1.wp.com/cghow.com/wp-content/uploads/2019/02/ToonShaderAnimation.gif" width=300 alt="toon shader with directional light"/> | <img src="http://3909.co/dev/od/img/Dither2-CameraSphere2.gif" width=300 alt="monocolor dither shader"/> | <img src="https://images.squarespace-cdn.com/content/v1/5a724d26a8b2b04c5d34119e/1534964689364-56OGVPAS5EIT8KHPJ7I6/grass2.gif" width="300" alt="low-poly grass waving in the wind"/> |
| :-: | :-: | :-: |
| A cell shader (also known as a toon shader), featuring two-tone shading (with hard lines separating light and shadow), specular reflection (brighter highlights representing reflected light), and rim lighting (bright edges). | A monocolor dithering shader from *Return of the Obra Dinn*, using a pixellated dithering pattern to show light and shadow. | A vertex shader simulating grass blowing in the wind, achieved by animating the position of vertices based on world position and local y position. |
| [Toon Shader Tutorial](https://roystan.net/articles/toon-shader.html) | [*Return of the Obra Dinn* Devlog](https://forums.tigsource.com/index.php?topic=40832.msg1363742#msg1363742) | [Waving Grass Tutorial](https://lindenreidblog.com/2018/01/07/waving-grass-shader-in-unity/) |

### When should I use a shader?
Although the above shaders look really cool, you might be wondering why we use shaders instead of simply baking the art style into the art. Actually, that is frequently a valid approach - but there are also many times when using a shader is better or even the only way to do something. The primary reason you might use a shader is dynamic effects. For things such as lighting, the look of the object has to be calculated at runtime - there's simply no way to include how an object might look from every possible angle with every configuration of lights while making the game. Other effects that rely on data only available at runtime like how a building will look after the player splatters paint on it randomly can also only be done with shaders. Another reason to use shaders is saving development time. Although you could in theory draw a thousand different color variations of an item, it's much less time consuming to simply use a shader to recolor the item. Finally, shaders can help with optimization to make the game run faster - the GPU is really good at parallelism, so it's much more efficient to allow the GPU to animate wind blowing through thousands of blades of grass than using the CPU. (In fact, the compute shaders mentioned earlier take this a step further by running calculations often completely unrelated to graphics on the GPU to speed up the game).

### How do I make and use shaders in Unity?
Unity has two primary methods for creating custom shaders. First, you can write a shader in **ShaderLab** (a Unity-specific language used to define the structure of a shader and can contain multiple shader programs) and **HLSL** (high-level shader language, in which the actual shader programs are written). Second, you can use Unity's **Shader Graph** package to create shaders with a visual node-based system.

This tutorial will focus on Shader Graph because it's much easier to pick up, and provides an easy way to start developing your intuition for the math behind beautiful shaders (warning: shaders involve a lot of math). That being said, if you are serious about diving into the world of shaders, you'll want to learn ShaderLab and HLSL eventually, since Shader Graph has a few disadvantages such as not being compatible with the built-in render pipeline, and that some effects are impossible to create in Shader Graph alone because tools like the stencil buffer are only available with code.

Once you have a shader, regardless of how it was created, you will need a material to use it. You can right-click in the `Project` section of Unity and use `Create → Material` to create a new material, then change the shader the material uses near the top of the inspector window. After filling in any appropriate parameters for your material to provide to the shader, you can add it to a game object by finding the object's `Renderer` component (e.g. `MeshRenderer`, `SpriteRenderer`, `Image`) and dragging your material into the renderer's `Material` parameter.

## Shader Graph
### Setup
<img src="./Universal%20RP%20Package.png" align="right" width=500 alt="Universal RP package in Unity registry"/>

For this tutorial, we will be working in a new, empty 2D project. Since Shader Graph is not compatible with Unity's built-in render pipeline, we will need to install the Universal Render Pipeline, or URP. To install this package, open the Package Manager by going to `Window → Package Manager`, then find and install the `Universal RP` package in the Unity registry.

<img src="./Project%20Settings.png" align="right" width=500 alt="Graphics section of the project settings, with the URP pipeline asset selected"/>

The Universal RP package actually includes the Shader Graph package as a dependency, so installing it will also automatically install Shader Graph as well. However, before we can start using Shader Graph, we need to configure the project's settings to use URP instead of the built-in pipeline. First, in your project right click and select: `Create → Rendering → Universal Render Pipeline → Pipeline Asset (Forward Renderer)`. This should create a `UniversalRenderPipelineAsset` and a `UniversalRenderPipelineAsset_Renderer`.

Next, go to `Edit → Project Settings` and find the `Graphics` section. In the scriptable render pipeline section, select or drag in your `UniversalRenderPipelineAsset`, as shown in the image to the right. Finally, in the hierarchy, right click and select `2D Object → Sprites → Square`. Select the square, and in the inspector, change the sprite to a more interesting image (preferably one with some transparent parts instead of a full rectangle). We will be using this sprite to test your shaders with. Congratulations, you are now ready to start working in Shader Graph!

### Creating the Simplest Shader Possible
In the project section, right click and select `Create → Shader → Universal Render Pipeline → Sprite Unlit Shader Graph`, and name the newly create Shader Graph asset. Then right click your new Shader Graph asset and select `Create → Material`, and name that material too. Finally, select your square and drag your new material into the material parameter of the `Sprite Renderer` component. Your sprite should turn into a grey square in the scene. Huzzah! You've made the simplest shader possible - one that always draws a grey square.

<img src="./Shader%20Graph%20Window.png" align="right" width=700 alt="Shader Graph window"/>

Okay, but we probably want to at least show your original image instead of a grey square. To do that, we'll need to open up Shader Graph by double-clicking on the shader graph asset you made earlier. Something like the image to the right should pop up - this is the shader graph window. At the top of the window is a bar with a couple of buttons - most notably the `Save Asset` button. Shader Graph won't save by itself, and the normal save shortcut of `Ctrl+s` or `Cmd+s` don't seem to work, so you'll need to remember to press that save button often.

On the right side of the top bar, there are also three buttons to enable and disable the `Blackboard`, `Graph Inspector`, and the `Main Preview`. If you click these buttons, you'll find that the the `Blackboard` is that box on the left, the `Graph Inspector` is the box in the upper right, and the `Main Preview` is the box in the lower right. The `Blackboard` is where you can define properties (input parameters) and keywords (used to make shader variants, but outside the scope of this tutorial). The `Graph Inspector` is like the inspector window of the rest of Unity, except just for Shader Graph. It shows the graph's settings, and if you click on a node in the graph, it will also show the settings for that node. Finally, the `Main Preview` shows what the current graph will output. By default, it maps to a sphere, but since we're working with a sprite, you should right click it and select `Quad` instead.

Finally, in the center, you should see a node labeled `Vertex` and node labeled `Fragment`, which we'll need to connect the output of other nodes to in order to not display a grey square. You can move these (and other nodes) by clicking and dragging, and you can pan around the graph by holding the left alt key while clicking and dragging. Alright, can you guess which of the parameters on the Vertex and Fragment nodes we need to modify to show a non-grey box?

<details>
 <summary>Answer</summary>
 We need to change the Base Color(3) of the fragment node! If you click on the grey box connected to the Base Color(3) node, you can pick a different non-grey color for your sprite. Progress! Note that the (3) at the end of Base Color(3) indicates that this parameter has three channels - namely red, green, and blue. Other parameters like Position(3) can also have three channels but have them mean something completely different (such as x, y, and z coordinates). Values with up to 4 channels are common in Shader Graph, so you'll need to get used to remembering how many channels each parameter has and what each channel means!
</details>

To display the sprite instead of a square, the shader will need a property to accept input from the renderer. On the `Blackboard`, click the plus button and add a new `Texture2D` property, or basically an image. Click on the property to inspect it in the `Node Settings` section of the `Graph Inspector`. Change the `name` **and** the `reference` to `_MainTex` exactly. The reference **must** be `_MainTex` in order for the renderer to correctly supply the sprite to the shader. In addition, you can choose your image as the default, so it will show up instead of a monocolor square when we start connecting nodes.

Click and drag the `_MainTex` property onto the graph to create a node. Unfortunately, if we try to drag the output of this node to attach it to any of the vertex and fragment inputs, it will fail to connect, because we can't convert a `Texture2D` into `Vector(3)` or a `Vector(1)`. Instead, we need to sample the texture first. Right click and select `Create Node`. Then find and select `Sample Texture 2D` by typing in the search bar or under `Input → Texture` to create the node. You can connect the `_MainTex` node to the `Texture(T2)` input of the `Sample Texture 2D` node, and your image should appear!

The `Sample Texture 2D` node also has two other inputs, of which `UV(2)` is very important. But we'll cover that a little later. Instead, we now need to link the output of the `Sample Texture 2D` node to the output so that our shader correctly displays an image. Try to figure this part out on your own based on what you've learned so far! The solution is below if you get stuck.

<details>
 <summary>Finished shader</summary>
 <img src="./Finished%20Shader.png"/>
 Connect the RGBA(4) output to the Base Color(3) input. Note that even though RGBA has 4 channels, shader graph intelligently drops the 4th channel automatically. However, that means we also still need to supply that 4th alpha channel somewhere, namely the Alpha(1) input. If you don't do this, your image won't have transparent parts!
</details>

### UV Coordinates
#### What are UV coordinates?
UV coordinates are a way of mapping a 2D texture onto a 3D surface! As shown in the images below, to properly texture a 3D model you need some way to "unwrap" the 3D model into a flat 2D plane. Then a shader can use those UV coordinates to determine what should go on your screen.

<p align="center">
 <img src="https://www.pluralsight.com/content/dam/pluralsight/blog/dt/wp-uploads/2014/01/UV_Distortion.jpg" width=500 alt="Mapping a 2D texture onto a 3D dinosaur"/>
 <img src="https://www.pluralsight.com/content/dam/pluralsight/blog/dt/wp-uploads/2014/01/UVs_Example.jpg" width=500 alt="Unwrapping the 3D dinosaur onto a 2D plane"/>
</p>

<img src="./UV%20Coordinates.png" width=500 alt="Splitting UV coordinates into separate channels" align="right"/>

Even though we're working with sprite shaders today, it turns out there are a lot of neat things you can do with UV coordinates, even when you're on a `Quad` (a flat plane). But first, let's take a look at how to read UV coordinates in Shader Graph. The image to the right shows a UV node connected to a `Split` node to split the two channels of the UV. Each channel is then connected to a `Preview` node to show what each channel looks like.

The preview of the UV might be confusing at first glance, but take a look at each channel separately. The red channel is black on the left and white on the right, indicating that it increases from 0 to 1 from left to right. Similarly, the green channel is black on the bottom and white on the top, increasing from 0 to 1 from bottom to top. So basically, the default UV coordinates are a square with (0,0) in the lower left corner and (1,1) in the upper right, and this is represented with red and green. Thus, in the lower left, where red and green are both close to 0, the preview is black, and in the upper right where red and green are both close to 1, the preview is a bright yellow (the combination of red and green). On the lower right where red is much greater than green, the preview is red, and in the upper left where green is much greater than red, the preview appears green. Make sense? If not, play around with these nodes and some basic math nodes until it does, because you'll need a solid understanding of how to read UV coordinates in the future.

#### Transforming UV coordinates
Pop quiz time! Using UV coordinates, figure out how to make each effect.

<details>
 <summary>Flip an image vertically.</summary>
 <img src="./Flip%20Vertical%20Solution.png" alt="Shader Graph for flipping an image vertically."/>
 If we subtract the green channel from 1, that makes the top of the square black, and the bottom white, flipping it vertically. (There is a subtract node, but why use that when we have a handy one-minus node available?) Then we recombine it with the red channel and feed that into the UV coordinates.
</details>
<details>
 <summary>Flip an image across its diagonal.</summary>
 <img src="./Flip%20Diagonal%20Solution.png" alt="Shader Graph for flipping an image across its diagonal."/>
 If we simply swap the red and the green channels, our image is flipped! (There's actually a node for this called the Swizzle node, which works for changing the order of up to 4 channels. This solution just splits and recombines for clarity though.)
</details>
<details>
 <summary>Rotate an image 90 degrees counterclockwise.</summary>
 <img src="./Rotate%20Counterclockwise%20Solution.png" alt="Shader Graph for rotating an image 90 degrees counterclockwise."/>
 The solution to this puzzle is simply combining the previous two puzzles. We use one minus on the red channel before swizzling. Note the use of a redirect node to route the connection around another node, making the graph more readable!
</details>
<details>
 <summary>Split the image into 4 corners, each showing the plus symbol.<br>
  <img src="./Four%20Corners%20Puzzle.png" alt="An image split into four corners." width=100/>
 </summary>
 <img src="./Four%20Corners%20Solution.png" alt="Shader Graph for splitting an image into four corners."/>
 This one's definitely trickier! We add 0.5 to both red and green channels, then subtract both channels from one, and take the absolute value of that. This gives us (0,0) in the center, and (0.5, 0.5) in the corners!
</details>
<details>
 <summary>Fully duplicate the image in each corner.<br>
  <img src="./Four%20Puzzle.png" alt="Image that has been duplicated in each corner." width=100/>
 </summary>
 <img src="./Four%20Puzzle%20Solution.png" alt="Shader Graph for duplicating an image in each corner."/>
 Here, we multiply the entire UV by 2, and then take the fractional part of that with the frac node. This leaves us with 4 copies of the UV, one in each corner. There's actually a Tiling and Offset node, which we will cover next, that does this as well.
</details>

#### Scrolling Textures
The Tiling and Offset node allows us to tile UV coordinates to create duplicates of an image, with an offset. We can combine this with the Time node, which provides input information about how much time has passed, to create an infinitely scrolling texture. Using these nodes and what you've learned so far, try creating a shader which will tile an image four times and scroll infinitely, repeating the images forever!
<details>
 <summary>Infinitely scrolling textures!</summary>
 <img src="./Scrolling.png" alt="Shader graph for infinitely scrolling texture"/>
 We can connect the time node to the Offset(2) to scroll diagonally. However, we need to take the fractional component of the Tiling and Offset node since both tiling and offset will increase the values of the UV past 1.
</details>

#### Screen Space UV
Right click and create a `Screen Position` node. Look familiar? Try swapping it in and playing around with it to see what happens!
<details>
 <summary>UV Spaces</summary>
 Thus far, we've been working with UVs in terms of the object, but you can also apply UVs from other "spaces" or coordinate systems, such as the entire screen, where the lower left corner of the screen is (0,0) and the upper right corner of the screen is (1,1). In case you didn't see it while messing around, the Screen node provides the width and height of the screen, so some simple division can tell you how to scale an image to maintain its correct aspect ratio and size. In addition to screen UVs, you can even use world position as your UVs!
</details>

---

## Additional Resources
* [Unity Documentation: Shaders](https://docs.unity3d.com/Manual/Shaders.html)
* [Unity Documentation: ShaderLab](https://docs.unity3d.com/Manual/SL-Reference.html)
* [Unity Documentation: MaterialPropertyBlocks](https://docs.unity3d.com/ScriptReference/MaterialPropertyBlock.html)

## Non-Essential Links
- [Studio Discord](https://discord.com/invite/bBk2Mcw)
- [Linktree](https://linktr.ee/acmstudio)
- [ACM Membership Portal](https://members.uclaacm.com/)
- [Unity Documentation](https://docs.unity3d.com/Manual/index.html)
- [ACM Website](https://www.uclaacm.com/)
- [ACM Discord](https://discord.com/invite/eWmzKsY)
