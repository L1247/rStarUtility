#region

using System;
using UnityEditor;
using UnityEngine;
using Zenject;

#endregion

namespace Game.Scripts.Editor
{
    public class MyWindow : ZenjectEditorWindow
    {
    #region Public Variables

        [MenuItem("Window/MyWindow")]
        public static MyWindow GetOrCreateWindow()
        {
            var window = GetWindow<MyWindow>();
            window.titleContent = new GUIContent("TimerWindow");
            return window;
        }

    #endregion

    #region Private Variables

        private readonly TimerController.State timerState = new TimerController.State();

    #endregion

    #region Public Methods

        public override void InstallBindings()
        {
            Container.BindInstance(timerState);
            Container.BindInterfacesTo<TimerController>().AsSingle();
        }

    #endregion
    }

    internal class TimerController : IGuiRenderable , ITickable , IInitializable
    {
    #region Private Variables

        private readonly State _state;

    #endregion

    #region Constructor

        public TimerController(State state)
        {
            _state = state;
        }

    #endregion

    #region Public Methods

        public void GuiRender()
        {
            GUI.Label(new Rect(25 , 25 , 200 , 200) , "Tick Count: " + _state.TickCount);

            if (GUI.Button(new Rect(25 , 50 , 200 , 50) , "Restart")) _state.TickCount = 0;
        }

        public void Initialize()
        {
            Debug.Log("TimerController initialized");
        }

        public void Tick()
        {
            _state.TickCount++;
        }

    #endregion

    #region Nested Types

        [Serializable]
        public class State
        {
        #region Public Variables

            public int TickCount;

        #endregion
        }

    #endregion
    }
}