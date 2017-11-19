using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float verticalDistanceLimit = 4f;

    public float moveSpeedMultiplier = 0.9f;
    public float maxSpeed = 4f;
    public float dragFactor = 0.98f;
    private Vector2 velocity = new Vector2(0, 0);

    private Vector2 mousePosition {
        get {
            return Camera.main.ScreenToWorldPoint(Input.mousePosition).to2D();
        }
    }

    // Update is called once per frame
    void Update() {
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
