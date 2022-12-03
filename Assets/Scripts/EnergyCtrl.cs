using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyCtrl : MonoBehaviour
{
    private CircleMovement player;
    private Slider slider;
    private float m_EnergyDrainSpeed = 0.0005f;
    private float m_EnergyRechargeRate = 0.1f;

    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CircleMovement>();
        slider = GameObject.Find("EnergySlider").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        player.m_Energy =  Mathf.Max(0.2f, player.m_Energy - m_EnergyDrainSpeed);
        if(Input.GetKey("v"))
        {
            player.m_Energy =  Mathf.Min(1.2f, player.m_Energy + m_EnergyRechargeRate);
        }
        slider.value = player.m_Energy;
    }
}
