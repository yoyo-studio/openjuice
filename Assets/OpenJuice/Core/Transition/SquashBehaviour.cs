// Copyright (c) 2020 Omid Saadat (@omid3098)
using DG.Tweening;
using UnityEngine;
namespace OpenJuice
{
    public class SquashBehaviour : MonoBehaviour
    {
        // [SerializeField] float squashAmount = 1;
        // [SerializeField] float bounceBackDuration = 0.4f;
        Vector3 previousPosition = Vector3.zero;
        Vector3 startScale = Vector3.one;
        private bool stopped;
        // private bool startBounceBack;

        private void Awake()
        {
            previousPosition = transform.position;
            startScale = transform.localScale;
            stopped = true;
            // startBounceBack = false;
        }
        private void Update()
        {
            Vector3 currentPosition = transform.position;
            if (previousPosition != currentPosition)
            {
                stopped = false;
                var deltaPosition = previousPosition - currentPosition;
                Vector3 deltaScale = new Vector3(startScale.x + Mathf.Abs(deltaPosition.x), startScale.y + Mathf.Abs(deltaPosition.y), startScale.z + Mathf.Abs(deltaPosition.z));
                // Debug.Log("[Delta position]: " + deltaPosition);
                transform.localScale = Vector3.Scale(startScale, deltaScale);
                previousPosition = currentPosition;
            }
            else if (stopped == false)
            {
                stopped = true;
                // startBounceBack = true;
            }

            // if (startBounceBack)
            // {
            //     startBounceBack = false;
            //     transform.localScale = startScale;
            // }
        }
    }
}