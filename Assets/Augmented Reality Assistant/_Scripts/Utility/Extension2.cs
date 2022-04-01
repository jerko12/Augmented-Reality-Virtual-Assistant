using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extension2
{
    public static Vector3 RelativeVector(this Vector3 vector, Transform relativeTransform)
    {
        Vector3 relativeVector = Vector3.zero;
        relativeVector += relativeTransform.forward * vector.z;
        relativeVector += relativeTransform.right * vector.x;
        relativeVector += relativeTransform.up * vector.y;
        return new Vector3(relativeVector.x, relativeVector.y, relativeVector.z);
    }

    public static Vector3 RelativeVectorFlat(this Vector3 vector, Transform relativeTransform)
    {
        float magnitude = vector.magnitude;
        Vector3 relativeVector = Vector3.zero;
        relativeVector += relativeTransform.forward * vector.z;
        relativeVector += relativeTransform.right * vector.x;

        return new Vector3(relativeVector.x, 0, relativeVector.z).normalized * magnitude;
    }

    public static Vector3 VectorFlat(this Vector3 vector)
    {
        return new Vector3(vector.x, 0, vector.z);
    }

    public static Vector3 Clamp(this Vector3 vector, float min, float max)
    {
        float magnitude = vector.magnitude;
        vector = vector.normalized;
        magnitude = Mathf.Clamp(magnitude, min, max);
        return vector * magnitude;
    }

    public static Vector2 RelativeVector(this Vector2 vector, Transform relativeTransform)
    {
        Vector3 relativeVector = Vector3.zero;
        relativeVector += relativeTransform.forward * vector.y;
        relativeVector += relativeTransform.right * vector.x;
        return new Vector2(relativeVector.x, relativeVector.z);
    }
    public static void DestroyChildren(this Transform t)
    {
        foreach (Transform child in t)
        {
            Object.Destroy(child.gameObject);
        }
    }

    // Vectors
    public static Vector3 Flat(this Vector3 input) => new Vector3(input.x, 0, input.z);
    public static Vector2 Flat2D(this Vector3 input) => new Vector2(input.x, input.z);
}
