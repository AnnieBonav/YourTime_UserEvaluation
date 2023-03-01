using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class InteractionsController : MonoBehaviour
{
    public static event Action GoForwardButtonClicked;
    public static event Action GoBackButtonClicked;
    public static event Action AboutButtonClicked;
    public static event Action<int> StarClicked;

    private UserEvaluation interactionController;

    [Header("Button properties")]
    [SerializeField]
    private MeshRenderer ButtonRenderer = null;
    [SerializeField]
    private Material ButtonBaseMaterial;
    [SerializeField]
    private Material ButtonHoverMaterial;

    [Header("Card properties")]
    [SerializeField]
    public MeshRenderer CardRenderer = null;
    [SerializeField]
    public Material CardBaseMaterial;
    [SerializeField]
    public Material CardHoverMaterial;

    [Header("Icons properties")]
    [SerializeField]
    public MeshRenderer GoBackIconRenderer = null;
    [SerializeField]
    public MeshRenderer AboutIconRenderer = null;
    [SerializeField]
    public Material IconBaseMaterial;
    [SerializeField]
    public Material IconHoverMaterial;

    [Header("Layer it is checking interactions in")]
    [SerializeField]
    private LayerMask layerMask;

    [Header("Stars properties")]
    public Stars stars;

    private bool _goForwardHovered = false; //Indludes getSTarted and card
    private bool _goBackHovered = false;
    private bool _aboutIconHovered = false;

    private bool _starIsHovered = false;
    private string _starHoveredId = "";

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
            _goForwardHovered = false;
            _goBackHovered = false;
            _aboutIconHovered = false;

            if(hit.transform.name == "GetStarted" || hit.transform.name == "DailyCard")
            {
                _goForwardHovered = true;
            }else if (hit.transform.name == "AboutIcon")
            {
                _aboutIconHovered= true;
            }else if(hit.transform.name == "GoBackIcon" || hit.transform.name == "CloseIcon")
            {
                _goBackHovered = true;
            }else if (hit.transform.tag == "star")
            {
                _starHoveredId = hit.transform.name;
                _starIsHovered = true;
            }
            return true;
        }
        else
        {
            _goForwardHovered = false;
            _goBackHovered = false;
            _aboutIconHovered = false;
            _starIsHovered = false;
            return false;
        }
        
    }

    private void CheckHover(InputAction.CallbackContext context)
    {
        CheckRayCollision();
        if (_goForwardHovered)
        {
            if(ButtonRenderer != null) ButtonRenderer.material = ButtonHoverMaterial;
            if(CardRenderer != null) CardRenderer.material = CardHoverMaterial;
        }
        else if (_goBackHovered)
        {
            GoBackIconRenderer.material = IconHoverMaterial;
        }
        else if (_aboutIconHovered)
        {
            AboutIconRenderer.material = IconHoverMaterial;
        }
        else if (_starIsHovered)
        {
            stars.ChangeStarColor(_starHoveredId);
        }
        else
        {
            if (ButtonRenderer != null) ButtonRenderer.material = ButtonBaseMaterial;
            if (CardRenderer != null) CardRenderer.material = CardBaseMaterial;
            if (GoBackIconRenderer != null) GoBackIconRenderer.material = IconBaseMaterial;
            if (AboutIconRenderer != null) AboutIconRenderer.material = IconBaseMaterial;
            if (stars != null) stars.WhipeStars();
        }
    }


    private void CheckClick(InputAction.CallbackContext context)
    {
        if (_goForwardHovered)
        {
            Debug.Log("Go Forward");
            GoForwardButtonClicked?.Invoke();
        }
        else if (_aboutIconHovered)
        {
            Debug.Log("Go About");
            AboutButtonClicked?.Invoke();

        }
        else if (_goBackHovered)
        {
            Debug.Log("Go Back");
            GoBackButtonClicked?.Invoke();
        }
        else if (_starIsHovered)
        {
            StarClicked?.Invoke(int.Parse(_starHoveredId));
        }
    }
}