using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Unit : MonoBehaviour
{
    [Header("is Allies?")]
    [SerializeField] private bool myUnit = true;

    [Header("Links")]
    [SerializeField] private UnitsStatistic _unit;
    [SerializeField] private Unit _tempTarget;
    [SerializeField] private Unit _trash;
    [SerializeField] private Money _money;
    [SerializeField] private UpgradeProperties _upgradeProperties;
    [SerializeField] private GameObject _win;
    [SerializeField] private GameObject _lose;

    [Header("Variables")]
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask layerMask;
    public float hp;
    [SerializeField] private float hpAdditionalEnemyTrash;
    private RaycastHit2D[] hits;
    private string _tagEnemy;
    private string _tagTrash;
    private bool canDamage = true;

    private void Start()
    {
        _tempTarget = _trash;
        hp = _unit.HP;

        //костиль ахахах
        if (myUnit)
        {
            _tagEnemy = "Enemy";
            _tagTrash = "EnemyTrash";
        }
        if (!myUnit)
        {
            _tagEnemy = "Unit";
            _tagTrash = "MyTrash";
        }

        if(gameObject.CompareTag("MyTrash"))
        {
            hp += _upgradeProperties.HpTrash;
        }
        if (gameObject.CompareTag("EnemyTrash"))
        {
            hp += hpAdditionalEnemyTrash;
        }
    }
    public void OnCreate(Unit enemyTrash, Money money)
    {
        _trash = enemyTrash;
        _money = money;
    }
    void Moving()
    {
        if (canDamage && _tempTarget)
        {
            Vector3 currentPosition = transform.position;
            Vector3 targetPosition = _tempTarget.transform.position;
            Vector3 newPosition = Vector3.MoveTowards(currentPosition, new Vector3(targetPosition.x, targetPosition.y, currentPosition.z), _unit.Speed * Time.deltaTime);
            transform.position = newPosition;
        }
    }

    private void Update()
    {
        if (_tempTarget == null)
            _tempTarget = _trash;

        Moving();
        SearchEnemy();
        Death();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (_tempTarget != null && canDamage)
        {
            if (collision.gameObject.CompareTag(_tagEnemy))
                StartCoroutine(DamagingEnemy());

            if (collision.gameObject.CompareTag(_tagTrash))
                StartCoroutine(DamagingTrash());
        }
    }
    IEnumerator DamagingEnemy()
    {
        canDamage = false;
        yield return new WaitForSeconds(_unit.AttackSpeed);
        if (_tempTarget != _trash)
            Damaging();

        canDamage = true;
    }
    IEnumerator DamagingTrash()
    {
        canDamage = false;
        yield return new WaitForSeconds(_unit.AttackSpeed);
        if (_tempTarget == _trash)
            Damaging();

        canDamage = true;
    }

    void Damaging()
    {
        float enemyHP = _tempTarget.hp;
        enemyHP -= _unit.Damage;
        _tempTarget.hp = enemyHP;
    }

    private void SearchEnemy()
    {
        hits = Physics2D.CircleCastAll(transform.position, _radius, Vector2.zero, 0f, layerMask);
        if (hits.Length <= 0)
        {
            canDamage = true;
            _tempTarget = _trash;
        }

        float closestDistance = Mathf.Infinity;

        foreach (RaycastHit2D hit in hits)
        {
            Unit hitUnit = hit.collider.gameObject.GetComponent<Unit>();

            if (hitUnit.CompareTag(_tagEnemy) && hitUnit)
            {
                float distance = Vector2.Distance(hitUnit.transform.position, transform.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    _tempTarget = hitUnit;
                }
            }
        }
    }

    public void Death()
    {
        if (hp <= 0)
        {
            if(!myUnit)
            {
                _money.RewardMoney(_unit.Reward);
            }

            if (gameObject.CompareTag("MyTrash"))
            {
                _lose.SetActive(true);
            }
            if (gameObject.CompareTag("EnemyTrash"))
            {
                _win.SetActive(true);
                _upgradeProperties.Lvl = SceneManager.GetActiveScene().buildIndex + 1;
            }

            Destroy(gameObject);
        }
    }

    public UnitsStatistic UnitStat
    {
        get { return _unit; }
    }
}
