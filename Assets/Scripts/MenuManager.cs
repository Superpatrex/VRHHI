using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class MenuManager : MonoBehaviour
{
    
    private GameObject menu;
    public InputActionProperty showButton;
    // Start is called before the first frame update
    void Start()
    {
        menu = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(showButton.action.WasPerformedThisFrame())
        {
            menu.SetActive(!menu.activeSelf);

        }
    }
}
