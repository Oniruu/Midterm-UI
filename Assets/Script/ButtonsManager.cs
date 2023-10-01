using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class ButtonsManager : MonoBehaviour
{
    public Image imageToScale;
    private bool isZoomOut = false;



    public Vector3 targetPos, originalPos;
    public Vector3 targetSize, originalSize;
    public Vector3 targetRotation, originalRotation;


    public float originalAlpha;

    public float speed;
    public float fadeDuration;
    public float rotateDuration;

    public float flyDistance = 10.0f;
    public float flyDuration = 1.0f;


    public void ReturnState()
    {
        imageToScale.transform.DOLocalMove(originalPos, speed).SetEase(Ease.Linear);
        imageToScale.transform.DOScale(originalSize, speed).SetEase(Ease.Linear);
        imageToScale.DOFade(originalAlpha, speed).SetEase(Ease.Linear);
        imageToScale.transform.DORotate(originalRotation, speed).SetEase(Ease.Linear);
    }


    public void Zoom()
    {
        float zoomVal = 0;
        float targetScale = isZoomOut ? 1.0f : zoomVal;
        imageToScale.transform.DOScale(targetScale, 0.25f);
        isZoomOut = !isZoomOut;
    }

    public void Scale()
    {
        imageToScale.transform.DOScale(targetSize, speed).SetEase(Ease.Linear);
    }

    public void Fade()
    {
        imageToScale.DOFade(0, fadeDuration);
    }
    public void Drop()
    {
        imageToScale.transform.DOMove(targetPos, speed).SetEase(Ease.OutBounce);
    }
    public void Flip()
    {
        imageToScale.transform.DORotate(targetRotation, rotateDuration).SetEase(Ease.OutBack);
    }
    public void Fly()
    {
        imageToScale.transform.DOMoveX(transform.position.x - flyDistance, flyDuration)
            .SetEase(Ease.OutCubic)
            .OnComplete(() => gameObject.SetActive(false));
    }

}
