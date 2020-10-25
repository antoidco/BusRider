using UnityEngine;
using UnityEngine.EventSystems;
using Photon.Pun;
using Photon.Pun.Demo.PunBasics;

namespace Com.Antoid.Bus {
    /// <summary>
    /// Player manager.
    /// </summary>
    public class PlayerManager : MonoBehaviourPunCallbacks {

        private void Start() {
            CameraWork _cameraWork = this.gameObject.GetComponent<CameraWork>();

            if (_cameraWork != null) {
                if (photonView.IsMine) {
                    _cameraWork.OnStartFollowing();
                }
            } else {
                Debug.LogError("<Color=Red><a>Missing</a></Color> CameraWork Component on playerPrefab.", this);
            }
        }

        /// <summary>
        /// MonoBehaviour method called on GameObject by Unity on every frame.
        /// </summary>
        void Update() {
            if (photonView.IsMine) {
                ProcessInputs();
            }
        }

        /// <summary>
        /// Processes the inputs. 
        /// </summary>
        void ProcessInputs() {

        }
    }
}
