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

You can found example in `~Example` folder，go Prefabs folder and drag `GFFsmSystem` prefab into your scene ，hit play, you should see console print logs.

`Stand State Init`

`Walk State Init`

`Stand State Enter`

`Stand State Leave`

`Walk State Enter`



```
public class StandState : FsmState<Actor>
{
    protected override void OnInit(IFsm<Actor> fsm)
    {
        base.OnInit(fsm);
        // State initialize
        Debug.Log("Stand State Init.");
    }

    protected override void OnDestroy(IFsm<Actor> fsm)
    {
        base.OnDestroy(fsm);
        // State destroy
        Debug.Log("Stand State Destroy.");
    }

    protected override void OnEnter(IFsm<Actor> fsm)
    {
        base.OnEnter(fsm);
        // State enter
        Debug.Log("Stand State Enter");

        // State change
        ChangeState<WalkState>(fsm);
    }

    protected override void OnLeave(IFsm<Actor> fsm, bool isShutdown)
    {
        base.OnLeave(fsm, isShutdown);

        // State leave
        Debug.Log("Stand State Leave");
    }

    protected override void OnUpdate(IFsm<Actor> fsm, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);

        //Debug.Log("Stand State Update");
    }
}



public class WalkState : FsmState<Actor>
{
    protected override void OnInit(IFsm<Actor> fsm)
    {
        base.OnInit(fsm);

        Debug.Log("Walk State Init.");
    }

    protected override void OnDestroy(IFsm<Actor> fsm)
    {
        base.OnDestroy(fsm);

        Debug.Log("Walk State Destroy.");
    }

    protected override void OnEnter(IFsm<Actor> fsm)
    {
        base.OnEnter(fsm);

        Debug.Log("Walk State Enter");
    }

    protected override void OnLeave(IFsm<Actor> fsm, bool isShutdown)
    {
        base.OnLeave(fsm, isShutdown);

        Debug.Log("Walk State Leave");
    }

    protected override void OnUpdate(IFsm<Actor> fsm, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);

        //Debug.Log("Walk State Update");
    }
}

public class Actor
{
    private IFsm<Actor> m_Fsm = null;

    private StandState m_StandState;
    private WalkState m_WalkState;

    public Actor(FsmComponent fsm)
    {
        // Create State
        m_StandState = new StandState();
        m_WalkState = new WalkState();

        // Create Fsm and add states
        m_Fsm = fsm.CreateFsm("ActorFsm", this, m_StandState, m_WalkState);
    }

    public void StartState()
    {
        // Start fsm
        m_Fsm.Start(m_StandState.GetType());
    }
}

public class GFFsmTest : MonoBehaviour
{

    private FsmComponent _mFsmComponent;

    private Actor _mActor;

    private void Start()
    {
        _mFsmComponent = GetComponent<FsmComponent>();

        _mActor = new Actor(_mFsmComponent);

        _mActor.StartState();

    }
}
```
