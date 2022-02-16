# Studio Creative Tutorials - UI & UX Design
 
**Date**: February 16, 2022<br>
**Location**: Online (On Zoom)<br>
**Instructor(s)**: Mauve Spillard, Izzy Szeto, Faustine Wang, Ray Hsiao
 
## Resources
[Slides]()

[Video]()
 
## Topics Covered
*
 
## What you'll need
*
---

## Canvas Render Modes
The [Unity documentation for the Canvas](https://docs.unity3d.com/2020.1/Documentation/Manual/UICanvas.html) is a good resource.

### Context

The *Camera* is like a window into your game. Your UI will either appear in front of the window, right behind the window, or somewhere in the space beyond the window. More info can be found in the [Unity documentation for the Camera](https://docs.unity3d.com/Manual/class-Camera.html).

*Screen space* is the 2D coordinates of the screen, measured in pixels. Coordinates range from (0,0) to (MAX_WIDTH, MAX_HEIGHT).

*World space* is the 3D coordinates of the game, measured in units. Coordinates range from (-infinity, -infinity) to (infinity, infinity).

The *render hierarchy* is the order in which things are rendered in Unity. The game hierarchy is always rendered first, and depending on Canvas Render Modes, the order in which the UI is rendered changes, changing the way it looks.

### Screen Space - Overlay
The Canvas containing your UI is placed on the screen and rendered last. The Canvas changes size with screen and will not be affected by post processing since that is attached to the camera.

### Screen Space - Camera
The Canvas containing your UI is placed relative to a chosen Camera and rendered after the game hierarchy but before camera effects. Thus, it is affected by changes in the camera's attributes and position and post processing. If you're interested in learning more about post processing, we recommend [Athena's tutorial on post processing](https://github.com/uclaacm/studio-creative-tutorials/tree/fall-21/Post%20Processing).

### World Space
The Canvas is rendered in the game hierarchy like a game object. It behaves like a game object: it can be resized using Rect Transform, it can be placed in front of or behind other objects in world space, and it is affected by everything a game object would be, such as physics and in-game systems. Since it is rendered before camera effects, it is affected by post processing. However, since it is not placed relative to the camera as in the `Screen Space - Camera` Render Mode, it is not affected by changes in the camera's perspective and position.

## Essential Links
- [Studio Discord](https://discord.com/invite/bBk2Mcw)
- [Linktree](https://linktr.ee/acmstudio)
- [ACM Membership Portal](https://members.uclaacm.com/)
## Additional Resources
- [Unity Documentation](https://docs.unity3d.com/Manual/index.html)
- [ACM Website](https://www.uclaacm.com/)
- [ACM Discord](https://discord.com/invite/eWmzKsY)
