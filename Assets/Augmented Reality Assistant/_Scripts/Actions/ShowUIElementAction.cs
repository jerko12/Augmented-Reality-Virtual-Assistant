using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Show UI Element", menuName = "Action/Show UI Element", order = 1)]
public class ShowUIElementAction : ActionBase
{
    public string UiElementName = "";
    public override void Perform()
    {
        base.Perform();
        UI_Element element = UIManager.Instance.GetUIElement(UiElementName);
        element.gameObject.SetActive(true);
        Finish();
    }
}
