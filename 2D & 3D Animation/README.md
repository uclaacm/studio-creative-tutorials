# Studio Creative Tutorials - 2D & 3D Animation
 
**Date**: November 15, 2021<br>
**Location**: Online (On Zoom)<br>
**Instructor(s)**: Caroline Wang, Athena Dai
 
## Resources
[Video](https://youtu.be/iRmBxDrh5gk)<br>
[Zoom Link](https://ucla.zoom.us/j/99684783298?pwd=Ykh2NlJCTDdoRGYxZzg2Z2xVWU1RZz09)<br>
 
## Topics Covered
* Skinning Editor
* Bones, Geometry, and Weights
* Inverse Kinematics (IK) and IK Solvers
* Animation State Machine
* Animation Blending
* Animation Retargeting
* Basics of Rigging
* Animation Constraints
 
## What you'll need
* [Unity Hub](https://unity.com/download)
* [Unity 2020.3.19f2](https://unity3d.com/unity/qa/lts-releases)
* [This Package](https://drive.google.com/file/d/1c-HtCTB4gnkF9j676lfUNTWDpNo5VmZx/view?usp=sharing)
---
## 2D:

yeet

---
## 3D:

### Mixamo
Animation is a separate category than modeling, and can require different skills. For the purposes of this topic, we will not be covering model creation or skeleton creation (like in blender, maya, etc.), as that is usually done outside of Unity. If you want to know how modeling feeds animation, please visit this file here to learn about how they interact.

Because of this case, we will instead be using a free animation library from Adobe called [mixamo](https://www.mixamo.com/#/). This library has an assortment of pre-set models and a wide range of animations, all for free. For efficiency, all of the needed animations and models have been included in the Unity package, but we will run through Mixamo's use cases all the same.

First, Mixamo's main interface. You can choose a core character in the "Character" tab, and all future animations you choose (regardless of the animation's preview image) will apply to that character model. For example, in the screenshot below, "TheBoss" model was first chosen, and then the "Capoeira" animation was chosen. Despite the preview for the Capoeira animation being the YBot, it is retargeted for the boss. You can verify this by looking at the title over the animation. You can also search for specific animations and models.<br>
![image](https://user-images.githubusercontent.com/49392395/141603965-370647e6-9e1e-43ac-9a5a-704f8d4f62dc.png)

Zooming in, we can examine the properties of the animation scene. The buttons on the lower left allow you to navigate the scene and look at the animation from different perspectives (including a skeleton perspective); hovering over them will let you know their properties.<br>
![image](https://user-images.githubusercontent.com/49392395/141604320-b3ed38e5-c6ea-4631-b98d-c88fea4b0180.png)

To the right, there are a lot of different parameters that dictate how the animation can be edited directly from Mixamo. Looking at the previous screenshot and this one, one can see that these properties are highly animation specific; simply modifying the settings will usually let you see what they effect quite easily, and if it doesn't, toggle skeleton mode. You can also upload your own character model if you want to apply the animation to your own models.<br>
![image](https://user-images.githubusercontent.com/49392395/141604353-f0ba1fb0-456d-491a-a7f9-d174e62ae9e5.png)

The "Mirror" and "In Place" toggles are important for your animations. One will completely flip the animation (EX: If the animation steps in a left-right sequence, it will now step right-left), and "In Place" determines if the animation itself has inherent movement, or simply moves in place. One must be extremely careful if they want animations to have inherent movement or just move in place, as that often dictates the "type" of animation that Unity will perform on the model.<br>
![image](https://user-images.githubusercontent.com/49392395/141604390-c77c4136-3aae-40a4-b0bc-b41e445a8941.png)

Once you find an animation and you hypothetically want to download it, you will be met with a series of options.
**Format:** This deals with how the information about the skeleton and model will be kept and processed. If you are using Unity, there is a specific FBX for Unity format.
**Skin:** This is asking if you would like the model to be exported along with the animation. If you already have the model, materials, and textures, this is unecessary-- it will just export the animation instead.
**Frames Per Second:** This has the same meaning as 2D or frame by frame animation-- simply asking you how many times the animation will be rendered per second. A lower framerate means the animation is smaller in file size and less intensive to compute, but can lead to choppier animation.
**Keyframe Reduction:** This is a form of animation culling that is meant to optimize animations. Essentially, if from one frame to another the animation only changes a minute amount, keyframe reduction will remove the second frame entirely. This is also a way to save space and computation, but can also lead to choppier/incorrect animation.
![image](https://user-images.githubusercontent.com/49392395/141604625-b22be154-5909-4fb3-a55e-6e0cb440edc3.png)

### Setting up an Animator
Upon opening the TUTORIAL scene, you should see the xBot@idle model in the middle of a plane. Despite the xBot@idle model having an idle animation attached to the core import and assuming the first frame/pose of the idle animation, on play that the animation will not play.<br>
![image](https://user-images.githubusercontent.com/49392395/141670748-1599232d-3f98-4157-bdde-e512b5398ce6.png)

To get the animation to work, you need to create an animator. To do this, navigate to Project > Animators, then right click and go to Create > Animation Controller. Name it whatever you wish. Then drag and drop that animator onto the xBot@idle object in the scene (you can do this by dragging it to the heirarchy, or by dragging it to the xBot@idle object specifically above the "Add Component" button).<br>
![image](https://user-images.githubusercontent.com/49392395/141670905-cb34b5ec-1ba1-408b-a37a-11e189f1331b.png)

Now open up the animator tab. Navigate to Window > Animation > Animator. It should open up a blank looking grid, but once you select the xBot in the hierarchy, it should be auto-populated by "Entry", "Exit", and "Any State" tabs.<br>
<details>
  <summary>What is an Animator?</summary>
  An Animator is essentially a wrapper that helps maintain, transition, and edit a group of animations. Using it, you can map out how certain animations should transition to others and when, what animations should override others, and more.
</details>

![image](https://user-images.githubusercontent.com/49392395/141670985-b112b263-08b9-45df-aec7-397e3ca77a0c.png)

The animation still won't play until we add the idle animation to the animator. However, if we add the idle animation as it is (attached to the model in the project), the idle animation will play once, and then stop. Click edit on the animation to access its properties.
<details>
  <summary>Why can I not edit the animation directly?</summary>
  This is because the animation is bound to the model, and Unity will not let you edit bound objects easily because it essentially will edit the components of the overall object.
</details>

![image](https://user-images.githubusercontent.com/49392395/141673169-fc1f8622-ad8d-4892-8cfc-19f602aaaa18.png)

Scroll down until you reach the Idle animation. There, you should see a "Loop Time" variable. Toggle the variable on. This will loop the Idle animation indefinitely. Then, drag and drop that animation into the animator. It should be immediately bound as the default state and turn orange. When you press play, the idle animation should now play successfully, and indefinitely.<br>
![image](https://user-images.githubusercontent.com/49392395/141673788-6a8e8161-a0c2-4a0f-8521-d0bb4a60dbd0.png)


## Final Task

yoted

## Essential Links
- [Studio Discord](https://discord.com/invite/bBk2Mcw)
- [Linktree](https://linktr.ee/acmstudio)
- [ACM Membership Portal](https://members.uclaacm.com/)
## Additional Resources
- [Unity Documentation](https://docs.unity3d.com/Manual/index.html)
- [ACM Website](https://www.uclaacm.com/)
- [ACM Discord](https://discord.com/invite/eWmzKsY)
