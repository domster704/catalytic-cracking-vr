using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour {
    public enum MovementType {
        moving,
        jerk
    }

    public MovementType Type = MovementType.moving;
    public MovingPath MyPath;
    public float speed = 3;
    public float distanceToPoint = .1f;

    private IEnumerator<Transform> pointInPath;
    public float delay = 0;

    public void Start() {
        if (MyPath == null) {
            return;
        }

        StartCoroutine(Wait());
    }

    private IEnumerator<WaitForSeconds> Wait() {
        yield return new WaitForSeconds(delay);
        InitPath();
    }

    private void InitPath() {
        MyPath.movingTo = 0;
        pointInPath = MyPath.GetNextPAthPoint();
        pointInPath.MoveNext();
        if (pointInPath.Current == null) {
            return;
        }

        transform.position = pointInPath.Current.position;
    }
    
    public void Update() {
        if (pointInPath == null || pointInPath.Current == null) {
            return;
        }

        if (pointInPath.Current.Equals(transform.parent.Find("EndStream").transform)) {
            InitPath();
        }

        if (Type == MovementType.moving) {
            transform.LookAt(pointInPath.Current);
            transform.position =
                Vector3.MoveTowards(transform.position, pointInPath.Current.position, Time.deltaTime * speed);
        }
        else if (Type == MovementType.jerk) {
            transform.LookAt(pointInPath.Current);
            transform.position = Vector3.Lerp(transform.position, pointInPath.Current.position, Time.deltaTime * speed);
        }

        float distanceSquare = (transform.position - pointInPath.Current.position).sqrMagnitude;
        if (distanceSquare < distanceToPoint * distanceToPoint) {
            pointInPath.MoveNext();
        }
    }
}