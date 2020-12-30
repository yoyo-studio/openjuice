# OpenJuice

OpenJuice tries to cover methods to juice up your unity games.

**Warning: This repository is highly under development**

## Features:

- [Color](#Color)
- [Bokeh](#Bokeh)

## Color

![image](https://git.cafebazaar.ir/cafebazi-studio/openjuice/uploads/8b87aac7a6fa0d6c9c71f6492456c561/OpenJuice_Color.gif)

Helps you to change the whole scene color in edit mode or runtime.
OpenJuice comes with 3 color palettes to use. You also can make your own color palettes from [Adobe Colors](https://color.adobe.com/create/color-wheel) or [Coolors](https://coolors.co/palettes/popular) or read [this tutorial](https://gamedevelopment.tutsplus.com/articles/picking-a-color-palette-for-your-games-artwork--gamedev-1174) to get more information about this topic.

### Usage:

1- Create a `ColorPaletteScriptable` Object or use pre-made ones. and fill it with some colorName objects and colors pairs. (you can use premade colorNameObjects or create new ones from `"OpenJuice/Coloring/ColorNameObject"` in create asset menu)

2- Do NOT manually set color On your images, texts, renderers, or cameras. Instead use `[Whatever]ColorBehaviour` components on them and set the ColorNameObject field. i.e. `ImageColorBehaviour` for Image.

3- Select your `ColorPaletteScriptable` and click on `SetAsCurrent` button.

Note: this will only change colors for current scene openned only. if you have multiple scenes, you need to open them as well and press SetAsCurrent button on your ColorPaletteScriptable again.

### Using C#

Use `ColorPalette.UpdateSceneColors()` to update current scene colors.

You can also check `01_ColorPaletteExampleScene` scene to test pre-made color palettes.

## Bokeh

![image](https://git.cafebazaar.ir/cafebazi-studio/openjuice/uploads/5f90b03a8a89a84549c5b96126257a70/OpenJuice_BokehEditor.gif)

### Usage

1- Prepare a static blured image.

2- Add BokehEditor component to an empty game object.

3- Assign material and sprite to use for bokeh and set flicker and movement chance.

4- Press Play and click on your scene. this will instantiate bokeh instances and **You can change all bokeh sizes with mouse scroll**

5- Press StopEditing, manually change instances component parameters if needed and Bake to prefab. it will make a prefab in bokeh sprite path.

![OpenJuice_BokehEditor_WIP](https://git.cafebazaar.ir/cafebazi-studio/openjuice/uploads/b748d9820fb6349df83c60a5f8ffafc9/OpenJuice_BokehEditor_WIP.gif)

## Easy Effects (Fire and forget!)

All effects will have their own objectPool in case you want to play some effects multiple time.

Effects can have 3 audios `StartClip` for the moment effect plays, `LoopClip` for effect lifetime and `EndClip` for after releasing effect. Duration parameter is for effect duration and if you set it to greater than 0, it will be automatically released.

### Usage:

- Add `Effect` component to any prefab and asign audio clips if needed
- Add prefab to your own `EffectPack` scriptable object (create your own from `CreateAssetMenu/OpenJuice/Effects/EffectPack`) or add it to `SampleEffectPack` located at `../OpenJuice/Effects/SampleEffectPack` scriptable object
- Add your effect pack to `EffectDatabase` located in `OpenJuice/Effects/Resources/EffectDatabase` path.
- Use `Juicer.PlayEffect(EffectName);` to play effect. it will return the Effect and you can keep it, modify it or release it when you want. Please note that if you set duration for effects, they will be released automatically and there is no need to release them manually.
- Use `Juicer.ReleaseEffect(Effect);` to release effect. Please do not destroy effect game objects.

## Transitions:

![Transitions](https://git.cafebazaar.ir/cafebazi-studio/openjuice/uploads/b7435cdcc8a83a66e7c338b9442a761a/Transitions.gif)

This repo uses [DoTween](http://dotween.demigiant.com/inde) library to tween different things.

You can use `MoveTransition`, `ScaleTransition`, `RotateTransision` or write your own transitions inherited from `BaseTransition` class

Another cool feature is animating Text characters separately.

Simply Add [Move/Scale/Rotate]Transition component to your GameObjects and config your desired values.

![image](https://git.cafebazaar.ir/cafebazi-studio/openjuice/uploads/c8975184fc9b88d6cb6df68a810507f3/image.png)

## UiEffects

Some Ui Effects made by [Mob Sakai](https://github.com/mob-sakai)

You can read documentation from [here](https://github.com/mob-sakai/UIEffect)

![UiEffect](https://user-images.githubusercontent.com/12690315/41398364-155cf5a6-6ff2-11e8-8124-9d16ef6ca267.gif)

## SceneTransition

Its better to do some transitions before changing scenes.
So insted of using
</br>`SceneManager.LoadScene("sceneName")`
</br> you can use:
</br>`Juicer.Instance.LoadScene("sceneName")`

- Moving things:
  - Move objects with tweens.
  - Stretch in move direction.
  - Rotate in move direction.
  - Trail or particle
- Hitted things:
  - Change scale
  - Wobble
  - Change color
  - Shake or scale some things
  - Play sound on each hit
  - Play some particles
  - Push things need to destroy, scale them down or shatter them
- Music
- Particles
- Slow motion/Fast speed
- Camera Shake
- Camera Zoom
- Flash
- Personalize things (like by adding eyes and mouth to them)
- Bloom

External Links: [Juice it or loose it](https://www.youtube.com/watch?v=Fy0aCDmgnxg)
