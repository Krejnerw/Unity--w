using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zadanie_6 : MonoBehaviour
{
    // Smooth towards the height of the target - Mathf.SmoothDamp

    public Transform target;
    float smoothTime = 1.0f;
    float yVelocity = 7.0f;

    // animate the game object from -1 to +1 and back - Mathf.Lerp
    public float minimum = 0.5F;
    public float maximum = 2.0F;

    // starting value for the Lerp
    static float t = 5.0f;

    void Update()
    {
        float newPositionY = Mathf.SmoothDamp(transform.position.y, target.position.y, ref yVelocity, smoothTime);
        transform.position = new Vector3(transform.position.x, newPositionY, transform.position.z);

        // ====================================================
        // animate the position of the game object...
        transform.position = new Vector3(Mathf.Lerp(minimum, maximum, t), 0.5f, 0);

        // .. and increase the t interpolater
        t += 0.5f * Time.deltaTime;

        // now check if the interpolator has reached 1.0
        // and swap maximum and minimum so game object moves
        // in the opposite direction.
        if (t > 1.0f)
        {
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
            t = 0.0f;
        }
    }
}
