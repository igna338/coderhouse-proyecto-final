using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastWarningCollision : MonoBehaviour
{
    public Image leftWarningCollision;
    public Image rightWarningCollision;
    public float raycastLength;

    private void Update()
    {
        CheckForLeftCollision();
        CheckForRightCollision();
    }

    private void CheckForLeftCollision()
    {
        Ray ray = new Ray(transform.position, (transform.right * -1));
        RaycastHit raycastHit;

        if (Physics.Raycast(ray, out raycastHit, raycastLength))
        {
            leftWarningCollision.enabled = true;
        }
        else
        {
            leftWarningCollision.enabled = false;
        }
    }

    private void CheckForRightCollision()
    {
        Ray ray = new Ray(transform.position, transform.right);
        RaycastHit raycastHit;

        if (Physics.Raycast(ray, out raycastHit, raycastLength))
        {
            rightWarningCollision.enabled = true;
        }
        else
        {
            rightWarningCollision.enabled = false;
        }
    }
}
