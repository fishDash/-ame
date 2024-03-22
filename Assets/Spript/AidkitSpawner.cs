using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AidkitSpawner : MonoBehaviour
{
    public Aidkit aidkitPrefab;
    public float dealeyMin = 3;
    public float dealeyMax = 9;

    public List<Transform> _spawnerPoint;

    private Aidkit _aidkit;

    private void Start()
    {
        _spawnerPoint = new List<Transform>(transform.GetComponentsInChildren<Transform>());
    }

    private void Update()
    {
        if (_aidkit != null)
        {
            return;
        }

        if (IsInvoking())
        {
            return;
        }

        Invoke("CreateAidkit", Random.Range(dealeyMin, dealeyMax));
    }

    private void CreateAidkit()
    {
        _aidkit = Instantiate(aidkitPrefab);
        _aidkit.transform.position = _spawnerPoint[Random.Range(0, _spawnerPoint.Count)].position;
    }
}
