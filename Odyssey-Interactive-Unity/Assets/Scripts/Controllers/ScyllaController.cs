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
    public float followSpeed = 0.66f;

    public float minStateTime = 1f;
    public float maxStateTime = 1.5f;

    public GameObject neckPivot;
    public GameObject neck;
    public GameObject head;

    public State state { get; private set; }

    private Vector3 target;

    private float time = 0f;
    private float neckLength = 0f;

    private float nextStateTime;

    // Use this for initialization
    void Start() {
        state = State.IDLE;
        nextStateTime = GetNextStateTime();
    }

    void CycleState() {
        nextStateTime = GetNextStateTime();
        time = 0f;

        if (state == State.IDLE) {
            state = State.ATTACKING;
            target = GameController.instance.playerController.transform.position;
        } else if (state == State.ATTACKING) {
            // haxx aka keep retracting until you're all the way back, we don't want weird half-retracted necks. *too weird*
            nextStateTime = 100f;
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

    float GetNextStateTime() {
        return Random.Range(minStateTime, maxStateTime);
    }

    // Update is called once per frame
    void Update() {
        if (GameController.instance.state != GameController.State.PLAYING) {
            return;
        }

        time += Time.deltaTime;
        if (time > nextStateTime) {
            CycleState();
        }

        if (state == State.IDLE) {
            RotateNeck(Vector2.left);
            MoveBase();
        } else if (state == State.ATTACKING) {
            target = Vector3.Lerp(target, GameController.instance.playerController.transform.position, followSpeed * Time.deltaTime);

            Vector2 distance = target - transform.position;
            RotateNeck(distance);

            if (distance.magnitude - neckLength > 0.05f) {
                neckLength += Time.deltaTime * neckMovementSpeed;
                ResizeNeck(neckLength);
            }
        } else if (state == State.RETRACTING) {
            if (neckLength > 0f) {
                neckLength -= Time.deltaTime * neckMovementSpeed;
                if (neckLength < 0f) {
                    neckLength = 0f;
                    CycleState();
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
