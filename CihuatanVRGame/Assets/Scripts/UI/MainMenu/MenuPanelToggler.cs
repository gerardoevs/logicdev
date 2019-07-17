using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPanelToggler : MonoBehaviour
{
    public Canvas CenterCanvas;
    // Start is called before the first frame update
    void Start()
    {
        if (CenterCanvas == null) {
            Debug.LogWarning("Canvas not assigned on the inspector!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
