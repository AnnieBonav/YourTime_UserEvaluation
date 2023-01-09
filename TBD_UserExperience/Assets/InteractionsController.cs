using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static MyTimer;



public class InteractionsController : MonoBehaviour
{

    public UserEvaluation interactionController;

    //Splash Screen
    public MeshRenderer getStartedRenderer = null;
    public Material lightBaseMaterial;
    public Material lightHoverMaterial;

    // Main Menu
    public MeshRenderer dailyCardRenderer = null;
    public MeshRenderer aboutCardRenderer = null;
    public Material darkBaseMaterial;
    public Material darkHoverMaterial;

    //Exercise
    public MeshRenderer startExerciseRenderer = null;
    public delegate void StartExerciseEvent();
    public static event StartExerciseEvent onExerciseTriggered;
    public GameObject startExerciseButton = null;

    public MeshRenderer goBackIconRenderer = null;
    public MeshRenderer aboutIconRenderer = null;
    public Material baseIconMaterial;
    public Material hoverIconMaterial;

    [SerializeField]
    LayerMask layerMask;

    private bool getStartedHovered = false;
    private bool aboutCardHovered = false;
    private bool dailyCardHovered = false;
    private bool startExerciseHovered = false;
    private bool goBackIconHovered = false;
    private bool aboutIconHovered = false;

    // Start is called before the first frame update
    private void Awake()
    {
        interactionController = new UserEvaluation();
        //currentScene = CurrentScene.
    }

    private void OnEnable()
    {
        interactionController.Enable();
        interactionController.UI.Click.canceled += CheckClick;
        interactionController.UI.Point.performed += CheckHover;
    }

    private void OnDisable()
    {
        interactionController.Disable();
        interactionController.UI.Click.canceled -= CheckClick;
        interactionController.UI.Point.performed -= CheckHover;

    }

    private void RemoveHover(InputAction.CallbackContext context)
    {
        Debug.Log("Removed Hover");
    }

    private bool CheckRayCollision()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, layerMask))
        {
            getStartedHovered = false;
            dailyCardHovered = false;
            aboutCardHovered = false;
            startExerciseHovered = false;
            goBackIconHovered = false;
            aboutIconHovered = false;

            switch (hit.transform.name)
            {
                case "GetStarted":
                    getStartedHovered = true;
                    break;

                case "DailyCard":
                    dailyCardHovered = true;
                    break;

                case "AboutCard":
                    aboutCardHovered = true;
                    break;

                case "StartExercise":
                    startExerciseHovered = true;
                    break;

                case "GoBackIcon":
                    goBackIconHovered = true;
                    break;

                case "AboutIcon":
                    aboutIconHovered = true;
                    break;
            }

            return true;
        }
        else
        {
            getStartedHovered = false;
            dailyCardHovered = false;
            aboutCardHovered = false;
            startExerciseHovered = false;
            goBackIconHovered = false;
            aboutIconHovered = false;
            return false;
        }
        
    }

    private void CheckHover(InputAction.CallbackContext context)
    {
        
        CheckRayCollision();
        Debug.Log(AppStateHandler.Instance.currentScene);
        if (getStartedHovered)
        {
            getStartedRenderer.material = lightHoverMaterial;
            //return; //Check logic if I can leave only ifs and rteturns
        }
        else if (dailyCardHovered)
        {
            dailyCardRenderer.material = darkHoverMaterial;
            if(aboutCardRenderer != null) aboutCardRenderer.material = darkBaseMaterial;
        }
        else if (aboutCardHovered)
        {
            dailyCardRenderer.material = darkBaseMaterial;
            if (aboutCardRenderer != null) aboutCardRenderer.material = darkHoverMaterial;
        }
        else if (startExerciseHovered)
        {
            startExerciseRenderer.material = lightHoverMaterial;
        }
        else if (goBackIconHovered)
        {
            goBackIconRenderer.material = hoverIconMaterial;
        }
        else if (aboutIconHovered)
        {
            aboutIconRenderer.material = hoverIconMaterial;
        }
        else
        {
            if (getStartedRenderer != null) getStartedRenderer.material = lightBaseMaterial;
            if (dailyCardRenderer != null) dailyCardRenderer.material = darkBaseMaterial;
            if (aboutCardRenderer != null) aboutCardRenderer.material = darkBaseMaterial;
            if (startExerciseRenderer != null) startExerciseRenderer.material = lightBaseMaterial;
            if (goBackIconRenderer != null) goBackIconRenderer.material = baseIconMaterial;
            if (aboutIconRenderer != null) aboutIconRenderer.material = baseIconMaterial;
        }
    }


    private void CheckClick(InputAction.CallbackContext context)
    {
        if (getStartedHovered)
        {
            AppStateHandler.Instance.ChangeScene(CurrentScene.MainMenu);
            SceneManager.LoadScene("MainMenu");
            
        }
        else if (dailyCardHovered)
        {
            SceneManager.LoadScene("BreathingExercise");
        }
        else if (aboutCardHovered)
        {
            SceneManager.LoadScene("About");
        }else if (startExerciseHovered)
        {
            startExerciseButton.SetActive(false);
            onExerciseTriggered.Invoke();
        }else if (goBackIconHovered)
        {
            SceneManager.LoadScene("SplashScreen");
        }
        else if (aboutIconHovered)
        {
            SceneManager.LoadScene("About");
        }
    }

}