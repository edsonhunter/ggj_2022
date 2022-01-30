using System.Collections.Generic;
using DG.Tweening;
using GameJam2022.JekyllHyde.Manager;
using GameJam2022.JekyllHyde.Manager.Interface;
using UnityEngine;

namespace GameJam2022.JekyllHyde.Scene
{
    public class LaunchScene : MonoBehaviour
    {
        [field: SerializeField] private List<SpriteRenderer> SplashArts { get; set; }

        private IGameManager GameManager { get; set; }
        private ISceneManager SceneManager { get; set; }

        [field: Header("Debug")]
        public float Speed = 1;

        private void Awake()
        {
            GameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
            SceneManager = GameObject.FindWithTag("SceneManager").GetComponent<SceneManager>();
        }
        
        private void Start()
        {
            GameManager.Init();

            var fadeLaunch = DOTween.Sequence();
            foreach (var splashArt in SplashArts)
            {
                fadeLaunch.Append(splashArt.DOFade(1, 1f * Speed));
                fadeLaunch.Append(splashArt.DOFade(0, 1f * Speed));
            }

            fadeLaunch.AppendCallback(() => { SceneManager.LoadScene("Menu"); });
            fadeLaunch.Play();
        }
    }
}