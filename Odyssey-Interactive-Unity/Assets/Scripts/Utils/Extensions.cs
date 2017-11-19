using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions {
    /// Converts a Vector3 into a Vector2, removing the Z component
    public static Vector2 to2D(this Vector3 self) {
        return new Vector2(self.x, self.y);
    }

    /// Converts a Vector2 into a Vector3, using the given Z value
    public static Vector3 to3D(this Vector2 self, float z = 0.0f) {
        return new Vector3(self.x, self.y, z);
    }

    /// Clamps a Vector2 between the given minX, maxX, minY, and maxY values
    public static Vector2 clamp(this Vector2 self, float minX, float maxX, float minY, float maxY) {
        return new Vector2(Mathf.Clamp(self.x, minX, maxX), Mathf.Clamp(self.y, minY, maxY));
    }
}