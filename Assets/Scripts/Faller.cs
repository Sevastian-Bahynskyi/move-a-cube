using System.Threading.Tasks;
using UnityEngine;

public class Faller : MonoBehaviour
{
    [SerializeField] private float seconds = 3;

    private Rigidbody rigidbody;
    private MeshRenderer renderer;
    // Start is called before the first frame update
    async void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        rigidbody = GetComponent<Rigidbody>();
        
        renderer.enabled = false;
        rigidbody.useGravity = false;
        await Task.Delay((int)(seconds * 1000));
        
        rigidbody.useGravity = true;
        renderer.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
