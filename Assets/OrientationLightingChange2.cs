using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientationLightingChange2 : MonoBehaviour
{

    public GameObject knickknackObject;
    public GameObject sunObject;
    public GameObject moonObject;
    bool sunIsShining = true;
    bool isUpsideDown;
    bool isRightsideUp;

    // Start is called before the first frame update
    void Start()
    {
       // Debug.Log(":\nKnickKnack Transformation: " + knickknackObject.transform.rotation.eulerAngles.x);
       InvokeRepeating("callLightingCoroutine2", 0f, 2f);
    }

    void callLightingCoroutine2()
    {
        StartCoroutine(lightingChanger2());
    }

    bool checkIfUpsideDown2()
    {
        Debug.Log("\n inside ifupsidedown2");

        float RotationX;
        float RotationY;
        float RotationZ;

        RotationX = knickknackObject.transform.localEulerAngles.x;
        RotationY = knickknackObject.transform.localEulerAngles.y;
        RotationZ = knickknackObject.transform.localEulerAngles.z;

        Debug.Log("\nifupsidedown2 rotation x " + RotationX);
        Debug.Log("\nifupsidedown2 rotation y " + RotationY);
        Debug.Log("\nifupsidedown2 rotation z " + RotationZ);

        if(Mathf.Abs(RotationZ - 180f) <= 30) {
            return true;

        }
        else
        {
            return false;
        }
    }

    bool checkIfRightsideUp2()
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


    // Update is called once per frame
    IEnumerator lightingChanger2()
    {
         Debug.Log(":\nKnickKnack Transformation X: " + knickknackObject.transform.rotation.eulerAngles.x);
         Debug.Log(":\nKnickKnack Transformation Y: " + knickknackObject.transform.rotation.eulerAngles.y);
         Debug.Log(":\nKnickKnack Transformation Z: " + knickknackObject.transform.rotation.eulerAngles.z);
        
        float RotationX;
        float RotationY;
        float RotationZ;

        RotationX = knickknackObject.transform.localEulerAngles.x;
        RotationY = knickknackObject.transform.localEulerAngles.y;
        RotationZ = knickknackObject.transform.localEulerAngles.z;

        Debug.Log("\n beginning lighting changer");

        // Light sunshine = sunObject.GetComponent<Light>();

        if(checkIfUpsideDown2() == true)
        {
            Debug.Log("\n Is up side down");
            // wait until right side up again
            checkIfRightsideUp2();
            yield return new WaitUntil(checkIfRightsideUp2);
            Debug.Log("\n Is right side up ");
            if(sunIsShining == true)
            {
                // sunshine.intensity = 0;
                sunIsShining = false;
                sunObject.SetActive(false);
                moonObject.SetActive(true);
                Debug.Log("\nsun set false");
            }
            else if(sunIsShining == false) {
                // sunshine.intensity = 20;
                sunIsShining = true;
                sunObject.SetActive(true);
                moonObject.SetActive(false);
                Debug.Log("\nsun set true");
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


        // Debug.Log(":\nRotation X: " + RotationX);
        // Debug.Log(":\nRotation Y: " + RotationY);
        // Debug.Log(":\nRotation Z: " + RotationZ);

    }
}
