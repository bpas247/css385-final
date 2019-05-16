using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTooltip : MonoBehaviour
{

    string tooltipText = "Attack: 1\nSpeed: 1\nRange: 1";

    private string currentTooltipText = "";
    GUIStyle guiStyleFore;
    GUIStyle guiStyleBack;


    // Start is called before the first frame update
    void Start()
    {
        guiStyleFore = new GUIStyle();
        guiStyleFore.normal.textColor = Color.white;
        guiStyleFore.alignment = TextAnchor.UpperCenter;
        guiStyleFore.wordWrap = true;
        guiStyleBack = new GUIStyle();
        guiStyleBack.normal.textColor = Color.black;
        guiStyleBack.alignment = TextAnchor.UpperCenter;
        guiStyleBack.wordWrap = true;
    }

    // Update is called once per frame
    private void OnMouseEnter()
    {
        currentTooltipText = tooltipText;
    }

    private void OnMouseExit()
    {
        currentTooltipText = "";
    }

    private void OnGUI()
    {
        if (currentTooltipText != "")
        {
            float x = Event.current.mousePosition.x;
            float y = Event.current.mousePosition.y;
            GUI.Label(new Rect(x - 149, y + 21, 300, 60), currentTooltipText, guiStyleBack);
            GUI.Label(new Rect(x - 150, y + 20, 300, 60), currentTooltipText, guiStyleFore);
        }
    }
}
