// Copyright (c) 2020 Omid Saadat (@omid3098)
using UnityEngine;

namespace YoYoStudio.OpenJuice
{
    public class RendererColorBehaviour : BaseColorBehaviour
    {
        Renderer _renderer;
        public override void UpdateColor()
        {
            if (_renderer == null) _renderer = GetComponent<Renderer>();
            var colorNameIndex = ColorPalette.CurrentColorPalette.colors.FindIndex(x => x.colorNameObject.name == colorNameObject.name);
            if (colorNameIndex != -1)
                _renderer.sharedMaterial.SetColor("_Color", ColorPalette.CurrentColorPalette.colors[colorNameIndex].color);
        }
    }
}