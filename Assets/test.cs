using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class test : MonoBehaviour {
    public LinearDrive circleDrive;

    private void Start() {
        circleDrive = GetComponent<LinearDrive>();
    }

    private void Update() {
        
        Debug.Log(circleDrive.momemtumDampenRate);
    }
}
