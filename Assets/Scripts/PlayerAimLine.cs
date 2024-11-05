using UnityEngine;

public class PlayerAimLine : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform firePoint;
    public Color lineColor = Color.red;
    
    [Header("Arc Settings")]
    public float arcHeight = 2f;
    public int lineSegments = 25; // More segments = smoother arc
    
    [Header("Dash Settings")]
    public float dashSize = 0.5f;
    public float gapSize = 0.5f;
    
    private Camera mainCamera;

    void Start()
    {
        if (lineRenderer == null)
        {
            Debug.LogError("LineRenderer component is not assigned! Please assign it in the inspector.");
            enabled = false;
            return;
        }
        
        // Set width once and don't modify it elsewhere
        lineRenderer.useWorldSpace = true;
        lineRenderer.widthMultiplier = 1f;  // Ensure multiplier is 1
        
        // Set material properties
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.material.color = lineColor;
        lineRenderer.textureMode = LineTextureMode.Tile;
        lineRenderer.material.mainTexture = CreateDashTexture();
        
        mainCamera = Camera.main;
    }

    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Vector3 targetPosition;

        if (Physics.Raycast(ray, out hit))
        {
            targetPosition = hit.point;
        }
        else
        {
            targetPosition = ray.GetPoint(100);
        }

        DrawArc(targetPosition);
    }

    void DrawArc(Vector3 targetPoint)
    {
        // Check if target is too close
        if ((targetPoint - firePoint.position).magnitude < 0.001f)
        {
            lineRenderer.positionCount = 0;
            return;
        }

        Vector3 velocity = CalculateArcVelocity(firePoint.position, targetPoint, arcHeight);
        float timeToTarget = EstimateTimeToTarget(firePoint.position, targetPoint, arcHeight);
        Vector3[] arcPoints = new Vector3[lineSegments];

        for (int i = 0; i < lineSegments; i++)
        {
            float t = i / (float)(lineSegments - 1);
            float timeAtPoint = t * timeToTarget;
            
            Vector3 position = firePoint.position + velocity * timeAtPoint + 
                              0.5f * Physics.gravity * timeAtPoint * timeAtPoint;

            // Check for invalid positions
            if (float.IsNaN(position.x) || float.IsInfinity(position.x) ||
                float.IsNaN(position.y) || float.IsInfinity(position.y) ||
                float.IsNaN(position.z) || float.IsInfinity(position.z))
            {
                position = firePoint.position;
            }

            arcPoints[i] = position;
        }

        lineRenderer.positionCount = lineSegments;
        lineRenderer.SetPositions(arcPoints);
    }

    Vector3 CalculateArcVelocity(Vector3 startPoint, Vector3 endPoint, float arcHeight)
    {
        try
        {
            Vector3 distance = endPoint - startPoint;
            Vector3 distanceXZ = distance;
            distanceXZ.y = 0;

            // Safety checks
            if (arcHeight <= 0) arcHeight = 0.1f;
            if (distanceXZ.magnitude < 0.001f) return Vector3.zero;

            float time = Mathf.Sqrt(-2 * arcHeight / Physics.gravity.y) + 
                        Mathf.Sqrt(2 * (distance.y - arcHeight) / Physics.gravity.y);

            // Check for invalid time
            if (float.IsNaN(time) || float.IsInfinity(time) || time <= 0)
            {
                time = 1f;
            }

            Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * Physics.gravity.y * arcHeight);
            Vector3 velocityXZ = distanceXZ / time;

            Vector3 finalVelocity = velocityXZ + velocityY * -Mathf.Sign(Physics.gravity.y);

            // Check for invalid values
            if (float.IsNaN(finalVelocity.x) || float.IsInfinity(finalVelocity.x) ||
                float.IsNaN(finalVelocity.y) || float.IsInfinity(finalVelocity.y) ||
                float.IsNaN(finalVelocity.z) || float.IsInfinity(finalVelocity.z))
            {
                return Vector3.zero;
            }

            return finalVelocity;
        }
        catch
        {
            return Vector3.zero;
        }
    }

    float EstimateTimeToTarget(Vector3 startPoint, Vector3 endPoint, float arcHeight)
    {
        try
        {
            if (arcHeight <= 0) arcHeight = 0.1f;
            Vector3 distance = endPoint - startPoint;
            float time = Mathf.Sqrt(-2 * arcHeight / Physics.gravity.y) + 
                        Mathf.Sqrt(2 * (distance.y - arcHeight) / Physics.gravity.y);

            // Check for invalid time
            if (float.IsNaN(time) || float.IsInfinity(time) || time <= 0)
            {
                return 1f;
            }

            return time;
        }
        catch
        {
            return 1f;
        }
    }

    Texture2D CreateDashTexture()
    {
        int textureWidth = 32;
        int textureHeight = 2;
        Texture2D texture = new Texture2D(textureWidth, textureHeight);
        
        // Create dash pattern
        for (int x = 0; x < textureWidth; x++)
        {
            for (int y = 0; y < textureHeight; y++)
            {
                if (x < textureWidth * dashSize / (dashSize + gapSize))
                    texture.SetPixel(x, y, Color.white);
                else
                    texture.SetPixel(x, y, Color.clear);
            }
        }
        
        texture.wrapMode = TextureWrapMode.Repeat;
        texture.Apply();
        return texture;
    }
} 