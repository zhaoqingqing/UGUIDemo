using UnityEngine;
public class LookAt : MonoBehaviour
{
	public Transform Target;
	public float Damping = 3.33f;
	protected void LateUpdate()
	{
		var r = Quaternion.LookRotation(transform.position - Target.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, r, Time.deltaTime * Damping);
	}
}
