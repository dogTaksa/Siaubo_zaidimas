using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    Light spotLight;
    public Transform batteryLevelIndicator;
    public bool isFlashlightEnabled = true;
    public bool isBlinkEnabled = true;

    public float batteryCharge = 1;
    public float batteryDischargePerSecond = 0.10f;
    public float batteryChargePerSecond = 0.10f;

    public float timerForDischarge = 0;
    public float timerForCharge = 0;
    private void Start()
    {
        spotLight = GetComponentInChildren<Light>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isFlashlightEnabled = !isFlashlightEnabled;

            if (!(batteryCharge <= 0))
            {
                isFlashlightToEnabled();
            }
        }

        if (isFlashlightEnabled == true)
        {
            timerForDischarge += Time.deltaTime;
            if (timerForDischarge >= 1)
            {
                batteryCharge -= batteryDischargePerSecond;
                timerForDischarge = 0;
            }
        }

        if (batteryCharge <= 0)
        {
            spotLight.enabled = false;
            batteryCharge = 0;
        }
        else if (batteryCharge > 0 && isFlashlightEnabled == true)
        {
            spotLight.enabled = true;
        }
        
        if (!spotLight.enabled && batteryCharge <= 1)
        {
            batteryRecharge();
        }

        if (batteryCharge < 0.5f && isBlinkEnabled)
        {
            spotLight.intensity = Random.Range(0.5f, 1.5f);
        }
        else
        {
            spotLight.intensity = 2;
        }

        if (batteryCharge > 1)
        {
            batteryCharge = 1;
        }

        batteryLevelIndicator.localScale = new Vector3(batteryCharge, 1, 1);
    }

    public void batteryRecharge()
    {
        timerForCharge += Time.deltaTime;
        if (timerForCharge >= 1)
        {
            batteryCharge += batteryChargePerSecond;
            timerForCharge = 0;
        }
    }

    public void isFlashlightToEnabled()
    {
        spotLight.enabled = isFlashlightEnabled;
    }
}
