using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.UI;

public class ChangeVision : MonoBehaviour
{
    // All of the fun pngs that we have for the different types of vision impairments
    [SerializeField]public Sprite [] DiabeticRetinopathyImages;
    [SerializeField]public Sprite [] MacularDegenerationImages;
    [SerializeField]public Sprite CataractsImage;
    [SerializeField]public Material CatractsMaterial;

    [SerializeField]public Image userImage;
    [SerializeField]public typeOfVisionImpairment visionImpairment;

    // The canvas that the images are displayed on, we use it to toggle and stuff
    [SerializeField] public Canvas canvas;
    
    // If isRandom is false then the indexUsedIfNotRandom is used to determine which image to use, else if it is true then it is random duh.
    [SerializeField]public bool isRandom;
    [SerializeField]public int indexUsedIfNotRandom;
    [SerializeField]public Material glacomaMaterial;
    [SerializeField]public Sprite macularDegenerationSprite;

    // Basically we want to know if the user has changed their vision impairment, so we can change the image
    private typeOfVisionImpairment lastVisionImpairment;

    // The different types of vision impairments that the user can have
    public enum typeOfVisionImpairment
    {
        DIABETICRETINOPATHY,
        GLAUCOME,
        MACULARDEGENERATION,
        CATARACTS,
        NONDISABLED,
        NOTSELECTEDYET
        
    }
    // Start is called before the first frame update
    void Start()
    {
        lastVisionImpairment = typeOfVisionImpairment.NOTSELECTEDYET;
    }

    // Update is called once per frame
    void Update()
    {
        if (visionImpairment == typeOfVisionImpairment.NOTSELECTEDYET)
        {  
            Debug.LogError("Vision impairment not selected. DO NOT USE NOTSELECTEDYET STOOOOPID!");
            return;
        }

        if (lastVisionImpairment != visionImpairment)
        {
            lastVisionImpairment = visionImpairment;
            ChangeImage(visionImpairment);
        }
    }

    /// <summary>
    /// Changes the user's vision to normal.
    /// </summary>
    void ChangeToNormalVision()
    {
        // Ensure that the canvas is not viewable
        canvas.gameObject.SetActive(false);
    }

    void ChangeToGlaucoma()
    {
        // Ensure that the canvas is viewable
        canvas.gameObject.SetActive(true);

        userImage.sprite = null;
        userImage.material = glacomaMaterial;
        SetImageToZero();
    }

    /// <summary>
    /// This method starts a diabetic retinopathy visual impairment, cycling through the images either randomly or in order
    /// </summary>
    void ChangeToDiabeticRetinopathy()
    {
        // Ensure that the canvas is viewable
        canvas.gameObject.SetActive(true);
        userImage.material = null;

        if (isRandom)
        {
            userImage.sprite = DiabeticRetinopathyImages[UnityEngine.Random.Range(0, DiabeticRetinopathyImages.Length)];
        }
        else
        {
            userImage.sprite = DiabeticRetinopathyImages[indexUsedIfNotRandom];
        }

        SetImageToZero();
    }

    /// <summary>
    /// This method starts a macular degeneration visual impairment, cycling through the images either randomly or in order
    /// </summary>
    void ChangeToMacularDegeneration()
    {
        // Ensure that the canvas is viewable
        canvas.gameObject.SetActive(true);
        userImage.material = null;
        userImage.sprite = macularDegenerationSprite;
        //userImage.transform.position = new Vector3(0, 0, 1000);
    }

    /// <summary>
    /// This method starts a cataracts visual impairment, cycling through the images either randomly or in order
    /// </summary>
    void ChangeToCataracts()
    {
        // Ensure that the canvas is viewable
        canvas.gameObject.SetActive(true);
        userImage.material = CatractsMaterial;
        userImage.sprite = CataractsImage;
        SetImageToZero();
    }

    /// <summary>
    /// This method changes the user's vision to the specified type of vision impairment, based on the enum
    /// </summary>
    /// <param name="type">The type of visual impairment that is the user is being subjected to</param>
    public void ChangeImage(typeOfVisionImpairment type)
    {
        if (type == typeOfVisionImpairment.DIABETICRETINOPATHY)
        {
            ChangeToDiabeticRetinopathy();
        }
        else if (type == typeOfVisionImpairment.GLAUCOME)
        {
            ChangeToGlaucoma();
        }
        else if (type == typeOfVisionImpairment.MACULARDEGENERATION)
        {
            ChangeToMacularDegeneration();
        }
        else if (type == typeOfVisionImpairment.CATARACTS)
        {
            ChangeToCataracts();
        }
        else if (type == typeOfVisionImpairment.NONDISABLED)
        {
            ChangeToNormalVision();
        }
    }

    void SetImageToZero()
    {
        //userImage.transform.position = new Vector3(0, 0, 0);
    }

    // RealVMCVR
    // cd Desktop
    // python3 EMSDevice.py
}