using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Vuforia;

public class Manager : MonoBehaviour
{
    public GameObject ARCamera;
    public GameObject wall;
    private SmartTerrainTracker mTracker;
    private ReconstructionBehaviour mReconstructionBehaviour;
    private PropBehaviour mPropBehaviour;
    
    // Use this for initialization
    void Start () {
        mTracker = TrackerManager.Instance.GetTracker<SmartTerrainTracker>();
        mReconstructionBehaviour = (ReconstructionBehaviour)FindObjectOfType(typeof(ReconstructionBehaviour));
    }

    public void saveMesh()
    {
        if(mTracker==null || mReconstructionBehaviour == null) { 
            mTracker = TrackerManager.Instance.GetTracker<SmartTerrainTracker>();
            mReconstructionBehaviour = (ReconstructionBehaviour)FindObjectOfType(typeof(ReconstructionBehaviour));
        }
        IEnumerable<Prop> propIEnu= mReconstructionBehaviour.GetActiveProps();
        IEnumerator<Prop> e = propIEnu.GetEnumerator();
        int count = 0;
        while (e.MoveNext())
        {
            count++;

            var mf = wall.GetComponent<MeshFilter>();
            var mesh=mf.sharedMesh;
            mesh.vertices= e.Current.GetMesh().vertices;
            mesh.triangles = e.Current.GetMesh().triangles;
            
            //Object tempMesh = e.Current.GetMesh();
            //Vector3[] temp = e.Current.GetMesh().vertices;
            //int[] b =e.Current.GetMesh().triangles;
            //Debug.Log(e.Current.GetMesh().vertexCount);
            
            //foreach(Vector3 a in temp)
            //{
            //    Debug.Log("coord= "+a);
            //}
            //foreach (int a in b)
            //{
            //    Debug.Log("tri= " + a);
            //}
            //SaveObjectToFile(tempMesh, "Assets/data" + count+".obj");

        }
        Debug.Log("count= " + count);
    }
    public static void SaveObjectToFile(Object obj, string fileName)
    {
        AssetDatabase.CreateAsset(obj, fileName);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
    public void restart()
    {
        if (mTracker == null || mReconstructionBehaviour == null)
        {
            mTracker = TrackerManager.Instance.GetTracker<SmartTerrainTracker>();
            mReconstructionBehaviour = (ReconstructionBehaviour)FindObjectOfType(typeof(ReconstructionBehaviour));
        }
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
