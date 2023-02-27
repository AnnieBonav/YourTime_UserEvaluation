using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CardInteraction : MonoBehaviour
{
    public string SceneName;

    public MeshRenderer star1 = null;
    public MeshRenderer star2 = null;
    public MeshRenderer star3 = null;
    public MeshRenderer star4 = null;
    public MeshRenderer star5 = null;

    public Material InactiveStar;
    public Material ActiveStar;

    public void OpenAbout()
    {
        //AppStateHandler.Instance.ChangeScene(true);
    }

    public void OpenNextScene() //Parameters in functions are not seen in the inspector inside Event Trigger
    {
        if(SceneName == "")
        {
            //AppStateHandler.Instance.ChangeScene(false);
        }
        else
        {
            SceneManager.LoadScene(SceneName); //In case I want to go somewhere not linear TODO: Change
        }
        
    }

    public void GoBack()
    {
        AppStateHandler.Instance.GoBack();
    }

    public void SelectStar1()
    {
        AppStateHandler.Instance.SubmitStars(1);
    }

    public void SelectStar2()
    {
        AppStateHandler.Instance.SubmitStars(2);
    }

    public void SelectStar3()
    {
        AppStateHandler.Instance.SubmitStars(3);
    }

    public void SelectStar4()
    {
        AppStateHandler.Instance.SubmitStars(4);
    }

    public void SelectStar5()
    {
        AppStateHandler.Instance.SubmitStars(5);
    }

    public void HoverStar1()
    {
        star1.material = ActiveStar;
    }

    public void HoverStar2()
    {
        star1.material = ActiveStar;
        star2.material = ActiveStar;
    }

    public void HoverStar3()
    {
        star1.material = ActiveStar;
        star2.material = ActiveStar;
        star3.material = ActiveStar;
    }

    public void HoverStar4()
    {
        star1.material = ActiveStar;
        star2.material = ActiveStar;
        star3.material = ActiveStar;
        star4.material = ActiveStar;
    }

    public void HoverStar5()
    {
        star1.material = ActiveStar;
        star2.material = ActiveStar;
        star3.material = ActiveStar;
        star4.material = ActiveStar;
        star5.material = ActiveStar;
    }

    public void RemoveHover()
    {
        star1.material = InactiveStar;
        star2.material = InactiveStar;
        star3.material = InactiveStar;
        star4.material = InactiveStar;
        star5.material = InactiveStar;
    }
}
