using System;
using System.Collections.Generic;
using GameJam2022.JekyllHyde.Controller;
using GameJam2022.JekyllHyde.Controller.Player;
using GameJam2022.JekyllHyde.Controller.Room;
using GameJam2022.JekyllHyde.Controller.Room.Interface;
using GameJam2022.JekyllHyde.Controller.State;
using GameJam2022.JekyllHyde.Controller.State.Interface;
using GameJam2022.JekyllHyde.Manager;
using GameJam2022.JekyllHyde.Manager.Interface;
using GameJam2022.JekyllHyde.Scene.Interface;
using GameJam2022.JekyllHyde.Service.Interface;
using UnityEngine;

namespace GameJam2022.JekyllHyde.Scene
{
    public class GameplayScene : MonoBehaviour, IGameplayScene
    {
        [field: SerializeField] private PlayerController PlayerController { get; set; }
        [field: SerializeField] private KeyboardController KeyboardController { get; set; }
        [field: SerializeField] private List<RoomController> RoomControllers { get; set; }
        [field: SerializeField] private TransitionController TransitionController { get; set; }

        [field: SerializeField] private Camera MainCamera { get; set; }
        
        private IGameManager GameManager { get; set; }
        private IRoomManager RoomManager { get; set; }
        
        private IStateMachineManager StateMachine { get; set; }

        private void Awake()
        {
            GameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        }
        
        private void Start()
        {
            PlayerController.Init(GameManager.GameplayService.Player);
            RoomManager = new RoomManager(RoomControllers, StateMachine, GameManager.GameplayService.CreateRooms());
            MainCamera.transform.SetParent(PlayerController.transform);
            
            KeyboardController.OnMove += PlayerController.Move;
            KeyboardController.OnHide += PlayerController.Hide;
            KeyboardController.OnInteract += PlayerController.Interact;

            StartStateMachine();
        }

        private void OnDestroy()
        {
            KeyboardController.OnMove -= PlayerController.Move;
            KeyboardController.OnHide -= PlayerController.Hide;
            KeyboardController.OnInteract -= PlayerController.Interact;
        }
        
        private void StartStateMachine()
        {
            StateMachine = new StateMachineManager();
            var gameContext = new StateMachineContext(KeyboardController, PlayerController, RoomManager, TransitionController);
            StateMachine.PushState(new TutorialState(gameContext));
        }
    }
}