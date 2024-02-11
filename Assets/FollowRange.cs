using System.Collections;
using System.Collections.Generic;
using Core3lb;
using UnityEngine;

public class FollowRange : MonoBehaviour
{
    public GameObject rotationTarget;
    public float followMin = 0.5f;
    public float stopMin = 0.05f;
    private float deltaTime = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        deltaTime += Time.deltaTime;
        if (deltaTime >= 0.1f)
        {
            deltaTime -= 0.1f;
            Vector3 pos = this.transform.position;
            Vector3 target_pos = rotationTarget.transform.position;
            Vector3 diff = pos - target_pos;
            if (diff.magnitude < stopMin)
                GetComponent<FollowTarget>()._StopFollow();
            else if (diff.magnitude > followMin)
                GetComponent<FollowTarget>()._StartFollow();
        }
    }
}
