using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Button Group Action", menuName = "Action/Button Group Action", order = 1)]
public class ButtonGroupAction : ActionBase
{
    public List<ButtonAction> buttonActions = new List<ButtonAction>();
    public string FinishButton;
    public override void Finish()
    {
        Debug.Log("Action => Finished Button Group Action");
        foreach (ButtonAction buttonAction in buttonActions)
        {
            Button button = UIManager.Instance.GetButton(buttonAction.buttonName);
            if (button == null) return;
            button.onClick.RemoveAllListeners();
            //buttonAction.action.OnFinished.RemoveAllListeners();
        }

        base.Finish();
    }

    public void showButtons()
    {
        Debug.Log("Action => show buttons in group");
        foreach (ButtonAction buttonAction in buttonActions)
        {
            Button button = UIManager.Instance.GetButton(buttonAction.buttonName);
            if (button == null) return;
            button.gameObject.SetActive(true);
        }
        Button finishButton = UIManager.Instance.GetButton(FinishButton);
        if (finishButton == null) return;
        finishButton.gameObject.SetActive(true);
    }


    public void hideButtons()
    {
        Debug.Log("Action => hide buttons in group");
        foreach (ButtonAction buttonAction in buttonActions)
        {
            Button button = UIManager.Instance.GetButton(buttonAction.buttonName);
            if (button == null) return;
            button.gameObject.SetActive(false);
        }
        Button finishButton = UIManager.Instance.GetButton(FinishButton);
        if (finishButton == null) return;
        finishButton.gameObject.SetActive(false);
    }

    public void subscribe()
    {
        foreach (ButtonAction buttonAction in buttonActions)
        {
            buttonAction.action.OnFinished.AddListener(showButtons);
        }
    }

    public override void Perform()
    {
        base.Perform();
        Debug.Log("Action => Wait For Buttion Group");
        foreach (ButtonAction buttonAction in buttonActions){
            Button button = UIManager.Instance.GetButton(buttonAction.buttonName);
            if (button == null) return;

            buttonAction.action.OnFinished.RemoveAllListeners();
            //buttonAction.action.OnFinished.AddListener(showButtons);

            //button.onClick.RemoveAllListeners();
            button.onClick.AddListener(subscribe);
            button.onClick.AddListener(buttonAction.action.Perform);
            button.onClick.AddListener(hideButtons);

            button.gameObject.SetActive(true);
        }

        Button finishButton = UIManager.Instance.GetButton(FinishButton);
        if (finishButton == null) return;
        finishButton.onClick.RemoveAllListeners();
        finishButton.onClick.AddListener(Finish);
        finishButton.onClick.AddListener(hideButtons);
        finishButton.gameObject.SetActive(true);
    }
}

[System.Serializable]
public class ButtonAction
{
    public string buttonName;
    public ActionBase action;
}
