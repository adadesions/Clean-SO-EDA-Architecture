# Game Assets

This directory contains all assets related to the game, including scripts, prefabs, scenes, materials, textures, audio, and other resources. It follows Clean Architecture and Scriptable Object Event-Driven Architecture (SO-EDA) principles.

## Directory Structure
- `Prefabs/` - Reusable game objects and components
- `Scenes/` - Game scenes and levels
- `Materials/` - Material assets
- `Textures/` - Texture assets
- `Models/` - 3D models and meshes
- `Animations/` - Animation clips and controllers
- `Audio/` - Sound effects and music
- `UI/` - User interface elements and assets
- `Config/` - Game configuration files

## Architecture Overview

This game follows Clean Architecture principles combined with Scriptable Object Event-Driven Architecture (SO-EDA):

1. **Clean Architecture Layers**:
   - Entities (Core game models)
   - Use Cases (Game logic and systems)
   - Interface Adapters (MonoBehaviours and Unity-specific implementations)
   - Frameworks & Drivers (Unity engine and external tools)

2. **SO-EDA Pattern**:
   - Events are defined as ScriptableObjects
   - Components communicate through events rather than direct references
   - Promotes loose coupling and modular design

## Asset Organization

1. Keep related assets together in their respective folders
2. Use clear, descriptive names for all assets
3. Maintain consistent naming conventions
4. Group assets by feature or system when appropriate
5. Use subfolders to organize large collections of assets
6. Keep the directory structure clean and logical

## Best Practices

1. Keep game-specific assets separate from framework code
2. Use ScriptableObjects for configuration and events
3. Follow SOLID principles
4. Implement new features through the event system
5. Document public APIs and complex systems
6. Write unit tests for core game logic
7. Optimize assets for performance
8. Use version control for all assets
9. Maintain asset dependencies properly

## Getting Started

1. Familiarize yourself with the event system in `Scripts/Events/`
2. Review existing assets before creating new ones
3. Follow the established naming conventions
4. Use the provided templates for new scripts when available
5. Check the asset import settings for optimal performance

## Contributing

1. Create feature-specific branches
2. Follow the established architecture patterns
3. Update documentation as needed
4. Ensure all tests pass before submitting changes
5. Optimize and compress assets appropriately
6. Include necessary metadata with assets 