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
<img src="./Sprite%20Tinted.png" width="300" align="right"/>
<img src="./Sprite%20Untinted.png" width="300" align="right"/>

Unity also has assets called **materials**, which are different but related to shaders. Basically, a material is a preset configuration of parameters that should be used in a shader, so multiple materials can use the same shader with different parameters.

For example, the images to the right show two materials which both use the `Sprites/Default` shader, but one of them is set to be tinted blue while the other is untinted.

Note: All objects which use the same material will share the same values for the parameters, even if the values are changed at runtime. If you want to modify these parameters at runtime separately for different objects without creating a bunch of identical materials, you can use [`MaterialPropertyBlocks`](https://docs.unity3d.com/ScriptReference/MaterialPropertyBlock.html).

### What can shaders do?
At the very basic level, shaders let your game actually display things - Unity provides a plethora of built-in shaders that do just that. However, shaders can also be used to do much, much more! Here are a few images illustrating what shaders can do, with links to guides/tutorials on recreating them:

| <img src="https://i1.wp.com/cghow.com/wp-content/uploads/2019/02/ToonShaderAnimation.gif" width=300/> | <img src="http://3909.co/dev/od/img/Dither2-CameraSphere2.gif" width="300"/> | <img src="https://images.squarespace-cdn.com/content/v1/5a724d26a8b2b04c5d34119e/1534964689364-56OGVPAS5EIT8KHPJ7I6/grass2.gif" width="300"/> |
| :-: | :-: | :-: |
| A cell shader (also known as a toon shader), featuring two-tone shading (with hard lines separating light and shadow), specular reflection (brighter highlights representing reflected light), and rim lighting (bright edges). | A monocolor dithering shader from *Return of the Obra Dinn*, using a pixellated dithering pattern to show light and shadow. | A vertex shader simulating grass blowing in the wind, achieved by animating the position of vertices based on world position and local y position. |
| [Toon Shader Tutorial](https://roystan.net/articles/toon-shader.html) | [*Return of the Obra Dinn* Devlog](https://forums.tigsource.com/index.php?topic=40832.msg1363742#msg1363742) | [Waving Grass Tutorial](https://lindenreidblog.com/2018/01/07/waving-grass-shader-in-unity/) |

### How do I make and use shaders in Unity?
Unity has two primary methods for creating custom shaders. First, you can write a shader in **ShaderLab** (a Unity-specific language used to define the structure of a shader and can contain multiple shader programs) and **HLSL** (high-level shader language, in which the actual shader programs are written). Second, you can use Unity's **Shader Graph** package to create shaders with a visual node-based system.

This tutorial will focus on Shader Graph because it's much easier to pick up, and provides an easy way to start developing your intuition for the math behind beautiful shaders (warning: shaders involve a lot of math). That being said, if you are serious about diving into the world of shaders, you'll want to learn ShaderLab and HLSL eventually, since Shader Graph has a few disadvantages such as not being compatible with the built-in render pipeline, and that some effects are impossible to create in Shader Graph alone because tools like the stencil buffer are only available with code.

Once you have a shader, regardless of how it was created, you will need a material to use it. You can right-click in the `Project` section of Unity and use `Create → Material` to create a new material, then change the shader the material uses near the top of the inspector window. After filling in any appropriate parameters for your material to provide to the shader, you can add it to an game object by finding the object's `Renderer` component (e.g. `MeshRenderer`, `SpriteRenderer`, `Image`) and dragging your material into the renderer's `Material` parameter.

## Shader Graph
### Setup
<img src="./Universal%20RP%20Package.png" align="right" width=500/>

Since Shader Graph is not compatible with Unity's built-in render pipeline, we will need to install one of Unity's scriptable render pipeline. For this tutorial, we will be using the Universal Render Pipeline, or URP. To install this package, open the Package Manager by going to `Window → Package Manager`, then find and install the `Universal RP` package in the Unity registry.

The Universal RP package actually includes the Shader Graph package as a dependency, so installing it will also automatically install Shader Graph as well. However, before we can start using Shader Graph, we need to configure the project's settings to use URP instead of the built-in pipeline. First, in your project right click and select: `Create → Rendering → Universal Render Pipeline → Pipeline Asset (Forward Renderer)`. This should create a `UniversalRenderPipelineAsset` and a `UniversalRenderPipelineAsset_Renderer`.

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
