# Studio Creative Tutorials - Audio & Sound Design (WORK IN PROGRESS)
 
**Date**: November 2, 2021, 7:00 pm - 9:00 pm<br>
**Location**: Zoom<br>
**Instructors**: Athena Dai, Peter Sutarjo<br>
 
## Resources
[Slides](https://docs.google.com/presentation/d/1N__34gQRdCBV8gSB7huCgWJGKWnnMpdQAGUF3QjkW_k/edit?usp=sharing)<br>
[Video](https://youtu.be/oB3sk4a3VkE)<br>
 
## Topics Covered
* Audio Mixer
* Audio Listener
* Audio Source
* Spatial Audio
* Audio Reverb Zones
* Audio Engineering Logic
 
## What you'll need
* [Unity Hub](https://unity.com/download)
* [Unity 2020.3.15f2](https://unity3d.com/unity/qa/lts-releases)
* [Lowpoly Environment - Nature Pack](https://drive.google.com/file/d/1AGSRnSt-Z32ARl03rovPyRvPZ_1j3ixi/view?usp=sharing)
* [Unity Tutorial Package](https://drive.google.com/file/d/1m5rqRRpF5Ak88407HmLDYbY7aHQkOqwK/view?usp=sharing)
* Headphones/Earbuds
---

## What is an Audio Mixer?
For the sake of this tutorial and simplicity, the audio mixer has been created for you and should exist in the project folders (Assets > Mixers).
What it does is simply control audio mastering.
<details>
  <summary>What is Audio Mastering?</summary>
  Audio mastering is simply the version of post-processing, but for sound. It essentially involves adding effects --like changing the speed or pitch or volume-- to an audio clip after the clip has been fully loaded, but before the clip is played.
</details>

To view this with more granularity, go to Window > Audio > Audio > Audio Mixer. Here, you'll see a bunch of audio groups, mixers, snapshots, and views; utilize these whenever you need to control groups of sounds.<br>
![image](https://user-images.githubusercontent.com/49392395/139575584-38b3b32e-80cf-40ec-b7a5-53621bd53848.png)

Some examples of functionality include:
- Adding basic effects to audio (EQ, High/Low Pass, Pitch Shifting, etc.)
- Changing the volume and pitch of groups
- Creating audio groups and switching between them when editing (i.e. Views)
- Creating audio groups that can have different global effects applied (i.e. Groups)
- Enabling functionality to switch between groups of effects (i.e. Snapshots)

You can see and add effects to specific audio groups by clicking "Add" under an audio group.<br>
![image](https://user-images.githubusercontent.com/49392395/139571583-b4e1bcf5-b1d4-4f1c-ab3c-4249c5d01084.png)

## What is an Audio Listener?
To be able to hear sounds in your scene, you need an Audio Listener component. All cameras will have an audio listener component by default.
You can treat audio listeners as literal ears; not only are they needed to percieve sound, but the location of an audio listener also effects how far or close sound is perceived. You can only ever have one audio listener active in a scene at once, but switching between them is sometimes necessary (EX: listening in on a far away conversation).

View the scene's audio listener in the inspector by going to the Hierarchy and clicking on Player > Main Camera.<br>
![image](https://user-images.githubusercontent.com/49392395/139572684-6ccefc77-f1c3-41d8-9441-14286e3ae325.png)

## Creating an Audio Source
Audio sources are in the name; they're sources for audio. We will first add an audio source on the AmbientAudio object under the player. Do this by navigating to it in the Hierarchy, and then goint to inspector and clicking Add Component, before searching "Audio Source".<br>
![image](https://user-images.githubusercontent.com/49392395/139573105-79fc06bd-6906-471b-9f35-b6507317411c.png)

Then, assign it an Audio Clip and an Output Mixer; this will dictate what sound clip it plays, and what audio mixer (and thus what effects) are applied to it before playing respectively. Do this by dragging and dropping the project file "wind-trees" into AudioClip, and the "Wind" group in the Audio Mixer window to Output.<br>
![image](https://user-images.githubusercontent.com/49392395/139573182-64f222e2-8a68-4d0c-83f6-edbb3fda8445.png)

You also want to make sure the "Play on Awake" and "Loop" buttons are checked. What this means is that a) the sound will immediately play when the scene loads, and b) the audio clip will automatically. play from the beginning once it finishes.<br>
![image](https://user-images.githubusercontent.com/49392395/139573269-2189b929-0ff5-4f5c-a50d-7fd40976c02f.png)

Audio will generally come in two types; a global audio that is heard pervasively throughout the scene no matter where the Audio Listener is located, and a location-specific audio that will get louder or fainter depending on Audio Listener proximity. These two types of sounds are affected by the "Spatial Blend" component-- essentially, how much an audio clip is affected by in game space. For this sound, Spatial Blend should be set to 0.<br>
![image](https://user-images.githubusercontent.com/49392395/139573342-bc654fed-cb8d-495e-958a-0150a5ba8d30.png)

When Spatial Blend is set to 0, all of the settings in "3D Sound Settings" will not work. However, the one that does is called "Stereo Pan". What this does is control how much of the sound is coming out of the left vs. the right ear. Toggle this to the extreme left and right and hear the effects on Play.
<details>
  <summary>What is Stereo?</summary>
  Stereo is short for Stereophonic, and is the counter of "Mono", or Monophonic. It essentially refers to how many audio "channels" are used for input and output of audio. This is why a colloquial "Stereo" (as in a boombox, etc.) have two speakers-- it's because audio is being played on multiple channels versus Mono's singular channel. This gives the illusion of depth, and is why "Stereo Pan" works; it simply treats your headphones as two speakers, and controls which speaker is louder or softer. Stereo sounds are used very liberally to create sound depth and distance; how far away and to what direction a sound is. 
 
 It might be confusing why one would use Mono at all in this case. One reason is because it saves space and boosts performance, necessary if you will have hundreds of audio files. Another reason is because of the way Unity handles audio-- it will play both channels as originating from the same space anyways (as opposed to a real life boombox or stereo), thus making it essentially the same as a mono file anyways.
 
 You can experiment with these two different file types by clicking on any audio clip in the project folders and examining its inspector. You can a) physically see the two channels if it's a stereo file, and toggling the "Force to Mono" option will merge those two channels into a singular one.<br>
 ![image](https://user-images.githubusercontent.com/49392395/139574017-922290d4-141b-42b9-910d-7ec86cec244e.png)
</details>

![image](https://user-images.githubusercontent.com/49392395/139573710-b366582d-3123-4e88-bee8-9d3691bdf484.png)

## Modifying an Audio Source
Now that we've successfully created a global audio, we will now experiment with proximity-based audio. Locate the "RuneSoundColliders" object in the hierarchy and add an Audio Source to all four rune children. Then, assign to them the according numbered audio clip (RuneSound1 + rune_1, etc.) and assign them the "Rune" AmbientMixer for an Output channel.<br>
![image](https://user-images.githubusercontent.com/49392395/139574150-633e6195-62e2-46f5-b7c6-5689ba4bc0a3.png)

Once that is done, we will be modifying each individual rune to have a different effect.

### Rune 1 - Linear Rolloff
This Rune will be represented with green particles in the scene. Under "3D Sound Settings", you will see multiple behaviors. We will focus on Volume Rolloffs first. Rolloff refers to the behavior of a sound when it fades away. In a very general way: does it fade away quickly (like a speeding car)? Or is it more regular, like something on a conveyor belt? Change the Volume Rolloff value to be "Linear Rolloff". A linear rolloff simulates the latter.

You can also toggle Min Distance and Max Distance; this refers to the maximum distance a sound is audible, and Min Distance refers to how close you need to be to a sound for it to be at max volume (remember, you can toggle volume using the Audio Mixer, not just within this component).

When you're outside of Play Mode, you can see the distance your sound can reach in the Scene View, represented by faint blue spheres for both the Min/Max Distances. In play mode, you can test by watching the sound graph and seeing where the listener (i.e. the player in this case) is in relation to the sound.<br>

![image](https://user-images.githubusercontent.com/49392395/139574426-014604b9-857a-4719-9684-bcc5e7024cf9.png)

### Rune 2 - Logarithmic Rolloff
This Rune will be represented with blue particles in the scene. Under "3D Sound Settings", toggle the Volume Rolloff to be "Logarithmic Rolloff", named so because the curve of the rolloff is represented by a log curve. The way true human ears percieve sound is actually more similar to a logarithmic rolloff, so for simulating realism this sort of rolloff is used often.

Again, feel free to play around with the distance settings. Sometimes, if the distance is too short, the log curve will never reach 0 (and thus the sound will never taper off). To change this, simply click and drag one of the red nodes/diamonds in the graph down to zero.
![image](https://user-images.githubusercontent.com/49392395/139574626-89c39fbb-8732-4ccd-87a5-aa51e9930278.png)

## Rune 3 - Custom Rolloff
This Rune will be represented with purple particles in the scene. You will notice that in the previous rune, when we clicked and dragged the red node, the type of rolloff automatically switched to be a custom rolloff-- this is because any modification to the preset Linear v. Logarithmic curves will create a custom rolloff. Simply drag around the nodes to your leisure. If you select a red node, you should also see two grey nodes appear; this allows you to change the curve itself. Double click anywhere on the line (or right click on the line) to create another node, and right click on a pre-existing node to bring up more sub-behaviors.
![image](https://user-images.githubusercontent.com/49392395/139574731-243d60a6-aeb7-4f12-aab3-6fec9243fb7f.png)

## Other Behaviors
Before we move onto the final rune, there are other behaviors that haven't been explored. What they do and their use cases are below. Feel free to test them out with any rune.

**Doppler Level**
This refers to how a sound can pitch depending on the speed you are approaching/leaving an object (think a car racing past you on the highway). The higher the number, the higher the variance of pitch. Test this out by setting a high number and then walking closer to or away from a rune.

**Spread**
This refers to how spread apart the left/right channels are from the audio listener in relation to the rune/object with an audio source. If the spread is at 0, when you are to the right of an audio source the sound will be near exclusively heard (i.e. panned, using the technical word) to your right ear. The higher the spread, the closer that sound sounds to the middle (i.e. not panned to either the left/right). Feel free to test this out by setting a high number and walking closer to or away from a rune.

## Creating an Audio Reverb Zone - Rune 4
On occasion, situations like this one will occur: One sound should be played continuously through a level, but the player will be navigating through a lot of varied locations, from a cave to underwater to a cathedral to a grassy plain-- it is unrealistic for a sound to sound exactly the same in such different environments. Reverb zones create areas that will apply certain mixing effects to the sounds you hear once you enter a specific area, to simulate the way sound changes in different terrain.

To make sure we hear this well, first we must create a custom rolloff for Rune 4. Start with a linear rolloff, then modify the curve (using the grey nodes, or by adding nodes) until it looks similar to this.<br>
![image](https://user-images.githubusercontent.com/49392395/139574985-36f36abb-25f0-4fb6-8125-a322959d42c1.png)

Then we will implement the zone. Do this by going to Hierarchy, then either right clicking or clicking on the plus sign and going to Audio > Audio Reverb Zone.<br>
![image](https://user-images.githubusercontent.com/49392395/139574924-b65dfed3-a6bb-4d0d-8675-b322a68b9ae8.png)

Change the coordinates of the Audio Reverb Zone object to be the same as Rune 4.
(Note: You can shorthand this by navigating to Rune 4 in the hierarchy, and then click on the three dots next to "Transform" in the inspector before clicking on "Copy Component Values". Do the same to the Audio Reverb Zone object, except click "Paste Component Values" instead.)<br>
![image](https://user-images.githubusercontent.com/49392395/139575065-8257f6e6-6ad6-4d48-9abd-7dff67ac2aca.png)

Now we can play around with the settings. Min/Max Distance works very similarly compared to Rolloff; min distance is when the effect will be at full --for lack of a better word-- effect, and max distance is the maximum distance the effect will be applied. Feel free to play around with any of the presets given by Unity under the variable "ReverbPreset". If you want to create your own custom effect, simply set the ReverbPreset variable to "User". You can test this effect by going into play mode. Warning: If your reverb zone is larger than the area a sound can be heard, there will be no difference in sound quality.

You can see the outline of the min/max distances, and the User preset, here.<br>
![image](https://user-images.githubusercontent.com/49392395/139575246-0afa601f-8552-4f46-aed8-f9498aff4ffd.png)

## Bypassing Effects and Custom Filters
If you want a certain audio source to ignore audio effects or reverb zones like the one created above, you can simple toggle the bypass settings in that audio source.<br>
![image](https://user-images.githubusercontent.com/49392395/139575275-95b67b09-2fbc-4943-81cb-0e5de97095cd.png)

If you want to apply certain audio effects to specific audio sources only, then you can add audio filter components, like the ones listed below.
(Note: Only a handful of mixing effects are available this way.)<br>
![image](https://user-images.githubusercontent.com/49392395/139575310-1bf37604-e6c4-4e8e-957a-71adbcfd4b9b.png)

## Final Task
Now that you know how to dynamically change the audio of the scene, change the audio sources and audio clips of the scene in such a way that you can play a musical number depending on where you move to. You can create harmonies with global sounds, make certain areas or objects associated with certain music notes or jingles-- the world is your oyster!

Royalty free sound effects can be found anywhere-- we took some of ours from Zapsplat.com.

If you're more technically minded and want to learn more about the technical capabilities of sound in games/the audio engineering side of things, try to understand the logic below, and the scripts associated with said objects.

## Extra Functionality - Variant Bird Sounds

## Extra Functionality - Dynamic Footsteps

---

## Essential Links
- [Studio Discord](https://discord.com/invite/bBk2Mcw)
- [Linktree](https://linktr.ee/acmstudio)
- [ACM Membership Portal](https://members.uclaacm.com/)
## Additional Resources
- [Unity Documentation](https://docs.unity3d.com/Manual/index.html)
- [ACM Website](https://www.uclaacm.com/)
- [ACM Discord](https://discord.com/invite/eWmzKsY)
 
 
