using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Antoid.Bus {
    public class CameraFollow : MonoBehaviour {
        // cached transform of the target
        private Transform cameraTransform;
        
        // maintain a flag internally to reconnect if target is lost or camera is switched
		private bool isFollowing = false;
        
        // Cache for camera offset
		public Vector3 cameraOffset = Vector3.zero;
        
		void LateUpdate() {
			// The transform target may not destroy on level load, 
			// so we need to cover corner cases where the Main Camera is different everytime we load a new scene, and reconnect when that happens
			if (cameraTransform == null && isFollowing) {
				OnStartFollowing();
			}

			// only follow is explicitly declared
			if (isFollowing) {
				Follow ();
			}
		}
        
        /// <summary>
		/// Raises the start following event. 
		/// Use this when you don't know at the time of editing what to follow, typically instances managed by the photon network.
		/// </summary>
		public void OnStartFollowing() {	      
			cameraTransform = Camera.main.transform;
			isFollowing = true;
		}
        
        /// <summary>
		/// Follow the target smoothly
		/// </summary>
		private void Follow() {
		    cameraTransform.position = this.transform.position - this.transform.rotation * new Vector3(0, -5, 5);
            cameraTransform.LookAt(this.transform.position + this.transform.rotation * new Vector3(0, 0, 10));
	    }
    }
}
