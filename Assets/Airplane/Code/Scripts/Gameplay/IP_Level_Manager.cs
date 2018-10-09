using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KodeKlubb
{
    public class IP_Level_Manager : MonoBehaviour
    {
        #region Variables
        private IP_Airplane_Controller targetController;
        private IP_Airplane_Engine targetEngine;
        private IP_BaseAirplane_Input targetInput;
        private IP_Airplane_Fuel targetFuel;
        #endregion

        #region Builtin Methods
        // Use this for initialization
        void Start()
        {
            var foundControllers = FindObjectsOfType<IP_Airplane_Controller>();
            var foundEngines = FindObjectsOfType<IP_Airplane_Engine>();
            var foundInputs = FindObjectsOfType<IP_BaseAirplane_Input>();
            var foundFuels = FindObjectsOfType<IP_Airplane_Fuel>();

            Debug.Log(foundControllers + " : " + foundControllers.Length);

            if (foundControllers.Length == 1)
            {
                targetController = foundControllers[0];
            }
            if (foundEngines.Length == 1)
            {
                targetEngine = foundEngines[0];
            }
            if (foundInputs.Length == 1)
            {
                targetInput = foundInputs[0];
            }
            if (foundFuels.Length == 1)
            {
                targetFuel = foundFuels[0];
            }

            // Altimeter
            IP_Airplane_Altimeter altimeter = GameObject.FindObjectOfType<IP_Airplane_Altimeter>();
            if (altimeter)
            {
                altimeter.airplane = targetController;
            }

            // Tachometer
            IP_Airplane_Tachometer tachometer = GameObject.FindObjectOfType<IP_Airplane_Tachometer>();
            if (tachometer)
            {
                tachometer.engine = targetEngine;
            }

            // Fuel_Gauge
            IP_Airplane_FuelGauge fuelGauge = GameObject.FindObjectOfType<IP_Airplane_FuelGauge>();
            if (fuelGauge)
            {
                fuelGauge.fuel = targetFuel;
            }

            // Throttle_Lever
            IP_Airplane_ThrottleLever throttleLever = GameObject.FindObjectOfType<IP_Airplane_ThrottleLever>();
            if (throttleLever)
            {
                throttleLever.input = targetInput;
            }

            // Flap_Lever
            IP_Airplane_FlapLever flapLever = GameObject.FindObjectOfType<IP_Airplane_FlapLever>();
            if (flapLever)
            {
                flapLever.input = targetInput;
            }

        }

        // Update is called once per frame
        void Update()
        {

        }
        #endregion

        #region Custom Methods

        #endregion
    }
}
