// Copyright (c) 2020 Omid Saadat (@omid3098)
using System;
using UnityEngine;

namespace OpenJuice
{
    public abstract class FrameAnimatorBase : MonoBehaviour
    {
        public Sprite[] frames;
        public float FPS = 30f;
        private float ellpsedTime = 0;
        private float frameDelay;
        protected int frameIndex;

        private void Awake()
        {
            ellpsedTime = 0;
            frameIndex = 0;
            frameDelay = 1 / FPS;
            UpdateSprite();
        }
        private void Update()
        {
            ellpsedTime += Time.deltaTime;
            if (ellpsedTime > frameDelay)
            {
                ellpsedTime = 0;
                frameIndex++;
                frameIndex = frameIndex % frames.Length;
                // Debug.Log(frameIndex);
                UpdateSprite();
            }
        }
        protected abstract void UpdateSprite();
    }
}