using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public GameObject item;
    public bool empty;
    public Sprite icon;
    public int slotNum;
    public bool equipped;

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
        guiStyleFore.fontSize = 24;
        guiStyleBack = new GUIStyle();
        guiStyleBack.normal.textColor = Color.black;
        guiStyleBack.alignment = TextAnchor.UpperCenter;
        guiStyleBack.wordWrap = true;
        guiStyleBack.fontSize = 24;

        tooltipText = "Attack: " + weaponDamage + "\nSpeed: " + weaponSpeed + "\nRange: " + weaponRange;
    }

    private void Update()
    {
       
    }

    public void UpdateSlot()
    {
        this.GetComponent<Image>().sprite = icon;
    }

    // Update is called once per frame
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (empty == false)
        {
            tooltipText = "Attack: " + weaponDamage + "\nSpeed: " + weaponSpeed + "\nRange: " + weaponRange;
            currentTooltipText = tooltipText;
        }
    }
    

    public void OnPointerExit(PointerEventData eventData)
    {
        currentTooltipText = "";
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        if (eventData.button == PointerEventData.InputButton.Right && empty == false && equipped == false)
        {

            Vector3 position = GameObject.FindWithTag("MainPlayer").transform.GetChild(0).transform.position;
            //Vector3 position = new Vector3(0,2,-12);
            item.SetActive(true);
            GameObject copy = Instantiate(item, position, Quaternion.identity);
            copy.GetComponent<ItemDropScript>().weaponDamage = item.GetComponent<ItemDropScript>().weaponDamage;
            copy.GetComponent<ItemDropScript>().weaponSpeed = item.GetComponent<ItemDropScript>().weaponSpeed;
            copy.GetComponent<ItemDropScript>().weaponRange = item.GetComponent<ItemDropScript>().weaponRange;
            empty = true;
            Destroy(item);
            this.GetComponent<Image>().sprite = null;
            this.GetComponent<Image>().color = new Color32(255, 204, 81, 255);

        }
        else if(eventData.button == PointerEventData.InputButton.Left && empty == false && equipped == false)
        {
            GameObject.Find("GameManager").GetComponent<InventroyScript>().ItemEquipped(slotNum);
        }

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
