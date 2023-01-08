using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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

    [SerializeField]
    LayerMask layerMask;

    private bool getStartedHovered = false;
    private bool aboutCardHovered = false;
    private bool dailyCardHovered = false;

    // Start is called before the first frame update
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
            if (hit.transform.name == "GetStarted") getStartedHovered = true;
            else getStartedHovered = false;

            if (hit.transform.name == "DailyCard") dailyCardHovered = true;
            else dailyCardHovered = false;

            if (hit.transform.name == "AboutCard") aboutCardHovered = true;
            else aboutCardHovered = false;

            return true;
        }
        else
        {
            getStartedHovered = false;
            dailyCardHovered = false;
            aboutCardHovered = false;
            return false;
        }
        
    }

    private void CheckHover(InputAction.CallbackContext context)
    {
        CheckRayCollision();
        if (getStartedHovered)
        {
            //Debug.Log("Entered Hovered");
            getStartedRenderer.material = lightHoverMaterial;
            //return; //Check logic if I can leave only ifs and rteturns
        }
        else if (dailyCardHovered)
        {
            dailyCardRenderer.material = darkHoverMaterial;
            aboutCardRenderer.material = darkBaseMaterial;
        }
        else if (aboutCardHovered)
        {
            dailyCardRenderer.material = darkBaseMaterial;
            aboutCardRenderer.material = darkHoverMaterial;
        }
        else
        {
            //Debug.Log("Entered else");
            if(getStartedRenderer != null) getStartedRenderer.material = lightBaseMaterial;
            if (dailyCardRenderer != null) dailyCardRenderer.material = darkBaseMaterial;
            if (aboutCardRenderer != null) aboutCardRenderer.material = darkBaseMaterial;
        }
    }


    private void CheckClick(InputAction.CallbackContext context)
    {
        if (getStartedHovered)
        {
            SceneManager.LoadScene("MainMenu");
        }
        else if (dailyCardHovered)
        {
            SceneManager.LoadScene("BreathingExercise");
        }
        else if (aboutCardHovered)
        {
            SceneManager.LoadScene("About");
        }
    }

}