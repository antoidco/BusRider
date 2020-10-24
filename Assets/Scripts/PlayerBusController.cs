using UnityEngine;
using System.Collections;

namespace Com.Antoid.Bus {
    public class PlayerBusController : MonoBehaviour {
        private Rigidbody _body;
        public float horzPower = 1f;
        public float vertPower = 5f;
        private float _horzInput = 0f;
        private float _vertInput = 0f;
        
        private void Start() {
            _body = GetComponent<Rigidbody>();
        }
        
        // Update is called once per frame
        private void Update() {
            _horzInput = Input.GetAxis("Horizontal");
            _vertInput = Input.GetAxis("Vertical");
        }
        
        private void FixedUpdate() {
            var force = new Vector3(0, 0, _vertInput * vertPower);
            var tourqe = new Vector3(0, _horzInput * horzPower, 0);
            _body.AddForce(transform.rotation * force);
            _body.AddTorque(transform.rotation * tourqe);
        }
    }
}
