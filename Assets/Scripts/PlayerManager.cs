using UnityEngine;
using UnityEngine.EventSystems;
using Photon.Pun;
using Photon.Pun.Demo.PunBasics;

namespace Com.Antoid.Bus {
    /// <summary>
    /// Player manager.
    /// </summary>
    public class PlayerManager : MonoBehaviourPunCallbacks {
        [Tooltip("The local player instance. Use this to know if the local player is represented in the Scene")]
        public static GameObject LocalPlayerInstance;

        private void Awake() {
            // #Important
            // used in GameManager.cs: we keep track of the localPlayer instance to prevent instantiation when levels are synchronized
            if (photonView.IsMine) {
                PlayerManager.LocalPlayerInstance = this.gameObject;
            }
            // #Critical
            // we flag as don't destroy on load so that instance survives level synchronization, thus giving a seamless experience when levels load.
            DontDestroyOnLoad(this.gameObject);
        }

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
