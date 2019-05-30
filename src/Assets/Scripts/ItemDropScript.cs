using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropScript : MonoBehaviour
{
    string tooltipText = "Attack: 1\nSpeed: 1\nRange: 1";

    public int weaponDamage = 0;
    public double weaponSpeed = 0;
    public double weaponRange = 0;

    public Texture2D icon;
    public bool pickedUp;
    private bool hovering;

    private string currentTooltipText = "";
    GUIStyle guiStyleFore;
    GUIStyle guiStyleBack;


    // Start is called before the first frame update
    public ItemDropScript()
    {
        weaponDamage = 100;
        weaponSpeed = 1.0;
        weaponRange = 1.0;
    }

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

        getWeaponDamage();
        getWeaponSpeed();
        getWeaponRange();

        tooltipText = "Attack: " + weaponDamage + "\nSpeed: " + weaponSpeed + "\nRange: " + weaponRange;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && hovering)
        {
            GameObject.Find("GameManager").GetComponent<InventroyScript>().itemClicked(this.gameObject);
        }
    }

    // Update is called once per frame
    private void OnMouseEnter()
    {
        currentTooltipText = tooltipText;
        hovering = true;
    }

    private void OnMouseExit()
    {
        currentTooltipText = "";
        hovering = false;
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

    private void getWeaponDamage()
    {
        int damageTier = Random.Range(0, 101);

        if (damageTier >= 95)
        {
            weaponDamage = Random.Range(250, 301);

        }
        else if (damageTier >= 75)
        {
            weaponDamage = Random.Range(175, 250);
        }
        else if (damageTier > 30)
        {
            weaponDamage = Random.Range(125, 175);
        }
        else
        {
            weaponDamage = Random.Range(50, 125);
        }
    }

    private void getWeaponSpeed()
    {
        int speedTier = Random.Range(0, 101);
        float tempSpeed = 0;

        if (speedTier >= 95)
        {
            tempSpeed = Random.Range(1.75f, 2.01f);

        }
        else if (speedTier >= 75)
        {
            tempSpeed = Random.Range(1.5f, 1.76f);
        }
        else if (speedTier > 30)
        {
            tempSpeed = Random.Range(1.0f, 1.31f);
        }
        else
        {
            tempSpeed = Random.Range(.75f, 1.0f);
        }

        weaponSpeed = System.Math.Round(tempSpeed, 2);
    }

    private void getWeaponRange()
    {
        int rangeTier = Random.Range(0, 101);
        float tempRange = 0;

        if (rangeTier >= 95)
        {
            tempRange = Random.Range(1.75f, 2.01f);

        }
        else if (rangeTier >= 75)
        {
            tempRange = Random.Range(1.25f, 1.76f);
        }
        else if (rangeTier > 30)
        {
            tempRange = Random.Range(1.0f, 1.25f);
        }
        else
        {
            tempRange = Random.Range(.75f, 1.0f);
        }

        weaponRange = System.Math.Round(tempRange, 2);
    }
}
