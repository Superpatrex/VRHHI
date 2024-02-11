using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MAKETHISWORK : MonoBehaviour
{
    [SerializeField] public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowMenu()
    {
        menu.SetActive(!menu.activeSelf);
    }

    public void HideMenu()
    {
        menu.SetActive(false);
    }

    // NOT TO SELF, GET AUGUST TO FIX MAYBE BUG WITH THE MENU. Basically, the menu and the controller are not the same. So it it might toggle the controller and the menu will be untoggled
    // and the menu might be toggled and the controller might be untoggled. So, the menu and the controller are not the same. So, the menu and the controller are not the same. We need them both
    // toggled when the gesture is performed.
}
