# RFramework
 Lightweight modular framework for Unity and C#. It organizes code into groups and modules that are easy to extend and modify.
 
Overview
RFramework is designed to enhance code structure and development efficiency by organizing code into distinct layers. Each layer has specific responsibilities and restrictions, ensuring a clean and maintainable codebase.

Layers
Module Layer
Restrictions: Cannot access any other layers.

Purpose: Contains reusable operations that may or may not return values, serving as isolated units of functionality.

Execution Layer
Restrictions: Can only access and use the System layer.

Purpose: Extends the functionality provided by the System layer.

Reception Layer
Restrictions: Can only access and use the Model layer.

Purpose: Extends the functionality provided by the Model layer.

Event Layer
Restrictions: Cannot access any other layers.

Purpose: Distributes events that cannot be easily separated. It is recommended not to overly rely on this layer.

System Layer
Restrictions: Cannot access the System, Model, or MONO layers.

Purpose: Acts as a manager for various systems, such as Buff systems and Skill systems.

Model Layer
Restrictions: Cannot access any other layers.

Purpose: Separates and manages data.

MONO Layer
Restrictions: Cannot directly access th
