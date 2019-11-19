
namespace GoogleARCore.Examples.ObjectManipulation
{
    using GoogleARCore.Examples.ObjectManipulationInternal;
    using UnityEngine;

    public class SelectionMore : Manipulator
    {
        public GameObject model1;
        public GameObject model2;
        public GameObject ManipulatorPrefab;
        private GameObject SelectedObject;
        private bool model = false;
        private GameObject theTarget;
        private Mesh initialMesh;
        private Mesh swapMesh;
        /// <summary>
        /// The Unity's Start method.
        /// </summary>
        protected void Start()
        {
        }

        /// <summary>
        /// The Unity's Update method.
        /// </summary>
        protected override void Update()
        {
        }

        /// <summary>
        /// Returns true if the manipulation can be started for the given gesture.
        /// </summary>
        /// <param name="gesture">The current gesture.</param>
        /// <returns>True if the manipulation can be started.</returns>
        protected override bool CanStartManipulationForGesture(TapGesture gesture)
        {
            if(gesture.TapObject == gameObject) return true;
            else return false;
        }

        /// <summary>
        /// Function called when the manipulation is started.
        /// </summary>
        /// <param name="gesture">The current gesture.</param>
        protected override void OnStartManipulation(TapGesture gesture)
        {
            TrackableHit hit;
            TrackableHitFlags raycastFilter = TrackableHitFlags.PlaneWithinPolygon;

            if (Frame.Raycast(gesture.StartPosition.x, gesture.StartPosition.y, raycastFilter, out hit))
            {
                GameObject gameObject;
                if(model) gameObject = Instantiate(model1, SelectedObject.transform.position, SelectedObject.transform.rotation);
                else      gameObject = Instantiate(model2, SelectedObject.transform.position, SelectedObject.transform.rotation);
                var manipulator = Instantiate(ManipulatorPrefab, SelectedObject.transform.position, SelectedObject.transform.rotation);
                gameObject.transform.parent = manipulator.transform;
                var anchor = hit.Trackable.CreateAnchor(hit.Pose);
                manipulator.transform.parent = anchor.transform;
                manipulator.GetComponent<Manipulator>().Select();
            }

            model = !model;
            Destroy(SelectedObject);
        }

        public void setTarget(GameObject target)
        {
            SelectedObject = target;
        }


    }
}
