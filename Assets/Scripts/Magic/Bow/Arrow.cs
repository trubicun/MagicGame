using DG.Tweening;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] float time = 2;
    [SerializeField] Vector3 distance;
    [SerializeField] float speed = 10;
    [SerializeField] Rigidbody rigidbody;

    Sequence arrowIn;
    public void Init()
    {
        rigidbody.isKinematic = true;

        arrowIn = DOTween.Sequence().Append(transform.DOLocalMove(distance, time).SetEase(Ease.InSine));
    }

    public void Launch()
    {
        arrowIn.Kill();
        transform.parent = null;
        rigidbody.isKinematic = false;
        rigidbody.AddRelativeForce(Vector3.right * speed, ForceMode.Impulse);
    }
}
