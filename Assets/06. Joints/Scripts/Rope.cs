using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Rope : MonoBehaviour
{
    public Rigidbody attachment;

    public Material ropeMaterial;

    [Range(1, 10)]
    public int segments = 5;

    public bool oneClickFix = false;

    private void Start()
    {
        GenerateRope();
    }

    private void GenerateRope()
    {
        Rigidbody myRigidBody = GetComponent<Rigidbody>();

        Vector3 segmentDirection = (myRigidBody.position - attachment.position) / segments;
        Vector3 currentPosition = attachment.position;
        Rigidbody upperBody = attachment;

        ConfigurableJointMotion jointMotion = ConfigurableJointMotion.Locked;
        VisualiseConnection connectionVisualiser;
        ConfigurableJoint joint;
        for(int i = segments - 1; i --> 0; )
        {
            GameObject newGO = new GameObject("Rope Piece " + (i+1).ToString());
            newGO.transform.position = currentPosition;
            Rigidbody ropePieceRB = newGO.AddComponent<Rigidbody>();
            joint = newGO.AddComponent<ConfigurableJoint>();

            joint.axis = Vector3.up;
            joint.secondaryAxis = Vector3.zero;
            joint.connectedBody = upperBody;
            joint.connectedAnchor = -segmentDirection;
            joint.yMotion = jointMotion;
            joint.xMotion = jointMotion;
            joint.zMotion = jointMotion;

            if(oneClickFix)
                joint.projectionMode = JointProjectionMode.PositionAndRotation;

            connectionVisualiser = newGO.AddComponent<VisualiseConnection>();
            connectionVisualiser.start = newGO.transform;
            connectionVisualiser.end = upperBody.transform;
            connectionVisualiser.material = ropeMaterial;

            upperBody = ropePieceRB;
            currentPosition += segmentDirection;
        }

        joint = gameObject.AddComponent<ConfigurableJoint>();

        joint.axis = Vector3.up;
        joint.secondaryAxis = Vector3.zero;
        joint.connectedBody = upperBody;
        joint.connectedAnchor = -segmentDirection;
        joint.yMotion = jointMotion;
        joint.xMotion = jointMotion;
        joint.zMotion = jointMotion;
        
        if(oneClickFix)
            joint.projectionMode = JointProjectionMode.PositionAndRotation;

        connectionVisualiser = gameObject.AddComponent<VisualiseConnection>();
        connectionVisualiser.start = transform;
        connectionVisualiser.end = upperBody.transform;
        connectionVisualiser.material = ropeMaterial;
    }
}
