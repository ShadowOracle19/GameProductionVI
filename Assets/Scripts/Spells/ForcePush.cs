using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

public class ForcePush : MonoBehaviour
{
    public float pushAmount = 1000;
    public float pushRadius = 10;

    public GameObject forceFieldPrefab;
    private Vector3 scaleChange = new Vector3(0f, 0f, 0f);
    //public Animator PlayerAnimator;
    //public float shakeDuration = 0.3f;
    //public float shakeAmplitude = 1.2f;
    //public float shakeFrequency = 2.0f;

    //private float shakeElapsedTime = 0f;

    //public CinemachineFreeLook Vcam;
    //private CinemachineBasicMultiChannelPerlin VcamNoise;

    void Start()
    {
        //Debug.Log(Vcam.VirtualCameraGameObject.GetComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            DoPush();
            var shield = Instantiate(forceFieldPrefab, gameObject.transform.position, Quaternion.identity) as GameObject;
            shield.transform.localScale = scaleChange;
            StartCoroutine(grow(shield));
        }
        
    }

    private void DoPush()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, pushRadius);
        
        foreach (Collider pushedObjec in colliders)
        {
            if (pushedObjec.CompareTag("Enemy"))
            {
                Rigidbody pushedBody = pushedObjec.GetComponent<Rigidbody>();
                Debug.Log(pushedObjec.gameObject.tag);
                pushedBody.AddExplosionForce(pushAmount, gameObject.transform.position, pushRadius);
            }
        }
    }
    
    IEnumerator grow(GameObject shield)
    {
        //shakeElapsedTime = shakeDuration;

        //if(Vcam != null || VcamNoise != null)
        //{
        //    if(shakeElapsedTime > 0)
        //    {
        //        VcamNoise.m_AmplitudeGain = shakeAmplitude;
        //        VcamNoise.m_FrequencyGain = shakeFrequency;

        //        shakeElapsedTime -= Time.deltaTime;
        //    }

        //    else
        //    {
        //        VcamNoise.m_AmplitudeGain = 0f;
        //        shakeElapsedTime = 0f;
        //    }
        //}
        //PlayerAnimator.SetInteger("AnimController", 1);

        float j = 10;
        yield return new WaitForSeconds(0.1f);
        for (float i = 0; i < 10; i++)
        {
            shield.transform.localScale += new Vector3(i, i, i);
            yield return new WaitForSeconds(0.007f);
        }
        

        yield return new WaitForSeconds(1.0f);
        for (float i = 0; i < 10; i++)
        { 
            j -= 1;
            shield.transform.localScale -= new Vector3(j, j, j);
            yield return new WaitForSeconds(0.007f);
        }
        //PlayerAnimator.SetInteger("AnimController", 0);
        Destroy(shield);
        yield return new WaitForSeconds(0.001f);

    }

}
