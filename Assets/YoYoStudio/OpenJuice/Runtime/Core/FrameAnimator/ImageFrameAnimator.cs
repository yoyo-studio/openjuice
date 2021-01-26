// Copyright (c) 2020 Omid Saadat (@omid3098)
using UnityEngine;
using UnityEngine.UI;

namespace YoYoStudio.OpenJuice
{
    public class ImageFrameAnimator : FrameAnimatorBase
    {
        [SerializeField] Image image = null;
        protected override void UpdateSprite()
        {
            image.sprite = frames[frameIndex];
        }
    }
}