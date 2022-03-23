using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Button Action", menuName = "Action/Button Action", order = 1)]
public class WaitForButtonAction : ActionBase
{
    public string buttonID = "";
    public bool showButton = true;

    public override void Finish()
    {
        Debug.Log("Action => Button " + buttonID + " pressed");
        
        Button button = UIManager.Instance.GetButton(buttonID);
        button.onClick.RemoveListener(Finish);
        button.gameObject.SetActive(false);
        base.Finish();
    }

    public override void Perform()
    {
        Debug.Log("Action => Wait for " + buttonID + " Button");

        base.Perform();

        Button button = UIManager.Instance.GetButton(buttonID);
        button.gameObject.SetActive(true);
        button.onClick.AddListener(Finish);

    }
}
