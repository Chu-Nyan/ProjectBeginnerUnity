using UnityEngine;
using UnityEngine.EventSystems;


public class ButtonFunc : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] ButtonType btnType;
    SelectScene throwEvent;

    void Awake()
    {
        throwEvent = GameObject.FindWithTag("UI").GetComponent<SelectScene>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        throwEvent.ClickBranch(btnType);
    }

    
}
