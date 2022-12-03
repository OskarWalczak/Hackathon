using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformSpeedCtrl : MonoBehaviour
{
    private GameObject[] platforms;
    private float m_SpeedDrain = 0.02f;
    private float m_SpeedRechargeRate = 2f;

    // Start is called before the first frame update
    private void Awake()
    {
        platforms = GameObject.FindGameObjectsWithTag("MovingPlatform");
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject obj in platforms)
        {
            Rotating platform = obj.GetComponent<Rotating>();
            platform.speed =  Mathf.Max(0f, platform.speed - m_SpeedDrain);
            if(Input.GetKey("x"))
            {
                platform.speed =  Mathf.Min(40f, platform.speed + m_SpeedRechargeRate);
            }
        }
    }
}
