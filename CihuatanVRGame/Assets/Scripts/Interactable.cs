using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Interactable : MonoBehaviour
{
    public VRTK_ControllerEvents vrtkCE;
    private bool interactButtonPressed = false;
    private bool grip = false;

    public virtual void Interact()
    {

    }

    public void Start()
    {
        if (vrtkCE == null) {
            Debug.LogWarning("VRTK_ControllerEvents not assigned on the hierachy");
        }
        vrtkCE.ButtonOnePressed += Interactable_ButtonOnePressed;
        vrtkCE.ButtonOneReleased += Interactable_ButtonOneReleased;
        vrtkCE.GripPressed += VrtkCE_GripPressed;
        vrtkCE.GripReleased += VrtkCE_GripReleased;
    }

    void Update()
    {
        if (interactButtonPressed && grip) {
            Interact();
        }
    }

    private void VrtkCE_GripReleased(object sender, ControllerInteractionEventArgs e)
    {
        grip = false;
    }

    private void VrtkCE_GripPressed(object sender, ControllerInteractionEventArgs e)
    {
        grip = true;
    }

    private void Interactable_ButtonOnePressed(object sender, ControllerInteractionEventArgs e)
    {
        interactButtonPressed = true;
    }

    private void Interactable_ButtonOneReleased(object sender, ControllerInteractionEventArgs e)
    {
        interactButtonPressed = false;
    }
}
