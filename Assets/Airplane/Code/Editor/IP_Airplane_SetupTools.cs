using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace KodeKlubb
{
    public static class IP_Airplane_SetupTools 
    {
        public static void BuildDefaultAirplane(string aName)
        {
            // Create the root GO
            GameObject rootGO = new GameObject(aName, typeof(IP_Airplane_Controller), typeof(IP_BaseAirplane_Input));

            // Create the Center of Gravity
            GameObject cogGO = new GameObject("COG");
            cogGO.transform.SetParent(rootGO.transform, false);

            // Create the Base Components or Find them
            IP_BaseAirplane_Input input = rootGO.GetComponent<IP_BaseAirplane_Input>();
            IP_Airplane_Controller controller = rootGO.GetComponent<IP_Airplane_Controller>();
            IP_Airplane_Characteristics characteristics = rootGO.GetComponent<IP_Airplane_Characteristics>();

            //Setup the Airplane
            if(controller)
            {
                // Assigning core Components
                controller.input = input;
                controller.characteristics = characteristics;
                controller.centerOfGravity = cogGO.transform;

                // Create Structure
                GameObject graphicsGrp = new GameObject("Graphics_GRP");
                GameObject collisionGrp = new GameObject("Collision_GRP");
                GameObject controlSurfaceGrp = new GameObject("ControlSurfaces_GRP");
                GameObject audioGrp = new GameObject("Audio_GRP", typeof(IP_Airplane_Audio));

                graphicsGrp.transform.SetParent(rootGO.transform, false);
                collisionGrp.transform.SetParent(rootGO.transform, false);
                controlSurfaceGrp.transform.SetParent(rootGO.transform, false);
                audioGrp.transform.SetParent(rootGO.transform, false);

                // Create GEO Structure
                GameObject controlSurfaceGeo = new GameObject("ControlSurfaces_GEO");
                GameObject propellersGeo = new GameObject("Propellers_GEO", typeof(IP_Airplane_Propeller));
                GameObject wheelsGeo = new GameObject("Wheels_GEO");

                controlSurfaceGeo.transform.SetParent(graphicsGrp.transform, false);
                propellersGeo.transform.SetParent(graphicsGrp.transform, false);
                wheelsGeo.transform.SetParent(graphicsGrp.transform, false);

                // Create ControlSurfaces_GEO children
                GameObject elevatorGeo = new GameObject("Elevator_GEO");
                GameObject rudderGeo = new GameObject("Rudder_GEO");
                GameObject laileronGeo = new GameObject("L_Aileron_GEO");
                GameObject raileronGeo = new GameObject("R_Aileron_GEO");
                GameObject lflapGeo = new GameObject("L_Flap_GEO");
                GameObject rflapGeo = new GameObject("R_Flap_GEO");

                elevatorGeo.transform.SetParent(controlSurfaceGeo.transform, false);
                rudderGeo.transform.SetParent(controlSurfaceGeo.transform, false);
                laileronGeo.transform.SetParent(controlSurfaceGeo.transform, false);
                raileronGeo.transform.SetParent(controlSurfaceGeo.transform, false);
                lflapGeo.transform.SetParent(controlSurfaceGeo.transform, false);
                rflapGeo.transform.SetParent(controlSurfaceGeo.transform, false);

                // Create ControlSurfaces_GRP children
                GameObject elevatorGrp = new GameObject("Elevator", typeof(IP_Airplane_ControlSurface));
                GameObject rudderGrp = new GameObject("Rudder", typeof(IP_Airplane_ControlSurface));
                GameObject laileronGrp = new GameObject("L_Aileron", typeof(IP_Airplane_ControlSurface));
                GameObject raileronGrp = new GameObject("R_Aileron", typeof(IP_Airplane_ControlSurface));
                GameObject lflapGrp = new GameObject("L_Flap", typeof(IP_Airplane_ControlSurface));
                GameObject rflapGrp = new GameObject("R_Flap", typeof(IP_Airplane_ControlSurface));

                elevatorGrp.transform.SetParent(controlSurfaceGrp.transform, false);
                rudderGrp.transform.SetParent(controlSurfaceGrp.transform, false);
                laileronGrp.transform.SetParent(controlSurfaceGrp.transform, false);
                raileronGrp.transform.SetParent(controlSurfaceGrp.transform, false);
                lflapGrp.transform.SetParent(controlSurfaceGrp.transform, false);
                rflapGrp.transform.SetParent(controlSurfaceGrp.transform, false);

                // Create Collision_GRP children
                GameObject bodyFrontCol = new GameObject("Body_Front_COL");
                GameObject bodyBackCol = new GameObject("Body_Back_COL");
                GameObject lwingCol = new GameObject("L_Wing_COL");
                GameObject rwingCol = new GameObject("R_Wing_COL");
                GameObject vertfinCol = new GameObject("Vertical_Fin_COL");
                GameObject horfinCol = new GameObject("Horizontal_Fin_COL");
                GameObject rwheelCol = new GameObject("R_Wheel_COL");
                GameObject lwheelCol = new GameObject("L_Wheel_COL");
                GameObject backwheelCol = new GameObject("Back_Wheel_COL");

                bodyFrontCol.transform.SetParent(collisionGrp.transform, false);
                bodyBackCol.transform.SetParent(collisionGrp.transform, false);
                lwingCol.transform.SetParent(collisionGrp.transform, false);
                rwingCol.transform.SetParent(collisionGrp.transform, false);
                vertfinCol.transform.SetParent(collisionGrp.transform, false);
                horfinCol.transform.SetParent(collisionGrp.transform, false);
                rwheelCol.transform.SetParent(collisionGrp.transform, false);
                lwheelCol.transform.SetParent(collisionGrp.transform, false);
                backwheelCol.transform.SetParent(collisionGrp.transform, false);

                // Create Follow_Camera, Cockpit_Camera and Camera_Controller
                GameObject followCamera = new GameObject("Follow_Camera", typeof(Camera), typeof(IP_Airplane_Camera));
                GameObject cockpitCamera = new GameObject("Cockpit_Camera", typeof(Camera));
                GameObject cameraControllerGO = new GameObject("Camera_Controller", typeof(IP_AirplaneCamera_Controller));
                IP_AirplaneCamera_Controller cameraController = cameraControllerGO.GetComponent<IP_AirplaneCamera_Controller>();
                cameraController.input = input;

                followCamera.transform.SetParent(rootGO.transform, false);
                cockpitCamera.transform.SetParent(rootGO.transform, false);
                cameraControllerGO.transform.SetParent(rootGO.transform, false);

                // Create Audio_GRP children
                GameObject idleAudio = new GameObject("Idle_Audio", typeof(AudioSource));
                GameObject fullthrottleAudio = new GameObject("FullThrottle_Audio",typeof(AudioSource));

                idleAudio.transform.SetParent(audioGrp.transform, false);
                fullthrottleAudio.transform.SetParent(audioGrp.transform, false);

                //Create First Engine
                GameObject engineGO = new GameObject("Engine", typeof(IP_Airplane_Engine));
                IP_Airplane_Engine engine = engineGO.GetComponent<IP_Airplane_Engine>();
                controller.engines.Add(engine);
                engineGO.transform.SetParent(rootGO.transform, false);

                //Create the base Airplane
                GameObject defaultAirplane = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Airplane/Art/Objects/Airplanes/F4U_Corsair/F4U_WithCockPit_Geo.FBX", typeof(GameObject));
                if (defaultAirplane)
                {
                    GameObject.Instantiate(defaultAirplane, graphicsGrp.transform);
                }
            }

            //Select the Airplane Setup
            Selection.activeGameObject = rootGO;

        }
    }
}
