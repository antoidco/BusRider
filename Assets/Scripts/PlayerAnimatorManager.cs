using UnityEngine;
using System.Collections;


namespace Com.Antoid.Bus
{
    public class PlayerAnimatorManager : MonoBehaviour
    {
        private Animator _animator;
        #region MonoBehaviour Callbacks


        // Use this for initialization
        void Start() {
            _animator = GetComponent<Animator>();
            if (!_animator)
                Debug.Log("Animator is missing in PlayerAnimatorManager");
        }


        // Update is called once per frame
        void Update() {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            if (v < 0) {
                v = 0;
            }
            
            if (_animator != null)
                _animator.SetFloat("Speed", h * h + v * v);
        }


        #endregion
    }
}
