using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class MuscleNeuropothy : MonoBehaviour
{
    [SerializeField]public GetRequestSender getRequestSender;
    // Start is called before the first frame update
    void Start()
    {
        if (getRequestSender == null)
        {
            Debug.LogError("getRequestSender is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// This is used to call the POST request to the webserver that is connected to the EMS device by starting a coroutine
    /// </summary>
    public void CallMuscleNeuropathyOnLeftPostRequest()
    {
        getRequestSender.CallMuscleNeuropathyOnLeftGetRequest();
    }

    public void CallMuscleNeuropathyOffLeftPostRequest()
    {
        getRequestSender.CallMuscleNeuropathyOffLeftGetRequest();
    }

    /// <summary>
    /// This is used to call the POST request to the webserver that is connected to the EMS device by starting a coroutine
    /// </summary>
    private void CallMuscleNeuropathyOnRightPostRequest()
    {
        getRequestSender.CallMuscleNeuropathyOnRightGetRequest();
    }

    private void CallMuscleNeuropathyOffRightPostRequest()
    {
        getRequestSender.CallMuscleNeuropathyOffRightGetRequest();
    }

    private void CallMuscleNeuropathyOnBothPostRequest()
    {
        getRequestSender.CallMuscleNeuropathyOnBothGetRequest();
    }

    private void CallMuscleNeuropathyOffBothPostRequest()
    {
        getRequestSender.CallMuscleNeuropathyOffBothGetRequest();
    }

    private void CallMuscleNeuropathyFrequencyPostRequest(float frequency)
    {
        getRequestSender.CallMuscleNeuropathyFrequencyGetRequest(frequency);
    }

    private void CallMuscleNeuropathyLengthPostRequest(float length)
    {
        getRequestSender.CallMuscleNeuropathyLengthGetRequest(length);
    }

    public void MuscleParkinsonDisease()
    {
        CallMuscleNeuropathyLengthPostRequest(.05f);
        CallMuscleNeuropathyFrequencyPostRequest(200f);
        CallMuscleNeuropathyOnBothPostRequest();
    }

    public void MuscleParkinsonDiseaseOff()
    {
        CallMuscleNeuropathyOffBothPostRequest();
    }

    public void MusclePeripheralNeuropathy()
    {
        CallMuscleNeuropathyLengthPostRequest(.25f);
        CallMuscleNeuropathyFrequencyPostRequest(10f);
        CallMuscleNeuropathyOnBothPostRequest();
    }

    public void MusclePeripheralNeuropathyOff()
    {
        CallMuscleNeuropathyOffBothPostRequest();
    }

    //EEee33##
}
