using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class InteractionsController : MonoBehaviour
{
    public UserEvaluation interactionController;

    //Splash Screen
    public MeshRenderer getStartedRenderer;
    public Material lightBaseMaterial;
    public Material lightHoverMaterial;

    // Main Menu
    public MeshRenderer dailyCardRenderer;
    public MeshRenderer aboutCardRenderer;
    public Material darkBaseMaterial;
    public Material darkHoverMaterial;

    [SerializeField]
    LayerMask layerMask;

    // Start is called before the first frame update
    private void Awake()
    {
        interactionController = new UserEvaluation();
    }

    private void OnEnable()
    {
        interactionController.Enable();
        interactionController.UI.Click.performed += CheckClick;
        interactionController.UI.Point.performed += CheckHover;
        interactionController.UI.Point.canceled += CheckClick;
        interactionController.UI.Point.canceled += RemoveHover;
    }

    private void OnDisable()
    {
        interactionController.Disable();
        interactionController.UI.Click.performed -= CheckClick;
        interactionController.UI.Point.performed -= CheckHover;

    }

    private void RemoveHover(InputAction.CallbackContext context)
    {
        Debug.Log("Removed Hover");
    }

    private void CheckHover(InputAction.CallbackContext context)
    { 
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, layerMask))
        {
            if (hit.collider != null && hit.transform.name == "GetStarted")
            {
                getStartedRenderer.material = lightHoverMaterial;
            }
            else if(hit.transform.name == "DailyCard")
            {
                dailyCardRenderer.material = darkHoverMaterial;
                aboutCardRenderer.material = darkBaseMaterial;
            }
            else if(hit.transform.name == "AboutCard")
            {
                dailyCardRenderer.material = darkBaseMaterial;
                aboutCardRenderer.material = darkHoverMaterial;
            }
        }
        else
        {
            getStartedRenderer.material = lightBaseMaterial;
            dailyCardRenderer.material = darkBaseMaterial;
            aboutCardRenderer.material = darkBaseMaterial;
        }
    }


    private void CheckClick(InputAction.CallbackContext context)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, layerMask))
        {
            if (hit.collider != null && hit.transform.name == "DailyCard")
            {
                SceneManager.LoadScene("ActivityPrototype");
            }else if(hit.transform.name == "AboutCard")
            {
                SceneManager.LoadScene("AboutScene");
            }
                
        }
    }

}