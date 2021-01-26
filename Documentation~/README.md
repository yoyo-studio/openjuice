# OpenJuice

OpenJuice tries to cover methods to juice up your unity games.

## Why Singleton?

because we dont do any logics, we just work with views.

**Warning: This repository is highly under development**

## Features:

- [Color](#Color)
- [Easy Effects](#Easy-Effects)
- [AudioPlayer](#AudioPlayer)

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

_TODO: The ideal state is to have a css style components to define visual behaviour of objects. so we only define something as "Button" class and all bottons have the same visual._

## Easy Effects

**Spoiler alert: Fire and forget!**

All effects will have their own objectPool in case you want to play some effects multiple time.

Effects can have 3 audios `StartClip` for the moment effect plays, `LoopClip` for effect lifetime and `EndClip` for after releasing effect. Duration parameter is for effect duration and if you set it to greater than 0, it will be automatically released.

### Usage:

- Add `Effect` component to any prefab and asign audio clips if needed
- Add prefab to your own `EffectPack` scriptable object (create your own from `CreateAssetMenu/OpenJuice/Effects/EffectPack`) or add it to `SampleEffectPack` located at `../OpenJuice/Effects/SampleEffectPack` scriptable object
- Add your effect pack to `EffectDatabase` located in `OpenJuice/Effects/Resources/EffectDatabase` path.
- Use `Juicer.PlayEffect(EffectName);` to play effect. it will return the Effect and you can keep it, modify it or release it when you want. Please note that if you set duration for effects, they will be released automatically and there is no need to release them manually.
- Use `Juicer.ReleaseEffect(Effect);` to release effect. Please do not destroy effect game objects.

## AudioPlayer

There is no need to implement audio system for each game. we just need audioclips to play them as we want.

OpenJuice has a fast and effective audio player that plays audioclips with desired loopType for looping musics or play once audio effects.
It also supports object pool to recycle any free audiosources.
Use:

```
Jucer.PlaySfx(audioclip, loop = false);
Jucer.PlaySfx(audioclip, Action onComplete);
Jucer.PlayMusic(audioclip, loop = true);
Jucer.PlayMusic(audioclip, Action onComplete);
```

## Transitions

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

this method loads scene async and will fade in when loading is completed.

![scene-transition](https://git.cafebazaar.ir/cafebazi-studio/openjuice/uploads/b445eaf9bd4af9e37817b3cbe701b689/scene-transition.gif)

_#TODO: we can have callbacks like Juicer.Instance.OnSceneLoadComplete_

## ObjectPool

An easy to use and fast object pool system.

```csharp
objectPool = new ObjectPool<T>(warmUpCapacity, OnCreate, OnGet, OnRelease);
```

Example:

```csharp
audioSourcePool = new ObjectPool<AudioSource>(1
                        , () => new GameObject(name + "-audio-source").AddComponent<AudioSource>()
                        , (audioSource) => { audioSource.gameObject.SetActive(true); }
                        , (audioSource) => { audioSource.gameObject.SetActive(false); });

```

## Frame Animator

Easy to use component to animate spritesheets with desired FPS

## Text Animator

Animate TextMeshPro characters separately

More things to do:

- Transitions:
  - Move objects with tweens. ✅
  - Stretch in move direction.
  - Rotate in move direction.
  - Trail or particle while moving
- Hitted things:
  - Shake or scale some things
  - Wobble
  - Change color
  - Play sound on each hit
  - Play some particles
  - for destroying things, scale them down or shatter them. DONT DESTROY THEM INSTANT
- Music ✅
- Particles => use easy effects for this ✅
- Slow motion/Fast speed
- Camera Shake
- Camera Zoom
- Flash
- Personalize things (like by adding eyes and mouth to them)
- Bloom
- Vignette
- Chromatic Abberation
- Color grading

External Links: [Juice it or loose it](https://www.youtube.com/watch?v=Fy0aCDmgnxg)
