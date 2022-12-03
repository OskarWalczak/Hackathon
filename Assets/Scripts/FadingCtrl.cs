using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;

public class FadingCtrl : MonoBehaviour
{

    private Light2D playerLight;
    private float m_FadingSpeed = 0.0005f;
    private float m_RechargeRate = 0.1f;
    private float m_InnerRadiusFadingSpeed = 0.02f;
    private float m_InnerRadiusRechargeRate = 1f;
    private float m_OuterRadiusFadingSpeed = 0.06f;
    private float m_OuterRadiusRechargeRate = 3f;

    // Start is called before the first frame update
    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;

        playerLight = GetComponent<Light2D>();
        playerLight.intensity = 1;
        playerLight.pointLightInnerRadius = 20;
        playerLight.pointLightOuterRadius = 60;
    }

    // Update is called once per frame
    void Update()
    {
        playerLight.intensity = Mathf.Max(0, playerLight.intensity - m_FadingSpeed);
        playerLight.pointLightInnerRadius = Mathf.Max(0, playerLight.pointLightInnerRadius - m_InnerRadiusFadingSpeed);
        playerLight.pointLightOuterRadius = Mathf.Max(0, playerLight.pointLightOuterRadius - m_OuterRadiusFadingSpeed);
        
        if(Input.GetKey("c") && Input.GetKey("p"))
        {        
            playerLight.intensity = Mathf.Min(1, playerLight.intensity + m_RechargeRate);
            playerLight.pointLightInnerRadius = Mathf.Min(20, playerLight.pointLightInnerRadius + m_InnerRadiusRechargeRate);
            playerLight.pointLightOuterRadius = Mathf.Min(60, playerLight.pointLightOuterRadius + m_OuterRadiusRechargeRate);
        }
    }
}
