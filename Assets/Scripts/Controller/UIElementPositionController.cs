using UnityEngine;

namespace Controller
{
    public class UIElementPositionController : MonoCache
    {
        [SerializeField]
        private Transform _uiElementRoot;
        [SerializeField]
        private RectTransform _uiElement;
        [SerializeField]
        private Vector3 _offset;

        public void Initialize(Transform uiElementRoot)
        {
            _uiElementRoot = uiElementRoot;
        }
        
        public override void OnTick()
        {
            if (_uiElementRoot == null)
            {
                Destroy(gameObject);
            }

            if (_uiElementRoot != null)
            {
                var pointInScreenSpace = RectTransformUtility.WorldToScreenPoint(Camera.main, _uiElementRoot.position + _offset);
                RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    transform.parent as RectTransform, pointInScreenSpace, null, out var localPoint);

                _uiElement.anchoredPosition = localPoint;
            }
        }
    }
}
