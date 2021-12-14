using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolTip : MonoBehaviour
{
    public string message;
    /// <summary>
    /// this function is callled upon when the cursor is on our object
    /// </summary>
    private void OnMouseEnter()
    {
        ToolTipManager._instance.showToolTip(message);
        Debug.Log("show me the toooltip");

    }
    private void OnMouseExit()
    {
        ToolTipManager._instance.hideTooltip();
        Debug.Log("hide the toooltip");
    }
}
