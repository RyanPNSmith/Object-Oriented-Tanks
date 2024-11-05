# Object Oriented Tanks
Project Overview:

This project involves designing and implementing a 3D tank war game in Unity using C#. Inspired by the classic game "Battle City," players control a tank, avoid enemy attacks, and destroy enemy tanks. The game will incorporate core Object-Oriented Programming (OOP) principles and utilize design patterns to create a modular, scalable structure.

Key Game Features:

Player-Controlled Tank: Players can move their tank, fire projectiles, and navigate obstacles while avoiding enemy tanks.
Enemy Tanks: Basic AI controls enemy tanks to patrol, chase, and attack the player. The game starts with six enemy tanks by default.
MedPacks: Restores health for both player and enemy tanks when collected.
Missiles: Fired by both player and enemy tanks, missiles deal damage to other tanks but are absorbed by walls.
Walls: Act as indestructible obstacles that tanks and missiles cannot pass through.
Explosions: Triggered when a tank is destroyed.
Project Objectives:

Apply OOP principles to model real-world objects (e.g., Tank, Wall, Missile).
Use design patterns (e.g., Factory, Strategy, Observer, Singleton) to ensure flexibility, reusability, and maintainability.
Separate concerns to follow clean software design practices.
Implement basic game mechanics, AI behaviors, and user interactions through Unity's 3D environment.
Game Features and Requirements:

Core Classes/Components:

Tank: Represents player and enemy tanks, capable of movement, firing, and taking damage. The player tank is controlled by input, while enemy tanks have AI-driven behavior.
Missile: Represents projectiles fired by tanks.
Wall: Indestructible obstacles within the game environment.
MedPack: Collectible item that restores health.
Explosion: Visual effect triggered when a tank is destroyed.
Game Mechanics:

Tank Movement: Player tank moves based on keyboard input and enemy tanks follow basic AI.
Missile Firing: Tanks can fire missiles in the direction they are facing.
Health System: Tracks health for all tanks and plays an explosion effect on destruction.
Winning/Losing Conditions: The player wins by destroying all enemy tanks and loses if their tank is destroyed.
Design Patterns:

Factory Pattern: Manages object creation (e.g., tanks, walls, missiles) for scalability.
Strategy Pattern: Defines different movement behaviors for player-controlled and AI-controlled tanks.
Observer Pattern: Manages game events (e.g., tank destruction, health pickup updates).
Singleton Pattern: Controls shared resources like game score or map state.
Game GUI:

Game Area: Displays tank movement, shooting, and obstacles.
Health Bar: Shows player tank health.
Score/Enemy Counter: Displays remaining enemies and player lives.
