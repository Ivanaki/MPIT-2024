using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Navedenie : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Navedenie _childIfHas = null;
    
    [SerializeField] private Color _enterColor = new Color(1,1,1,0.03529412f);
    [SerializeField] private Color _exitColor = new Color(0,0,0,0);

    private Image _image = null;
    public bool _isChild { private get; set; } = false;

    private void Start()
    {
        _image = GetComponent<Image>();
        if(_childIfHas != null)
            _childIfHas._isChild = true;
        _image.color = _exitColor;
    }
    
    public void OnPointerEnter(PointerEventData eventData = null)
    {
        if (_image != null) _image.color = _enterColor;

        if(_childIfHas != null && !_isChild)
            _childIfHas.OnPointerEnter();
    }

    public void OnPointerExit(PointerEventData eventData = null)
    {
        if (_image != null) _image.color = _exitColor;

        if(_childIfHas != null && !_isChild)
            _childIfHas.OnPointerExit();
    }

    private void OnDisable()
    {
        OnPointerExit();
    }
}