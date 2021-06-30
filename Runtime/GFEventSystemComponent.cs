using GF.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GF.EventSystem
{
    public class GFEventSystemComponent : GameFrameworkComponent, IEventManager
    {

        public static GFEventSystemComponent Instance;

        private IEventManager m_EventManager;

        public int EventHandlerCount => m_EventManager.EventHandlerCount;

        public int EventCount => m_EventManager.EventCount;

        public bool Check(int id, EventHandler<GameEventArgs> handler)
        {
            return m_EventManager.Check(id, handler);
        }

        public int Count(int id)
        {
            return m_EventManager.Count(id);
        }

        public void Fire(object sender, GameEventArgs e)
        {
            m_EventManager.Fire(sender, e);
        }

        public void FireNow(object sender, GameEventArgs e)
        {
            m_EventManager.FireNow(sender, e);
        }

        public void SetDefaultHandler(EventHandler<GameEventArgs> handler)
        {
            m_EventManager.SetDefaultHandler(handler);
        }

        public void Subscribe(int id, EventHandler<GameEventArgs> handler)
        {
            m_EventManager.Subscribe(id, handler);
        }

        public void Unsubscribe(int id, EventHandler<GameEventArgs> handler)
        {
            m_EventManager.Unsubscribe(id, handler);
        }

        protected override void ComponentInitialized()
        {
            base.ComponentInitialized();

            if (Instance == null)
            {
                Instance = this;
            }

            m_EventManager = new EventManager();
        }

        protected override void ComponentUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.ComponentUpdate(elapseSeconds, realElapseSeconds);

            ((EventManager)m_EventManager).Update(Time.deltaTime, Time.unscaledDeltaTime);
        }

    }

}
