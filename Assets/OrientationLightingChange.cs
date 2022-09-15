using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientationLightingChange : MonoBehaviour
{

    public GameObject knickknackObject;
    public GameObject sunlightObject;
    public GameObject rainfallObject;
    public GameObject cloudObject;
    bool sunIsShining = true;
    bool isUpsideDown;
    bool isRightsideUp;

    // Start is called before the first frame update
    void Start()
    {
       // Debug.Log(":\nKnickKnack Transformation: " + knickknackObject.transform.rotation.eulerAngles.x);
       InvokeRepeating("callLightingCoroutine", 0f, 2f);
    }

    void callLightingCoroutine()
    {
        StartCoroutine(lightingChanger());
    }

    bool checkIfUpsideDown()
    {
        float RotationX;
        float RotationY;
        float RotationZ;

        RotationX = knickknackObject.transform.localEulerAngles.x;
        RotationY = knickknackObject.transform.localEulerAngles.y;
        RotationZ = knickknackObject.transform.localEulerAngles.z;

        if(Mathf.Abs(RotationZ - 180f) <= 30) {
            return true;

        }
        else
        {
            return false;
        }
    }

    bool checkIfRightsideUp()
    {
        float RotationX;
        float RotationY;
        float RotationZ;

        RotationX = knickknackObject.transform.localEulerAngles.x;
        RotationY = knickknackObject.transform.localEulerAngles.y;
        RotationZ = knickknackObject.transform.localEulerAngles.z;

        if(Mathf.Abs(RotationZ - 180f) <= 30) 
        {
            isRightsideUp = false;
            return false;

        }
        else
        {
            isRightsideUp = true;
            return true;
        }
    }

    // public IEnumerator WaitUntilTrue(Func<bool> checkMethod)
    //     {
    //         while (checkMethod() == false)
    //         {
    //             yield return null;
    //         }
    //     }

    // Update is called once per frame
    IEnumerator lightingChanger()
    {
        // Debug.Log(":\nKnickKnack Transformation X: " + knickknackObject.transform.rotation.eulerAngles.x);
        // Debug.Log(":\nKnickKnack Transformation Y: " + knickknackObject.transform.rotation.eulerAngles.y);
        // Debug.Log(":\nKnickKnack Transformation Z: " + knickknackObject.transform.rotation.eulerAngles.z);
        
        float RotationX;
        float RotationY;
        float RotationZ;

        RotationX = knickknackObject.transform.localEulerAngles.x;
        RotationY = knickknackObject.transform.localEulerAngles.y;
        RotationZ = knickknackObject.transform.localEulerAngles.z;

        Debug.Log("\n beginning lighting changer");

        // Light sunshine = sunlightObject.GetComponent<Light>();

        // if(Mathf.Abs(RotationZ - 180f) <= 30 && sunIsShining == true)
        // {
            
        //     sunshine.intensity = 0;
        //     sunIsShining = false;
        // }
        // else if(Mathf.Abs(RotationZ - 180f) > 30 && sunIsShining == false)
        // {
        //     sunshine.intensity = 5;
        //     sunIsShining = true;
        // }

        // if(Mathf.Abs(RotationZ - 180f) <= 30) {
        //     isUpsideDown = true;
        // }
        // else
        // {
        //     isUpsideDown = false;
        // }

        if(checkIfUpsideDown() == true)
        {
            Debug.Log("\n Is up side down");
            // wait until right side up again
            checkIfRightsideUp();
            yield return new WaitUntil(checkIfRightsideUp);
            Debug.Log("\n Is right side up ");
            if(sunIsShining == true)
            {
                sunlightObject.SetActive(false);
                sunIsShining = false;
                cloudObject.SetActive(true);
                Debug.Log("\n sun off, cloud active");
            }
            else if(sunIsShining == false) {
                sunlightObject.SetActive(true);
                sunIsShining = true;
                cloudObject.SetActive(false);
                Debug.Log("\n sun active, cloud off");
            }
        }

        /*
        if(knickknackObject.transform.rotation.eulerAngles.x <= 180f)
        {
            RotationX = knickknackObject.transform.rotation.eulerAngles.x;
        }
        else
        {
            RotationX = knickknackObject.transform.rotation.eulerAngles.x - 360f;
        }

        if(knickknackObject.transform.rotation.eulerAngles.y <= 180f)
        {
            RotationY = knickknackObject.transform.rotation.eulerAngles.y;
        }
        else
        {
            RotationY = knickknackObject.transform.rotation.eulerAngles.y - 360f;
        }

        if(knickknackObject.transform.rotation.eulerAngles.z <= 180f)
        {
            RotationZ = knickknackObject.transform.rotation.eulerAngles.z;
        }
        else
        {
            RotationZ = knickknackObject.transform.rotation.eulerAngles.z - 360f;
        } */


        Debug.Log(":\nRotation X: " + RotationX);
        Debug.Log(":\nRotation Y: " + RotationY);
        Debug.Log(":\nRotation Z: " + RotationZ);

    }
}
