// Copyright (c) 2020 Omid Saadat (@omid3098)
using UnityEngine;
using UnityEngine.UI;

namespace OpenJuice
{
    public class ImageColorBehaviour : BaseColorBehaviour
    {
        Image image;
        public override void UpdateColor()
        {
            if (image == null) image = GetComponent<Image>();
            var colorNameIndex = ColorPalette.currentColorPalette.colors.FindIndex(x => x.colorNameObject.name == colorNameObject.name);
            if (colorNameIndex != -1)
                image.color = ColorPalette.currentColorPalette.colors[colorNameIndex].color;
        }
    }
}