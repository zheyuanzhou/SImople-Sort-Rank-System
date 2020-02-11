using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingBG : MonoBehaviour
{
    [SerializeField] private float dist;//18.241
    [SerializeField] private float moveSpeed;

    private void Update()
    {
        transform.Translate(-transform.right * moveSpeed * Time.deltaTime);

        if(transform.position.x <= -dist)
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }
}
