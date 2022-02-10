using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DigitalRubyShared;
public class DPadController : MonoBehaviour
    {
        [Tooltip("Fingers DPad Script #1")] public FingersDPadScript DPadScript;

        [Tooltip("Object to move with the first dpad")]
        public GameObject Mover;

        [Tooltip("Units per second to move the square with dpad")]
        public float Speed = 250.0f;

        //[Tooltip("Whether dpad moves to touch start location")]
        //public bool MoveDPadToGestureStartLocation;

        private Vector3 startPos;
        public LineRenderer line;
        [SerializeField] private UnityEvent startLaunching;
        private void Awake()
        {
            DPadScript.DPadItemTapped = DPadTapped;
            DPadScript.DPadItemPanned = DPadPanned;
            startPos = Mover.transform.position;
            line.gameObject.SetActive(false);
            //DPadScript.MoveDPadToGestureStartLocation = MoveDPadToGestureStartLocation;
            //DPadScript2.MoveDPadToGestureStartLocation = MoveDPadToGestureStartLocation;
        }

        private void DPadTapped(FingersDPadScript script, FingersDPadItem item, TapGestureRecognizer gesture)
        {
            if ((item & FingersDPadItem.Center) != FingersDPadItem.None)
            {
                GameObject mover = Mover;
                mover.transform.position = startPos;
                startLaunching.Invoke();
            }
        }

        private void DPadPanned(FingersDPadScript script, FingersDPadItem item, PanGestureRecognizer gesture)
        {
            GameObject mover = Mover;
            Vector3 pos = mover.transform.position;
            Quaternion rot = mover.transform.rotation;
            float move = 1.0f * Time.deltaTime;
            if ((item & FingersDPadItem.Right) != FingersDPadItem.None)
            {
                rot.y += move;
            }

            if ((item & FingersDPadItem.Left) != FingersDPadItem.None)
            {
                rot.y -= move;
            }

            if ((item & FingersDPadItem.Up) != FingersDPadItem.None)
            {
                rot.x += move;
            }

            if ((item & FingersDPadItem.Down) != FingersDPadItem.None)
            {
                rot.x -= move;
            }
            line.gameObject.SetActive(true);
            line.SetPosition(0, pos);
            line.SetPosition(1, pos - Mover.transform.forward * 4);
            mover.transform.rotation = rot;
            startLaunching.Invoke();
        }
    }
