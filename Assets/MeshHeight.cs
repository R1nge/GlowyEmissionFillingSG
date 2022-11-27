using UnityEngine;

public class MeshHeight : MonoBehaviour
{
    [SerializeField] private int index;
    [SerializeField] private float speed;
    private bool _up;
    private float _fill;
    private Mesh _mesh;
    private float _height;
    private Material _material;
    private static readonly int ObjectHeight = Shader.PropertyToID("_ObjectHeight");
    private static readonly int Fill = Shader.PropertyToID("_Fill");


    private void Awake()
    {
        _mesh = GetComponent<MeshFilter>().mesh;
        _material = GetComponent<MeshRenderer>().materials[index];
    }

    private void Start()
    {
        _height = _mesh.bounds.size.y;
        _material.SetFloat(ObjectHeight, _height);
    }

    private void Update()
    {
        if (_fill >= 1)
        {
            _up = false;
        }
        else if (_fill <= 0)
        {
            _up = true;
        }

        if (_up)
        {
            _fill += Time.deltaTime * speed;
        }
        else
        {
            _fill -= Time.deltaTime * speed;
        }

        _material.SetFloat(Fill, _fill);
    }
}