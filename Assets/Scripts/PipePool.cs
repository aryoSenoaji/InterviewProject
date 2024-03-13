using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePool : MonoBehaviour
{
    public static PipePool Instance;

    public GameObject prefab;
    public int poolSize = 5;

    private List<GameObject> pool = new List<GameObject>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        for (int i = 0; i < poolSize; i++)
        {
            GameObject pipe = Instantiate(prefab, transform.position, Quaternion.identity);
            pipe.SetActive(false);
            pool.Add(pipe);
        }
    }

    public GameObject GetFromPool()
    {
        foreach (GameObject pipe in pool)
        {
            if (!pipe.activeInHierarchy)
            {
                pipe.SetActive(true);
                return pipe;
            }
        }

        GameObject newPipe = Instantiate(prefab, transform.position, Quaternion.identity);
        pool.Add(newPipe);
        return newPipe;
    }

    public void ReturnToPool(GameObject pipe)
    {
        pipe.SetActive(false);
    }
}
