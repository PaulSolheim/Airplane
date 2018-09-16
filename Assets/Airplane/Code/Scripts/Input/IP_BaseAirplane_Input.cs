﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KodeKlubb
{
    public class IP_BaseAirplane_Input : MonoBehaviour
    {
        #region Variables
        protected float pitch = 0f;
        protected float roll = 0f;
        protected float yaw = 0f;
        protected float throttle = 0f;
        protected int flaps = 0;
        protected float brake = 0f;

        protected float stickyThrottle;
        public float StickyThrottle
        {
            get { return stickyThrottle; }
        }

        public int maxFlapIncrement = 2;
        public float throttleSpeed = 0.1f;

        [SerializeField]
        public KeyCode brakeKey = KeyCode.Space;
        #endregion

        #region Properties
        public float Pitch
        {
            get { return pitch; }
        }

        public float Roll
        {
            get { return roll; }
        }

        public float Yaw
        {
            get { return yaw; }
        }

        public float Throttle
        {
            get { return throttle; }
        }

        public float Flaps
        {
            get { return flaps; }
        }

        public float Brake
        {
            get { return brake; }
        }
        #endregion

        #region Builtin Methods
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            HandleInput();
            StickyThrottleControl();
            ClampInputs();
        }
        #endregion

        #region Custom Methods
        protected virtual void HandleInput()
        {
            pitch = Input.GetAxis("Vertical");
            roll = Input.GetAxis("Horizontal");
            yaw = Input.GetAxis("Yaw");
            throttle = Input.GetAxis("Throttle");
            brake = Input.GetKey(brakeKey) ? 1f : 0f;

            // Process Flaps input
            if (Input.GetKeyDown(KeyCode.F))
            {
                flaps += 1;
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                flaps -= 1;
            }

            flaps = Mathf.Clamp(flaps, 0, maxFlapIncrement);
        }

        // Create a Throttle value that gradually grows and shrinks
        protected void StickyThrottleControl()
        {
            stickyThrottle = stickyThrottle + (-throttle * throttleSpeed * Time.deltaTime);
            stickyThrottle = Mathf.Clamp01(stickyThrottle);
        }

        protected void ClampInputs()
        {
            pitch = Mathf.Clamp(pitch, -1f, 1f);
            roll = Mathf.Clamp(roll, -1f, 1f);
            yaw = Mathf.Clamp(yaw, -1f, 1f);
            throttle = Mathf.Clamp(throttle, -1f, 1f);
        }
        #endregion
    }
}
