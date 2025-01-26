using UnityEngine;

public class Follower : MonoBehaviour
{
    public Transform Target { get; set;  }
    
    private void Update()
    {
        if (Target == null) return;
        transform.position = Target.position;
    }
}
