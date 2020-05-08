using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform spawnPoint;

    private Queue<GameObject> pool = new Queue<GameObject>();

    public GameObject Take()
    {
        GameObject takenObject;

        if (pool.Count == 0)
        {
            takenObject = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation, this.transform);
        }
        else
        {
            takenObject = pool.Dequeue();
            takenObject.gameObject.SetActive(true);
            takenObject.transform.position = spawnPoint.position;
            takenObject.transform.rotation = spawnPoint.rotation;
        }

        return takenObject;
    }

    public void Return(GameObject objectToReturn)
    {
        pool.Enqueue(objectToReturn);
        objectToReturn.gameObject.SetActive(false);
    }
}