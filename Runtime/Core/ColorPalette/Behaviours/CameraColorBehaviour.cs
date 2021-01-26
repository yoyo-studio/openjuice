// Copyright (c) 2020 Omid Saadat (@omid3098)
using UnityEngine;

namespace YoYoStudio.OpenJuice
{
    public class CameraColorBehaviour : BaseColorBehaviour
    {
        Camera _camera;
        public override void UpdateColor()
        {
            if (_camera == null) _camera = GetComponent<Camera>();
            var colorNameIndex = ColorPalette.CurrentColorPalette.colors.FindIndex(x => x.colorNameObject.name == colorNameObject.name);
            if (colorNameIndex != -1)
                _camera.backgroundColor = ColorPalette.CurrentColorPalette.colors[colorNameIndex].color;
        }
    }
}