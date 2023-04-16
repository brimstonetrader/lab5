using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CDPickup : MonoBehaviour
{
    public GameObject cd;

    void Start()
    {
        Spin();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider != null && collision.collider.tag == "MainCamera")
        {
            Debug.Log("CD picked up");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    IEnumerator Spin()
    {
        while (true)
        {
            cd.transform.Rotate(0.0f, 1.0f, 1.0f, Space.Self);    //Rotate left 
            yield return new WaitForSeconds(0.1f);
        }
    }
}
