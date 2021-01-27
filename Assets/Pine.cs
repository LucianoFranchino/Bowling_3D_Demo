using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pine : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (transform.rotation.x < -0.3f
            || transform.rotation.x > 0.3f
            || transform.rotation.z < -0.3f
            || transform.rotation.z > 0.3f)
        {
            FindObjectOfType<GameManager>().AddPoint();
            Destroy(this);
        }
    }
}
