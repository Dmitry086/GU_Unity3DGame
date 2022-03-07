using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtforGate : MonoBehaviour
{
    [SerializeField] bool DoorClose;
    [SerializeField] bool playerAtButton;
    [SerializeField] Material RedMaterial;
    [SerializeField] Material GreenMaterial;
    MeshRenderer ButRender;
    [SerializeField] GameObject Door;
    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Player") playerAtButton = true;
    }
    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player") playerAtButton = false;
    }

    private void Start()
    {
        ButRender = GetComponent<MeshRenderer>();
        ButRender.material = RedMaterial;
        DoorClose = true;

    }
    void DoorOenClose()
    {
        if (playerAtButton & Input.GetKeyDown(KeyCode.F))
        {
            if (DoorClose)
            {
                ButRender.material = GreenMaterial;
                DoorClose = false;
                transform.localScale -= new Vector3(0.09f, 0, 0);
                Door.GetComponent<DoorOpenCloseInput>().DoorClose = false;
            }
            else
            {
                ButRender.material = RedMaterial;
                DoorClose = true;
                transform.localScale += new Vector3(0.09f, 0, 0);
                Door.GetComponent<DoorOpenCloseInput>().DoorClose = true;
            }
        }
    }
    private void Update()
    {
        DoorOenClose();
    }


}
