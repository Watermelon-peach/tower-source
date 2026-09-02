using UnityEngine;
using UnityEngine.SceneManagement;
using Tower.Game;
using Tower.Player.Data;
using Tower.UI;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Tower.Player
{
    public class Character : MonoBehaviour, IDamageable
    {
        #region Variables
        public CharacterBaseSO characterBase;
        public GameObject fairyForm;

        private GameObject fgo;

        private float currentHP;
        private float maxHP;
        private float currentMP;
        private float maxMP;

        private PlayerController p_controller;
        protected Animator animator;

        private Parrying parrying;

        [Header("강공")]
        [SerializeField] protected float strongAtackMultiplier;
        [SerializeField] protected LayerMask enemyLayer;
        [SerializeField] protected float range;
        [SerializeField] protected ParticleSystem strongAtkVfx;
        #endregion

        #region Property
        public bool IsDead => currentHP <= 0;
        public float Atk => characterBase.atk;
        public float AtkBuff { get; set; } = 1f;
        public float CurrentHP => currentHP;
        public float CurrentMP => currentMP;
        #endregion

        #region Unity Event Method
        protected virtual void Awake()
        {
            //참조
            animator = GetComponent<Animator>();
            p_controller = GetComponent<PlayerController>();
            parrying = GetComponent<Parrying>();
            UpdateStats();
            //초기화
            currentHP = maxHP;
            currentMP = maxMP;
        }

        private void OnEnable()
        {
            if (fgo != null)
            {
                Destroy(fgo);
            }
            p_controller.enabled = true;
            parrying.IsParrying = false;
        }

        private void OnDisable()
        {
#if UNITY_EDITOR
            if (!EditorApplication.isPlaying || !EditorApplication.isPlayingOrWillChangePlaymode)
                return;
#endif

            // 씬 언로드 중이거나 이 오브젝트가 속한 씬이 이미 로드되지 않았다면 Fairy 생성 X
            if (!Application.isPlaying || !gameObject.scene.isLoaded)
                return;

            if (!IsDead)
                fgo = Instantiate(fairyForm, new Vector3(transform.position.x, 2f, transform.position.z), Quaternion.identity);
        }

        private void OnDestroy()
        {
            //버그 방지
            if (fgo != null)
            {
                Destroy(fgo);
            }
        }
        #endregion

        #region Custom Method

        #region HP
        public void TakeDamage(float damage, int groggyAmount = 0)
        {
            if (parrying.IsParrying || !gameObject.activeSelf || animator.GetBool(AnimHash.isParrying))
                return;

            if (IsDead)
            {
                PlayerStatsInfo.Instance.UpdateCurrentHPInfo();
                return;
            }

            animator.SetTrigger(AnimHash.hit);

            damage = Mathf.Max(damage * (100f / (100f + characterBase.def)), 1f);
            currentHP = Mathf.Max(currentHP - damage, 0);
            PlayerStatsInfo.Instance.UpdateCurrentHPInfo();

            if (IsDead)
            {
                Die();
            }
        }

        public void Heal(float amount)
        {
            if (IsDead) return;

            currentHP = Mathf.Min(currentHP + amount, maxHP);
            PlayerStatsInfo.Instance.UpdateCurrentHPInfo();
        }
        #endregion

        #region MP
        public bool UseMana(float amount)
        {
            if (currentMP < amount)
                return false;

            currentMP -= amount;
            return true;
        }

        public void ManaRecover(float amount)
        {
            if (IsDead) return;
            currentMP = Mathf.Min(currentMP + amount, maxMP);
        }
        #endregion

        public void Revibe()
        {
            currentHP = maxHP;
            currentMP = maxMP;

            animator.SetBool(AnimHash.isDead, false);

            PlayerStatsInfo.Instance.SwitchCharatersInfo();
        }

        public virtual void OnStrongAttack() { }

        public virtual void SwitchCombo()
        {
            TeamManager.Instance.SwitchComboSignal = false;
        }

        private void Die()
        {
            Debug.Log("사망");
            animator.SetBool(AnimHash.isDead, true);
            currentMP = 0f;
            PlayerStatsInfo.Instance.UpdateCurrentHPInfo();
            StartCoroutine(AfterDeath());
        }

        private IEnumerator AfterDeath()
        {
            float timer = 0;
            while (timer < 3f)
            {
                if (!gameObject.activeSelf)
                    yield break;

                timer += Time.deltaTime;
                yield return null;
            }

            TeamManager.Instance.SwitchToNextCharacter();
        }

        public int GetHPForUI()
        {
            return Mathf.CeilToInt(currentHP);
        }

        public void UpdateStats()
        {
            maxHP = characterBase.maxHp;
            maxMP = characterBase.maxMp;
        }
        #endregion
    }
}
