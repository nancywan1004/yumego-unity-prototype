using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRubyShared;

public class JoyStickController : MonoBehaviour
    {
        [Tooltip("Fingers Joystick Script")]
        public FingersJoystickScript JoystickScript;

        [Tooltip("Object to move with the joystick")]
        public GameObject Mover;

        [Tooltip("Units per second to move the square with joystick")]
        public float Speed = 250.0f;
        
        public LineRenderer line;
        
        private float xRot, yRot = 0f;
        private Vector3 initPosition;

        private void Awake()
        {
            line.gameObject.SetActive(false);
            JoystickScript.JoystickExecuted = JoystickExecuted;
        }

        private void JoystickExecuted(FingersJoystickScript script, Vector2 amount)
        {
            //Debug.LogFormat("Joystick: {0}", amount);
            Vector3 pos = Mover.transform.position;
            // pos.x += (amount.x * Speed * Time.deltaTime);
            // pos.y += (amount.y * Speed * Time.deltaTime);
            // Mover.transform.position = pos;

            // Quaternion rot = Mover.transform.rotation;
            Mover.transform.rotation = Quaternion.Euler(amount.y * Speed, amount.x * Speed, 0f);
            
            line.gameObject.SetActive(true);
            line.SetPosition(0, pos);
            line.SetPosition(1, pos - Mover.transform.forward * 4);
        }
    }
