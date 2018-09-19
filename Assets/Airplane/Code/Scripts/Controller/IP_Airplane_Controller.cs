using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KodeKlubb
{
    public class IP_Airplane_Controller : IP_BaseRigidBody_Controller
    {
        #region Variables
        [Header("Base Airplane Properties")]
        public IP_XboxAirplane_Input input;
        public Transform centerOfGravity;

        [Tooltip("Weight is in LBS")]
        public float airplaneWeight = 800f;

        [Header("Engines")]
        public List<IP_Airplane_Engine> engines = new List<IP_Airplane_Engine>();

        [Header("Wheels")]
        public List<IP_Airplane_Wheel> wheels = new List<IP_Airplane_Wheel>();

        #endregion

        #region Constants
        const float poundsToKilos = 0.453592f;
        #endregion

        #region Builtin Methods
        public override void Start()
        {
            base.Start();

            float finalMass = airplaneWeight * poundsToKilos;
            if (rb)
            {
                rb.mass = finalMass;
                if (centerOfGravity)
                {
                    rb.centerOfMass = centerOfGravity.localPosition;
                }
            }

            if (wheels != null)
            {
                if (wheels.Count > 0)
                {
                    foreach (IP_Airplane_Wheel wheel in wheels)
                    {
                        wheel.InitWheel();
                    }
                }
            }
        }
        #endregion

        #region Custom Methods
        protected override void HandlePhysics()
        {
            HandleEngines();
            HandleAerodynamics();
            HandleWheel();
            HandleBrakes();
            HandleAltitude();
        }

        void HandleEngines()
        {
            if (engines != null)
            {
                if (engines.Count > 0)
                {
                    foreach (IP_Airplane_Engine engine in engines)
                    {
                        rb.AddForce(engine.CalculateForce(input.StickyThrottle));
                    }
                }
            }
        }

        void HandleAerodynamics()
        {

        }

        void HandleWheel()
        {
            foreach (IP_Airplane_Wheel wheel in wheels)
            {
                wheel.HandleWheel(input);
            }
        }

        void HandleBrakes()
        {

        }

        void HandleAltitude()
        {

        }
        #endregion

    }
}