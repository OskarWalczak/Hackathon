using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadingCtrl : MonoBehaviour
{

    private Image m_FadeScreen;
    private float m_FadingSpeed = 0.005f;
    private float m_RechargeRate = 0.1f;

    // Start is called before the first frame update
    private void Awake()
    {
        m_FadeScreen = GameObject.Find("Image").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        {
            Color backgroundColor = m_FadeScreen.color;
            float newAlpha = Mathf.Min(255, backgroundColor.a + m_FadingSpeed);
            backgroundColor.a = newAlpha;
            m_FadeScreen.color = backgroundColor;
        }

        if(Input.GetKey("c") && Input.GetKey("p"))
        {
            Color backgroundColor = m_FadeScreen.color;
            float newAlpha = Mathf.Max(0, backgroundColor.a - m_RechargeRate);
            backgroundColor.a = newAlpha;
            m_FadeScreen.color = backgroundColor;
        }
    }
}
