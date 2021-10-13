# Studio Creative Tutorials - Post Processing
 
**Date**: October 11, 2021<br>
**Location**: Online (On Zoom)<br>
**Instructor(s)**: Athena Dai
 
## Resources
[Slides]()<br>
[Video]()<br>
[Zoom Link](https://ucla.zoom.us/j/99684783298?pwd=Ykh2NlJCTDdoRGYxZzg2Z2xVWU1RZz09)<br>
 
## Topics Covered
* Different Render Pipelines
* Package Importing and Updating
* Asset Importing and Updating
* Basics of Materials and Shaders
* Post Processing/Render Pipeline Effects
 
## What you'll need
* [Unity Hub](https://unity.com/download)
* [Unity 2020.3.19f2](https://unity3d.com/unity/qa/lts-releases)
* [This Package](https://drive.google.com/file/d/1c-HtCTB4gnkF9j676lfUNTWDpNo5VmZx/view?usp=sharing)
---
## Setting up a scene:
Start Unity Hub and click on **Projects** on the sidebar. Click on New Project and name the project PostProcessing. Make sure the project type is 3D Core, and the Unity version is 2020.3.19f2 (or some variation of 2020.3 LTS)
![ScreenShot](Screenshots/PostProcessCreation.png)<br>

Go to Edit > Project Settings > Graphics and make sure that the object under Scriptable Render Pipeline Settings is currently set to None.<br>
[What is a Render Pipeline? -->](Dictionary/Render%20Pipelines.md)
![ScreenShot](Screenshots/InitProjSettings.png)<br>

Then go to Window > Package Manager. In the tab that pops up, switch the packages from "In Project" to "Unity Registry". Then search up "High Definition RP" in the search bar. Install it.
![ScreenShot](Screenshots/PackageManager.png)<br>
 
 After High Definition Render Pipeline (here on out referred to as HDRP) is finished installing, the Render Pipeline Wizard will pop up. Click "Fix All" to fix the errors. After you fix the errors, something will popup called "Create or Load HDRenderPipelineAsset". Click "Create one".<br>
 
 **Note:** If you need to open the Wizard again, simply go to Window > Render Pipeline > HD Render Pipeline Wizard.<br>
 
 **Note 2:** If you want to check to make sure this worked, go to Edit > Project Settings > Graphics again and make sure Scriptable Render Pipeline Settings has been set.
<details>
  <summary>Why are there so many errors?</summary>
  As mentioned in the "What is a Render Pipeline" file, none of the render pipelines are compatible with each other. This means that if you upload some texture to the core render pipeline, it might be missing parameters (or have extra parameters) compared to those in HDRP. You'll notice a lot of the errors talk about things not being supported or things missing for this very reason.
</details>

![Screenshot](Screenshots/RPWizard.png)<br>

Now find wherever you downloaded PostProcessTPKG and double click on it. An "Import Unity Package" pop up will appear. Click on Import. You should now see two more folders under assets, and a new scene in Scenes called TutorialScene. Your project should look like this once you click on TutorialScene.
![Screenshot](Screenshots/TutorialScene.png)<br>

## Setting up post-processing
Navigate to "First Person Camera" in your hierarchy (under "First Person Controller Minimal"). Upon clicking on it, navigate to your inspector and click "Add Component" at the very bottom of the inspector. Search up "Volume" and add that component.
![Screenshot](Screenshots/VolumeComponent.png)<br>

## Navigating your workspace

---

## Essential Links
- [Studio Discord](https://discord.com/invite/bBk2Mcw)
- [Linktree](https://linktr.ee/acmstudio)
- [ACM Membership Portal](https://members.uclaacm.com/)
## Additional Resources
- [Unity Documentation](https://docs.unity3d.com/Manual/index.html)
- [ACM Website](https://www.uclaacm.com/)
- [ACM Discord](https://discord.com/invite/eWmzKsY)
 
 
