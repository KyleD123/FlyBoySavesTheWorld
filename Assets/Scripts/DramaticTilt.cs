using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DramaticTilt : MonoBehaviour
{
    public void Tilt()
    {
        StartCoroutine(RotateCam()); 
    }

    IEnumerator RotateCam()
    {
        float targetAngle = 358; // The target angle in degrees
        float speed = 10; // The speed of rotation in degrees per second

        // Rotate until the z angle is less than 358 (equivalent to -2)
        while (this.transform.localEulerAngles.z > targetAngle || this.transform.localEulerAngles.z < 2)
        {
            float angle = Mathf.MoveTowardsAngle(this.transform.localEulerAngles.z, targetAngle, speed * Time.deltaTime);
            this.transform.rotation = Quaternion.Euler(this.transform.localEulerAngles.x, this.transform.localEulerAngles.y, angle);
            yield return null;
        }

        yield return new WaitForSeconds(3);

        targetAngle = 0; // Change the target angle

        // Rotate until the z angle is greater than 0
        Debug.Log(this.transform.localEulerAngles.z);
        while (this.transform.localEulerAngles.z < targetAngle || this.transform.localEulerAngles.z >= 358)
        {
            float angle = Mathf.MoveTowardsAngle(this.transform.localEulerAngles.z, targetAngle, speed * Time.deltaTime);
            this.transform.rotation = Quaternion.Euler(this.transform.localEulerAngles.x, this.transform.localEulerAngles.y, angle);
            Debug.Log("RotatingBack");
            yield return null;
        }
    }





}
