using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject item;
    public bool empty;
    public Texture2D icon;

    public int weaponDamage = 0;
    public double weaponSpeed = 0;
    public double weaponRange = 0;

    string tooltipText = "Attack: 1\nSpeed: 1\nRange: 1";
    private string currentTooltipText = "";
    GUIStyle guiStyleFore;
    GUIStyle guiStyleBack;

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

        tooltipText = "Attack: " + weaponDamage + "\nSpeed: " + weaponSpeed + "\nRange: " + weaponRange;
    }

    private void Update()
    {
       
    }

    public void UpdateSlot()
    {
        this.GetComponent<Image>().sprite = Sprite.Create(icon, new Rect(0, 0, icon.width, icon.height) , new Vector2(0.5f, 0.5f));
    }

    // Update is called once per frame
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(empty == false)
        {
            currentTooltipText = tooltipText;
        }
    }
    

    public void OnPointerExit(PointerEventData eventData)
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
