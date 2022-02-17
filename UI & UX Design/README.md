# Studio Creative Tutorials - UI & UX Design
 
**Date**: February 16, 2022<br>
**Location**: Online (On Zoom)<br>
**Instructor(s)**: Mauve Spillard, Izzy Szeto, Faustine Wang, Ray Hsiao
 
## Resources
[Slides](https://docs.google.com/presentation/d/1NLSH-O6HlAjAkD2QMGLmoSrs5iogmbQl7fjtGaVB_-k/edit#slide=id.p)

[Video]()
 
## Topics Covered
* UI/UX Theory
* UI/UX Implementation
* UI in Unity (UI Components)
 
## What you'll need
* Unity Skeleton Package

---

## Canvas Render Modes
The [Unity documentation for the Canvas](https://docs.unity3d.com/2020.1/Documentation/Manual/UICanvas.html) is a good resource.

### Context
<details>
<summary>What is the Camera?</summary>
You can think of the Camera as just a window into your game. Your UI will either appear in front of the window, right behind the window, or somewhere in the space beyond the window. More info can be found in the [Unity documentation for the Camera](https://docs.unity3d.com/Manual/class-Camera.html).
</details>

<details>
<summary>What is screen space?</summary>
Screen space is the 2D coordinates of the screen, measured in pixels. Coordinates range from (0,0) to (MAX_WIDTH, MAX_HEIGHT).
</details>

<details>
<summary>What is world space?</summary>
World space is the 3D coordinates of the game, measured in units. Coordinates range from (-infinity, -infinity) to (infinity, infinity).
</details>

<details>
<summary>What is the render hierarchy?</summary>
The render hierarchy is the order in which things are rendered in Unity. The game hierarchy is always rendered first, and depending on Canvas Render Modes, the order in which the UI is rendered changes, changing the way it looks.
</details>

### Screen Space - Overlay
The Canvas containing your UI is placed on the screen and rendered last. The Canvas changes size with screen and will not be affected by post processing since that is attached to the camera.

### Screen Space - Camera
The Canvas containing your UI is placed relative to a chosen Camera and rendered after the game hierarchy but before camera effects. Thus, it is affected by changes in the camera's attributes and position and post processing. If you're interested in learning more about post processing, we recommend [Athena's tutorial on post processing](https://github.com/uclaacm/studio-creative-tutorials/tree/fall-21/Post%20Processing).

### World Space
The Canvas is rendered in the game hierarchy like a game object. It behaves like a game object: it can be resized using Rect Transform, it can be placed in front of or behind other objects in world space, and it is affected by everything a game object would be, such as physics and in-game systems. Since it is rendered before camera effects, it is affected by post processing. However, since it is not placed relative to the camera as in the `Screen Space - Camera` Render Mode, it is not affected by changes in the camera's perspective and position.

## Canvas Components
We will make a rough main menu and settings menu, an introduction to useful UI Components in Unity. Check out the [Unity UI Tutorial](https://learn.unity.com/tutorial/ui-componentsv).

### Main Menu
Set your **canvas** to scale with screen size, **reference resolution** to the current aspect ratio (such as 1920 x 1080), so that our UI will scale according to your screen.

<details>
<summary>Button Component</summary>
<p>Transition Types determine how the UI looks when clicked on or diabled.</p>
<p>If your UI will be used on computers, turn off automatic navigation to make sure it doesn't stay selected after being clicked on. </p>
</details>

<details>
<summary>Text Component (use Text Mesh Pro)</summary>
<p>WHY TMP: text stays CRISP at any size, many additional options available.</p>
<p>If your UI will be used on computers, turn off automatic navigation to make sure it doesn't stay selected after being clicked on (this is used for consoles)</p>
</details>


explore formatting options, AUTO SIZE
custom font imports
To edit in code: 
`using TMPro;
TextMeshProUGUI example;
example.text = "whatever you want here";`
Images (Panels)
background: Anchors, and holding shift/alt to set the size or anchors/pivots/positions
Landscape image: https://www.adorama.com/alc/basic-landscape-photography-tips/

SETTINGS MENU
(use as many canvases as you need! new functions can go on a new canvas; layer canvases based on sort order; can make a canvas preset to make sure all canvases use the same settings)
Canvas settings: adjust matching according to the platforms
Sliders (navi: none)
directions can be adjusted 
min/max value is what the slider represents at each end of the area (0-1 normally)
check whole numbers to slide up in whole number increments
value returns the value the slider represents
Toggles
(no tmp option, can see how blurry it gets; add text if needed)
is On (on/off)
graphic is the child
toggle group: mutually exclusive (https://docs.unity3d.com/Packages/com.unity.ugui@1.0/manual/script-ToggleGroup.html)
Input Field (Panel)
(https://stackoverflow.com/questions/57223275/access-the-tm-pro-inputfield-text-in-unity)
Dropdown Menu
(https://www.youtube.com/watch?v=5onggHOiZaw)
scroll view
NOTICE MASK COMPONENT (delete to demonstrate function)
can be used for other things as well
toggle vertical or horizontal
content size fitter if you need things to scale accordingly
vertical layout group for things to distribute evenly

Paths for Exploration:
TextMeshPro font asset creation
https://learn.unity.com/tutorial/textmesh-pro-font-asset-creation
Raw image
https://answers.unity.com/questions/1070280/raw-image-vs-image.html
https://forum.unity.com/threads/downsides-to-using-rawimage-over-image.614284/ 
More flexible scrolling
Scrollbar
scroll rect
scroll rect/scroll bar by themselves (Scrolling and scrollbars in Unity - Unity UI tutorial)
Masking Pizzazz
For creating health bars and more
Creating a HUD in Unity: https://learn.unity.com/tutorial/visual-styling-ui-head-up-display
Layout components
Layout Groups, Fitters, Scalers


Additional Materials
UI Best practices
https://medium.com/@dariarodionovano/unity-ui-best-practices-40964a7a9aba
Optimizing unity UI
https://learn.unity.com/tutorial/optimizing-unity-ui
Scrollview grid tutorial
https://blog.studica.com/unity-ui-tutorial-scroll-grid
Toggle group
https://docs.unity3d.com/Packages/com.unity.ugui@1.0/manual/script-ToggleGroup.html
Enabling UI w the new input system:
https://www.youtube.com/watch?v=TBcfhJoCVQo 
Unity UI course:
https://learn.unity.com/tutorial/ui-components# 

On Optimization/Shortcuts
Turn off raycast target if not needed
scale uniformly by clicking and dragging scale tool center
To move pivot, change from center to pivot
Hold shift/alt to set pivot or scale while setting anchor presets
Can toggle canvas component to enable or disable canvas objects (or set active or inactive for the entire game object)

Notes
"raycast?" whether it is interactable https://answers.unity.com/questions/1099030/raycast-target-on-ui-elements.html
what is a "rect?" (it is essentially a rectangle)
https://docs.unity3d.com/ScriptReference/Rect.html


## Essential Links
- [Studio Discord](https://discord.com/invite/bBk2Mcw)
- [Linktree](https://linktr.ee/acmstudio)
- [ACM Membership Portal](https://members.uclaacm.com/)
## Additional Resources
- [Unity Documentation](https://docs.unity3d.com/Manual/index.html)
- [ACM Website](https://www.uclaacm.com/)
- [ACM Discord](https://discord.com/invite/eWmzKsY)
