using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class TableData : MonoBehaviour {
    public List<Transform> buildings;
    public Vector3 startPos;

    public GameObject chosenBuilding;
    public Vector3[] chosenBuildingData = new Vector3[2];
    public Quaternion startRotation;
    public bool flag;
    public Transform tableWithModels;

    private void Start() {
        startPos = transform.position;
        startRotation = transform.rotation;

        tableWithModels = transform.Find("[Table Elements]");
        for (int i = 0; i < tableWithModels.childCount; i++) {
            if (tableWithModels.GetChild(i).name == gameObject.name) continue;
            buildings.Add(tableWithModels.GetChild(i));
        }
    }

    public void SetFlag(Transform transform, bool flag) {
        // GetComponent<MeshRenderer>().enabled = flag;
        // GetComponent<BoxCollider>().enabled = flag;
        // GetComponent<Interactable>().enabled = flag;
        gameObject.SetActive(flag);

        // for (int i = 0; i < buildings.Count; i++) {
        //     if (transform != null && buildings[i].name == transform.name) continue;
        //
        //     // TODO: change BoxCollider to MeshCollider
        //     buildings[i].gameObject.SetActive(flag);
        // }
    }
}