using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private Transform _plPosition;
    private Transform PlayerPosition
    {
        get => _plPosition;
    }

    private Transform _instanPosition;
    private Transform InstanPosition
    {
        get => _instanPosition;
    }

    public GameObject NormalenemyPrefab;
    public GameObject FastenemyPrefab;
    public GameObject BigenemyPrefab;

    public int PortalHealth = 30;

    public bool SpawnerDie = false;
    public bool SpawnerCanDie = false;

    public bool IsLevel1 = false;
    public bool IsLevel2 = false;
    public bool IsLevel3 = false;
    public bool IsLevel4 = false;

    public float delayTime = 10f;

    public UnityEvent PortalDie;

    public GameObject[] a;

    private void Awake()
    {
        _instanPosition = transform.Find("InstanPosition").GetComponent<Transform>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _plPosition = GameManager.Instance.PlayerPosition;
    }

    private void Update()
    {
        CalDistanceToLevel();
    }

    private void CalDistanceToLevel()
    {
        float distance = Vector2.Distance(_instanPosition.position, _plPosition.position);

        if(distance > 50 && IsLevel1 == false && SpawnerDie == false)
        {
            delayTime += 5;
            IsLevel1 = true;
            if(IsLevel1)
            {
                StartCoroutine(Level1());
                StopCoroutine(Level2());
                StopCoroutine(Level3());
                StopCoroutine(Level4());
            }
        }
        else if(distance < 50 && distance > 37 && IsLevel2 == false && SpawnerDie == false)
        {
            StopCoroutine(Level1());
            delayTime = 10f;
            delayTime += 7f;
            IsLevel2 = true;
            if(IsLevel2 == true)
            {
                StartCoroutine(Level2());
                StopCoroutine(Level1());
                StopCoroutine(Level3());
                StopCoroutine(Level4());
            }
        }
        else if(distance < 36 && distance > 21 && IsLevel3 == false && SpawnerDie == false)
        {
            StopCoroutine(Level2());
            delayTime = 10f;
            delayTime += 10f;
            IsLevel3 = true;
            if (IsLevel3 == true)
            {
                StartCoroutine(Level3());
                StopCoroutine(Level1());
                StopCoroutine(Level2());
                StopCoroutine(Level4());
            }
        }
        else if (distance < 20 && IsLevel4 == false && SpawnerDie == false)
        {
            SpawnerCanDie = true;
            StopCoroutine(Level3());
            delayTime = 10f;
            delayTime += 15f;
            IsLevel4 = true;
            if (IsLevel4 == true)
            {
                StartCoroutine(Level4());
                StopCoroutine(Level1());
                StopCoroutine(Level2());
                StopCoroutine(Level3());
            }
        }
    }

    IEnumerator Level1()
    {
        // 10, 5, 2
        for (int i = 0; i < 1; i++)
        {
            for (int k = 0; k < 8; k++)
            {
                // Instantiate(FastenemyPrefab, InstanPosition.position, Quaternion.identity); // ???????? ????
                Enemy enemy = PoolManager.Instance.Pop(FastenemyPrefab.name) as Enemy;
                enemy.transform.SetPositionAndRotation(InstanPosition.position, Quaternion.identity);
                yield return new WaitForSeconds(0.8f);
            }
            for (int j = 0; j < 3; j++)
            {
                // Instantiate(NormalenemyPrefab, InstanPosition.position, Quaternion.identity); // ???????? ????
                Enemy enemy = PoolManager.Instance.Pop(NormalenemyPrefab.name) as Enemy;
                enemy.transform.SetPositionAndRotation(InstanPosition.position, Quaternion.identity);
                yield return new WaitForSeconds(0.8f);
            }
            for (int l = 0; l < 1; l++)
            {
                // Instantiate(BigenemyPrefab, InstanPosition.position, Quaternion.identity); // ???????? ????
                Enemy enemy = PoolManager.Instance.Pop(BigenemyPrefab.name) as Enemy;
                enemy.transform.SetPositionAndRotation(InstanPosition.position, Quaternion.identity);
                yield return new WaitForSeconds(0.8f);
            }
        }
        yield return new WaitForSeconds(delayTime);
        IsLevel1 = false;
    }

    IEnumerator Level2()
    {
        // 15, 10, 2
        yield return new WaitForSeconds(10f);
        for (int i = 0; i < 1; i++)
        {
            for (int k = 0; k < 10; k++)
            {
                // Instantiate(FastenemyPrefab, InstanPosition.position, Quaternion.identity); // ???????? ????
                Enemy enemy = PoolManager.Instance.Pop(FastenemyPrefab.name) as Enemy;
                enemy.transform.SetPositionAndRotation(InstanPosition.position, Quaternion.identity);
                yield return new WaitForSeconds(0.76f);
            }
            for (int j = 0; j < 4; j++)
            {
                // Instantiate(NormalenemyPrefab, InstanPosition.position, Quaternion.identity); // ???????? ????
                Enemy enemy = PoolManager.Instance.Pop(NormalenemyPrefab.name) as Enemy;
                enemy.transform.SetPositionAndRotation(InstanPosition.position, Quaternion.identity);
                yield return new WaitForSeconds(0.76f);
            }
            for (int l = 0; l < 1; l++)
            {
                // Instantiate(BigenemyPrefab, InstanPosition.position, Quaternion.identity); // ???????? ????
                Enemy enemy = PoolManager.Instance.Pop(BigenemyPrefab.name) as Enemy;
                enemy.transform.SetPositionAndRotation(InstanPosition.position, Quaternion.identity);
                yield return new WaitForSeconds(0.76f);
            }
        }
        yield return new WaitForSeconds(delayTime);
        IsLevel2 = false;
    }

    IEnumerator Level3()
    {
        // 20, 15, 3
        yield return new WaitForSeconds(10f);
        for (int i = 0; i < 1; i++)
        {
            for (int k = 0; k < 12; k++)
            {
                // Instantiate(FastenemyPrefab, InstanPosition.position, Quaternion.identity); // ???????? ????
                Enemy enemy = PoolManager.Instance.Pop(FastenemyPrefab.name) as Enemy;
                enemy.transform.SetPositionAndRotation(InstanPosition.position, Quaternion.identity);
                yield return new WaitForSeconds(0.72f);
            }
            for (int j = 0; j < 6; j++)
            {
                // Instantiate(NormalenemyPrefab, InstanPosition.position, Quaternion.identity); // ???????? ????
                Enemy enemy = PoolManager.Instance.Pop(NormalenemyPrefab.name) as Enemy;
                enemy.transform.SetPositionAndRotation(InstanPosition.position, Quaternion.identity);
                yield return new WaitForSeconds(0.72f);
            }
            for (int l = 0; l < 2; l++)
            {
                // Instantiate(BigenemyPrefab, InstanPosition.position, Quaternion.identity); // ???????? ????
                Enemy enemy = PoolManager.Instance.Pop(BigenemyPrefab.name) as Enemy;
                enemy.transform.SetPositionAndRotation(InstanPosition.position, Quaternion.identity);
                yield return new WaitForSeconds(0.72f);
            }
        }
        yield return new WaitForSeconds(delayTime);
        IsLevel3 = false;
    }

    IEnumerator Level4()
    {
        // 30, 18, 4
        yield return new WaitForSeconds(10f);
        for (int i = 0; i < 1; i++)
        {
            for (int k = 0; k < 14; k++)
            {
                // Instantiate(FastenemyPrefab, InstanPosition.position, Quaternion.identity); // ???????? ????
                Enemy enemy = PoolManager.Instance.Pop(FastenemyPrefab.name) as Enemy;
                enemy.transform.SetPositionAndRotation(InstanPosition.position, Quaternion.identity);
                yield return new WaitForSeconds(0.7f);
            }
            for (int j = 0; j < 8; j++)
            {
                // Instantiate(NormalenemyPrefab, InstanPosition.position, Quaternion.identity); // ???????? ????
                Enemy enemy = PoolManager.Instance.Pop(NormalenemyPrefab.name) as Enemy;
                enemy.transform.SetPositionAndRotation(InstanPosition.position, Quaternion.identity);
                yield return new WaitForSeconds(0.7f);
            }
            for (int l = 0; l < 2; l++)
            {
                // Instantiate(BigenemyPrefab, InstanPosition.position, Quaternion.identity); // ???????? ????
                Enemy enemy = PoolManager.Instance.Pop(BigenemyPrefab.name) as Enemy;
                enemy.transform.SetPositionAndRotation(InstanPosition.position, Quaternion.identity);
                yield return new WaitForSeconds(0.7f);
            }
        }
        yield return new WaitForSeconds(delayTime);
        IsLevel4 = false;
    }

    public void GetHit()
    {
        _spriteRenderer.color = Color.black;
        StartCoroutine(ColorReset());
    }

    IEnumerator ColorReset()
    {
        yield return new WaitForSeconds(0.07f);
        _spriteRenderer.color = Color.red;
    }

    public void SpawnerDieToEnemyDie()
    {
        a = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = 0; i < a.Length; i++)
        {
            a[i].GetComponent<Enemy>().OnEnemyDie();
        }
    }
}
