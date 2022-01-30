using System;
using GameJam2022.JekyllHyde.Controller.Player;
using UnityEngine;

namespace GameJam2022.JekyllHyde.Controller
{
    public class KeyboardController : MonoBehaviour
    {
        private bool Enabled { get; set; }
        public bool Tutorial { get; private set; }
        
        public event Action OnMove
        {
            add => _onMove += value;
            remove => _onMove -= value;
        }

        private Action _onMove { get; set; }

        public event Action<bool> OnHide
        {
            add => _onHide += value;
            remove => _onHide -= value;
        }

        private Action<bool> _onHide { get; set; }

        public event Action OnInteract
        {
            add => _onInteract += value;
            remove => _onInteract -= value;
        }
        
        private Action _onTutorialEnd { get; set; }

        public event Action OnTutorialEnd
        {
            add => _onTutorialEnd += value;
            remove => _onTutorialEnd -= value;
        }

        private Action _onInteract { get; set; }
        
        private void Update()
        {
            if(CheckTutorial())
                return;
            
            if(!Enabled)
                return;

            if(Input.GetAxis("Horizontal") != 0f)
                _onMove?.Invoke();

            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
                _onInteract?.Invoke();

            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
                _onHide?.Invoke(true);
            else if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
                _onHide?.Invoke(false);
        }

        public void ToggleKeyboard(bool enabled)
        {
            Enabled = enabled;
        }

        private bool CheckTutorial()
        {
            if (!Tutorial)
                return false;
            
            if (Input.anyKey)
            {
                Tutorial = false;
                _onTutorialEnd.Invoke();
            }

            return Tutorial;

        }

        public void StartTutorial()
        {
            Tutorial = true;
        }
    }
}