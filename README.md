# ClippyCore

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=flat)](http://makeapullrequest.com)
[![Contributions Welcome](https://img.shields.io/badge/contributions-welcome-brightgreen.svg?style=flat)](https://github.com/your-username/your-repo/issues)
###### Current Version: v0.2


A library + deployable programs to use multiple Microsoft Agents on modern Windows systems (7 and newer) that keeps some of the old functionality and has AI capabilities. Comes with a .exe WinForms and a Microsoft Word add-in as well. Based on a previous implementation I made of [Bonzi Buddy](https://github.com/lethargiesleeps/BonziBuddy) using the DoubleAgent SDK. Comes with 3 Agents so far with more to be added :)

Doc site coming soon

Will eventually release as an installable program bundled with the required dependencies, but the ClippyCore project can still be used for anyone's own personal development (which I will eventually release as it's own DLL in this repo).

**Currently Supported Agents**
- Clippy
- Bonzi Buddy
- Shrek (Club Tuki)

**ClippyCore uses .NET Standard 2.0.**

### Setup for Development

The following will guide the setup process for using the ClippyCore library, but the same can be applied for your own MS Agent development.

#### Requirements

* Designed for 64-bit systems only
* .NET Framework 2.0
* DoubleAgent x64
* DoubleAgent SDK x64
* A Windows system (developed on Win11, but should work with anything Win7 and above)
* MASH (optional, helps a lot but not required)

#### Dependencies
The following DLLs are mandatory to do any MS Agent development. They come with the DoubleAgent SDK but I've added them in this repo along with the required installers for DoubleAgent in the Installers directory. The files can also usually be found after installing DoubleAgent SDK in `Program Files/Double Agent/Dev/4.0`.

- DoubleAgent.AxControl.dll
- DoubleAgent.Control.dll
- DoubleAgent.Server.dll

*Note: Any project, even outside of the ClippyCore project must reference these assemblies.*

**System.Windows.Forms***
MS Agent, and even DoubleAgent, rely on ActiveX to properly function. Because of this limitation, for a project to properly function, it needs to have reference to and use the `System.Windows.Forms` assembly and namespace (even if it doesn't look like it uses it in your code). It gives `AxControl` the ability to call `CreateControl()` which is required for any of this to work.

#### Steps
1. Ensure you have .NET SDK installed.
2. Install DoubleAgent
3. Install DoubleAgent SDK
4. Clone this repository (if using ClippyCore library)
5. If using the repo, ensure all projects have the correct references to the 3 DoubleAgent DLLs, or update the paths based on your machine if necessary.
6. If building your own project with or without ClippyCore, ensure it has references to the 3 DLLs and `System.Windows.Forms` and that it works with .NET Framework 2.0
7. (Optional but recommended) Install MASH, it is a tool that lets you load and mess around with your agents. It also generates scripts (in VB) that show some of the functions used by DoubleAgent.AxControl.
8. Check out GETTING_STARTED.md more code examples. Documentation site coming soon!

```csharp
//Some example code to get started
//See GETTING_STARTED.md for better
//Similar code can be found @ ClippyDesktop.Forms.Main.cs at HelloWorldDemo()
            
//With ClippyCore
AxControl axControl = new AxControl();
axControl.CreateControl(); //This is what uses the Control class from Windows.System.Forms
IAgent clippy = AgentManager.CreateAgent(axControl, AgentType.Clippy);
clippy.Show();
clippy.Play(Animations.Clippy.Wave);
clippy.Speak("Hello World!");
clippy.Hide();

//With AxControl directly
AxControl axControl2 = new AxControl();
string agentName = "BonziVine";
axControl2.CreateControl();
axControl2.Characters.Load(agentName, "../some/path/to/an/acsfile.acs");
axControl2.Characters[agentName].TTSModeID = "{some-tts-id}"; //Required for some agents for Text to speech to work
axControl2.Characters[agentName].Show();
axControl2.Characters[agentName].Play("Wave");
axControl2.Characters[agentName].Speak("Hello World!");
axControl2.Characters[agentName].Hide();
```

### Current Capabilities
This project is still very early and is in active development. A lot of planned features are missing.
As of right now, with ClippyCore you can:
- Create 3 different types agents (Clippy, Bonzi, Shrek), multiple simultaneous agents possible using one in stance of AxControl
- Show/Hide them
- Play any of their animations
- Stop the animations (if looping)
- Make them say stuff
- Right+Click context menus that can be expanded on
- Event handling API for the context menus
- Command API

### Future Development
**Version 0.3 should include**
- Implement more from the DoubleAgent SDK (Gesture/Look to position, Agent specific features)
- Some pre-determined default events for each agent (that can be replaced with custom events)
- Sayings for the agents to speak, and a Speech API (like I did in BonziBuddy repo)
- Get agents to read and speak contents of a text-file, or let developers load in key:value based JSON files and load as Speech
- Singing if TTS enabled (will probably just copy over the Singing API I made in the BonziBuddy repo)

**Version 0.4 should include**
- Debug mode (option to log errors and continue execution if off, or throw exceptions if on)
- Peristent Settings (changing current Agent, default Agent, amongst other stuff)
- Fully functional Logging and better error handling for all of ClippyCore
- Documentation up and running
- Some unit tests?


