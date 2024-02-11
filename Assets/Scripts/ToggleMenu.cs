using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMenu : MonoBehaviour
{
    [SerializeField] GameObject content;
    [SerializeField] GameObject menu;
    [SerializeField] Transform playerCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Toggle()
    {
        content.SetActive(!content.activeSelf);
        menu.transform.localPosition = new Vector3(menu.transform.localPosition.x,playerCamera.position.y,menu.transform.localPosition.z);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
