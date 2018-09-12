using System.Collections;
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

        #region Custom Methods
        void HandleInput()
        {
            pitch = Input.GetAxis("Vertical");
            roll = Input.GetAxis("Horizontal");

            Debug.Log("Pitch: " + pitch + " - " + "Roll: " + roll);
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
        }
        #endregion
    }
}
