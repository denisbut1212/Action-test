using UnityEngine;

public class SnapshotCameraTest : MonoBehaviour
{
    public Color backgroundColor = Color.clear;

    public GameObject objectToSnapshot;

    public Vector3 position = new Vector3(0, 0, 1);

    public Vector3 rotation = new Vector3(345.8529f, 313.8297f, 14.28433f);

    public Vector3 scale = new Vector3(1, 1, 1);

    private SnapshotCamera _snapshotCamera;
    private Texture2D _texture;

    private void Start()
    {
        _snapshotCamera = SnapshotCamera.MakeSnapshotCamera("SnapshotLayer");

        UpdatePreview();
    }

    private void OnGUI()
    {
        GUI.TextField(new Rect(10, 5, 275, 21), "Press \"Spacebar\" to save the snapshot");
        GUI.TextField(new Rect(10, 30, 275, 21), "Press \"Q or R\" to rotate object");

        if (_texture != null)
        {
            GUI.backgroundColor = Color.clear;
            GUI.Box(new Rect(10, 32, _texture.width, _texture.height), _texture);
        }
    }

    public void UpdatePreview()
    {
        if (objectToSnapshot != null)
        {
            // Destroy the texture to prevent a memory leak
            // For a bit of fun you can try removing this and watching the memory profiler while for example continuously changing the rotation to trigger UpdatePreview()
            Destroy(_texture);

            // Take a new snapshot of the objectToSnapshot
            _texture = _snapshotCamera.TakeObjectSnapshot(objectToSnapshot, backgroundColor, position,
                Quaternion.Euler(rotation), scale, 512, 512);
        }
    }

    private void Update()
    {
        // Save a PNG of the snapshot when pressing space
        if (Input.GetKeyUp(KeyCode.Space))
        {
            UpdatePreview();
            var fi = SnapshotCamera.SavePNG(_texture);

            Debug.Log(string.Format("Snapshot {0} saved to {1}", fi.Name, fi.DirectoryName));
        }
    }
}