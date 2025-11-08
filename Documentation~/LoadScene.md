<div align="center">

  # Load Scene
</div>

To load a scene through a loading screen, all you need to do is use the `SceneLoader.Load()` function from the `Generalisk.LoadingScreen` namespace.

This function accepts one of two values:
- The scenes name, which corresponds to the scenes file name (minus the .unity extension).
  - For example: "SampleScene", "Menu" & "Game".
- The scenes build index, which corresponds to it's placement in the builds scene list.
  - For example, the first scene would have an index of 0, the second would have an index of 1, and so on.
  - You can see the scenes index by going to the [Build Settings](https://docs.unity3d.com/2021.3/Documentation/Manual/BuildSettings.html). The index is located to the right of where the scenes path is located in the scene list.

### Example Script

```csharp
using Generalisk.LoadingScreen;
using UnityEngine;

public class ExampleScript : MonoBehaviour
{
  public void LoadMenu()
  {
    // Load the menu scene using it's scene index
    SceneLoader.Load(0);
  }
  
  public void LoadGame()
  {
    // Load the game scene using it's name
    SceneLoader.Load("Game");
  }
}
```
