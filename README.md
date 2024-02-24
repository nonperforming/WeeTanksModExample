# Wee Tanks Mod Example

## How to create your mod
You will need
- Visual Studio (or dotnet CLI, but for this tutorial we will be using Visual Studio)
  - Install Game Development with Unity
  - Install .NET desktop development
- Wee Tanks (alpha branch)
- Knowledge of C#

### 1. Create a new project
Open Visual Studio.
Create a new project, choose 'Class Library (.NET Framework)'
Select a name, location, and set the Framework to '.NET Framework 4.8'
Create the project.

### 2. Add references
In your Solution Explorer, right click on References, and choose 'Add Reference...'
In the window that pops up, click 'Browse...'. Navigate to Wee Tanks library location (default 'C:\Program Files (x86)\Steam\steamapps\common\Wee Tanks\Wee Tanks_Data\Managed')
Avoid adding everything.
Notable libraries:

| Library Name                            | Description        | Documentation                                                                                                |
|-----------------------------------------|--------------------|--------------------------------------------------------------------------------------------------------------|
| `Assembly-CSharp`                       | Wee Tanks Code     | Use dnSpy/ILSpy/dotPeek/etc. and decompile (sorry, no docs yet!)                                             |
| `0Harmony`                              | HarmonyX           | https://harmony.pardeike.net/articles/intro.html, https://github.com/BepInEx/HarmonyX/wiki                   |
| `QFSW.QC`                               | Quantum Console    | https://www.qfsw.co.uk/docs/QC/                                                                              |
| `UnityEngine`, `UnityEngine.CoreModule` | Unity Engine       | https://docs.unity3d.com/2021.3/Documentation/ScriptReference/index.html                                     |
| `Heathen.Steamworks`                    | Heathen Steamworks | https://kb.heathen.group/toolkit-for-steamworks-sdk/unity/api, https://partner.steamgames.com/doc/sdk/api    |

### 3. Create mod
Wee Tanks will automatically patch your library into the game by using [Harmony's PatchAll()](https://github.com/BepInEx/HarmonyX/wiki).
This requires you to annotate your patches ([HarmonyPatch], [HarmonyPrefix], etc.)
May be subject to change in the future.

### 4. Install mod
Compile your mod and move it to the `mods/dll` folder.
If it doesn't exist, create it.
Location:
- Windows - `%userprofile%\Documents\My Games\Wee Tanks\mods\dll`
- MacOS - `~/Library/Application Support/Studio Kit/Wee Tanks/mods/dll`
- Linux - `$XDG_CONFIG_HOME/unity3d/Studio Kit/Wee Tanks/mods/dll`

Log files will be in:
- Windows - `%appdata%\..\LocalLow\Studio Kit\Wee Tanks\Player.log`
- MacOS - `~/Library/Application Support/Studio Kit/Wee Tanks/Player.log`
- Linux - `$XDG_CONFIG_HOME/unity3d/Studio Kit/Wee Tanks/Player.log`
Alternatively, you can use the Quantum Console (press \`) to show recent messages