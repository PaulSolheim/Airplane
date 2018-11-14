using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace KodeKlubb
{
    public class IP_Airplane_EngineCutoff : MonoBehaviour
    {
        #region Variables
        [Header("Engine Cutoff Properties")]
        public KeyCode cutoffKey = KeyCode.O;
        public KeyCode restartKey = KeyCode.P;
        public UnityEvent onEngineCutoff = new UnityEvent();
        public UnityEvent onEngineRestart = new UnityEvent();
        #endregion

        #region Builtin Methods
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(cutoffKey))
            {
                HandleEngineCutoff();
            }
            else if (Input.GetKeyDown(restartKey))
            {
                HandleEngineRestart();
            }
        }
        #endregion

        #region Custom Methods
        void HandleEngineCutoff()
        {
            if (onEngineCutoff != null)
            {
                onEngineCutoff.Invoke();
            }
        }

        void HandleEngineRestart()
        {
            if (onEngineRestart != null)
            {
                onEngineRestart.Invoke();
            }
        }
        #endregion

    }
}
