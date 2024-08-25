using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{

    [SerializeField] private Transform cammera;

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Slerp(transform.localRotation,
        Quaternion.LookRotation(cammera.position - transform.position),
        360 * Time.deltaTime);

        float yRotation = transform.eulerAngles.y;
        transform.eulerAngles = new Vector3(0, yRotation, 0);
    }
}
