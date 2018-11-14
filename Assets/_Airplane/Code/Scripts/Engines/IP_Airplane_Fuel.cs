using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace KodeKlubb
{
    public class IP_Airplane_Fuel : MonoBehaviour
    {
        #region Variables
        [Header("Fuel Properties")]
        [Tooltip("The total number of gallons in the fuel tank.")]
        public float fuelCapacity = 26f;
        [Tooltip("The average fuel burn per hour")]
        public float fuelBurnRate = 6.1f;

        [Header("Events")]
        public UnityEvent onFuelFull = new UnityEvent();
        #endregion

        #region Properties
        private float currentFuel;
        public float CurrentFuel
        {
            get { return currentFuel; }
        }

        private float normalizedFuel;
        public float NormalizedFuel
        {
            get { return normalizedFuel; }
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

        }
        #endregion

        #region Custom Methods
        public void InitFuel()
        {
            currentFuel = fuelCapacity;
        }

        public void UpdateFuel(float aPercentage)
        {
            float currentBurn = ((fuelBurnRate * aPercentage) / 3600f) * Time.deltaTime;
            currentFuel -= currentBurn;
            currentFuel = Mathf.Clamp(currentFuel, 0f, fuelCapacity);

            normalizedFuel = currentFuel / fuelCapacity;
        }

        public void AddFuel(float aFuelAmount)
        {
            currentFuel += aFuelAmount;
            currentFuel = Mathf.Clamp(currentFuel, 0f, fuelCapacity);

            if (currentFuel >= fuelCapacity)
            {
                if (onFuelFull != null)
                {
                    onFuelFull.Invoke();
                }
            }
        }

        public void ResetFuel()
        {
            currentFuel = fuelCapacity;
        }

        #endregion
    }
}
