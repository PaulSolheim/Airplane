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
        }
        #endregion

        #region Custom Methods
        protected override void HandlePhysics()
        {
            HandleEngines();
            HandleAerodynamics();
            HandleSteering();
            HandleBrakes();
            HandleAltitude();
        }

        void HandleEngines()
        {

        }

        void HandleAerodynamics()
        {

        }

        void HandleSteering()
        {

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