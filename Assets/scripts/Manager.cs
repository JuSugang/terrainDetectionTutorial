using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Manager : MonoBehaviour
{
    public GameObject ARCamera;
    private SmartTerrainTracker mTracker;
    private ReconstructionBehaviour mReconstructionBehaviour;
    private PropBehaviour mPropBehaviour;
    // Use this for initialization
    void Start () {
        mTracker = TrackerManager.Instance.GetTracker<SmartTerrainTracker>();
        mReconstructionBehaviour = (ReconstructionBehaviour)FindObjectOfType(typeof(ReconstructionBehaviour));
        Debug.Log("h1 " + mTracker);
        Debug.Log("h2 " + mReconstructionBehaviour);
    }

    public void saveMesh()
    {
        mTracker = TrackerManager.Instance.GetTracker<SmartTerrainTracker>();
        mReconstructionBehaviour = (ReconstructionBehaviour)FindObjectOfType(typeof(ReconstructionBehaviour));
        Debug.Log("h1 " + mTracker);
        Debug.Log("h2 " + mReconstructionBehaviour);
    }
    public void restart()
    {
        mTracker = TrackerManager.Instance.GetTracker<SmartTerrainTracker>();
        mReconstructionBehaviour = (ReconstructionBehaviour)FindObjectOfType(typeof(ReconstructionBehaviour));
        if ((mReconstructionBehaviour != null) && (mReconstructionBehaviour.Reconstruction != null))
        {
            bool trackerWasActive = mTracker.IsActive;
            // first stop the tracker
            if (trackerWasActive)
                mTracker.Stop();
            // now you can reset...
            mReconstructionBehaviour.Reconstruction.Reset();
            // ... and restart the tracker
            if (trackerWasActive)
            {
                mTracker.Start();
                mReconstructionBehaviour.Reconstruction.Start();
            }
        }
    }
	// Update is called once per frame
	void Update () {
		
	}

}
