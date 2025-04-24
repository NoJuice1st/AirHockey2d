using DG.Tweening;
using UnityEngine;

public class MenuLogoAnimator : MonoBehaviour
{
    private void Start()
    {
        transform.DOScale(1.2f, 1f).SetLoops(-1, LoopType.Yoyo);
        transform.DOBlendableLocalRotateBy(new Vector3(0f, 0f, 2f), 1f).SetLoops(-1, LoopType.Yoyo);
    }
}
