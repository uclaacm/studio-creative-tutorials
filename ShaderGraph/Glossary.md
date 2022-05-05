## Glossary
This glossary/word bank is used to help explain certain phrases in the tutorial/README. They will be listed in alphabetical order.
The definitions will also cater to a better understanding of shaders rather than a holistic definition-- please consult elsewhere for a more comprehensive explanation!

### CPU
CPU stands for "Central Processing Unit". The CPU is a microprocessor that does the legwork for your computer's operating system, and is exceptionally good at executing individual complex tasks. Compared to the CPU, it is better at performing individual tasks but not as good at executing in parallel.

### Dithering
Dithering, as a general definition, is a process of adding "noise" to an image to simulate colors that are not included in a color palette. Imagine you only have access to black dots, and white dots. However, you have a canvas that you can apply thousands of dots to. To create the illusion of light grey, you can put only a few dots of black in the middle of white, and then look at it from a distance-- it will create a light grey color without actually using the color itself. Replace the "dots" with pixels on a computer screen, and you have a dithering effect-- mixing different but limited colors in such a way to create an illusion of a new one.

<details>
  <summary>Example of Dithering</summary>
  <img src = Images/dither_bw.png></img>
</details>

### GPU
GPU stands for "Graphics Processing Unit". It, like the CPU, is a microprocessor, but with a different use case. While the CPU is good at running individual complex tasks, the GPU is very good at running many things in parallel-- this makes it ideal for things like video games and shaders, as a lot of parallel processes need to be run to render things on screen (i.e. get things to show up).

### Interpolate
To Interpolate means, very generally, to define or estimate a specific value between a range of values. In the case of shaders and game development, it often means traversing a range between some values x and y given a specific delineation (could be a fraction, an alpha, etc.).

<details>
  <summary>Examples of Interpolation</summary>
  
  - Going through an alpha value (opacity decimal) of 0 and 1 in relation to time.
  - Running from vector A to vector B in relation to a character's speed.
</details>

### Material
### Mesh
### Node
### Noise
### Polygon
### Post processing
### Rasterize
### Render pipeline
### Shader
### Shader graph
### Shader lab
### Shading
### Texture
### UV Coordinates
