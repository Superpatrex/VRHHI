using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public enum Impairment
{
    DIABETICRETINOPATHY,
    GLAUCOME,
    MACULARDEGENERATION,
    CATARACTS,
    PARKINSONS,
    NEUROPATHY,
    NONE
}

public class GrandController : MonoBehaviour
{
    private static Impairment last_impairment = Impairment.NONE;
    [SerializeField] private static GrandController grandController;
    [SerializeField] public MuscleNeuropothy muscleNeuropathy;
    [SerializeField] public ChangeVision changeVision;

    void Start()
    {
        grandController = this;
    }

    public static void removeLastImpairment()
    {
        switch (last_impairment)
        {
            case Impairment.DIABETICRETINOPATHY:
            case Impairment.GLAUCOME:
            case Impairment.MACULARDEGENERATION:
            case Impairment.CATARACTS:
                grandController.changeVision.ChangeImage(ChangeVision.typeOfVisionImpairment.NONDISABLED);
                break;
            case Impairment.PARKINSONS:
                grandController.muscleNeuropathy.MuscleParkinsonDiseaseOff();
                break;
            case Impairment.NEUROPATHY:
                grandController.muscleNeuropathy.MusclePeripheralNeuropathyOff();
                break;
            case Impairment.NONE:
                Debug.LogError("There is no impairment to remove FFFFFUUUUUUUUUU........");
                break;
        }

        last_impairment = Impairment.NONE;
    }

    public static void setImpairment(string new_impairment)
    {
        if (last_impairment != Impairment.NONE)
        {
            Debug.Log("you are a monster this man is already impaired");
            return;
        }

        Impairment enum_new_impairment = (Impairment)System.Enum.Parse(typeof(Impairment), new_impairment);
        switch (enum_new_impairment)
        {
            case Impairment.DIABETICRETINOPATHY:
                grandController.changeVision.ChangeImage(ChangeVision.typeOfVisionImpairment.DIABETICRETINOPATHY);
                break;
            case Impairment.GLAUCOME:
                grandController.changeVision.ChangeImage(ChangeVision.typeOfVisionImpairment.GLAUCOME);
                break;
            case Impairment.MACULARDEGENERATION:
                grandController.changeVision.ChangeImage(ChangeVision.typeOfVisionImpairment.MACULARDEGENERATION);
                break;
            case Impairment.CATARACTS:
                grandController.changeVision.ChangeImage(ChangeVision.typeOfVisionImpairment.CATARACTS);
                break;
            case Impairment.PARKINSONS:
                grandController.muscleNeuropathy.MuscleParkinsonDisease();
                break;
            case Impairment.NEUROPATHY:
                grandController.muscleNeuropathy.MusclePeripheralNeuropathy();
                break;
            case Impairment.NONE:
                Debug.LogError("You are kinda stupid ngl if you are trying to set nothing");
                break;
            default:
                Debug.LogError("You are a monster you are trying to set an impairment that does not exist    " + new_impairment + "   FFFFFUUUUUUUUUU........");
                break;
        }

        last_impairment = enum_new_impairment;
    }
}
