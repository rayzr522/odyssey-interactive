using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour {
    public void SetLength(float length) {
        Vector3 pos = transform.localPosition;
        pos.x = length;
        transform.localPosition = pos;
    }
}
