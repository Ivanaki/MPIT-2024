using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PogruzhickURP.Scripts.Utils
{
    [RequireComponent(typeof(BoxCollider), typeof(RectTransform))]
    public class BoxColliderButton : MonoBehaviour
    {
        [SerializeField] private float _buttonWight = 1f;
        
        private void Start()
        {
            UpdateSize();
        }

        private void OnValidate()
        {
            UpdateSize();
        }

        public void UpdateSize()
        {
            var rectTransform = GetComponent<RectTransform>();
            GetComponent<BoxCollider>().size = new Vector3(rectTransform.rect.width, rectTransform.rect.height, _buttonWight);
        }

        public void UpdateNew()
        {
            StartCoroutine(UpdateIe());
        }

        private IEnumerator UpdateIe()
        {
            yield return null;
            yield return null;
            yield return null;
            var rectTransform = GetComponent<RectTransform>();
            GetComponent<BoxCollider>().size = new Vector3(rectTransform.rect.width, rectTransform.rect.height, _buttonWight);
            
        }
    }
    
#if UNITY_EDITOR
    //-------------------------------------------------------------------------
    [UnityEditor.CustomEditor( typeof( BoxColliderButton ) )]
    public class BoxColliderButtonEditor : UnityEditor.Editor
    {
        //-------------------------------------------------
        // Custom Inspector GUI allows us to click from within the UI
        //-------------------------------------------------
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            BoxColliderButton uiElement = (BoxColliderButton)target;
            if ( GUILayout.Button( "Update Size" ) )
            {
                uiElement.UpdateSize();
            }
        }
    }
#endif
    
}