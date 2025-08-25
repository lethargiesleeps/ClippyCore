# Getting Started with ClippyCore
## Before Starting
1. Follow the setup steps in [README.md](https://github.com/lethargiesleeps/ClippyAI/blob/main/README.md)
2. Create a project, ensure it has access to System.Windows.Forms.
3. Add project reference to ClippyCore or ClippyCore.dll (DLL not yet available)

```csharp
//This document requires the following namespaces.
using DoubleAgent.AxControl;
using ClippyCore.Interfaces;
using ClippyCore.Global;
using ClippyCore.Agents;
using ClippyCore.EventManagement;
```

## Creating and Displaying an Agent
### Loading a prebuilt Agent
```csharp

AxControl axControl = new AxControl();
axControl.CreateControl();
IAgent clippy = AgentManager.CreateAgent(axControl, AgentType.Clippy); //Will load ACS file, and all animations/sounds
clippy.Show();
```

### Loading a custom Agent
```csharp

AxControl axControl = new AxControl();
axControl.CreateControl();

string agentName = "My Custom Agent";
string pathToAcs = "some/path/to/acsfile.acs";
string ttsID = "0000-0000-0000-0000"; //Optional final argument to enable and set TTS
IAgent myCustomAgent = AgentManager.CreateCustomAgent(axControl, agentName, pathToAcs, ttsID ); //Will load ACS file, and all animations/sounds
myCustomAgent.Show();
```

## Basic Agent Commands
### Moving an Agent on the Screen
```csharp
//.MoveTo() can be called before .Show() to set its starting position.
int agentPosX = Screen.PrimaryScreen.Bounds.Right - 600;
int agentPosY = Screen.PrimaryScreen.Bounds.Bottom - 450;
clippy.MoveTo(agentPosX, agentPosY);
clippy.Show(); //Will start in bottom-right of screen

//.MoveTo can also be passed a speed argument (in miliseconds)
//x and y pos can be either int or short
clippy.MoveTo(500, 300, 1000); //Move agent to this position over 1 second
```

### Speaking
```csharp
string helloWorld = "Hello, I am Clippy the Microsoft Office assistant!";
clippy.Speak(helloWorld);
//You can see if an Agent is TTS enabled by using it's IsTtsEnabled property
```

### Hide Agent
```csharp
clippy.Hide();
```

## Animations
### Using Prebuilt Animations
```csharp
//Only works if you are using a prebuilt Agent. For custom agents, see Creating Custom Animations

//Method 1 - Using the preloaded animation Dictionary, use Animations class to see list of animations for particular Agent)
clippy.Play(Animations.Clippy.Explain)

//Method 2 - Pass a string. Value MUST match name of Animation present in ACS File
clippy.Play("Explain");

for(string name in clippy.GetAnimationNames()) {
    Debug.WriteLine(name); //Could do something like this to see all available animations for any Agent
}

//Method 3 - Using the Animation Object
clippy.GetAnimation(Animations.Clippy.Explain).Play(clippy);
//or
clippy.GetAnimation("Explain").Play(clippy);

//Method 4 - Searching for Animation example. Kind of redundant in this case.
// GetAnimation return an Animation object that's part of ClippyCore. It has a .Name property as well
clippy.Play(clippy.GetAnimation("Explain"));
```

### Using Custom Animations
```csharp
Animation myAnim = Animation.Create("CustomWave", myCustomAgent, "Custom Wave");
myAnim.Play(myCustomAgent);

//Optionally you can add to Agent.Animations as well. Key must be a byte and not exist already.
//Allows for using GetAnimation(), GetAnimations() etc...
myCustomAgent.Animations.Add(0, myAnim);
myCustomAgent.Animations[1] = myAnim2
```

## Command, Events and Command Scripting
Some preamble about Commands and Events, to help seperate the terminology: In ClippyCore a *Command* is essentially an Object representing a thing that happens. An *Event* is what causes that thing to happen.

Eventless Commands are referred to as a Generic Command and have the CommandType of NoEvent.

Commands require an Action (the thing that happens). So a Lambda expression or function can be passed as long as they don't return anything (to be implemented).

An Event is always tied to a Command, but a Command doesn't need an Event to be executed.
Examples of events:
- Click
- Double click
- Right click menu
- Key Press
- Keyboard Shortcut
- Move
- And many more....

All Command related stuff can be found in **ClippyCore.EventManagement**.

### Creating a Command
## Using CommandFactory
```csharp
ICoreCommand greetCommand = CommandFactory.CreateContextMenuCommand("Greet", () => clippy.Speak("I'm here to help you.")); //This will create a Greet command for the Agent's right click menu. When it is clicked, the action of clippy.Speak() will be executed.

ICoreCommand genericCommand = CommandFactory.CreateCommand("HelloWorld", () => clippy.Speak("Hello I am clippy!")); //Command with no event

ICoreCommand dblClickCommand = CommandFactory.CreateCommand(EventType.DoubleClick, "Poke", () => clippy.Play(Animations.Clippy.Explain)); //Command to be fired when Agent is double clicked.
```

## Using CommandBuilder
```csharp
ICoreCommand jokeCommand = new CommandBuilder()
    .WithEventType(EventType.ContextMenu)
    .WithName("TellJoke")
    .WithDisplayName("Tell Joke")
    .WithDescription("Bonzi tells a joke haha.")
    .WithAction( () => clippy.Speak("Why don't scientists trust atoms? Because they make everything!"))
    .Build(); //Creates the Tell Joke command to Agent's Right-Click (Context) menu
```

## CommandFactory vs. CommandBuilder
Use CommandBuilder if you need more flexibility for a command. Allows you to override certain members that otherwise aren't exposed outside of ClippyCore. CommandFactory is a quicker and better on performance if that ever becomes an issue

## Registering and Trigger/Firing Commands
**IMPORTANT**: Commands with Events MUST be registered to work. Generic Commands don't need to, but it will add them to Agent.Commands to be referenced at other points during runtime without having to pass same Actions over and over.

```csharp
//Register Commands
clippy.Commands.AddCommand(greetCommand);
clippy.Commands.AddCommand(dblClickCommand);
clippy.Commands.AddCommand(jokeCommand);

//Now whenever those Events happen, it will execute the appropriate commands.

//Triggering a Generic Command
clippy.Commands.TriggerCommand(genericCommand); //Fires whatever code you passed as the Command Action

//You can also register the generic command then trigger it by name
clippy.Commands.AddCommand(genericCommand);
clippy.Commands.TriggerCommand("HelloWorld");

//Alternatively you can pass a standalone Action without creating an ICoreCommand
clippy.Commands.TriggerCommand(() => clippy.Speak("Hello, this is an unregistered command"));

//You can also pass your Commands with Events attached to TriggerCommand() to run the same code without the event being fired.
clippy.Commands.TriggerCommand(jokeCommand);

//Look at CommandManager.cs
//There are methods for removing commands, resetting event handlers and editing commands as well

```

### Loading Default Agent Commands
The preprogrammed Agents have some Default Commands you can load.
These are the commands we will be using in Clippy-Desktop (our implementation using ClippyCore).
Some basic AI functionality (hence why it's called ClippyAI), Jokes, Singing (if TTS enabled) and such.

If you'd like to just use these commands just call .UseDefaultCommands() after creating the Agent.

You can override, remove or extend the commands using the Command scripting system covered above :)

# Enjoy! and Have Fun! More to Come soon!
