using UnityEngine;
using System.Collections;

/// <summary>
/// Contains manager related classes.
/// </summary>
namespace Base.Manager {

    /// <summary>
    /// BaseClass for managers that want to be Loaded,Unloaded and Reset.
    /// </summary>
    public class ManagerObject : MonoBehaviour {

        /// <summary>
        /// Load this manager.
        /// </summary>
        public virtual void Load () {

        }

        /// <summary>
        /// Unload this manager.
        /// </summary>
        public virtual void Unload () {

        }

        /// <summary>
        /// Resets the manager.
        /// </summary>
        public virtual void Reset () {

        }

    }

}