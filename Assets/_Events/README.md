# Events System

This directory contains the core event system implementation following the Scriptable Object Event-Driven Architecture (SO-EDA) pattern. Events are used to facilitate loose coupling between game components and systems.

## Directory Structure

The event system is organized into three main categories:

### 1. Global Events (`Global/`)
System-wide events that affect the entire game:
- `OnPlayerAdded.asset` - Event triggered when a new player is added to the game
- `PlayerDataEvent.asset` - Event for handling player data updates and changes

### 2. Feature Events (`Features/`)
Feature-specific events that handle particular game mechanics:
- `OnClickCircle.asset` - Event for handling circle click interactions

### 3. Scene Events (`Scene/`)
Scene-specific events (currently empty, reserved for future scene-specific event implementations)

## Event System Architecture

The event system follows these key principles:

1. **ScriptableObject-Based Events**
   - Events are implemented as ScriptableObjects
   - Allows for easy creation and management in the Unity Editor
   - Enables event reuse across different scenes

2. **Event Categories**
   - Global: System-wide events that affect the entire game
   - Feature: Specific to particular game mechanics or features
   - Scene: Specific to particular scenes or levels

3. **Event Naming Convention**
   - Global events: Descriptive names (e.g., `PlayerDataEvent`)
   - Feature events: Prefix with "On" for action events (e.g., `OnClickCircle`)
   - Scene events: Prefix with scene name (e.g., `SceneName_EventName`)

## Usage Guidelines

### Creating New Events

1. **Choose the Appropriate Category**
   - Global: For system-wide events
   - Features: For specific game mechanics
   - Scene: For scene-specific events

2. **Follow Naming Conventions**
   - Use clear, descriptive names
   - Follow the established prefix patterns
   - Use past tense for completed actions
   - Use present tense for ongoing actions

3. **Event Implementation**
```csharp
[CreateAssetMenu(fileName = "NewEvent", menuName = "Events/Category/EventName")]
public class NewEvent : ScriptableObject
{
    private List<EventListener> listeners = new List<EventListener>();

    public void Raise()
    {
        for(int i = listeners.Count -1; i >= 0; i--)
            listeners[i].OnEventRaised();
    }

    public void RegisterListener(EventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(EventListener listener)
    {
        listeners.Remove(listener);
    }
}
```

### Best Practices

1. **Event Organization**
   - Place events in the appropriate category folder
   - Keep related events together
   - Use clear, descriptive names
   - Document event purpose and usage

2. **Performance Considerations**
   - Unregister listeners when they're no longer needed
   - Avoid raising events every frame unless necessary
   - Use event pooling for frequently raised events
   - Consider using a queue for events that might be raised rapidly

3. **Debugging**
   - Add debug logs for important events
   - Use the Unity Event System debugger
   - Implement event validation in development builds

## Example Usage

```csharp
// Event Listener
public class CircleClickHandler : MonoBehaviour
{
    public OnClickCircleEvent clickEvent;

    private void OnEnable()
    {
        clickEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        clickEvent.UnregisterListener(this);
    }

    public void OnCircleClicked()
    {
        // Handle circle click
        Debug.Log("Circle was clicked!");
        // Update score
        // Play animation
        // etc.
    }
}
```

## Testing

1. Create test events for unit testing
2. Use event mocking for integration tests
3. Verify event registration and unregistration
4. Test event propagation and handling
5. Validate event data integrity

## Troubleshooting

Common issues and solutions:
1. Events not firing - Check registration and event references
2. Multiple listeners - Ensure proper cleanup in OnDisable
3. Performance issues - Review event frequency and listener count
4. Memory leaks - Verify unregistration of listeners 