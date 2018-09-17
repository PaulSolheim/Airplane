﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KodeKlubb
{
    [RequireComponent(typeof(IP_Airplane_Fuel))]
    public class IP_Airplane_Engine : MonoBehaviour
    {
        #region Variables
        [Header("Engine Properties")]
        public float maxForce = 200f;
        public float maxRPM = 2550f;
        public float shutOffSpeed = 2f;
        public AnimationCurve powerCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

        [Header("Propellers")]
        public IP_Airplane_Propeller propeller;

        private bool isShutOff = false;
        private float lastThrottleValue;
        private float finalShutoffThrottleValue;

        private IP_Airplane_Fuel fuel;
        #endregion

        #region Properties
        public bool ShutEngineOff
        {
            set { isShutOff = value; }
        }

        private float currentRPM;
        public float CurrentRPM
        {
            get { return currentRPM; }
        }

        #endregion

        #region Builtin Methods
        private void Start()
        {
            if (!fuel)
            {
                fuel = GetComponent<IP_Airplane_Fuel>();
                if (fuel)
                {
                    fuel.InitFuel();
                }
            }
        }
        #endregion

        #region Custom Methods
        public Vector3 CalculateForce(float throttle)
        {
            // Calculate Power
            float finalThrottle = Mathf.Clamp01(throttle);

            if (!isShutOff)
            {
                finalThrottle = powerCurve.Evaluate(finalThrottle);
                lastThrottleValue = finalThrottle;
            }
            else
            {
                lastThrottleValue -= Time.deltaTime * shutOffSpeed;
                lastThrottleValue = Mathf.Clamp01(lastThrottleValue);
                finalShutoffThrottleValue = powerCurve.Evaluate(lastThrottleValue);
                finalThrottle = finalShutoffThrottleValue;
            }

            // Calculate RPM's
            currentRPM = finalThrottle * maxRPM;
            if (propeller)
            {
                propeller.HandlePropeller(currentRPM);
            }

            HandleFuel(finalThrottle);

            // Create Force
            float finalPower = finalThrottle * maxForce;
            Vector3 finalForce = transform.forward * finalPower;

            return finalForce;
        }

        void HandleFuel(float throttleValue)
        {
            if (fuel)
            {
                fuel.UpdateFuel(throttleValue);
                if(fuel.CurrentFuel <= 0f)
                {
                    isShutOff = true;
                }
            }
        }
        #endregion
    }
}
