<div align="center">

  # Loading Screen Info
</div>

The Loading Screen info is stored in a `LoadingInfo` component. It is generated just before the Loading Screen is opened and is destroyed just before the Loading Screen closes.

The `LoadingInfo` component contains Loading instructions & Load Progress (ranged from 0-1).

### Example Scripts

```csharp
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class LoadingPercentage : MonoBehaviour
{
  private TextMeshProUGUI text;
  private LoadingInfo info;

  void Awake()
  {
    text = GetComponent<TextMeshProUGUI>();
  }

  void Start()
  {
    info = FindFirstObjectByType<LoadingInfo>();
  }

  void Update()
  {
    text.text = (info.Progress * 100) + "%";
  }
}
```

```csharp
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class LoadingBar : MonoBehaviour
{
  private Slider loadingBar;
  private LoadingInfo info;

  void Awake()
  {
    loadingBar = GetComponent<Slider>();
  }

  void Start()
  {
    info = FindFirstObjectByType<LoadingInfo>();
  }

  void Update()
  {
    loadingBar.value = info.Progress;
  }
}
```
