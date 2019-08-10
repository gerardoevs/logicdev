using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager _instance;

    public TextMeshProUGUI tutorialText;
    public float fadingTime = 3f;
    public float timeBetweenText = 10f;

    private float globalTimer = 0f;
    private float fadeInTimer = 0f;
    private float fadeOutTimer = 0f;
    private bool isFadingIn = false;
    private bool isFadingOut = false;
    private int step = 0;


    private bool instantiatedPanel = false;

    //Buttons Pressed
    private bool gripPressed = false;
    private bool cubeGrabbed = false;
    private bool triggerPressed = false;
    private bool thumbTouchTouched = false;
    private bool menuButtonPressed = false;

    //Prefabs
    public Transform parent;
    public Transform gripButtonPrefab;
    public Transform handGrabPrefab;
    public Transform triggerButtonPrefab;
    public Transform thumbTouchPrefab;
    public Transform okSignalPrefab;

    //Texto de cada paso
    private string[] tutorialSteps = {
        "Preciona el boton 'Grip' para poder agarrar objetos",
        "¡Genial! ahora toma el cubo que esta frente a ti." ,
        "Ahora sabes como agarrar objetos... ",
        "Puedes utilizar el boton 'Trigger' para poder seleccionar",
        "Pon tu dedo en el Joystick izquierdo para apuntar un laser guia",
        "¡Bien! ahora selecciona los botones rojos!"
    };


    //SINGLETON
    public static TutorialManager Instance
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
    }

    // Start is called before the first frame update
    void Start()
    {
        if (tutorialText == null)
            Debug.LogError("el texto del tutorial (TextCanvas/Panel/TutorialText - en el Hierachy) no ha sido asignado en el ispector!");
    }

    // Update is called once per frame
    void Update()
    {
        globalTimer += Time.deltaTime * 1;
        if (globalTimer > timeBetweenText) {

            if(!isFadingIn)
                fadeIn();
            isFadingIn = true;
            fadeInTimer += Time.deltaTime * 1;

            if (fadeInTimer > fadingTime) {
                //Muestra el texto del paso en el que esta el tutorial
                tutorialText.SetText(tutorialSteps[step]);

                if (!isFadingOut)
                    fadeOut();
                fadeOutTimer += Time.deltaTime * 1;
                if (fadeOutTimer > fadingTime) {
                    if (showTutorialStep()) {

                        //limpia los timers del loop
                        clearLoop();
                        if(step < tutorialSteps.Length )
                            step++;
                            

                    }
                }
            }
            
        }
        
    }

    private bool showTutorialStep() {
        bool actionCompleted = false; 
        switch(step)
        {
            case 0:
                if (!instantiatedPanel)
                {
                    instatiatePanel(gripButtonPrefab);
                }
                if (gripPressed)
                {
                    instatiatePanel(okSignalPrefab);
                    actionCompleted = true;
                    gripPressed = false;
                    instantiatedPanel = false;
                }
                break;
            case 1:
                if (!instantiatedPanel)
                {
                    instatiatePanel(handGrabPrefab);
                }
                if (cubeGrabbed)
                {
                    instatiatePanel(okSignalPrefab);
                    actionCompleted = true;
                    cubeGrabbed = false;
                    instantiatedPanel = false;
                }
                break;
            case 2:
                actionCompleted = true;
                break;
            case 3:
                if (!instantiatedPanel)
                {
                    instatiatePanel(triggerButtonPrefab);
                }
                if (triggerPressed)
                {
                    instatiatePanel(okSignalPrefab);
                    actionCompleted = true;
                    triggerPressed = false;
                    instantiatedPanel = false;
                }
                break;
            case 4:
                if (!instantiatedPanel)
                {
                    instatiatePanel(thumbTouchPrefab);
                }
                if (thumbTouchTouched)
                {
                    instatiatePanel(okSignalPrefab);
                    actionCompleted = true;
                    thumbTouchTouched = false;
                    instantiatedPanel = false;
                }
                break;
        }
        return actionCompleted;
    }

    private void instatiatePanel(Transform prefab) {
        destroyPanel();
        Debug.Log("Panel instantiated!");
        Transform panel = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
        panel.parent = parent;
        panel.transform.position = parent.transform.position;
        panel.transform.localScale = parent.transform.localScale;
        instantiatedPanel = true;
    }

    private void destroyPanel() {
        Debug.Log("Panel destroyed!");
        instantiatedPanel = false;
        foreach (Transform child in parent)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    private void clearLoop() {
        globalTimer = 0f;
        fadeOutTimer = 0f;
        fadeInTimer = 0f;
        isFadingOut = false;
        isFadingIn = false;
    }

    public void fadeIn()
    {
        tutorialText.CrossFadeAlpha(0.0f, fadingTime, false);
    }

    public void fadeOut()
    {
        tutorialText.CrossFadeAlpha(1f, fadingTime, false);
    }

    //Metodos publicos para llamado de acciones

    public void HasPressedGrip() {
        gripPressed = true;
    }

    public void HasGrabTheCube()
    {
        Debug.Log("cubeGrabbed");
        cubeGrabbed = true;
    }

    public void HasPressedTrigger()
    {
        triggerPressed = true;
    }

    public void HasTouchJoystick()
    {
        thumbTouchTouched = true;
    }

}
