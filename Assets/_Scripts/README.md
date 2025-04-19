# Scripts Architecture

This directory contains the core scripts implementation following Clean Architecture principles combined with Scriptable Object Event-Driven Architecture (SO-EDA). The scripts are organized into distinct layers to maintain separation of concerns and promote modularity.

## Directory Structure

The scripts are organized into five main categories:

### 1. Core (`Core/`)
Foundation layer containing essential systems and utilities:
- Base classes and interfaces
- Core game systems
- Utility functions
- Common components

### 2. Domain (`Domain/`)
Business logic and game rules:
- Game entities
- Business rules
- Domain models
- Use cases
- Interfaces for repositories

### 3. Features (`Features/`)
Feature-specific implementations:
- Individual game features
- Feature-specific components
- Feature-specific systems
- Feature-specific utilities

### 4. Game (`Game/`)
Game-specific implementations:
- Game-specific components
- Game-specific systems
- Game-specific utilities
- Game-specific configurations

### 5. Editor (`Editor/`)
Unity Editor extensions and tools:
- Custom editor windows
- Editor tools
- Editor utilities
- Custom inspectors

## Architecture Overview

The architecture follows Clean Architecture principles with SO-EDA integration:

1. **Clean Architecture Layers**
   - Entities (Domain layer)
   - Use Cases (Domain layer)
   - Interface Adapters (Features and Game layers)
   - Frameworks & Drivers (Core layer)

2. **SO-EDA Integration**
   - Events are defined in `Assets/_Events`
   - Components communicate through events
   - Systems are loosely coupled
   - State changes are event-driven

## Layer Responsibilities

### Core Layer
- Provides foundational functionality
- Contains reusable components
- Implements core systems
- Defines base interfaces
- Contains utility functions

### Domain Layer
- Contains business logic
- Defines game rules
- Implements use cases
- Defines entity models
- Specifies repository interfaces

### Features Layer
- Implements specific game features
- Contains feature-specific logic
- Manages feature-specific state
- Handles feature-specific events
- Implements feature-specific UI

### Game Layer
- Implements game-specific functionality
- Contains game-specific components
- Manages game-specific systems
- Handles game-specific events
- Implements game-specific UI

### Editor Layer
- Extends Unity Editor functionality
- Provides custom tools
- Implements editor utilities
- Creates custom inspectors
- Adds editor-specific features

## Best Practices

1. **Code Organization**
   - Keep related code together
   - Follow the established directory structure
   - Use clear, descriptive names
   - Maintain separation of concerns

2. **Clean Architecture**
   - Dependencies point inward
   - Inner layers don't know about outer layers
   - Use interfaces for dependencies
   - Keep business logic in Domain layer

3. **Event-Driven Architecture**
   - Use events for communication
   - Keep components loosely coupled
   - Handle events in appropriate layers
   - Follow event naming conventions

4. **Performance**
   - Optimize critical paths
   - Use object pooling where appropriate
   - Cache frequently used values
   - Profile and optimize as needed

## Example Structure

```
_Scripts/
├── Core/
│   ├── Interfaces/
│   ├── Systems/
│   └── Utils/
├── Domain/
│   ├── Entities/
│   ├── UseCases/
│   └── Interfaces/
├── Features/
│   ├── Feature1/
│   └── Feature2/
├── Game/
│   ├── Components/
│   ├── Systems/
│   └── Utils/
└── Editor/
    ├── Tools/
    └── Windows/
```

## Development Guidelines

1. **Adding New Features**
   - Create feature-specific folder in Features
   - Implement domain logic in Domain layer
   - Create necessary events in _Events
   - Implement UI and components in Game layer

2. **Modifying Existing Features**
   - Follow existing patterns
   - Maintain layer separation
   - Update documentation
   - Add tests for new functionality

3. **Creating Editor Tools**
   - Place in Editor directory
   - Follow Unity Editor patterns
   - Document usage
   - Add error handling

## Testing

1. Unit Tests
   - Test domain logic
   - Test use cases
   - Test utilities
   - Test core systems

2. Integration Tests
   - Test feature integration
   - Test system interaction
   - Test event handling
   - Test UI functionality

## Troubleshooting

Common issues and solutions:
1. Circular dependencies - Review architecture
2. Tight coupling - Use events and interfaces
3. Performance issues - Profile and optimize
4. Maintenance problems - Follow patterns 