using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TableData : MonoBehaviour {
    public List<Transform> buildings;
    public Vector3 startPos;
    
    public GameObject chosenBuilding;
    public Vector3[] chosenBuildingData = new Vector3[2];

    private void Start() {
        startPos = transform.position;
        for (int i = 0; i < transform.childCount; i++) {
            if (transform.GetChild(i).name == gameObject.name) continue;
            buildings.Add(transform.GetChild(i));
        }
    }
}