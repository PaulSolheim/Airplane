using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace KodeKlubb
{
    [CustomEditor(typeof(IP_BaseAirplane_Input))]
    [CanEditMultipleObjects]
    public class IP_BaseAirplaneInput_Editor : Editor
    {
        #region Variables
        private IP_BaseAirplane_Input targetInput;
        #endregion

        #region Builtin Methods
        private void OnEnable()
        {
            targetInput = (IP_BaseAirplane_Input)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            // Custom Editor Code
            string debugInfo = "";
            debugInfo += "Pitch = " + targetInput.Pitch + "\n";
            debugInfo += "Roll = " + targetInput.Roll + "\n";
            debugInfo += "Yaw = " + targetInput.Yaw + "\n";
            debugInfo += "Throttle = " + targetInput.Throttle + "\n";
            debugInfo += "Sticky Throttle = " + targetInput.StickyThrottle + "\n";
            debugInfo += "Brake = " + targetInput.Brake + "\n";
            debugInfo += "Flaps = " + targetInput.Flaps + "\n";

            GUILayout.Space(20);
            EditorGUILayout.TextArea(debugInfo, GUILayout.Height(100));
            GUILayout.Space(20);

            Repaint();
        }
        #endregion

    }
}