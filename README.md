# Object Oriented Tanks

Description:
This game is a 3D action shooter where players control a character that can move, aim, and shoot projectiles at enemies. The game features health management for both players and enemies, dynamic shooting mechanics with arc trajectories, and a game over system that triggers when the player runs out of lives or all enemies are defeated.

# How to Install:
Please download the latest patch of game: 
https://github.com/RyanPNSmith/Object-Oriented-Tanks/blob/main/OOTanksWindows.7z

Unzip this file 
then run: Tanks (OOP Project).exe

# UML Diagram 
https://mermaid.live/view#pako:eNq9V02P4jgQ_StRTr3antPeOKxEQ0_3SKBBwPRhhbQq4iLxdmIj26FBo_7vW7YT8uHAsKOe5eS4nu2q51dV5nucSIbxKE5y0HrKIVVQbEREPzcTLXI4oXpGyE0WffcW-_udCxMVcPSW3nxSKoXCBDa_2YwfUEf7ZtxCHCRn0cqAMne_9afX8IpTKCDFO3sIc8MANeUYLrWeuEVQyFKYtn2XSzDRE1beLlAl5Lo9pEK9b0RIiI-hz4eRBvJ-SC1C-qb1fPH3Go8myvkOJ9YzVPb7RkJmUuOMVoaWJWr0p4W2Jyjw6wFVx2KdJA4mLT_Dld_2DIw7sfL1KkVzecCCNuuw5NkuyLTaI7LAoohBw6XoW9cKhN5JVUQJua_g_D2IMSBeH0Bjy7jkKWdbyU6R2t5I72d-ROZjvhroKpOyG6WjePsPJibalnmOZqFwB9tBX3dccZEuJN1AwAao5Bl5ml2xTDIQKS7JxwBDOw8bBEnsMxnXvMDhOw7JcEF2pl8oPKn-iCaQJ2VOi8YqecFcJtyc7mqjttS64O6jeg4Fq2Z6sVwjecyLGRfYodlOLGk3VKgohZqPS0Rjn-aJzKVf6ka9hLDzK0ytiNtZO3EKpOLHhR8GFc4rYt-Mb1TcJfKnCt6I3TOrtDpFT-v_ciMt7Txqwwva2mpnLdfOkY-87bo6zUFQDVaX0iqtYBMQB-hXW4X2biirHgUW_Ob-8gyC5ehvcIpgsksQu-3pAoKu--2p49xgdbYeWNhQUQc2J_fnKMrQ-lVMabGSpwsVybn2Qd1a21KcROPEFmQ6uQn7lzbsbivyXt3a0YfYGH_5kA7krQwNOj6WtuwGZm2TnYTXt35UQ7hY0oc6RbOlr0S3VpulZYCS-w0U0z4dQpDt7j-AuMo3NlWN-CWFKrtSSR6P-1wyovJBHjsKWNC-PMlxddIGiwgtTtOVPu52dEyYcdQacu4A7s1z_oySehSE7s--9GyoXpqQvAY5mpFp7BQd-rFWPKWS2PKCml0kTYbq2jkPoL51U2DlV2bO7D-CFlbVkH3r47p-Brs2LWQzKbtx9nVpQf8xDamUjUWa441duZYPeWZegAKeUh65NP6pxnwOtUPVp09_dv4cjKJS172n9yJuoP6lEEL9fIOrnz9tZL9VNujKoxG9YEji4gq-3S968Lp4DmzLrQQhqV9FnUz7Mbwl_1vBXsMDaMa1FZHu3YcXXYM_M9_aP76PSSakF0Z_f50-NzHlEj2J4xENGajXTbwR74SD0sjVSSTxyKgS72MlyzSLRzvINX2VThzVf-casgfxl5RFBXr_F4PS2do

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
