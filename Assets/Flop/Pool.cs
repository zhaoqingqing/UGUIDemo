using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pool : Singleton<Pool>
{
	public int Count = 7;
	public bool Grow = false;
	public GameObject Prefab;
	private List<GameObject> _pool;
	private void Awake()
	{
		_pool = new List<GameObject>(Count);
		for (int i = 0; i < Count; i++)
		{
			_pool.Add(New());
		}
	}
	private GameObject New()
	{
		GameObject o = Instantiate(Prefab) as GameObject;
		o.transform.parent = gameObject.transform;
		o.transform.position = Vector3.zero;
		o.SetActive(false);
		return o;
	}
	public GameObject Enter()
	{
		for (int i = 0; i < _pool.Count; i++)
		{
			if (!_pool[i].activeInHierarchy)
			{
				return _pool[i];
			}
			if (Grow)
			{
				_pool.Add(New());
			}
		}
		return null;
	}
	public void Exit(GameObject o)
	{
		o.SetActive(false);
	}
}
