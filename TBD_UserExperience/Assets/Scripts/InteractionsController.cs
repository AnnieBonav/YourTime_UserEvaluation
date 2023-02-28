using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static MyTimer;


public class InteractionsController : MonoBehaviour
{
    public static event Action GoForwardButtonClicked;
    public static event Action GoBackButtonClicked;
    public static event Action AboutButtonClicked;

    public UserEvaluation interactionController;

    //Splash Screen
    public MeshRenderer ButtonRenderer = null;
    public Material ButtonBaseMaterial;
    public Material ButtonHoverMaterial;

    // Main Menu
    public MeshRenderer CardRenderer = null;
    public Material CardBaseMaterial;
    public Material CardHoverMaterial;


    //General
    public MeshRenderer GoBackIconRenderer = null;
    public MeshRenderer AboutIconRenderer = null;
    
    public Material IconBaseMaterial;
    public Material IconHoverMaterial;

    [SerializeField]
    LayerMask layerMask;

    private bool GoForwardHovered = false; //Indludes getSTarted and card
    private bool GoBackHovered = false;
    private bool AboutIconHovered = false;

    private bool StarHovered = false;
    public Stars stars;
    private string starHovered = "";


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
        if (Physics.Raycast(ray, out hit, 10, layerMask))
        {
            GoForwardHovered = false;
            GoBackHovered = false;
            AboutIconHovered = false;

            if(hit.transform.name == "GetStarted" || hit.transform.name == "DailyCard")
            {
                GoForwardHovered = true;
            }else if (hit.transform.name == "AboutIcon")
            {
                AboutIconHovered= true;
                Debug.Log(AboutIconHovered);

            }else if(hit.transform.name == "GoBackIcon" || hit.transform.name == "CloseIcon")
            {
                GoBackHovered = true;
            }else if (hit.transform.tag == "star")
            {
                starHovered = hit.transform.name;
                StarHovered = true;
            }
            return true;
        }
        else
        {
            GoForwardHovered = false;
            GoBackHovered = false;
            AboutIconHovered = false;
            StarHovered = false;

            return false;
        }
        
    }

    private void CheckHover(InputAction.CallbackContext context)
    {
        CheckRayCollision();
        if (GoForwardHovered)
        {
            if(ButtonRenderer != null) ButtonRenderer.material = ButtonHoverMaterial;
            if(CardRenderer != null) CardRenderer.material = CardHoverMaterial;
        }
        else if (GoBackHovered)
        {
            GoBackIconRenderer.material = IconHoverMaterial;
        }
        else if (AboutIconHovered)
        {
            AboutIconRenderer.material = IconHoverMaterial;
        }
        else if (StarHovered)
        {
            stars.ChangeStarColor(starHovered);
        }
        else
        {
            if (ButtonRenderer != null) ButtonRenderer.material = ButtonBaseMaterial;
            if (CardRenderer != null) CardRenderer.material = CardBaseMaterial;
            if (GoBackIconRenderer != null) GoBackIconRenderer.material = IconBaseMaterial;
            if (AboutIconRenderer != null) AboutIconRenderer.material = IconBaseMaterial;
            stars.WhipeStars();
        }
    }


    private void CheckClick(InputAction.CallbackContext context)
    {
        if (GoForwardHovered)
        {
            Debug.Log("Go Forward");
            GoForwardButtonClicked?.Invoke();
        }
        else if (AboutIconHovered)
        {
            Debug.Log("Go About");
            AboutButtonClicked?.Invoke();

        }
        else if (GoBackHovered)
        {
            Debug.Log("Go Back");

            GoBackButtonClicked?.Invoke();
        }
        else if (StarHovered)
        {
            //Submit stars
        }
    }
}