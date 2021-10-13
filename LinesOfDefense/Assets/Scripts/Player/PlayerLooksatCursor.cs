using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLooksatCursor : MonoBehaviour
{

    public Transform target;

   
    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
