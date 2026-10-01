# TOWER : Sky & Earth

*[한국어로 보기 →](README.ko.md)*

**▶ Gameplay video: https://youtu.be/sp2ACbRQ-O8**

6-person team project — 3D action RPG with character-switching combat, climbing a tower floor by floor. Built during a Unity game-dev bootcamp (2025.07 ~ 2025.08).
Unity · C# · PC, 3rd-person free-look.

## Where to start reading

| File | What to look at |
|---|---|
| [`Player/Parrying.cs`](Scripts/Player/Parrying.cs) | Parry check (`TryParry`), parry-mode presentation (grayscale post-processing + `timeScale` 0.3), then the strong-attack / character-swap branch |
| [`Enemy/Enemy.cs`](Scripts/Enemy/Enemy.cs) | `Jigumini()` — an animation event on enemy attack motions that opens the parry window (`CanParry`). Groggy gauge and the 150% damage multiplier while groggy |
| [`Player/StateMachine/DashState.cs`](Scripts/Player/StateMachine/DashState.cs) | Animator `StateMachineBehaviour` that triggers the parry check the moment the dash animation starts |
| [`Player/TeamManager.cs`](Scripts/Player/TeamManager.cs) | 3-character switching; stores the party formation as offsets in the leader's local space and moves it |
| [`Player/Character/Character.cs`](Scripts/Player/Character/Character.cs) | `IDamageable` implementation (defense formula); spawns the spirit form (`fairyForm`) when swapped out |
| [`Enemy/StateMachine/EnemyHitState.cs`](Scripts/Enemy/StateMachine/EnemyHitState.cs) | Fix for enemies moving while being hit — disables `NavMeshAgent` during the hit state |

To follow a parry end to end: `Enemy.Jigumini()` (window opens) → `DashState` (dodge input) → `Parrying.TryParry()` (check + presentation).

## About this repository

This is a **code-only extract** of the C# scripts I authored, pulled from the full team Unity project by cross-referencing git commit history — specifically the combat system and character-skill work I was responsible for.

The full project (including third-party Unity Asset Store packages) lives in a private repository. This repo excludes those assets, and excludes scripts fully owned by teammates working on other systems (enemy AI/behavior graphs, environment art tooling, etc.).

- `Scripts/Player/` — player controller, combat/parrying, attack & dash state machine, 3-character switching (Dealer / Healer / Tanker), character skills
- `Scripts/Enemy/` — enemy base data and hit-reaction state work I touched
- `Scripts/Sound/`, `Scripts/UI/`, `Scripts/Util/`, `Scripts/Game/` — supporting scripts I touched (SFX triggers, pause UI, singletons, damageable interface)

## Team & my role

- Team size: 6
- My role: **combat system design & implementation, character-skill design & implementation**

This repo won't open/build in Unity as-is (scenes, prefabs, and third-party assets are excluded).
