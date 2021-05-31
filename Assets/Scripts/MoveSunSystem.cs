using UnityEngine;
using System.Collections;

public class MoveSunSystem : MonoBehaviour {

	public Transform target; // the object to rotate around
	public float speedRotation = 10f; // the speed of rotation
	public float speedMoving = 0.5f;

	private IEnumerator _coroutineMoveSun;
	private WaitForSeconds waitForMoveSun;
	[SerializeField] private float waitForMoveSunDely = 0.1f;


	#region UnityMetods

	private void Start() 
	{
		if (target == null) 
		{
			target = this.gameObject.transform;
			Debug.Log ("RotateAround target not specified. Defaulting to parent GameObject");
		}
		waitForMoveSun = new WaitForSeconds(waitForMoveSunDely);
		StartCoroutineMoveSun();
	}

	private void Update () 
	{
		AroundRotate();
	}

	#endregion

	public void AroundRotate()
	{
		transform.RotateAround(target.transform.position, target.transform.up, speedRotation * Time.deltaTime);
	}

	public void MoveSun()
	{
		if (gameObject.name == "Sun")
        {
			transform.Translate(Vector3.forward * speedRotation * Time.deltaTime);
		}
	}

	[ContextMenu("StartCoroutineMoveSun")]
	public void StartCoroutineMoveSun()
    {
		_coroutineMoveSun = MoveSunCor();
		StartCoroutine(_coroutineMoveSun);
	}

	[ContextMenu("StopCoroutineMoveSun")]
	public void StopCoroutineMoveSun()
	{
		StopCoroutine(_coroutineMoveSun);
	}

	private IEnumerator MoveSunCor()
    {
		while(true)
        {
			yield return waitForMoveSun;
			MoveSun();
		}
	}
}
