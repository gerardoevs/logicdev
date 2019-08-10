using System.Collections;
using System.Collections.Generic;
using VRTK;
using UnityEngine;

public class DetectGrab : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //make sure the object has the VRTK script attached... 
        if (GetComponent<VRTK_InteractableObject>() == null)

        {
            Debug.LogError("DetectGrab is required to be attached to an Object that has the VRTK_InteractableObject script attached to it");
            return;

        }

        //subscribe to the event.  NOTE: the "ObectGrabbed"  this is the procedure to invoke if this objectis grabbed.. 
        GetComponent<VRTK_InteractableObject>().InteractableObjectGrabbed += new InteractableObjectEventHandler(ObjectGrabbed);
    }

    private void ObjectGrabbed(object sender, InteractableObjectEventArgs e)
    {
        Debug.Log("Im Grabbed");
        TutorialManager.Instance.HasGrabTheCube();
    }
}
