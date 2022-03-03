# Studio Creative Tutorials - UI & UX Design
 
**Date**: February 16, 2022<br>
**Location**: Online (On Zoom)<br>
**Instructor(s)**: Mauve Spillard, Izzy Szeto, Faustine Wang, Ray Hsiao
 
## Resources
[Slides](https://docs.google.com/presentation/d/1NLSH-O6HlAjAkD2QMGLmoSrs5iogmbQl7fjtGaVB_-k/edit#slide=id.p)

[Video](https://youtu.be/w3pyDio0xM8)
 
## Topics Covered
* UI/UX Theory
* UI/UX Implementation
* UI in Unity (UI Components)
 
## What you'll need
* [Unity Skeleton Package](https://drive.google.com/file/d/1Z9d0-3XrcYnCS2uoVOesONbDHvxbQbUQ/view?usp=sharing)

---

## Canvas Components
We will make a rough main menu and settings menu as an introduction to useful UI Components in Unity. Check out the [Unity UI Tutorial](https://learn.unity.com/tutorial/ui-components).

### Main Menu
Set your **canvas** to scale with screen size, **reference resolution** to the current aspect ratio (such as 1920 x 1080), so that our UI will scale according to your screen.

**Button Component**
* Transition Types determine how the UI looks when clicked on or diabled.
* If your UI will be used on computers, turn off automatic navigation to make sure it doesn't stay selected after being clicked on.

**Text Component (use Text Mesh Pro)**
* WHY TMP: text stays CRISP at any size, many additional options available.
* Explore formatting options and auto size settings.
* To edit in code:
```
using TMPro;
TextMeshProUGUI example;
example.text = "whatever you want here";
```

**Image Component (Panels)**
* Images take in sprites to display them.
* To set the background image, hold shift to set its pivot and hold alt to set its size at the same time as setting its anchors.
* *Landscape image from: https://www.adorama.com/alc/basic-landscape-photography-tips/*

### Settings Menu
Use as many canvases as you need! New functions can go on a new canvas. Layer canvases using their sort orders. You can make a canvas preset to make sure all canvases use the same settings (adjust the matching float according to the platforms you will be using).

**Slider Component** (navigation: none)
* Sliding direction can be adjusted.
* "Min/max" value is what the slider represents at each end of the area (0-1 normally).
* Check "whole numbers" box to slide up in whole-number increments.
* "Value" returns the value the slider represents.

**Toggles** <br>
(Toggles don't have built-in TMP option, we can see how blurry it gets. Add TMP text if needed)
* "Is On" adjusts whether it is on/off.
* "Graphic" is the child of the toggle game object.
* [Toggle group](https://docs.unity3d.com/Packages/com.unity.ugui@1.0/manual/script-ToggleGroup.html): mutually exclusive selections.

**Input Field**
* [How to access text in TMPro Input Field.](https://stackoverflow.com/questions/57223275/access-the-tm-pro-inputfield-text-in-unity)

**Dropdown Menu**
* [How to create a dropdown menu and access the value.](https://www.youtube.com/watch?v=5onggHOiZaw)

**Scroll view**
* Notice the mask component in the scroll view game object. (If you delete it the "hidden" game objects will disappear)
    * masks can be used in other contexts as well (such as health bars)
* Toggle vertical or horizontal scrolling
* Content size fitter if you need things to scale according to number of objects in "Content"
* Vertical layout group for things to distribute evenly and stay aligned

**Paths for Exploration:**
* [TextMeshPro font asset creation](https://learn.unity.com/tutorial/textmesh-pro-font-asset-creation)
* [Raw image](https://answers.unity.com/questions/1070280/raw-image-vs-image.html)
* More flexible scrolling
    * Scrollbar
    * Scroll rect
    * [Scroll rect/scroll bar by themselves](https://www.youtube.com/watch?v=rAqyi85IAJ0&ab_channel=CocoCode)
* Masking Pizzazz
    * For creating health bars and more
    * [Creating a HUD in Unity](https://learn.unity.com/tutorial/visual-styling-ui-head-up-display)
* Layout components
    * Layout Groups, Fitters, Scalers


**Additional Materials**
* [UI Best practices](https://medium.com/@dariarodionovano/unity-ui-best-practices-40964a7a9aba)
* [Optimizing unity UI](https://learn.unity.com/tutorial/optimizing-unity-ui)
* [Scrollview grid tutorial](https://blog.studica.com/unity-ui-tutorial-scroll-grid)
* [Toggle group](https://docs.unity3d.com/Packages/com.unity.ugui@1.0/manual/script-ToggleGroup.html)
* [Enabling UI with the new input system](https://www.youtube.com/watch?v=TBcfhJoCVQo)
* [Unity UI course](https://learn.unity.com/tutorial/ui-components#)

**On Optimization/Shortcuts**
* Turn off "raycast target" if not needed
* Scale uniformly by clicking and dragging scale tool center
* To move pivot, change from "center" to "pivot"
* Hold shift/alt to set pivot or scale while setting anchor presets
* Can toggle canvas component to enable or disable canvas objects (vs. setting active or inactive for the entire game object)

**Notes**
* "raycast?" [whether it is clickable](https://answers.unity.com/questions/1099030/raycast-target-on-ui-elements.html)
* What is a "rect?" [(it is essentially a rectangle)](https://docs.unity3d.com/ScriptReference/Rect.html)



## Canvas Render Modes
The [Unity documentation for the Canvas](https://docs.unity3d.com/2020.1/Documentation/Manual/UICanvas.html) is a good resource.

### Context
The *Camera* is just a window into your game. Your UI will either appear in front of the window, right behind the window, or somewhere in the space beyond the window. You can see the view of the Camera in the Scene window in 3D view and change Camera attributes in the Inspector. More info can be found in the [Unity documentation for the Camera](https://docs.unity3d.com/Manual/class-Camera.html).

*Screen space* is the 2D coordinates of the screen, measured in pixels. Coordinates range from (0,0) in the bottom-left to (MAX_WIDTH, MAX_HEIGHT) in the top-right.

*World space* is the 3D coordinates of the game, measured in units. Coordinates range from (-infinity, -infinity, -infinity) to (infinity, infinity, infinity).

The *render hierarchy* is the order in which things are rendered in Unity. The game hierarchy is always rendered first, then post processing, and depending on Canvas Render Modes, the order in which the UI is rendered changes, changing the way it looks.

*Post processing* consists of visual filters and effects applied after a scene is drawn but before it is rendered. If you're interested in learning more about post processing, we recommend [Athena's tutorial on post processing](https://github.com/uclaacm/studio-creative-tutorials/tree/fall-21/Post%20Processing).

### Screen Space - Overlay
The Canvas containing your UI is placed on the *screen* and rendered last. The Canvas changes size with screen and will not be affected by post processing.

### Screen Space - Camera
The Canvas containing your UI is placed relative to a chosen Camera and rendered after the game hierarchy and before post processing. Since the Canvas is placed relative to the Camera, it is possible to place game objects between the Canvas and the Camera, covering the Canvas. 

### World Space
The Canvas is rendered in the game hierarchy like a game object and, as such, is affected by post processing. It behaves like a game object: it can be resized using Rect Transform, it can be placed in front of or behind other objects in world space, and it is affected by everything a game object would be, such as physics and in-game systems.

## Essential Links
- [Studio Discord](https://discord.com/invite/bBk2Mcw)
- [Linktree](https://linktr.ee/acmstudio)
- [ACM Membership Portal](https://members.uclaacm.com/)
## Additional Resources
- [Unity Documentation](https://docs.unity3d.com/Manual/index.html)
- [ACM Website](https://www.uclaacm.com/)
- [ACM Discord](https://discord.com/invite/eWmzKsY)
