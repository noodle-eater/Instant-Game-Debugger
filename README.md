# Instant Game Debugger
An Instant, Simple &amp; Ready to use Unity In-Game Debugger &amp; Console. We already have some in-game console in unity asset store. But sometimes I find bug that I do not have a time to fix it. And I found my self repeating stacking a UI in Unity to test thirdparty features, like the one in [Ads Framework](https://github.com/AmdHamdani/Ads-Framework). So this debugger is the extension version of the UI I stacked in the [Ads Framework](https://github.com/AmdHamdani/Ads-Framework). Beside it, I just want to see the log from my game, so if the in-game console I get from asset store not working, I do not want to spend my time fixing it. So I decide to make this fun little thing. And the main reason is of course because I love doing this. By the way, Thank you for :) take a look or try this tiny debugger. Feel free to reach me or create an issue if you have any suggestion, feedback or report.

## A. Table of Content

[TOC]

## B. Example

### 1. Code 

```c#
using UnityEngine;

public class DebugExample : MonoBehaviour
{
    private int counter = 0;
    
    private void Start() {
        var debug = new GameDebugger();

        debug.Init();
        debug.AddText("In Game Debugger");
        debug.AddText(() => "Counter : " + counter);
        debug.AddButton("Add", () => { counter++; Debug.Log("Counter " + counter); });
        debug.AddConsole();
    }
}
```

### 2. Result

![example](https://github.com/AmdHamdani/Instant-Game-Debugger/blob/develop/images/example.png)

## C. Documentation

### 1. Init

Initialize the Debugger Canvas and all required config. Make sure to call this first before add any UI.

```c#
public void Init()
```

### 2. Button

Add a button into the debugger canvas.

```c#
public void AddButton(string buttonName, System.Action OnClicked)
```

### 3. Text

Add a text into the debugger canvas. You can use this, if you want to inspect a value. The text will be updated each frame.

```c#
public void AddText(System.Func<string> GetText)
```

### 4. Static Text

Add a text into the debugger canvas. This text will not be updated, so if you want to inspect a value do not use this one.

```c#
public void AddText(string text)
```

### 5. Separator

Add black straight line to separate UI.

```c#
public void AddSeparator()
```

### 6. Console

Add small console window in debugger.

```c#
public void AddConsole()
```

### 7. Additional

All the debugger UI & console here I usually used for testing thirdparty features in Android in potrait mode. So, all available UI here is fit in potrait mode. You can change it from the prefab directly, e.g if you want to use it in landscape mode, just open the `Debug Canvas` prefabs. Change the `Reference Resolution` in `Canvas Scaller`.

## D. Next Features

- [ ] Drop Down
- [ ] Show Console on Error
- [ ] Debugger Config
- [ ] Potrait & Landscape UI Mode

