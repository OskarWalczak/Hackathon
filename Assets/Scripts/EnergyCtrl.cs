using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyCtrl : MonoBehaviour
{
    private CircleMovement player;
    private float m_EnergyDrainSpeed = 0.005f;
    private float m_EnergyRechargeRate = 1f;

    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CircleMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        // player.m_Energy =  Mathf.Max(0.2f, player.m_Energy - m_EnergyDrainSpeed);
        // if(Input.GetKey("v"))
        // {
        //     player.m_Energy =  Mathf.Min(1.2f, player.m_Energy + m_EnergyRechargeRate);
        // }

    }
}
