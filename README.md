# RFramework
 Lightweight modular framework for Unity and C#. It organizes code into groups and modules that are easy to extend and modify.

## Overview

RFramework is designed to enhance code structure and development efficiency by organizing code into distinct layers. Each layer has specific responsibilities and restrictions, ensuring a clean and maintainable codebase.

## Layers

### Module Layer

**Restrictions**: Cannot access any other layers.

**Purpose**: Contains reusable operations that may or may not return values, serving as isolated units of functionality.

### Execution Layer

**Restrictions**: Can only access and use the System layer.

**Purpose**: Extends the functionality provided by the System layer.

### Reception Layer

**Restrictions**: Can only access and use the Model layer.

**Purpose**: Extends the functionality provided by the Model layer.

### Event Layer

**Restrictions**: Cannot access any other layers.

**Purpose**: Distributes events that cannot be easily separated. It is recommended not to overly rely on this layer.

### System Layer

**Restrictions**: Cannot access the System, Model, or MONO layers.

**Purpose**: Acts as a manager for various systems, such as Buff systems and Skill systems.

### Model Layer

**Restrictions**: Cannot access any other layers.

**Purpose**: Separates and manages data.

### MONO Layer

**Restrictions**: Cannot directly access the System and Model layers.

**Purpose**: Manages the lifecycle aspects and MonoBehaviour related operations in Unity.



## Future Directions

### Event System

- **Description**: Implement a simple event system to facilitate communication between different parts of the application without creating tight coupling.
- Too much reliance is not recommended

### Object Pooling

- **Description**: Introduce an object pooling system to reduce garbage collection (GC) overhead by reusing objects instead of creating and destroying them frequently.

### Examples and Use Cases

- **Description**: Provide a comprehensive set of examples and use cases to demonstrate how RFramework can be applied in various scenarios.
- **Benefits**: Help developers understand how to effectively use the framework in real-world applications. Examples will cover common patterns and best practices, showcasing the flexibility and power of RFramework.

### Additional Features

- **Extensible Configuration System**: Allow developers to easily configure modules and systems via a centralized configuration mechanism.
- **Enhanced Debugging Tools**: Integrate tools to facilitate debugging and monitoring of the framework's components.
- **Documentation Improvements**: Continuously update and expand the documentation to ensure it remains clear, comprehensive, and helpful for both new and experienced users.
