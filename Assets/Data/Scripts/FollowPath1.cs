using System.Collections.Generic;
using UnityEngine;

public class FollowPath1 : MonoBehaviour {
    public enum MovementType {
        moving,
        jerk
    }

    public class ArrowData {
        public Transform transform;
        public MovementType Type = MovementType.moving;
        public MovingPath myPath;
        public IEnumerator<Transform> pointInPath;

        public ArrowData(Transform transform, MovingPath MyPath) {
            this.transform = transform;
            this.myPath = MyPath;
        }
    }

    public MovementType Type = MovementType.moving;
    public MovingPath MyPath;
    public float speed = 1;
    public float distanceToPoint = .1f;

    public int arrowCount = 5;
    private List<ArrowData> arrowsList = new List<ArrowData>();
    private float defaultDelay = 1;

    private IEnumerator<Transform> pointInPath;

    public void Start() {
        if (MyPath == null) {
            return;
        }

        for (int i = 0; i < arrowCount; i++) {
            arrowsList.Add(new ArrowData(transform, MyPath));
            arrowsList[i].pointInPath = arrowsList[i].myPath.GetNextPAthPoint();
            arrowsList[i].pointInPath.MoveNext();

            if (arrowsList[i].pointInPath.Current == null) {
                continue;
            }

            arrowsList[i].transform.position = arrowsList[i].pointInPath.Current.position;
        }
        // pointInPath = MyPath.GetNextPAthPoint();
        // pointInPath.MoveNext();
        // if (pointInPath.Current == null) {
        //     return;
        // }
        //
        // transform.position = pointInPath.Current.position;
    }

    public void Update() {
        if (MyPath == null) return;

        for (int i = 0; i < arrowCount; i++) {
            ArrowData arrow = arrowsList[i];
            if (arrow.pointInPath == null || arrow.pointInPath.Current == null) {
                return;
            }

            if (arrow.Type == MovementType.moving) {
                arrow.transform.position =
                    Vector3.MoveTowards(arrow.transform.position, arrow.pointInPath.Current.position,
                        Time.deltaTime * speed);

                arrow.transform.LookAt(arrow.pointInPath.Current);
            }
            else if (Type == MovementType.jerk) {
                arrow.transform.position = Vector3.Lerp(arrow.transform.position, arrow.pointInPath.Current.position,
                    Time.deltaTime * speed);
                arrow.transform.LookAt(arrow.pointInPath.Current);
            }

            float distanceSquare = (arrow.transform.position - arrow.pointInPath.Current.position).sqrMagnitude;
            if (distanceSquare < distanceToPoint * distanceToPoint) {
                arrow.pointInPath.MoveNext();
            }

            StartCoroutine(Wait(defaultDelay));
        }
    }

    private IEnumerator<WaitForSeconds> Wait(float delay) {
        yield return new WaitForSeconds(delay);
    }
}