// Copyright (c) 2020 Omid Saadat (@omid3098)
using UnityEngine;

namespace OpenJuice
{
    public class RendererColorBehaviour : BaseColorBehaviour
    {
        Renderer _renderer;
        public override void UpdateColor()
        {
            if (_renderer == null) _renderer = GetComponent<Renderer>();
            var colorNameIndex = ColorPalette.currentColorPalette.colors.FindIndex(x => x.colorNameObject.name == colorNameObject.name);
            if (colorNameIndex != -1)
                _renderer.sharedMaterial.SetColor("_Color", ColorPalette.currentColorPalette.colors[colorNameIndex].color);
        }
    }
}