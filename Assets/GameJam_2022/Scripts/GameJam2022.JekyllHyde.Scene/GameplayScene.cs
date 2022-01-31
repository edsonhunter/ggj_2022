using System;
using System.Collections.Generic;
using GameJam2022.JekyllHyde.Controller;
using GameJam2022.JekyllHyde.Controller.Enemy;
using GameJam2022.JekyllHyde.Controller.Player;
using GameJam2022.JekyllHyde.Controller.Room;
using GameJam2022.JekyllHyde.Controller.Room.Interface;
using GameJam2022.JekyllHyde.Controller.State;
using GameJam2022.JekyllHyde.Controller.State.Interface;
using GameJam2022.JekyllHyde.Manager;
using GameJam2022.JekyllHyde.Manager.Interface;
using GameJam2022.JekyllHyde.Scene.Interface;
using GameJam2022.JekyllHyde.Util;
using UnityEngine;

namespace GameJam2022.JekyllHyde.Scene
{
    public class GameplayScene : MonoBehaviour, IGameplayScene
    {
        [field: SerializeField] private PlayerController PlayerController { get; set; }
        [field: SerializeField] private EnemyController EnemyController { get; set; }
        [field: SerializeField] private KeyboardController KeyboardController { get; set; }
        [field: SerializeField] private List<RoomController> RoomControllers { get; set; }
        [field: SerializeField] private TransitionController TransitionController { get; set; }

        [field: SerializeField] private Camera MainCamera { get; set; }
        
        private IGameManager GameManager { get; set; }
        private ISceneManager SceneManager { get; set; }
        private IRoomManager RoomManager { get; set; }
        
        private IStateMachineManager StateMachine { get; set; }

        private void Awake()
        {
            GameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
            SceneManager = GameObject.FindWithTag("SceneManager").GetComponent<SceneManager>();
            StateMachine = new StateMachineManager();
        }
        
        private void Start()
        {
            PlayerController.Init(GameManager.GameplayService.Player);
            RoomManager = new RoomManager(RoomControllers, StateMachine, GameManager.GameplayService.CreateRooms());
            EnemyController.Init(Factory.CreateEnemy(Domain.Interface.PlayerOrientation.Left), GameManager.GameplayService.Player, PlayerController.transform);
            
            MainCamera.transform.SetParent(PlayerController.transform);

            KeyboardController.OnMove += PlayerController.Move;
            KeyboardController.OnHide += PlayerController.Hide;
            KeyboardController.OnInteract += PlayerController.Interact;

            EnemyController.OnKillPlayer += GameOver;
            StartStateMachine();
        }

        private void OnDestroy()
        {
            KeyboardController.OnMove -= PlayerController.Move;
            KeyboardController.OnHide -= PlayerController.Hide;
            KeyboardController.OnInteract -= PlayerController.Interact;

            EnemyController.OnKillPlayer -= GameOver;
        }

        public void GameOver()
        {
            SceneManager.LoadOverlay("GameOver");
        }
        
        private void StartStateMachine()
        {
            var gameContext = new StateMachineContext(KeyboardController, PlayerController, RoomManager, TransitionController);
            StateMachine.PushState(new TutorialState(gameContext));
        }
    }
}
