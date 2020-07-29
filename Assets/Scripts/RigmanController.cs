using System.Collections.Generic;
using UnityEngine;

public class RigmanController : MonoBehaviour, IHittedObject
{
    private class RigJoint
    {
        public Rigidbody rigidbody;
        public Vector3 defaultPosePosition;
        public Quaternion defaultPoseRotation;
        
        public RigJoint(Rigidbody rigidbody)
        {
            this.rigidbody = rigidbody;
            defaultPosePosition = rigidbody.transform.localPosition;
            defaultPoseRotation = rigidbody.transform.localRotation;
        }
    }

    private bool _freezed = false;
    private List<RigJoint> _joints = new List<RigJoint>();

    private void Start()
    {
        _joints = FindJoints(transform);
        Freeze();
    }

    public void ResetPose()
    {
        foreach (RigJoint joint in _joints)
        {
            joint.rigidbody.transform.localPosition = joint.defaultPosePosition;
            joint.rigidbody.transform.localRotation = joint.defaultPoseRotation;
        }
    }

    public void Hit(HitData hit)
    {
        RigJoint joint = _joints.Find(x => x.rigidbody.GetComponent<Collider>() == hit.collider);
        
        if (joint != null)
        {
            Unfreeze();
            joint.rigidbody.AddForce(hit.direction * hit.force, ForceMode.Impulse);

            foreach (IEffect effect in GetComponents<IEffect>())
            {
                effect.PlayEffect();
            }
        }
    }

    public void Freeze()
    {
        _freezed = true;
        UpdateJointState();
    }

    public void Unfreeze()
    {
        _freezed = false;
        UpdateJointState();
    }

    private void UpdateJointState()
    {
        foreach (RigJoint joint in _joints)
        {
            joint.rigidbody.isKinematic = _freezed;
        }
    }

    private List<RigJoint> FindJoints(Transform root)
    {
        List<RigJoint> joints = new List<RigJoint>();

        foreach (Rigidbody rigidbody in root.GetComponentsInChildren<Rigidbody>())
        {
            joints.Add(new RigJoint(rigidbody));
        }

        return joints;
    }
}
