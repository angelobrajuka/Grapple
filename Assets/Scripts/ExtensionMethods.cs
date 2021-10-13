using UnityEngine;

public static class ExtensionMethods
{
    public static void SetJointMotion(this ConfigurableJoint joint, ConfigurableJointMotion motionType)
    {
        joint.xMotion = motionType;
        joint.yMotion = motionType;
        joint.zMotion = motionType;
    }

    public static Vector3 GetStart(this ConfigurableJoint joint)
    {
        return joint.transform.GetComponent<Rigidbody>().position+joint.anchor;
    }

    public static Vector3 GetEnd(this ConfigurableJoint joint)
    {
        return joint.connectedBody.position+joint.connectedAnchor;
    }

    public static void SetDistance(this ConfigurableJoint joint)
    {
        var ll = joint.linearLimit;
        ll.limit = Vector3.Distance(joint.GetStart(), joint.GetEnd());
        joint.linearLimit = ll;
    }

    public static bool WithinLimit(this ConfigurableJoint joint, float tolerance)
    {
        return Vector3.Distance(joint.GetStart(), joint.GetEnd()) <= joint.linearLimit.limit+tolerance;
    }
}