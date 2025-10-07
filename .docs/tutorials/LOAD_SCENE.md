<div align="center">

  # Loading A scene
</div>

To load A scene using Simple Loading Screen, use the `SceneLoader.Load()` function & provide it with either one of the following:
- A [scene](https://docs.unity3d.com/ScriptReference/SceneManagement.Scene.html) object
- The name of the scene
- The scenes build index (which you can find in the projects build settings)

> [!Warning]
> Providing this function with an invalid value will cause the system to softlock while in the loading screen

## Example Script
```csharp
using Generalisk.LoadingScreen;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExampleScript : MonoBehaviour
{
    public void LoadActiveScene()
    {
        SceneLoader.Load(SceneManager.GetActiveScene());
    }

    public void LoadSceneBySceneObject(Scene scene)
    {
        SceneLoader.Load(scene);
    }

    public void LoadSceneByName(string sceneName)
    {
        SceneLoader.Load(sceneName);
    }

    public void LoadSceneByBuildIndex(int index)
    {
        SceneLoader.Load(index);
    }
}
```
