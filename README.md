# 🧠 Unity Clean Architecture Template  
With **VContainer** + **ScriptableObject Event-Driven Architecture (SO-EDA)**

> A scalable, modular, testable architecture built for Unity games. Designed with Clean Architecture principles, Dependency Injection via VContainer, and decoupled game logic using ScriptableObject Events.

---

## 📂 Project Structure

```
Assets/
├── _Scripts/
│   ├── Core/
│   │   └── Events/
│   │       ├── Base/          ← GameEvent<T>, GameEventListener<T>
│   │       ├── Types/         ← IntEvent, BoolEvent, etc.
│   │       └── CustomTypes/   ← e.g., PlayerDataEvent
│   ├── Domain/
│   │   └── Player/
│   │       ├── Interfaces/
│   │       ├── UseCases/
│   │       └── PlayerDataDto.cs
│   ├── Infrastructure/
│   │   └── PlayerService.cs
│   ├── Application/
│   │   └── Usecase/       ← MonoBehaviours, triggers, input UI
│   └── Presentation/
│       └── PopupController.cs
```

---

## 📦 Dependencies

This project uses the following external packages:

- [UniTask](https://github.com/Cysharp/UniTask) - Provides an efficient async/await implementation for Unity
- [VContainer](https://github.com/hadashiA/VContainer) - A lightweight DI (Dependency Injection) container for Unity

To install these dependencies:

1. Open the Unity Package Manager (Window > Package Manager)
2. Click the '+' button and select "Add package from git URL"
3. Enter the following URLs:
   ```
   https://github.com/Cysharp/UniTask.git
   https://github.com/hadashiA/VContainer.git
   ```

---

## 🔌 VContainer Setup

### GameLifetimeScope.cs
```csharp
public class GameLifetimeScope : LifetimeScope
{
    [SerializeField] PlayerDataEvent playerDataEvent;
    [SerializeField] BoolEvent onPlayerAdded;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<PlayerService>(Lifetime.Singleton).As<IPlayerService>();
        builder.Register<AddPlayerUseCase>(Lifetime.Transient);
        builder.RegisterComponentInHierarchy<AddPlayerToGame>();
        builder.RegisterInstance(playerDataEvent).As<PlayerDataEvent>();
        builder.RegisterInstance(onPlayerAdded).As<BoolEvent>();
    }
}
```

### Inject into MonoBehaviours
```csharp
public class AddPlayerToGame : MonoBehaviour
{
    private AddPlayerUseCase useCase;

    [Inject]
    public void Construct(AddPlayerUseCase useCase)
    {
        this.useCase = useCase;
    }

    public void Trigger(string name)
    {
        useCase.Execute(name);
    }
}
```

---

## 🧠 SO-EDA (ScriptableObject Event-Driven Architecture)

### Define Event Types
```csharp
[CreateAssetMenu(menuName = "Events/Bool Event")]
public class BoolEvent : GameEvent<bool> { }
```

### Raise Event
```csharp
onPlayerAdded.Raise(true);
```

### Listen to Event in UI
Use `BoolEventListener` component and drag UI elements into the UnityEvent field to enable/disable on trigger.

---

## 🧪 UseCase Pattern

### AddPlayerUseCase.cs
```csharp
public class AddPlayerUseCase
{
    private readonly IPlayerService playerService;
    private readonly BoolEvent onPlayerAdded;

    public AddPlayerUseCase(IPlayerService playerService, BoolEvent onPlayerAdded)
    {
        this.playerService = playerService;
        this.onPlayerAdded = onPlayerAdded;
    }

    public void Execute(string name)
    {
        var playerData = new PlayerDataDto { PlayerName = name };
        onPlayerAdded.Raise(true);
        playerService.AddPlayer(playerData);
    }
}
```

### IPlayerService.cs
```csharp
public interface IPlayerService
{
    void AddPlayer(PlayerDataDto data);
}
```

---

## ✅ Benefits of This Architecture

| Feature | Benefit |
|--------|---------|
| ✅ Clean Architecture | Separation of concerns by layer |
| ✅ Use Cases | Testable business logic |
| ✅ VContainer | Automatic dependency injection |
| ✅ SO-EDA | Visual event system for designers |
| ✅ Feature Modules | Easy to scale and isolate gameplay features |
| ✅ Testability | Services and use cases are pure C# |

---

## 🧩 Example: Update Score Flow

1. UI Button → `UpdateScoreButton.OnClick()`
2. Calls `UpdateScoreUseCase.Execute(10)`
3. `ScoreService.AddScore(10)` → returns new score
4. `onScoreUpdated.Raise(score)`
5. `UpdateScoreView` displays new score via `IntEventListener`

---

## 🧠 Tips

- Use `RegisterComponentInHierarchy<T>()` to inject into scene MonoBehaviours
- Use `SetActiveListOnBoolEvent` if you want to enable/disable many objects at once
- You don't need to register all SO Events unless they are injected (use in use cases or services)
- Keep UI logic dumb — let UseCases coordinate logic, and Events communicate results

---

## 🔧 Extensions You Can Add

- [ ] Visual Event Debugger
- [ ] CodeGen for Custom Events and Listeners
- [ ] Base EventInstaller to auto-register all SO Events
- [ ] Unit tests for UseCases
- [ ] Command pattern for undoable use cases

---

## 🧠 Clean Architecture Summary

| Layer | Description |
|-------|-------------|
| **Domain** | Pure logic: UseCases, Interfaces, DTOs |
| **Infrastructure** | Implementations of services |
| **Core** | Shared, reusable systems (Events, Utilities) |
| **Features** | MonoBehaviours, UI, input, Unity-only |
| **Game** | Entry point: DI config (LifetimeScope) |

---

## 📄 License

MIT

---

> 💡 "Architecture should scale with the game — this template lets you build cleanly from day one."
