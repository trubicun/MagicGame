using Magic.Input;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class Bow : MonoBehaviour
{
    IPlayerInput playerInput;
    [SerializeField] GameObject arrowPrefab;
    [SerializeField] Transform arrowPosition;

    [Inject]
    public void Init(IPlayerInput playerInput)
    {
        this.playerInput = playerInput;
    }

    void Start()
    {
        // playerInput.Action1
        //     .Subscribe(OnFire)
        //     .AddTo(this);
    }

    Arrow arrow;
    
    void OnFire(InputAction action)
    {
        switch (action.phase)
        {
            //Strted -> Perfomed -> Canceled
            case InputActionPhase.Started:
            {
                arrow = Instantiate(arrowPrefab, arrowPosition.position, arrowPosition.transform.rotation,transform)
                    .GetComponent<Arrow>();
                arrow.transform.localPosition = arrowPosition.transform.localPosition;
                arrow.transform.localScale = arrowPosition.localScale;
                arrow.Init();
            } break;
            case InputActionPhase.Canceled:
                arrow.Launch();
                break;
        }
    }
}
