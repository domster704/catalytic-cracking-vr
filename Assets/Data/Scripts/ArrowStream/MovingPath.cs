using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPath : MonoBehaviour {
    public enum PathTypes {
        linear,
        loop
    }

    public PathTypes PathType;
    public int movementDirection = 1;
    public int movingTo = 0;

    public Transform[] points;

    private void OnDrawGizmos() {
        if (points == null || points.Length < 2) {
            return;
        }

        for (var i = 1; i < points.Length; i++) {
            Gizmos.DrawLine(points[i - 1].position, points[i].position);
        }

        if (PathType == PathTypes.loop) {
            Gizmos.DrawLine(points[0].position, points[points.Length - 1].position);
        }
    }

    public IEnumerator<Transform> GetNextPAthPoint() {
        if (points == null || points.Length < 1) {
            yield break;
        }

        while (true) {
            yield return points[movingTo];
            if (points.Length == 1) continue;

            if (PathType == PathTypes.linear) {
                if (movingTo <= 0) {
                    movementDirection = 1;
                }
                if (movingTo >= points.Length - 1) {
                    movingTo = 0;
                    yield return transform.parent.Find("EndStream").transform;
                }
            }

            if (PathType == PathTypes.loop) {
                if (movingTo >= points.Length) {
                    movingTo = 0;
                }
                else if (movingTo < 0) {
                    movingTo = points.Length - 1;
                }
            }
            
            movingTo += movementDirection;
        }
    }
}