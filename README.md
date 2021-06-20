# GF-EventSystem

EventSystem Of GameFramework

[中文文档](README-zhc.md)

## First Thing

Please take a look [GameFramework](https://github.com/EllanJiang/GameFramework) first.

And thanks to [EllanJiang](https://github.com/EllanJiang).

## Install

### Install via git URL

Requires a version of unity that supports path query parameter for git packages (Unity >= 2019.3.4f1, Unity >= 2020.1a21). 

1. In Unity , Go to Window -> Package Manager -> Add package from git URL

2. **This module depends on the GF-Core , so you need to install GF-Core First.** , use the url  `https://github.com/shaun-he/GF-Core.git` , then click **Add** , and wait for complie finished.

3. Next , use the url `https://github.com/shaun-he/GF-EventSystem.git` , then click **Add** ,  wait for complie finished and done !

### Install via disk

1. Go `https://github.com/shaun-he/GF-Core.git` ,  Click the **Green Code** button , then click **Download Zip**.

2. Go `https://github.com/shaun-he/GF-EventSystem.git` , Click the **Green Code** button , then click **Download Zip**.

3. Unzip two file somewhere in your disk.

4. In Unity , Go to Window -> Package Manager -> Add package from disk

5. open the **package.json** which in your GF-Core unzip folder.

6. open the **package.json** which in your GF-EventSystem unzip folder.

7. Done!

## About Errors

If you see Errors after install GF-EventSystem , that means you didn't install **GF-Core**.

If you still see the Errors , go find **GF.EventSystem.asmdef** in your unzip folder , add **GF.Core** and **GF.Runtime** to the **Assembly Definition Reference** list.

And your **GF.EventSystem.asmdef** should look like this

![https://z3.ax1x.com/2021/06/19/RiCl3q.png](https://z3.ax1x.com/2021/06/19/RiCl3q.png)

## Usage

You can found example in **Test** folder，drag **GFEventSystem** prefab in your scene which in Prefabs folder ，then run，you should see the log `Test` in console window.

```
GFEventSystemComponent.Instance.Subscribe(EventId, EventHandler);
//Subscribe Event
```

```
GFEventSystemComponent.Instance.Fire(gameObject, GameEventArgs);
//This operation is thread safe. That means even if it is not thrown in the main thread, the event handler can be called back in the main thread, but the event will be called in the next frame.
```

```
GFEventSystemComponent.Instancet.FireNow(this, e);
//This operation is thread safe.The event will be called immediately.
```
