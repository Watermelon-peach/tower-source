# TOWER : Sky & Earth

*[한국어로 보기 →](README.ko.md)*

6-person team project — 3D action RPG with character-switching combat, climbing a tower floor by floor. Built during a Unity game-dev bootcamp (2025.07 ~ 2025.08).
Unity · C# · PC, 3rd-person free-look.

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
