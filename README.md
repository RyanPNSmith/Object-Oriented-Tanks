# Object Oriented Tanks

Description:
This game is a 3D action shooter where players control a character that can move, aim, and shoot projectiles at enemies. The game features health management for both players and enemies, dynamic shooting mechanics with arc trajectories, and a game over system that triggers when the player runs out of lives or all enemies are defeated.

# How to Install:
Please download the latest patch of game: 
https://github.com/RyanPNSmith/Object-Oriented-Tanks/blob/main/OOTanksWindows.7z

Unzip this file 
then run: Tanks (OOP Project).exe

# Key Features:

 - Player Movement: The player can move in a 3D space using WASD/Arrow keys, with smooth rotation towards the movement direction.
 - Shooting Mechanics: Players can shoot projectiles with adjustable arc heights by pressing Q to decrease and E to increase, allowing for strategic aiming and shooting.
 - Health System: Both players and enemies have health systems that manage damage and healing. Players can collect health packs to restore health.
 - Enemy AI: Enemies detect the player within a certain range and can move towards and shoot at the player.
 - Visual Effects: Particle systems are used for shooting trails and explosions, enhancing the visual experience.
 - Optimization so that it can fit on GitHub.

# Components:
 - Player: Controls movement and shooting, manages health and lives.
 - Enemies: AI-controlled characters that can detect and attack the player.
 - Health Packs: Collectible items that restore health to players or enemies.
 - Exploding Boxes: Objects that explode upon collision with bullets, adding environmental interaction.

# Technologies Used:
 - Unity Engine: The game is developed using Unity, leveraging its physics and rendering capabilities.
 - C# Programming: All game logic is implemented in C# scripts, managing interactions, health, and game states.

# Object Oriented Programming Principles In This Project

Object-Oriented Programming (OOP) principles are effectively utilized in this game project developed in C# and Unity, enhancing code organization, reusability, and maintainability.
The project demonstrates encapsulation by defining each game entity, such as PlayerHealth and EnemyHealth, as separate classes. This structure allows for clear separation of concerns, with private variables protected from direct access and public methods provided for safe interaction. The use of [SerializeField] enables configuration in the Unity Inspector while maintaining encapsulation.
Inheritance is supported by the potential to create base classes, such as a Character class, which could encapsulate shared functionality for both players and enemies. This reduces code duplication and promotes reusability. Additionally, implementing interfaces for common behaviors (e.g., IDamageable) can further enhance inheritance.
Polymorphism is evident in the ability to treat different classes as instances of a common superclass. This allows for method overriding in derived classes, enabling specific implementations while maintaining a unified interface. Interfaces also facilitate flexible interactions among various game components. Abstraction simplifies complex systems by focusing on essential properties and behaviors within each class. Each class is designed to manage specific aspects of the game, such as health or movement, allowing developers to work independently on components. Public methods abstract implementation details, enabling users to interact with classes without needing to understand their internal workings. Overall, the project adheres to OOP principles, leveraging C# and Unity's capabilities to create a well-structured and maintainable codebase. This approach not only enhances the current development but also lays a solid foundation for future expansions and improvements.
