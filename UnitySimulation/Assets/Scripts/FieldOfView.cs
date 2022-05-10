using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FieldOfView : MonoBehaviour
{
    public float viewRadius = 2;
    [Range(0, 360)]
    public float viewAngle = 90;
    [Range (0, 360)]
    public int numberOfRays = 6;
    public LayerMask objectMask;

    public UnityEvent onObjectEnter;
    public UnityEvent onOBjectLeave;

    [HideInInspector]
    public bool objectDetected;
    [HideInInspector]
    public RaycastHit objectHit;

    private void Start()
    {
        if (onObjectEnter == null) onObjectEnter = new UnityEvent();
        if (onOBjectLeave == null) onOBjectLeave = new UnityEvent();
        StartCoroutine("FindObjectsWithDelay", .1f);
    }

    IEnumerator FindObjectsWithDelay(float delay)
    {
        while(true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleObjects();
        }
    }

    void FindVisibleObjects()
    {
        float rayAngleIncrement = (viewAngle / (numberOfRays - 1));
        for (int i = 0; i < numberOfRays; i++)
        {
            Vector3 rayDir = DirFromAngle((rayAngleIncrement * i) - viewAngle/2, false);
            if (Physics.Raycast(transform.position, rayDir, out objectHit, viewRadius, objectMask))
            {
                if (!objectDetected)
                {
                    if (onObjectEnter != null) onObjectEnter.Invoke();
                    objectDetected = true;
                }
                return;
            }
        }

        if (objectDetected)
        {
            if (onOBjectLeave != null) onOBjectLeave.Invoke();
            objectDetected = false;
        }
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        // 0deg in unity is shifted back 90deg from regular unit circle
        // 90 - angle
        // sin(90 - angle) == cos(x)
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        if (objectDetected) Gizmos.color = Color.red;
        GizmosExtensions.DrawWireArc(transform.position, transform.forward, viewAngle, viewRadius, 5);
    }
}
