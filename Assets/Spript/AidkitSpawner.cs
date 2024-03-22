using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AidkitSpawner : MonoBehaviour
{
    public Aidkit aidkitPrefab;
    public float dealeyMin = 3;
    public float dealeyMax = 9;

    private Aidkit _aidkit;

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
        _aidkit.tranform.position = tranform.position;
    }
}
