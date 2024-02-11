using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEditor;

public class GetRequestSender : MonoBehaviour
{
    // The URL and the api point that we are going to send the Get request to
    private static string onLeftUrl = "10.103.55.106:5000/left/on";
    private static string offLeftUrl = "10.103.55.106:5000/left/off";
    private static string onRightUrl = "10.103.55.106:5000/right/on";
    private static string offRightUrl = "10.103.55.106:5000/right/off";
    private static string offAllUrl = "10.103.55.106:5000/all/off";
    private static string onAllUrl = "10.103.55.106:5000/all/on";
    private static string frequencyUrl = "10.103.55.106:5000/frequency";
    private static string lengthUrl = "10.103.55.106:5000/length";

    void Awake()
    {
        PlayerSettings.insecureHttpOption = InsecureHttpOption.AlwaysAllowed;
    }

    /// <summary>
    /// This is used to call the Get request to the webserver that is connected to the EMS device by starting a coroutine
    /// </summary>
    public void CallMuscleNeuropathyOnLeftGetRequest()
    {
        StartCoroutine(GetRequestSender.SendGetRequestOnLeft());
    }

    public void CallMuscleNeuropathyOffLeftGetRequest()
    {
        StartCoroutine(GetRequestSender.SendGetRequestOffLeft());
    }

    public void CallMuscleNeuropathyOnRightGetRequest()
    {
        StartCoroutine(GetRequestSender.SendGetRequestOnRight());
    }

    public void CallMuscleNeuropathyOffRightGetRequest()
    {
        StartCoroutine(GetRequestSender.SendGetRequestOffRight());
    }

    public void CallMuscleNeuropathyOnBothGetRequest()
    {
        StartCoroutine(GetRequestSender.SendGetRequestOnBoth());
    }

    public void CallMuscleNeuropathyOffBothGetRequest()
    {
        StartCoroutine(GetRequestSender.SendGetRequestOffBoth());
    }

    public void CallMuscleNeuropathyFrequencyGetRequest(float frequency)
    {
        StartCoroutine(GetRequestSender.SendGetRequestFrequency(200f));
    }

    public void CallMuscleNeuropathyLengthGetRequest(float frequency)
    {
        StartCoroutine(GetRequestSender.SendGetRequestLength(.05f));
    }


    /// <summary>
    /// Sends a Get request to the specified URL, basically to toggle the webserver connected to the EMS device
    /// </summary>
    /// <returns></returns>
    public static IEnumerator SendGetRequestOnLeft()
    {
        // Create a new request, set its method to GET
        UnityWebRequest www = UnityWebRequest.Get("http://"+GetRequestSender.onLeftUrl);
        Debug.Log("Sending http://"+onLeftUrl);
        // Send the request and wait for a response
        yield return www.SendWebRequest();
        Debug.Log(www.ToString());

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Get request sent successfully. Response: " + www.downloadHandler.text);
        }
    }

    public static IEnumerator SendGetRequestOffLeft()
    {
        // Create a new request, set its method to GET
        UnityWebRequest www = UnityWebRequest.Get("http://"+GetRequestSender.offLeftUrl);
        Debug.Log("Sending http://"+offLeftUrl);

        // Send the request and wait for a response
        yield return www.SendWebRequest();
        Debug.Log(www.ToString());

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error + " " + UnityWebRequest.Result.ConnectionError);
        }
        else
        {
            Debug.Log("Get request sent successfully. Response: " + www.downloadHandler.text);
        }
    }

     /// <summary>
    /// Sends a Get request to the specified URL, basically to toggle the webserver on that is connected to the EMS device for the right arm
    /// </summary>
    /// <returns></returns>
    public static IEnumerator SendGetRequestOnRight()
    {
        // Create a new request, set its method to GET
        UnityWebRequest www = UnityWebRequest.Get("http://"+GetRequestSender.onRightUrl);
        Debug.Log("Sending http://"+onRightUrl);
        // Send the request and wait for a response
        yield return www.SendWebRequest();
        Debug.Log(www.ToString());

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Get request sent successfully. Response: " + www.downloadHandler.text);
        }
    }

    /// <summary>
    /// Sends a Get request to the specified URL, basically to toggle the webserver off that is connected to the EMS device for the right arm
    /// </summary>
    /// <returns></returns>
    public static IEnumerator SendGetRequestOffRight()
    {
        // Create a new request, set its method to GET
        UnityWebRequest www = UnityWebRequest.Get("http://"+GetRequestSender.offRightUrl);
        Debug.Log("Sending http://"+offRightUrl);

        // Send the request and wait for a response
        yield return www.SendWebRequest();
        Debug.Log(www.ToString());

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error + " " + UnityWebRequest.Result.ConnectionError);
        }
        else
        {
            Debug.Log("Get request sent successfully. Response: " + www.downloadHandler.text);
        }
    }

    public static IEnumerator SendGetRequestOnBoth()
    {
        // Create a new request, set its method to GET
        UnityWebRequest www = UnityWebRequest.Get("http://"+GetRequestSender.onAllUrl);
        Debug.Log("Sending http://"+offRightUrl);

        // Send the request and wait for a response
        yield return www.SendWebRequest();
        Debug.Log(www.ToString());

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error + " " + UnityWebRequest.Result.ConnectionError);
        }
        else
        {
            Debug.Log("Get request sent successfully. Response: " + www.downloadHandler.text);
        }
    }

    public static IEnumerator SendGetRequestOffBoth()
    {
       // Create a new request, set its method to GET
        UnityWebRequest www = UnityWebRequest.Get("http://"+GetRequestSender.offAllUrl);
        Debug.Log("Sending http://"+offRightUrl);

        // Send the request and wait for a response
        yield return www.SendWebRequest();
        Debug.Log(www.ToString());

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error + " " + UnityWebRequest.Result.ConnectionError);
        }
        else
        {
            Debug.Log("Get request sent successfully. Response: " + www.downloadHandler.text);
        }
    }

    public static IEnumerator SendGetRequestFrequency(float frequency)
    {
        // Create a new request, set its method to GET
        UnityWebRequest www = UnityWebRequest.Get("http://"+GetRequestSender.frequencyUrl + "?amount=" + frequency);
        Debug.Log("Sending http://"+frequencyUrl + "?amount=" + frequency);

        // Send the request and wait for a response
        yield return www.SendWebRequest();
        Debug.Log(www.ToString());

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error + " " + UnityWebRequest.Result.ConnectionError);
        }
        else
        {
            Debug.Log("Get request sent successfully. Response: " + www.downloadHandler.text);
        }
    }

    public static IEnumerator SendGetRequestLength(float length)
    {
        // Create a new request, set its method to GET
        UnityWebRequest www = UnityWebRequest.Get("http://"+GetRequestSender.lengthUrl + "?amount=" + length);
        Debug.Log("Sending http://"+lengthUrl + "?amount=" + length);

        // Send the request and wait for a response
        yield return www.SendWebRequest();
        Debug.Log(www.ToString());

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error + " " + UnityWebRequest.Result.ConnectionError);
        }
        else
        {
            Debug.Log("Get request sent successfully. Response: " + www.downloadHandler.text);
        }
    }
}