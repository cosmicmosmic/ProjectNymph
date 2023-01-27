using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool
{
    public Stack<GameObject> stack = new Stack<GameObject>();
    public Transform trRoot;
}

public class ObjectPool : GameObjectSingleton<ObjectPool>
{
    private Dictionary<GameObject, Pool> dicPools = new Dictionary<GameObject, Pool>();

    public void ClearPool()
    {
        //신 이동 시 클리어
    }

    public GameObject Spawn(GameObject _prefab, Transform _parent)
    {
        if (dicPools.ContainsKey(_prefab))
        {
            var pool = dicPools[_prefab];
            GameObject go;
            if (pool.stack.Count == 0)
            {
                go = Instantiate(_prefab);
            }
            else
            {
                go = pool.stack.Pop();
            }

            go.transform.SetParent(_parent);
            go.transform.localScale = Vector3.one;
            go.SetActive(true);
            return go;
        }
        else
        {
            var pool = new Pool();
            var goRoot = new GameObject(_prefab.name);
            var trRoot = goRoot.transform;
            trRoot.SetParent(transform);
            trRoot.position = Vector3.zero;
            trRoot.localScale = Vector3.one;
            pool.trRoot = trRoot;

            dicPools.Add(_prefab, pool);

            return Spawn(_prefab, _parent);
        }
    }

    public void Despawn(GameObject _prefab, GameObject _go)
    {
        if (dicPools.ContainsKey(_prefab))
        {
            var pool = dicPools[_prefab];
            _go.transform.SetParent(pool.trRoot);
            _go.transform.position = new Vector3(9999f, 9999f, 9999f);
            pool.stack.Push(_go);
            _go.SetActive(false);
        }
        else
        {
            Debug.LogError("ObjectPool Despawn Error : " + _prefab.name);
            Destroy(_go);
        }
    }
}
