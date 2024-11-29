using System;
using UnityEngine;

namespace VRnLit.Scripts.Gameplay
{
    public class Book : MonoBehaviour, IBook
    {
        private int _bookId = 0;
        private bool _isOpen = false;
        
        [SerializeField] private GameObject _close;
        [SerializeField] private GameObject _open;
        
        [SerializeField] private GameObject[] _gameObjects;

        private void Start()
        {
            _close.SetActive(true);
            _open.SetActive(false);
            
            foreach (var o in _gameObjects)
            {
                o.SetActive(false); 
            }
        }

        public void Left()
        {
            if (_isOpen && _bookId == 0)
            {
                _isOpen = false;
                _close.SetActive(true);
                _open.SetActive(false);
                _gameObjects[0].SetActive(false);
            }
            else
            {
                if(_bookId > 0)
                    _bookId--;
                UpdateAll();
            }
        }

        public void Right()
        {
            if (!_isOpen)
            {
                _isOpen = true;
                _close.SetActive(false);
                _open.SetActive(true);
                UpdateAll();
            }
            else
            {
                if (_bookId < _gameObjects.Length-1)
                {
                    _bookId++;
                }
                UpdateAll();
            }
        }

        private void UpdateAll()
        {
            print(_bookId);
            _gameObjects[_bookId].SetActive(true);
            if (_bookId-1 != -1)
            {
                _gameObjects[_bookId-1].SetActive(false);
            }
            if (_bookId + 1 < _gameObjects.Length)
            {
                _gameObjects[_bookId+1].SetActive(false);
            }
        }
    }
}