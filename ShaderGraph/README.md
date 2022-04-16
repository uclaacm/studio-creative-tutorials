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
* [Shader Graph](#shader-graph)
 
### What you'll need
* Unity version 2020.x or newer. Note that in 2021 versions, shaders generated with Shader Graph are not compatible with UI components, unlike 2020 versions.

---

## Shaders
### What is a `shader`?
The term `shader` is often used to refer to several related concepts, but in the broadest sense a `shader` is a program that runs on the GPU instead of the CPU. This includes `compute shaders` and `ray tracing shaders`, but for the purposes of this tutorial, we are interested in the type of `shader` which determines the color of pixels. In other words, these `graphics pipeline shaders` determine what you see on the screen.

For the rest of this tutorial, we will use `shader` to refer to this type of `graphics pipeline shader` specifically, unless otherwise noted, but you can read more about these other kinds of `shaders` at the links provided in [Additional Resources](#additional-resources) below.

A `shader` is composed of two parts: a `vertex shader` and a `fragment shader`. The `vertex shader` runs first, and does computations for each `vertex` in the `mesh` a game object being rendered is composed of. Things `vertex shaders` can do include moving the position of `vertices` to distort the `mesh` (and thus its appearance), and running calculations to produce data that will be used by the `fragment shader`, such determining the distance to a point at each `vertex`. After the `vertex shader` runs, the GPU does some processing to interpolate the output of the `vertex shader` between the `vertices` and rasterizes the object being rendered to produce `fragments`. (You can think of `fragments` as the pixels on the screen, although they're not actually equivalent.) Finally, the `fragment shader` does computations for each `fragment` to determine what color it should be.

### What can `shaders` do?
At the very basic level, `shaders` let your game actually display things - Unity provides a plethora of built-in `shaders` that do just that. However, `shaders` can also be used to do much, much more! Here are a few images illustrating what `shaders` can do, with links to guides/tutorials on recreating them:

| <img src="https://i1.wp.com/cghow.com/wp-content/uploads/2019/02/ToonShaderAnimation.gif" width=300/> | <img src="http://3909.co/dev/od/img/Dither2-CameraSphere2.gif" width="300"/> | <img src="https://images.squarespace-cdn.com/content/v1/5a724d26a8b2b04c5d34119e/1534964689364-56OGVPAS5EIT8KHPJ7I6/grass2.gif" width="300"/> |
| :-: | :-: | :-: |
| A `cell shader` (also known as a `toon shader`), featuring two-tone shading (with hard lines separating light and shadow), specular reflection (see the brighter highlights on small parts of the shapes), and rim lighting (bright edges). | A monocolor dithering `shader` from *Return of the Obra Dinn*, using a pixellated dithering pattern to show light and shadow. | A `vertex shader` simulating grass blowing in the wind, achieved by animating the position of vertices based on world position and local y position. |
| [Toon Shader Tutorial](https://roystan.net/articles/toon-shader.html) | [*Return of the Obra Dinn* Devlog](https://forums.tigsource.com/index.php?topic=40832.msg1363742#msg1363742) | [Waving Grass Tutorial](https://lindenreidblog.com/2018/01/07/waving-grass-shader-in-unity/) |

## Shader Graph

**Paths for Exploration:**
* List stuff here
  * List more stuff here

---
## Additional Resources
* [Unity's Shader Documentation](https://docs.unity3d.com/Manual/Shaders.html)

## Non-Essential Links
- [Studio Discord](https://discord.com/invite/bBk2Mcw)
- [Linktree](https://linktr.ee/acmstudio)
- [ACM Membership Portal](https://members.uclaacm.com/)
- [Unity Documentation](https://docs.unity3d.com/Manual/index.html)
- [ACM Website](https://www.uclaacm.com/)
- [ACM Discord](https://discord.com/invite/eWmzKsY)
