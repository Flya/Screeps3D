# Screeps3D
A 3D client for the MMORTS Screeps.com

## Goal 
To build a 3D client for Screeps.

## Progress
I think it has a fairly solid foundation so that if anyone wants to contribute to it, it is at a good point. There is a websocket/http client that could be fleshed out more but has all the basic functionality. There is a solid system for rendering rooms/objects. At the moment the project is organized into two systems:

* ScreepsAPI - HTTP/Websocket client for communicating with the server
* Screeps3D - Login, WorldView, RoomView, etc.

It would be ideal to keep these two separate, so that the ScreepsAPI can be exported as a package for use in other screeps/unity3D projects. 

Here are the major areas that I'd like to tackle next: 
* ~Get it working with private servers~
* Gameplay options like hotkeys, camera controls, console colors, etc.
* Finish model set for room objects (Missing nuker, links, and terminal)
* ~Rendering roads~
* ~Rendering creeps (new model with player icon downloaded and assigned as texture)~
* Rendering creep, tower, link, etc. actions (particle systems are an excellent way to make these visually appealing)
* Creep Say (I'm imagining a floating text that appears above their heads and drifts up to eventually disappear)
* ~Figure out the best way to subscribe/unsubscribe from rooms, fog of war, etc.~
  
---
The following was added by thmsn

## Requirements
* Unity 2018.3.7f1
* Blender 2.79
  * If no models are showing up, you need to install blender, .blend files are used in unity



### ideas
* Crumble walls based on hitpoints
* Render alliances
  * Render your "friends" in another color than red
* Make resource/material nodes larger / smaller based on resource amount available
* color code material nodes based on the type of material
* minimap

### stuff found when rendering BotArena
 * can we implement a spectator mode? https://github.com/bonzaiferroni/Screeps3D/issues/13
   * yes xD, currently shuffles random rooms with pvp if you toffle PVP Spectate on
   * ideas
     * follow a creep? perhaps random?
     * different camera angels
 * render safemode
 * prevent certain objects from being selected, 
 * selecting creeps and having roads selected sucks
 
 #### bugs
* creeps not despawning
* tombstones not showing
* dropped energy not rendered
* attacks are rendered too far (blue beam)
* room update / connection is lost, and rooms looses all data
  * Possibly because of this
```
["err@room:E3S3","subscribe limit reached"]
 
(Filename: C:\buildslave\unity\build\Runtime/Export/Debug.bindings.h Line: 45)

recieved null data from server
 
(Filename: C:\buildslave\unity\build\Runtime/Export/Debug.bindings.h Line: 45)
```
* http error stays center of screen (Locked)
* Creeps remain dorment after their TTL becomes negative
* CreepView _body.material.mainTexture = _creep.Owner.Badge; Owner is null



