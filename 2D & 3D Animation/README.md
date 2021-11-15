# Studio Creative Tutorials - 2D & 3D Animation
 
**Date**: November 15, 2021<br>
**Location**: Online (On Zoom)<br>
**Instructor(s)**: Caroline Wang, Athena Dai
 
## Resources
[Video](https://youtu.be/iRmBxDrh5gk)<br>
[Zoom Link](https://ucla.zoom.us/j/99684783298?pwd=Ykh2NlJCTDdoRGYxZzg2Z2xVWU1RZz09)<br>
 
## Topics Covered
* Good Animation Practices and Basics
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

### 2D Rigging
As opposed to frame by frame animation, 2D rigging Animation typically offers smoother results and a faster, more flexible workflow. To get started in Unity, ensure that you have the correct version of Unity downloaded (refer to the link above in "What you'll need"), as well as the proper packages which will allow you to create a character to rig. Because the 2D IK package is now included in the 2D Animation package, the only two packages you will need for this portion of the tutorial is **2D Animation** and **2D PSDImporter**. Both of these can be found through "Window" > "Package Manager". Ensure that both are in "Packages: In Project".<br>
(image to be added)

In the Assets folder, you may drag in the file labeled "CharacterExample.psb". When creating the character asset for the purpose of 2D rigging, you should keep in mind that any separate part of the body you want to move around should be on a separate layer (e.g. head, limbs, chest, etc.). PSB files conveniently separate the layers of a photoshop file, which simplifies the workflow visually by a bit. It is also possible to use PNG files, but you must make sure that each part of the body you would like to rig is separated from each other.<br>

### Skinning Editor

Once you click on the character PSB, set the Sprite Mode to "Multiple" and check the box next to "Character Rig". You can then click "Sprite Editor" which will bring up a new window with all the layers of the file separated. Make sure that each part is accurately configured and if not, you can manually fix it by dragging the edges of the box. Once you're satisfied, you can move to the top left tab of the window and change the setting from "Sprite Editor" to "Skinning Editor". The Skinning Editor will allow you to prepare your character for rigging.<br>
(image to be added) 

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

### Animation Transitions and a Basic Walk/Run
We now also want to make the xBot walk and run. To do this, we must first navigate to Assets > Movement, and drag and drop "Walking" and "Running" into the Animator.
![image](https://user-images.githubusercontent.com/49392395/141732086-533d7ce9-1631-4832-aa89-df6d88e53706.png)

However, if you press play right now, only the idle will play. This is because we need to create animation transitions that will specify what requirements need to be fulfilled before animations are played. If pressing down the "W" key means we should walk, we need to specify that.<br>

To do this, right click on the Idle animation and select make transition. You should see an arrow connected to your cursor. Drag that arrow over to the "Walk" animation and click.That creates a transition from your "Idle" to "Walk".<br>
![image](https://user-images.githubusercontent.com/49392395/141734561-d1387b1c-b96a-4cde-add3-338c19f560d3.png)

Repeat this from "Walk" to "Idle", and make the same set of transitions from "Walk" to "Run". Your transitions should look like below. If you make a mistake, simply click on the transition (it should be highlighted blue) and then press the "Delete" key.
![image](https://user-images.githubusercontent.com/49392395/141734632-d78de239-a264-4487-ae6e-5b943520d9a1.png)

Now that we have our transitions hooked, we need to specify what parameter, exactly, will make the animator change from one animation to another. To do this, switch to the "Parameters" tab in the Animator (if you weren't there already) and click on the "+" button, then create a Bool. Name the variable "isWalking". Make another, and name it "isRunning".<br>
<details>
  <summary>What is a Bool?</summary>
  Bool is short for Boolean, and it evaluates things to either "True" or "False". So if we have a bool variable called "isEating", then it will essentially evaluate always to some object is eating, or isn't eating. Another way to think about it is that it is a variable that will evaluate to one of two values given some prerequisites.
</details>

![image](https://user-images.githubusercontent.com/49392395/141735366-c7a09e29-2eda-4d8b-bf64-78d9c68fc76b.png)

Now we will modify the transitions to recognize these parameters. Click on the transition from idle > Walk (it should turn blue) and in the inspector, find the "Conditions" tab. Click on the "+" button to add a condition; this will essentially give the Animator a requirement that must be met to transition from Idle > Walk. In this case, we want the Animator to change the animation when isWalking is True. Set the variable and variable value until they match the screenshot below.<br>
![image](https://user-images.githubusercontent.com/49392395/141737502-c252ec04-1730-49e0-b9db-d5202c7adca1.png)

Create conditions for the other transitions. They should be as follows:
* Walk > Idle should have "isWalking" + false.
* Walk > Run should have "isRunning" + true.
* Run > Walk should have "isRunning" + false.<br>

An example is below.<br>
![image](https://user-images.githubusercontent.com/49392395/141738126-7eb51905-be1c-4496-b8a6-a60a30987893.png)

Now, in your project folders, navigate to Assets > Scripts and drag and drop the "MovementScript" script onto the xBot in the scene (you do not need to understand the contents). Once this is done, you can press play and press the "W" key to walk, and the "Left Shift" key to run. Your animations should now begin working almost perfectly-- but not quite.<br>
![image](https://user-images.githubusercontent.com/49392395/141738749-2f58c80d-aab9-44dd-aee6-c79a38fdab88.png)

You should notice an incredibly long lag time between holding down the "W" key and when the walk animation actually begins. This is because we have enabled animation "Exit Time". Navigate to your Animator, select on the transition from Idle > Walking, and you'll see in the inspector that "Has Exit Time" is checked. What this does is essentially force a certain animation to play for however many percent specified in the "Settings" tab (default to 98.4%) before the next animation can play. This is useful in some cases, but not in cases where we need player feedback to feel reactive and snappy. Toggle that off for all transitions.<br>
![image](https://user-images.githubusercontent.com/49392395/141739119-e6a7f92a-dd75-45db-9d61-a69274b1184b.png)<br>

Now, your Walk/Run animations should transition smoothly and quickly depending on the keys you press.

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
