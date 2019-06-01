using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuToggler : MonoBehaviour
{
    public bool IsMenuActive = false;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(this.IsMenuActive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggleMenu() {
        this.IsMenuActive = !this.IsMenuActive;
        this.gameObject.SetActive(IsMenuActive);
    }
}
