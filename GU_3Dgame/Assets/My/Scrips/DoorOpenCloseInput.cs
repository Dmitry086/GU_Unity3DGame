using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenCloseInput : MonoBehaviour
{
    [SerializeField] float DoorOpenAngle;
    [SerializeField] float DoorOpenSpeed;
    float DoorCloseAngle = 0;
    [SerializeField] public bool DoorClose;

    void DoorOpenClose()
    {
        if (!DoorClose)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(transform.rotation.x, DoorOpenAngle, transform.rotation.z), DoorOpenSpeed * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(transform.rotation.x, DoorCloseAngle, transform.rotation.z), DoorOpenSpeed * Time.deltaTime);
        }
    }

    private void Start()
    {
        DoorClose = true;
    }
    void Update()
    {
        DoorOpenClose();
    }
}
