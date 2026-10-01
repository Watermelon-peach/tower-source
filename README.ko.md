# TOWER : Sky & Earth

*[→ Read in English](README.md)*

**▶ 플레이 영상: https://youtu.be/sp2ACbRQ-O8**

6인 팀 프로젝트 — 캐릭터 스위칭 전투가 특징인 3D 액션 RPG, 탑을 층층이 올라가는 게임. Unity 게임제작 부트캠프 2차 팀 프로젝트 (2025.07 ~ 2025.08).
Unity · C# · PC, 3인칭 프리룩 뷰.

## 코드 읽기 시작점

| 파일 | 볼 만한 부분 |
|---|---|
| [`Player/Parrying.cs`](Scripts/Player/Parrying.cs) | 패링 판정(`TryParry`), 패링 모드 연출(흑백 포스트 프로세싱 + `timeScale` 0.3), 이후 강공격 / 캐릭터 교체 분기 |
| [`Enemy/Enemy.cs`](Scripts/Enemy/Enemy.cs) | `Jigumini()` — 적 공격 모션의 애니메이션 이벤트로, 패링 가능 구간(`CanParry`)을 엽니다. 그로기 게이지와 그로기 중 150% 대미지 배율 |
| [`Player/StateMachine/DashState.cs`](Scripts/Player/StateMachine/DashState.cs) | 대시 애니메이션 진입 순간 패링 판정을 호출하는 Animator `StateMachineBehaviour` |
| [`Player/TeamManager.cs`](Scripts/Player/TeamManager.cs) | 3인 캐릭터 교체, 리더 기준 로컬 오프셋으로 파티 포메이션을 저장하고 이동 |
| [`Player/Character/Character.cs`](Scripts/Player/Character/Character.cs) | `IDamageable` 구현(방어력 공식), 교체되어 비활성화될 때 정령 폼(`fairyForm`) 생성 |
| [`Enemy/StateMachine/EnemyHitState.cs`](Scripts/Enemy/StateMachine/EnemyHitState.cs) | 피격 중 적이 이동하던 버그 수정 — 히트 상태 동안 `NavMeshAgent` 비활성화 |

패링 흐름은 `Enemy.Jigumini()`(구간 열림) → `DashState`(회피 입력) → `Parrying.TryParry()`(판정·연출) 순서로 따라가면 됩니다.

## 이 리포에 대해

전체 팀 Unity 프로젝트에서, git 커밋 기록을 기준으로 **내가 작성한 C# 스크립트만 추출**한 리포입니다 — 담당했던 전투 시스템과 캐릭터 스킬 파트입니다.

전체 프로젝트(유료 Unity 에셋 스토어 패키지 포함)는 private 리포에 있습니다. 이 리포에는 그 에셋들과, 다른 시스템을 담당한 팀원의 스크립트(적 AI/비헤이비어 그래프, 환경 아트 툴링 등)는 제외했습니다.

- `Scripts/Player/` — 플레이어 컨트롤러, 전투/패링, 공격·대시 상태머신, 3인 캐릭터 스위칭(딜러/힐러/탱커), 캐릭터 스킬
- `Scripts/Enemy/` — 관여했던 적 기본 데이터 및 피격 반응 상태 스크립트
- `Scripts/Sound/`, `Scripts/UI/`, `Scripts/Util/`, `Scripts/Game/` — 관여했던 보조 스크립트(SFX 트리거, 퍼즈 UI, 싱글톤, 데미지 인터페이스)

## 팀 구성 & 담당 역할

- 팀 인원: 6명
- 담당: **전투 시스템 설계 및 개발, 캐릭터 스킬 설계 및 구현**

이 리포는 그대로는 Unity에서 열리거나 빌드되지 않습니다(씬, 프리팹, 서드파티 에셋이 빠져 있음).
