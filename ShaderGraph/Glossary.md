## Glossary
This glossary/word bank is used to help explain certain phrases in the tutorial/README. They will be listed in alphabetical order.
The definitions will also cater to a better understanding of shaders rather than a holistic definition-- please consult elsewhere for a more comprehensive explanation!

### CPU
CPU stands for "Central Processing Unit". The CPU is a microprocessor that does the legwork for your computer's operating system, and is exceptionally good at executing individual complex tasks. Compared to the [GPU](https://github.com/uclaacm/studio-creative-tutorials/blob/main/ShaderGraph/Glossary.md#gpu), it is better at performing individual tasks but not as good at executing in parallel.

### Dithering
Dithering, as a general definition, is a process of adding ["noise"](https://github.com/uclaacm/studio-creative-tutorials/blob/main/ShaderGraph/Glossary.md#noise) to an image to simulate colors that are not included in a color palette. Imagine you only have access to black dots, and white dots. However, you have a canvas that you can apply thousands of dots to. To create the illusion of light grey, you can put only a few dots of black in the middle of white, and then look at it from a distance-- it will create a light grey color without actually using the color itself. Replace the "dots" with pixels on a computer screen, and you have a dithering effect-- mixing different but limited colors in such a way to create an illusion of a new one.

<details>
  <summary>Example of Dithering</summary>
  <img src = Images/dither_bw.png></img>
</details>

### GPU
GPU stands for "Graphics Processing Unit". It, like the [CPU](https://github.com/uclaacm/studio-creative-tutorials/blob/main/ShaderGraph/Glossary.md#cpu), is a microprocessor, but with a different use case. While the CPU is good at running individual complex tasks, the GPU is very good at running many things in parallel-- this makes it ideal for things like video games and shaders, as a lot of parallel processes need to be run to render things on screen (i.e. get things to show up).

### Interpolate
To Interpolate means, very generally, to define or estimate a specific value between a range of values. In the case of shaders and game development, it often means traversing a range between some values x and y given a specific delineation (could be a fraction, an alpha, etc.).

<details>
  <summary>Examples of Interpolation</summary>
  
  - Going through an alpha value (opacity decimal) of 0 and 1 in relation to time.
  - Running from vector A to vector B in relation to a character's speed.
</details>

### Material
A material is a wrapper-like object that will decide how a specific (object's) surface will look like depending on the [shader](https://github.com/uclaacm/studio-creative-tutorials/blob/main/ShaderGraph/Glossary.md#shader) and [textures](https://github.com/uclaacm/studio-creative-tutorials/blob/main/ShaderGraph/Glossary.md#texture) passed in. A material can only ever reference a single shader. The modifiable parameters dynamically depend on the shader and textures the material references.

### Mesh
A mesh is a data structure that essentially keeps the information of all of the [polygons](https://github.com/uclaacm/studio-creative-tutorials/blob/main/ShaderGraph/Glossary.md#polygon) that make up some object. This includes information about each polygon's vertices, edges, and surfaces-- and where they are in relation to each other, to create a holistic object mesh. Ultimately, a mesh determines the shape of any 3D object.

<details>
  <summary>Example of A Mesh</summary>
  <img src = Images/mesh_bunny.png></img>
</details>

### Node
A "node" has many definitions, but within the definition of [Shadergraph](https://github.com/uclaacm/studio-creative-tutorials/blob/main/ShaderGraph/Glossary.md#shadergraph), refers to a single function, variable, or item within the visual scripting language. In this sense, a function like "vertex" is considered a node.

<details>
  <summary>Example of Nodes</summary>
  <img src = Images/Shader%20Graph%20Window.png></img>
</details>

### Noise
Noise in computer graphics as a whole refers to some pseudo-random generation of values between 0 and 1 within certain parameters. These parameters can be across a plane (so imagine a piece of paper, mapped with random values between 0 and 1 at every point), or perhaps even a 3D space (an example would be randomly generated height maps-- think of how Minecraft generates land masses). The resulting product after performing this pseudo-random generation of values is referred to as "noise". This noise can be used for most anything, but a common use in shaders is to control the alpha (i.e. transparency) value of certain images through noise, setting the alpha value to the noise value at a certain point.

<details>
  <summary>Example of Noise</summary>
  <img src = Images/noise.jpg></img>
</details>

### Polygon
Polygon, in the context of shaders, always refers to the smallest number of vertices and edges needed to generate a surface-- which in this case, is a triangle. This is why meshes, and games as a whole, deal with processing visuals in terms of polygons. Even a square that you see on the screen is actually made up of two polygons/triangles.

### Post processing
Post processing is a step in the [game render pipeline](https://github.com/uclaacm/studio-creative-tutorials/blob/main/ShaderGraph/Glossary.md#render-pipeline), that takes place after culling and rendering. At this phase, things within the game space cannot be modified fundamentally-- you can only add or subtract effects. Think of this like already having taken a picture, and only applying different instagram filters to it, rather than retaking the photo. To learn more about post processing, please view [this tutorial.](https://github.com/uclaacm/studio-creative-tutorials/tree/fall-21/Post%20Processing)

### Rasterize
Rasterize is the process of converting, or "flattening", some visual from being represented by vectors --for example: a graphic made in Adobe Illustrator is called a "vector graphic"-- to being represented with pixels instead.

### Render pipeline
The render pipeline refers to the flow that a game must take to be able to accurately represent a game on a computer screen. This includes three main stages: culling, rendering, and post processing. [Shaders](https://github.com/uclaacm/studio-creative-tutorials/blob/main/ShaderGraph/Glossary.md#shader) operate somewhere between rendering and [post processing](https://github.com/uclaacm/studio-creative-tutorials/blob/main/ShaderGraph/Glossary.md#post-processing), where they cannot fundamentally alter the objects that appear in game, but can alter the pre-existing object's appearance. This is in contrast to post processing, which cannot alter either but can only add or subtract effects. To learn more about render pipelines, please view [this article.](https://github.com/uclaacm/studio-creative-tutorials/blob/fall-21/Post%20Processing/Dictionary/Render%20Pipelines.md)

### Shader
Shaders are a series of math functions and algorithms that, after running, will determine the color of individual pixels on a screen (as pixels inherently only have the color property). There are two types of shaders: fragment shaders, and vertex shaders. Fragment shaders determine the appearance of [polygon](https://github.com/uclaacm/studio-creative-tutorials/blob/main/ShaderGraph/Glossary.md#polygon) surfaces; an example would be changing the color of an apple from red to blue. Vertex shaders, on the other hand, will modify the edges and vertices of said polygons; an example would be making an apple two times its original size.

### Shader graph
Unity's Shader Graph is a visual scripting tool that lets you create shaders without the need to look at code. There are, of course, limitations to this despite its simplicity-- many shader functions are available only in shader lab/code versus shader graph, and debugging is more difficult in shader graph.

### Shader lab
Unity's Shader Lab is a language that Unity uses to create shaders, and shader files. It uses HLSL (High Level Shader Language), that is similar to C/C derivative, that allows you to code shaders. Despite the harsher learning curve, it provides a lot more flexibility, debugging, and better foundational clarity.

### Shading
The act of applying a shader to an object.

### Texture
A texture at its core is a 2D (i.e. flat) image, that is then wrapped around an object. One can think of it like a gift or candy wrapper, that applies its visual effect on the thing it is wrapped around. In this same vein, 2D images/sprites are synonymous with textures, as both are 2D images. In the below image, you can see an example of a 3D model versus its unwrapped texture.

<details>
  <summary>Abstract Texture Example</summary>
  <img src = Images/texture_wrapping.png></img>
</details>

### UV Coordinates/Mapping
UV Mapping is the act of plotting a point on a 2D image (in this case, a texture) onto a 3D model (in this case, an object or mesh). UV Coordinates, then, are the coordinate representation of this 2D to 3D relationship. Modifying UV coordinates will thus change the position a texture represents itself on a model-- an example of this would be like unwrapping then trying to rewrap a present-- the change in wrapping paper is similar to a modification of the UV mapping/coodrinates. The below example shows a more abstract example of UV mapping, where instead of certain points, whole faces are mapped to certain "positions" of a cube.

<details>
  <summary>Abstract Texture Example</summary>
  <img src = Images/cube_unwrapped.png></img>
</details>
