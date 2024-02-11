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
}
