using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonesRojos : MonoBehaviour
{

    public static BotonesRojos _instance;

    private int btnPressed = 0;

    //SINGLETON
    public static BotonesRojos Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        this.gameObject.SetActive(false);
    }

    public int getBtnPressed() {
        return btnPressed;
    }

    public void buttonPressed() {
        btnPressed++;
    }

    public void unHideButtons() {
        this.gameObject.SetActive(true);
    }

}
