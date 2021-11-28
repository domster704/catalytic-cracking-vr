using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUI : MonoBehaviour
{

    public GameObject info;
    public GameObject player;
    public GameObject punktir;

    private float someVar = 0.25f;
    
    void Start() {
        // player = GameObject.Find("Camera");

        float upPoint = GetComponent<BoxCollider>().size.y + someVar;
        Vector3 position = transform.position + new Vector3(0, upPoint, 0);

        for (float i = upPoint - someVar * 2 - 0.1f; i <= upPoint; i += 0.05f) {
            Vector3 punktirCoord = transform.position + new Vector3(0, i, 0);
            Instantiate(punktir, punktirCoord, Quaternion.identity);
        }

        Instantiate(info, position, Quaternion.identity);
        
    }

    private void Update() {
        if (player != null) {
            info.transform.LookAt(player.transform, Vector3.left);
            // info.transform.rotation *= Quaternion.FromToRotation(Vector3.left, Vector3.forward);
            // info.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(transform.position),
            //     1 * Time.deltaTime);
        }
    }
}
