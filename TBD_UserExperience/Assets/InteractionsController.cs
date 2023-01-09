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
    public MeshRenderer cardRenderer = null;
    public Material darkBaseMaterial;
    public Material darkHoverMaterial;

    //Exercise
    public delegate void StartExerciseEvent();
    public static event StartExerciseEvent onExerciseTriggered;
    public GameObject startExerciseButton = null;    

    //General
    public MeshRenderer goBackIconRenderer = null;
    public MeshRenderer aboutIconRenderer = null;
    
    public Material baseIconMaterial;
    public Material hoverIconMaterial;

    [SerializeField]
    LayerMask layerMask;

    private bool moveForwardHovered = false; //Indludes getSTarted and card
    private bool goBackIconHovered = false;
    private bool aboutIconHovered = false;

    private void Awake()
    {
        interactionController = new UserEvaluation();
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

    private bool CheckRayCollision()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, layerMask))
        {
            moveForwardHovered = false;
            goBackIconHovered = false;
            aboutIconHovered = false;

            if(hit.transform.name == "GetStarted" || hit.transform.name == "DailyCard")
            {
                moveForwardHovered = true;
            }else if (hit.transform.name == "AboutIcon")
            {
                aboutIconHovered= true;
            }else if(hit.transform.name == "GoBackIcon" || hit.transform.name == "CloseIcon")
            {
                goBackIconHovered = true;
            }

            return true;
        }
        else
        {
            moveForwardHovered = false;
            goBackIconHovered = false;
            aboutIconHovered = false;
            return false;
        }
        
    }

    private void CheckHover(InputAction.CallbackContext context)
    {
        CheckRayCollision();
        if (moveForwardHovered)
        {
            if(getStartedRenderer != null) getStartedRenderer.material = lightHoverMaterial;
            if(cardRenderer != null) cardRenderer.material = darkHoverMaterial;
            //return; //Check logic if I can leave only ifs and rteturns
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
            if (cardRenderer != null) cardRenderer.material = darkBaseMaterial;
            if (goBackIconRenderer != null) goBackIconRenderer.material = baseIconMaterial;
            if (aboutIconRenderer != null) aboutIconRenderer.material = baseIconMaterial;
        }
    }


    private void CheckClick(InputAction.CallbackContext context)
    {
        if (moveForwardHovered) AppStateHandler.Instance.ChangeScene(false);
        else if (aboutIconHovered) AppStateHandler.Instance.ChangeScene(true);
        else if (goBackIconHovered) AppStateHandler.Instance.GoBack();
    }
}