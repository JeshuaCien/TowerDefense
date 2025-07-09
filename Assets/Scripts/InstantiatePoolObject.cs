using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class InstantiatePoolObject : MonoBehaviour
{
    [SerializeField]

    private GameObject _prefab;

    private List<GameObject> _pool = new List<GameObject>();

    public void InstantiateListObject(Transform target)
    {
        GameObject obj = GetPooledObject();
        if (obj != null)
        {
            obj.transform.position = target.position;
            obj.transform.rotation = target.rotation;
            obj.SetActive(true);
        }
    }

    private GameObject GetPooledObject()
    {
        GameObject obj = null;
        obj = _pool.Find(x => !x.activeInHierarchy);
        if (obj == null)
        {
            obj = Instantiate(_prefab);
            _pool.Add(obj);
            obj.SetActive(false);
        }
        return obj;
    }
}
