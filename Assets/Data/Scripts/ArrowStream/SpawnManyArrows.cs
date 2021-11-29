using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManyArrows : MonoBehaviour {
    public Transform Liquid;
    public int count = 3;
    public float defaultDelay = 1;

    private void Start() {
        Liquid = transform.Find("Liquid");
        for (int i = 0; i < count; i++) {
            Transform newLiqiud = Liquid;
            newLiqiud.transform.Find("Arrow").GetComponent<FollowPath>().delay = (1 + i) * defaultDelay;
            Instantiate(newLiqiud, transform);
        }
    }
}