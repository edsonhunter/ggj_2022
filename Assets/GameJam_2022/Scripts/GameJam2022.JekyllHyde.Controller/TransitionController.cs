using System;
using DG.Tweening;
using UnityEngine;

namespace GameJam2022.JekyllHyde.Controller
{
    public class TransitionController : MonoBehaviour
    {
        [field: SerializeField] private SpriteRenderer FadeImage { get; set; }
        
        public void FadeIn(Action onComplete)
        {
            var fadeInSequence = DOTween.Sequence();
            fadeInSequence.Append(FadeImage.DOFade(1, 2f));
            fadeInSequence.AppendCallback(() =>
            {
                onComplete();
            });
        }

        public void FadeOut(Action onComplete)
        {
            var fadeOutSequence = DOTween.Sequence();
            fadeOutSequence.Append(FadeImage.DOFade(0, 1f));
            fadeOutSequence.AppendCallback(() =>
            {
                onComplete();
            });
        }
    }
}