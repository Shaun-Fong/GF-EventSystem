using UnityEngine;
using GF.EventSystem;

public class TestMonoBehaviour : MonoBehaviour
{

    void Start()
    {
        //注册事件
        GFEventSystemComponent.Instance.Subscribe(TestEventArgs.EventId, TestHandler);

        //抛出事件
        GFEventSystemComponent.Instance.Fire(gameObject, TestEventArgs.Create("Test"));
    }

    private void TestHandler(object sender, GameEventArgs e)
    {
        TestEventArgs args = e as TestEventArgs;
        Debug.Log(args.TestStr);
    }

}
