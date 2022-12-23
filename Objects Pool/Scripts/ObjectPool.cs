using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    private List<Enemy> _enemies = new();

    private void Start()
    {
        StartCoroutine(Instantiate());
    }

    private IEnumerator Instantiate()
    {
        int enemyCount = 5;
        while (true)
        {
            for(int i = 0; i < enemyCount; i++)
            {
                Enemy enemyPool = GetPooledObject();
                if(enemyPool is null)
                {
                    Enemy enemy = Instantiate(_enemy, new Vector3(Random.Range(0f, 20f), 0, Random.Range(0f, 20f)), Quaternion.identity);
                    _enemies.Add(enemy);
                    enemy.Initialize($"Enemy {_enemies.Count}");
                }
                else
                {
                    enemyPool.Revival();
                    enemyPool.ChangeName($"Enemy pooled");
                }
            }

            yield return new WaitForSeconds(2f);

            foreach(Enemy enemy in _enemies)
            {
                enemy.Death();
            }

            enemyCount += 5;
        }
    }

    private Enemy GetPooledObject()
    {
        for (int i = 0; i < _enemies.Count; i++)
        {
            if (!_enemies[i].gameObject.activeSelf)
            {
                return _enemies[i];
            }
        }

        return null;
    }
}
