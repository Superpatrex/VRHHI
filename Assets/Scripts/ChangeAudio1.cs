using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAudio : MonoBehaviour
{
    public enum typeOfHearingImpairment
    {
        HEARINGDAMAGE,
        NONE
    }

    public enum whichDamnAudio
    {
        MENU,
        CATARACTSDESCRIPTION,
        DIABETICRETINOPATHYDESCRIPTION,
        GLAUCOMADESCRIPTION,
        MACULARDEGENERATIONDESCRIPTION,
        PERIPHERALNEUROPATHYDESCRIPTION,
        PARKINSONSDESCRIPTION
    }

    [SerializeField] public AudioSource audioSourceImpairment;
    [SerializeField] public AudioSource audioSourceInformation;
    [SerializeField] public AudioClip whiteNoise;
    [SerializeField] public typeOfHearingImpairment hearingImpairment;
    [SerializeField] public AudioClip menuAudio;
    [SerializeField] public AudioClip cataractsAudioDescription;
    [SerializeField] public AudioClip diabeticRetinopathyAudioDescription;
    [SerializeField] public AudioClip glacomaAudioDescription;
    [SerializeField] public AudioClip macularDegenerationAudioDescription;
    [SerializeField] public AudioClip peripheralNeuropathyAudioDescription;
    [SerializeField] public AudioClip parkinsonsAudioDescription;

    // Start is called before the first frame update
    void Start()
    {
        hearingImpairment = typeOfHearingImpairment.NONE;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeAudioClip(typeOfHearingImpairment type)
    {
        if (type == typeOfHearingImpairment.NONE)
        {
            Debug.LogError("You are trying to change the audio to NONE. This is not allowed. Use StopAudio() instead. Are you an idiot, a fool, a moron, a dunderhead, a simpleton, a imbecile, a cretin, a halfwit, a nitwit, a nincompoop, a blockhead, a jerk, a dolt, a dimwit, a dummy, a dunce, a dork, a sap, a chump, a bonehead, a fathead, a num");
        }

        switch(type)
        {
            case typeOfHearingImpairment.HEARINGDAMAGE:
                audioSourceImpairment.clip = whiteNoise;
                audioSourceImpairment.loop = true;
                audioSourceImpairment.Play();
                break;
            case typeOfHearingImpairment.NONE:
                audioSourceImpairment.clip = null;
                audioSourceImpairment.Stop();
                break;
        }
    }

    public void StopAudioImpairment()
    {
        audioSourceImpairment.clip = null;
        audioSourceImpairment.Stop();
    }

    public void PlayAudioRecordings(string audio)
    {
        if (audioSourceInformation.isPlaying)
        {
            audioSourceInformation.Stop();
            audioSourceInformation.clip = null;
            return;
        }

        whichDamnAudio funkyAudio = (whichDamnAudio)System.Enum.Parse(typeof(whichDamnAudio), audio);

        switch(funkyAudio)
        {
            case whichDamnAudio.MENU:
                audioSourceInformation.clip = menuAudio;
                audioSourceInformation.loop = false;
                audioSourceInformation.Play();
                break;
            case whichDamnAudio.CATARACTSDESCRIPTION:
                audioSourceInformation.clip = cataractsAudioDescription;
                audioSourceInformation.loop = false;
                audioSourceInformation.Play();
                break;
            case whichDamnAudio.DIABETICRETINOPATHYDESCRIPTION:
                audioSourceInformation.clip = diabeticRetinopathyAudioDescription;
                audioSourceInformation.loop = false;
                audioSourceInformation.Play();
                break;
            case whichDamnAudio.GLAUCOMADESCRIPTION:
                audioSourceInformation.clip = glacomaAudioDescription;
                audioSourceInformation.loop = false;
                audioSourceInformation.Play();
                break;
            case whichDamnAudio.MACULARDEGENERATIONDESCRIPTION:
                audioSourceInformation.clip = macularDegenerationAudioDescription;
                audioSourceInformation.loop = false;
                audioSourceInformation.Play();
                break;
            case whichDamnAudio.PERIPHERALNEUROPATHYDESCRIPTION:
                audioSourceInformation.clip = peripheralNeuropathyAudioDescription;
                audioSourceInformation.loop = false;
                audioSourceInformation.Play();
                break;
            case whichDamnAudio.PARKINSONSDESCRIPTION:
                audioSourceInformation.clip = parkinsonsAudioDescription;
                audioSourceInformation.loop = false;
                audioSourceInformation.Play();
                break;  
        }
    }

    public void StopAudioWhenChangingMenus()
    {
        if (audioSourceInformation.isPlaying)
        {
            audioSourceInformation.Stop();
            audioSourceInformation.clip = null;
        }
    }
}
