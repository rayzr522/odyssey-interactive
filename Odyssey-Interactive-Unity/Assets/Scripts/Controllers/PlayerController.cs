using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour {
    public enum State {
        ALIVE, DYING, DEAD
    }

    public State state { get; private set; }

    // Movement variables
    public float verticalDistanceLimit = 4f;
    public float moveSpeedMultiplier = 0.9f;
    public float maxSpeed = 4f;
    public float dragFactor = 0.98f;

    // Prefab for the explosion
    public GameObject explosionPrefab;
    public AudioClip explosionSound;
    public AudioClip hitSound;

    // Remaining health
    public int health { get; private set; }
    public DeathReason deathReason { get; private set; }

    private Vector2 velocity = new Vector2(0, 0);
    private Animator animator;

    private Vector2 mousePosition {
        get {
            return Camera.main.ScreenToWorldPoint(Input.mousePosition).to2D();
        }
    }

    void Start() {
        state = State.ALIVE;
        animator = GetComponent<Animator>();

        health = 6;
    }

    // Update is called once per frame
    void Update() {
        if (!GameController.instance.isPlaying) {
            return;
        }

        if (state == State.ALIVE) {
            DoPhysics();

            if (Input.GetMouseButton(0)) {
                // Prevent recalculation each time this is accessed
                // I doubt this has a massive performance benefit/impact, but what the heck I might as well
                Vector2 currentMousePosition = mousePosition;
                Vector2 pos = transform.position.to2D();

                // The direction in which to aim
                Vector2 direction = (currentMousePosition - pos).normalized;

                transform.rotation = Quaternion.Euler(0f, 0f, -Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg);

                // Reduce velocity change a tad
                AddVelocity(direction * moveSpeedMultiplier);
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if (GameController.instance.state != GameController.State.PLAYING || state != State.ALIVE) {
            return;
        }

        if (other.CompareTag("Cliffs")) {
            deathReason = DeathReason.CLIFFS;
            StartCoroutine(Kill(true));
        } else if (other.CompareTag("Whirlpool")) {
            deathReason = DeathReason.WHIRLPOOL;
            StartCoroutine(Kill(false));
        } else if (other.CompareTag("ScyllaHead")) {
            // Prevent multi-hit from scylla in one attack
            if (GameController.instance.scyllaController.hasHit) {
                return;
            }
            GameController.instance.scyllaController.hasHit = true;

            health--;
            GameController.instance.uiController.SetHealth(health);

            GameController.instance.PlaySound(hitSound, 0.5f);
            if (health < 1) {
                deathReason = DeathReason.EATEN;
                StartCoroutine(Kill(true));
            } else {
                GameController.instance.cameraShake.ShakeCamera(0.2f, 0.008f);
            }
        }
    }

    public IEnumerator Kill(bool explode) {
        if (state == State.ALIVE) {
            state = State.DYING;

            animator.SetTrigger("implode");

            if (explode) {
                GameController.instance.cameraShake.ShakeCamera(1.8f, 0.017f);
                GameController.instance.PlaySound(explosionSound, 0.9f);
                GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(1.5f);
                Destroy(explosion);
            } else {
                yield return new WaitForSeconds(1.5f);
            }

            state = State.DEAD;

            GameController.instance.EndGame();
        }
    }

    void DoPhysics() {
        velocity *= dragFactor;

        Vector2 pos = transform.position.to2D();
        pos += velocity * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, -verticalDistanceLimit, verticalDistanceLimit);

        transform.position = pos.to3D();
    }

    public void AddVelocity(Vector2 velocity) {
        // TODO: Reimplement this with the `velocity` variable?
        this.velocity += velocity;

        CheckVelocity();
    }

    void CheckVelocity() {
        if (velocity.magnitude > maxSpeed) {
            velocity = velocity.normalized * maxSpeed;
        }
    }
}
