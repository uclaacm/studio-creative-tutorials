## What is Anti-Aliasing?
Monitors and screens are made up of pixels (squares/rectangles), and game engines at their current stage render in polyons, specifically triangles (which is where the term low poly comes from; low amount of polygons). This makes it incredibly difficult for games to show smooth curves. The jagged edge on an object that occurs when the game fails to show a rounded edge is called aliasing.

Anti-Aliasing is simply a process to remove those jagged edges. Below is an example.<br>
Note: Another way is simply by drastically increasing the resolution, which a lot of moderm monitors are able to do.<br>
![Screenshot](Screenshots/AA.png)

## How does Anti-Aliasing work?
There are three ways. The first is by utilizing and sampling high resolutions, which is very effective but very slow. The second is by using color sampling, which is moderately effective and moderately fast and often the most customizable, so it's also the most common. The final method is smudging aliased lines/edges; this is something a lot of raster digital art programs utilize (Photoshop, Paint Tool Sai, etc.)-- when you zoom in close you'll see some color smearing despite your brush's predicted radius to be smaller than the smeared radius, and that's your art program's anti-aliasing at work. This is the least accurate, but incredibly fast.

## When is Anti-Aliasing used? (pipeline side)
There are usually two places; the first is when an item is first rendered (when the object is drawn on the screen). The edges will be anti-aliased at that instance. The second is through post-processing effects, where a kind of "overlay" on the camera will have some kind of blurring or color sampling effect, which is the anti-aliasing effect.

Anti-aliasing will also sometimes only work on specific things; depending on the AA process, certain things other than the core object (textures, shaders, etc.) might not be anti-aliased.
