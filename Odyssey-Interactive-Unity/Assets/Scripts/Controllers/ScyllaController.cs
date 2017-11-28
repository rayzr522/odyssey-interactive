using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScyllaController : MonoBehaviour {
    public enum State {
        IDLE, ATTACKING, RETRACTING
    }

    public float verticalBounds = 4f;
    public float speed = 3f;
    public float neckMovementSpeed = 3f;

    public GameObject neckPivot;
    public GameObject neck;
    public GameObject head;

    public State state { get; private set; }

    private Vector3 target;

    private float time = 0f;
    private float neckLength = 0f;

    // Use this for initialization
    void Start() {
        state = State.IDLE;
    }

    void CycleState() {
        if (state == State.IDLE) {
            state = State.ATTACKING;
            target = GameController.instance.playerController.transform.position;
        } else if (state == State.ATTACKING) {
            state = State.RETRACTING;
        } else {
            state = State.IDLE;
        }
    }

    void ResizeNeck(float units) {
        Vector3 neckScale = neck.transform.localScale;
        neckScale.x = units / 0.6f;
        neck.transform.localScale = neckScale;

        Vector3 neckPos = neck.transform.localPosition;
        neckPos.x = units * -0.5f;
        neck.transform.localPosition = neckPos;

        Vector3 headPos = head.transform.localPosition;
        headPos.x = -units - 0.3f;
        head.transform.localPosition = headPos;
    }

    void RotateNeck(Vector2 dir) {
        neckPivot.transform.rotation = Quaternion.Euler(0f, 0f, -Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg - 90f);
    }

    // Update is called once per frame
    void Update() {
        if (GameController.instance.state != GameController.State.PLAYING) {
            return;
        }

        time += Time.deltaTime;
        if (time > 1f) {
            time = 0f;
            CycleState();
        }

        if (state == State.IDLE) {
            RotateNeck(Vector2.left);
            MoveBase();
        } else if (state == State.ATTACKING) {
            // Uncomment for a very difficult to avoid AI:
            // target = GameController.instance.playerController.transform.position;
            Vector2 distance = target - transform.position;
            RotateNeck(distance);

            if (distance.magnitude - neckLength > 0.1f) {
                neckLength += Time.deltaTime * neckMovementSpeed;
                ResizeNeck(neckLength);
            }
        } else if (state == State.RETRACTING) {
            if (neckLength > 0f) {
                neckLength -= Time.deltaTime * neckMovementSpeed;
                if (neckLength < 0f) {
                    neckLength = 0f;
                }
                ResizeNeck(neckLength);
            }
        }
    }

    private void MoveBase() {
        Vector2 pos = transform.position.to2D();
        float y = pos.y;

        y += Time.deltaTime * speed;
        if (speed > 0f && y >= verticalBounds) {
            y = verticalBounds;
            speed *= -1;
        } else if (speed < 0f && y <= -verticalBounds) {
            y = -verticalBounds;
            speed *= -1;
        }

        pos.y = y;
        transform.position = pos.to3D();
    }
}
