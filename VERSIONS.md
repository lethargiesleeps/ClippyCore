# Current Version: 0.3
## Current Official Release: none
## Current DLL Release: none

### v0.3
- Added ClickCommand, MoveCommand, Show/HideCommand
- Added options to trigger events when command meets specific requirement (right-click, left-click, hide cause, etc...)
- Added SongMaker. Create songs using SongBuilder and predetermine notes. Has 3 prebuilt songs for TTS agents.

### v0.2
- Implemented Command system for Agents
    - Ability to create Commands for specific events (click, doubleclick, move, right-click menu, etc...)
    - Ability to create custom scriptable Commands not tied to event listeners
    - Attach/Detach commands to agent
    - Commands are scriptable and can take Lambda expressions or functions as arguments.

### v0.1
- Project init
- Agent creation
- Some basic Agent commands
- 3 Precompiled agents (BonziBuddy, Clippy, Shrek) with all their animations, correct paths and TTS IDs