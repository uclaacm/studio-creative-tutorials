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
  * [How do I make and use shaders in Unity?](#how-do-i-make-and-use-shaders-in-unity)
* [Shader Graph](#shader-graph)
  * [Setup](#setup)
  * [Creating a Shader](#creating-the-simplest-shader-possible)
 
### What You'll Need
* Unity version 2020.x or newer. Note that in 2021 versions, shaders generated with Shader Graph are not compatible with UI components, unlike 2020 versions.
* A scriptable render pipeline - the URP (universal render pipeline) package is recommended.
* Shader Graph package (which is included within the URP package, but can also be installed separately).

Note that more detailed setup instructions are covered [below](#setup).

---

## Shaders
### What is a shader?
The term **shader** is often used to refer to several related concepts, but in the broadest sense a shader is a program that runs on the GPU instead of the CPU. This includes compute shaders and ray tracing shaders, but for the purposes of this tutorial, we are interested in graphics pipeline shaders which determines the color of pixels, or in other words, determine what you see on the screen.

For the rest of this tutorial, we will use shader to refer to this type of graphics pipeline shader specifically, unless otherwise noted, but you can read more about these other kinds of shaders at the links provided in [Additional Resources](#additional-resources) below.

A shader is composed of two parts: a **vertex shader** and a **fragment shader**. The vertex shader runs first, and does computations for each **vertex** in the mesh a object being rendered is composed of. Vertex shaders can run computations including moving the position of vertices to distort the mesh (and thus its appearance), and running calculations to produce data that will be used by the fragment shader, such as determining the distance to a point at each vertex. After the vertex shader runs, the GPU does some processing to interpolate the output of the vertex shader between the vertices and rasterizes the object being rendered to produce **fragments**. (You can think of fragments as the pixels on the screen, although they're not actually equivalent.) Finally, the fragment shader does computations for each fragment to determine what color it should be.

#### Materials
<img src="./Sprite%20Tinted.png" width="300" align="right" alt="material using default shader but tinted blue"/>
<img src="./Sprite%20Untinted.png" width="300" align="right" alt="material using default shader but untinted"/>

Unity also has assets called **materials**, which are different but related to shaders. Basically, a material is a preset configuration of parameters that should be used in a shader, so multiple materials can use the same shader with different parameters.

For example, the images to the right show two materials which both use the `Sprites/Default` shader, but one of them is set to be tinted blue while the other is untinted.

Note: All objects which use the same material will share the same values for the parameters, even if the values are changed at runtime. If you want to modify these parameters at runtime separately for different objects without creating a bunch of identical materials, you can use [`MaterialPropertyBlocks`](https://docs.unity3d.com/ScriptReference/MaterialPropertyBlock.html).

### What can shaders do?
At the very basic level, shaders let your game actually display things - Unity provides a plethora of built-in shaders that do just that. However, shaders can also be used to do much, much more! Here are a few images illustrating what shaders can do, with links to guides/tutorials on recreating them:

| <img src="https://i1.wp.com/cghow.com/wp-content/uploads/2019/02/ToonShaderAnimation.gif" width=300 alt="toon shader with directional light"/> | <img src="http://3909.co/dev/od/img/Dither2-CameraSphere2.gif" width=300 alt="monocolor dither shader"/> | <img src="https://images.squarespace-cdn.com/content/v1/5a724d26a8b2b04c5d34119e/1534964689364-56OGVPAS5EIT8KHPJ7I6/grass2.gif" width="300" alt="low-poly grass waving in the wind"/> |
| :-: | :-: | :-: |
| A cell shader (also known as a toon shader), featuring two-tone shading (with hard lines separating light and shadow), specular reflection (brighter highlights representing reflected light), and rim lighting (bright edges). | A monocolor dithering shader from *Return of the Obra Dinn*, using a pixellated dithering pattern to show light and shadow. | A vertex shader simulating grass blowing in the wind, achieved by animating the position of vertices based on world position and local y position. |
| [Toon Shader Tutorial](https://roystan.net/articles/toon-shader.html) | [*Return of the Obra Dinn* Devlog](https://forums.tigsource.com/index.php?topic=40832.msg1363742#msg1363742) | [Waving Grass Tutorial](https://lindenreidblog.com/2018/01/07/waving-grass-shader-in-unity/) |

### How do I make and use shaders in Unity?
Unity has two primary methods for creating custom shaders. First, you can write a shader in **ShaderLab** (a Unity-specific language used to define the structure of a shader and can contain multiple shader programs) and **HLSL** (high-level shader language, in which the actual shader programs are written). Second, you can use Unity's **Shader Graph** package to create shaders with a visual node-based system.

This tutorial will focus on Shader Graph because it's much easier to pick up, and provides an easy way to start developing your intuition for the math behind beautiful shaders (warning: shaders involve a lot of math). That being said, if you are serious about diving into the world of shaders, you'll want to learn ShaderLab and HLSL eventually, since Shader Graph has a few disadvantages such as not being compatible with the built-in render pipeline, and that some effects are impossible to create in Shader Graph alone because tools like the stencil buffer are only available with code.

Once you have a shader, regardless of how it was created, you will need a material to use it. You can right-click in the `Project` section of Unity and use `Create → Material` to create a new material, then change the shader the material uses near the top of the inspector window. After filling in any appropriate parameters for your material to provide to the shader, you can add it to an game object by finding the object's `Renderer` component (e.g. `MeshRenderer`, `SpriteRenderer`, `Image`) and dragging your material into the renderer's `Material` parameter.

## Shader Graph
### Setup
<img src="./Universal%20RP%20Package.png" align="right" width=500 alt="Universal RP package in Unity registry"/>

For this tutorial, we will be working in a new, empty 2D project. Since Shader Graph is not compatible with Unity's built-in render pipeline, we will need to install one of Unity's scriptable render pipeline. For this tutorial, we will be using the Universal Render Pipeline, or URP. To install this package, open the Package Manager by going to `Window → Package Manager`, then find and install the `Universal RP` package in the Unity registry.

<img src="./Project%20Settings.png" align="right" width=500 alt="Graphics section of the project settings, with the URP pipeline asset selected"/>

The Universal RP package actually includes the Shader Graph package as a dependency, so installing it will also automatically install Shader Graph as well. However, before we can start using Shader Graph, we need to configure the project's settings to use URP instead of the built-in pipeline. First, in your project right click and select: `Create → Rendering → Universal Render Pipeline → Pipeline Asset (Forward Renderer)`. This should create a `UniversalRenderPipelineAsset` and a `UniversalRenderPipelineAsset_Renderer`.

Next, go to `Edit → Project Settings` and find the `Graphics` section. In the scriptable render pipeline section, select or drag in your `UniversalRenderPipelineAsset`, as shown in the image to the right. Finally, in the hierarchy, right click and select `2D Object → Sprites → Square`. Select the square, and in the inspector, change the sprite to a more interesting image (preferably one with some transparent parts instead of a full rectangle). We will be using this sprite to test your shaders with. Congratulations, you are now ready to start working in Shader Graph!

### Creating the Simplest Shader Possible
In the project section, right click and select `Create → Shader → Universal Render Pipeline → Sprite Unlit Shader Graph`, and name the newly create Shader Graph asset. Then right click your new Shader Graph asset and select `Create → Material`, and name that material too. Finally, select your square and drag your new material into the material parameter of the `Sprite Renderer` component. Your sprite should turn into a grey square in the scene. Huzzah! You've made the simplest shader possible - one that always draws a grey square.

<img src="./Shader%20Graph%20Window.png" align="right" width=700 alt="Shader Graph window"/>

Okay, but we probably want to at least show your original image instead of a grey square. To do that, we'll need to open up Shader Graph by double-clicking on the shader graph asset you made earlier. Something like the image to the right should pop up - this is the shader graph window. At the top of the window is a bar with a couple of buttons - most notably the `Save Asset` button. Shader Graph won't save by itself, and the normal save shortcut of `Ctrl+s` or `Cmd+s` don't seem to work, so you'll need to remember to press that save button often.

On the right side of the top bar, there are also three buttons to enable and disable the `Blackboard`, `Graph Inspector`, and the `Main Preview`. If you click these buttons, you'll find that the the `Blackboard` is that box on the left, the `Graph Inspector` is the box in the upper right, and the `Main Preview` is the box in the lower right. The `Blackboard` is where you can define properties (input parameters) and keywords (used to make shader variants, but outside the scope of this tutorial). The `Graph Inspector` is like the inspector window of the rest of Unity, except just for Shader Graph. It shows the graph's settings, and if you click on a node in the graph it will also show the settings for that node. Finally, the `Main Preview` shows what the current graph will output. By default, it maps to a sphere, but since we're working with a sprite, you should right click it and select `Quad` instead.

Finally, in the center, you should see a node labeled `Vertex` and node labeled `Fragment`, which we'll need to connect the output of other nodes to in order to not display a grey square. You can move these (and other nodes) by clicking and dragging, and you can pan around the graph by holding the left alt key while clicking and dragging. Alright, can you guess which of the parameters on the Vertex and Fragment nodes we need to modify to show a non-grey box?

<details>
 <summary>Answer</summary>
 We need to change the `Base Color(3)` of the fragment node! If you click on the grey box connected to the `Base Color(3)` node, you can pick a different non-grey color for your sprite. Progress! Note that the (3) at the end of `Base Color(3)` indicates that this parameter has three channels - namely red, green, and blue. Other parameters like `Position(3)` can also have three channels but have them mean something completely different (such as x, y, and z coordinates). Values with up to 4 channels are common in Shader Graph, so you'll need to get used to remembering how many channels each parameter has and what each channel means!
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
