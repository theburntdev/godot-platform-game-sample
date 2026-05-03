# godot-platform-game-sample
A basic platform game using godot 4.6 c#

Credit to the following for the assets available:
https://brackeysgames.itch.io/brackeys-platformer-bundle

Credit to the following tutorial:
https://www.youtube.com/watch?v=LOhfqjmasi0

Primary differences are this version uses C# and made a couple of tweaks for the player to be a bit more object oriented.

### Benefits for C#:
- For those who already have proficiency here vs GDScript
- More object oriented
- Strong typing
- Better performance
- Access to .NET libraries
### Gotchas for C#:
- No avoiding Godot's editor
- While you can use `[Export]` as a way to associate a scene's child nodes as a dependency, you will need the Godot's Inspector Panel for the parent scene to assign that child node to your private property in the respective scene script.cs 
- The tutorial said you can set the GameManager as a "Unique Name" https://youtu.be/LOhfqjmasi0?t=3888. I struggled With that in C#. I ended having to use Godot -> Project -> Project Settings -> Global -> AutoLoad and add it there as a global variable instead

### Benefits for GDScript:
- Built for Godot engine
- More seemless integration as you can map child nodes to your script with ctrl -> click -> drag (like XCode iOS development)
