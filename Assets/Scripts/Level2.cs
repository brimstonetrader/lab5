// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine.SceneManagement;
// using UnityEngine;

// public class Level2 : MonoBehaviour {

// 	public GameObject target;
// 	public float speed;
// 	public float rotationSpeed;

// 	private Rigidbody body;

//     void Awake()
//     {
//         StartCoroutine(VirusSpeed());
//     }

//     void Start () {
// 		body = GetComponent<Rigidbody>();
// 	}
	
// 	// Update is called once per frame
// 	void FixedUpdate () {
// 		Vector3 desired = (target.transform.position - transform.position).normalized;
// 		body.AddForce(desired * speed - body.velocity);

// 		float angle = (Mathf.Atan2(desired.y, desired.x) * Mathf.Rad2Deg) - 90;
// 		Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
// 		transform.rotation = Quaternion.Slerp(transform.rotation,
// 			q, Time.deltaTime * rotationSpeed);

// 	}

// 	public void IncreaseSpeed() {
// 		speed *= 1.2f;
// 	}

// 	void OnCollisionEnter(Collision coll) {
//         if (coll.gameObject == target)
//         {
//             GetComponent<AudioSource>().Play();
//             SceneManager.LoadScene("Death_scene");
//         }
//     }


//     IEnumerator VirusSpeed()
//     {
//         while (true)
//         {
//             yield return new WaitForSeconds(3);
//             IncreaseSpeed();
// 			// After 60 seconds, the swan speed will be 10+.
// 			// This basically makes the game unplayable. So the player has one minute to make it to the cave
//         }
//     }

// }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : MonoBehaviour{
    public float speed;
    public float distance;

    private Vector3 startPosition;
    private Vector3 endPosition;
    private Vector3 direction;
    private float travelTime;

    void Start(){
        startPosition = transform.position;
        endPosition = startPosition + new Vector3(distance, 0, 0);
        direction = (endPosition - startPosition).normalized;
        travelTime = distance / speed;
        StartCoroutine(Move());
    }

    IEnumerator Move(){
        while (true){
            yield return StartCoroutine(MoveToPosition(endPosition, travelTime));
            yield return StartCoroutine(MoveToPosition(startPosition, travelTime));
        }
    }

    IEnumerator MoveToPosition(Vector3 targetPosition, float time){
        float elapsedTime = 0;

        Vector3 startingPosition = transform.position;

        while (elapsedTime < time){
            transform.position = Vector3.Lerp(startingPosition, targetPosition, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
    }
}

