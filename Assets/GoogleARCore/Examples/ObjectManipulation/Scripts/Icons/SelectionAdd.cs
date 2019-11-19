
namespace GoogleARCore.Examples.ObjectManipulation
{
    using GoogleARCore.Examples.ObjectManipulationInternal;
    using UnityEngine;

    public class SelectionAdd : Manipulator
    {
        private GameObject SelectedObject;
        public GameObject ManipulatorPrefab;
        public GameObject PawnPrefab;

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
            var offSet = new Vector3(0, 0, 0.18f);
            for (int i = 0; i < 2; ++i)
            {
                TrackableHit hit;
                TrackableHitFlags raycastFilter = TrackableHitFlags.PlaneWithinPolygon;

                if (Frame.Raycast(gesture.StartPosition.x, gesture.StartPosition.y, raycastFilter, out hit))
                {
                    var gameObject = Instantiate(PawnPrefab, SelectedObject.transform.position + offSet, SelectedObject.transform.rotation);
                    var manipulator = Instantiate(ManipulatorPrefab, SelectedObject.transform.position + offSet, SelectedObject.transform.rotation);
                    gameObject.transform.parent = manipulator.transform;
                    var anchor = hit.Trackable.CreateAnchor(hit.Pose);
                    manipulator.transform.parent = anchor.transform;
                    manipulator.GetComponent<Manipulator>().Deselect();
                }

                offSet = new Vector3(0.18f, 0, 0);
            }

            Destroy(gameObject);
        }

        public void setTarget(GameObject target)
        {
            SelectedObject = target;
        }


    }
}
