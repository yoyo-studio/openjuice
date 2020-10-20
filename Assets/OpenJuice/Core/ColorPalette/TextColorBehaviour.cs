// Copyright (c) 2020 Omid Saadat (@omid3098)
using UnityEngine;
using UnityEngine.UI;

namespace OpenJuice
{
    public class TextColorBehaviour : BaseColorBehaviour
    {
        Text text;
        public override void UpdateColor()
        {
            if (text == null) text = GetComponent<Text>();
            var colorNameIndex = ColorPalette.currentColorPalette.colors.FindIndex(x => x.colorNameObject.name == colorNameObject.name);
            if (colorNameIndex != -1)
                text.color = ColorPalette.currentColorPalette.colors[colorNameIndex].color;
        }
    }
}