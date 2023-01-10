using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
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

    public MeshRenderer star1 = null;
    public MeshRenderer star2 = null;
    public MeshRenderer star3 = null;
    public MeshRenderer star4 = null;
    public MeshRenderer star5 = null;

    public Material activatedStar;
    public Material inactiveStar;

    private bool star1Hovered = false;
    private bool star2Hovered = false;
    private bool star3Hovered = false;
    private bool star4Hovered = false;
    private bool star5Hovered = false;

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
            Debug.Log(hit.transform.name);
            Debug.Log("Entered here");
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
            }else if (hit.transform.name == "1") //A for loop kills it
            {
                star1Hovered = true;
                /*
                for(int i = int.Parse(hit.transform.name); i > 0; i++)
                {
                    Debug.Log(i);
                }*/
            }
            else if (hit.transform.name == "2") //A for loop kills it
            {
                star2Hovered = true;
            }
            else if (hit.transform.name == "3") //A for loop kills it
            {
                star3Hovered = true;
            }
            else if (hit.transform.name == "4") //A for loop kills it
            {
                star4Hovered = true;
            }
            else if (hit.transform.name == "5") //A for loop kills it
            {
                star5Hovered = true;
            }

            return true;
        }
        else
        {
            moveForwardHovered = false;
            goBackIconHovered = false;
            aboutIconHovered = false;

            star1Hovered = false;
            star2Hovered = false;
            star3Hovered = false;
            star4Hovered = false;
            star5Hovered = false;

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
        else if (star1Hovered)
        {
            star1.material = activatedStar;
        }
        else if (star2Hovered)
        {
            star1.material = activatedStar;
            star2.material = activatedStar;
        }
        else if (star3Hovered)
        {
            star1.material = activatedStar;
            star2.material = activatedStar;
            star3.material = activatedStar;
        }
        else if (star4Hovered)
        {
            star1.material = activatedStar;
            star2.material = activatedStar;
            star3.material = activatedStar;
            star4.material = activatedStar;
        }
        else if (star5Hovered)
        {
            star1.material = activatedStar;
            star2.material = activatedStar;
            star3.material = activatedStar;
            star4.material = activatedStar;
            star5.material = activatedStar;
        }
        else
        {
            if (getStartedRenderer != null) getStartedRenderer.material = lightBaseMaterial;
            if (cardRenderer != null) cardRenderer.material = darkBaseMaterial;
            if (goBackIconRenderer != null) goBackIconRenderer.material = baseIconMaterial;


            if (star1 != null) star1.material = inactiveStar;
            if (star2 != null) star2.material = inactiveStar;
            if (star3 != null) star3.material = inactiveStar;
            if (star4 != null) star4.material = inactiveStar;
            if (star5 != null) star5.material = inactiveStar;
        }
    }


    private void CheckClick(InputAction.CallbackContext context)
    {
        if (moveForwardHovered) AppStateHandler.Instance.ChangeScene(false);
        else if (aboutIconHovered) AppStateHandler.Instance.ChangeScene(true);
        else if (goBackIconHovered) AppStateHandler.Instance.GoBack();

        else if (star1Hovered) AppStateHandler.Instance.SubmitStars(1);
        else if (star2Hovered) AppStateHandler.Instance.SubmitStars(2);
        else if (star3Hovered) AppStateHandler.Instance.SubmitStars(3);
        else if (star4Hovered) AppStateHandler.Instance.SubmitStars(4);
        else if (star5Hovered) AppStateHandler.Instance.SubmitStars(5);

        //else if (star1Hovered || star2Hovered || star3Hovered || star4Hovered || star5Hovered) AppStateHandler.Instance.ChangeScene();
    }
}