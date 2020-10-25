using UnityEngine;
using System.Collections;
using Photon.Pun;

namespace Com.Antoid.Bus {
    public class PlayerBusController : MonoBehaviourPun {
        public float horzPower = 1f;
        public float vertPower = 5f;
        public float maxSpeed = 5f;
        public float maxAngularSpeed = 1.5f;
        private float _horzInput = 0f;
        private float _vertInput = 0f;
        private Rigidbody _body;
        
        private void Start() {
            _body = GetComponent<Rigidbody>();
        }
        
        // Update is called once per frame
        private void Update() {
            if (photonView.IsMine && PhotonNetwork.IsConnected) {
                _horzInput = Input.GetAxis("Horizontal");
                _vertInput = Input.GetAxis("Vertical");
            }
        }
        
        private void FixedUpdate() {
            if (photonView.IsMine && PhotonNetwork.IsConnected) {
                var force = new Vector3(0, 0, _vertInput * vertPower);
                var tourqe = new Vector3(0, _horzInput * horzPower, 0);
                if (_body.velocity.magnitude < maxSpeed) {
                    _body.AddForce(transform.rotation * force);          
                }
                if (_body.velocity.magnitude > 0.1f && _body.angularVelocity.magnitude < maxAngularSpeed) {
                    if (_body.angularVelocity.magnitude < maxAngularSpeed * 0.25f) tourqe *= 1.5f;
                    _body.AddTorque(transform.rotation * tourqe);
                }
            }
        }
    }
}
