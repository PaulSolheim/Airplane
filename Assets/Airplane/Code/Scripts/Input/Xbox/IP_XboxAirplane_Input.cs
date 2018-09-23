﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KodeKlubb
{
    public class IP_XboxAirplane_Input : IP_BaseAirplane_Input
    {

        #region Custom Methods
        protected override void HandleInput()
        {
            // Process Keyboard
            base.HandleInput();

            pitch += Input.GetAxis("Vertical");
            roll += Input.GetAxis("Horizontal");
            yaw += Input.GetAxis("X_RH_Stick");
            throttle += Input.GetAxis("X_RV_Stick");

            // Process Brake inputs
            brake += Input.GetAxis("Fire1");

            // Process Flaps input
            if (Input.GetButtonDown("X_R_Bumper"))
            {
                flaps += 1;
            }
            if (Input.GetButtonDown("X_L_Bumper"))
            {
                flaps -= 1;
            }

            //Camera Switch Button
            cameraSwitch = Input.GetButtonDown("X_Y_Button") || Input.GetKeyDown(cameraKey);

        }
        #endregion

    }
}
