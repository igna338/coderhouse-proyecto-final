using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarRigidbodyConstraints : MonoBehaviour
{
    private Rigidbody m_Rigidbody;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        Freeze();
    }

    public void Freeze()
    {
        m_Rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
    }

    public void Unfreeze()
    {
        m_Rigidbody.constraints = RigidbodyConstraints.None;
    }
}
