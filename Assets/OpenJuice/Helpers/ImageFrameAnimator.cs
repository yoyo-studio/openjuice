// Copyright (c) 2020 Omid Saadat (@omid3098)
using UnityEngine;
using UnityEngine.UI;

namespace OpenJuice
{
    public class ImageFrameAnimator : FrameAnimatorBase
    {
        [SerializeField] Image image;
        protected override void UpdateSprite()
        {
            image.sprite = frames[frameIndex];
        }
    }
}