using UnityEngine;
using UnityEngine.AI;

public class BotMove : Character
{
    
    private int cornerIndex;
    private Vector3 point;
    public NavMeshPath path;

    private void Awake()
    {
        path = new NavMeshPath();
    }

    public void CalculatePath(Vector3 point)
    {
        if (point == this.point) return;
        this.point = point;
        cornerIndex = 0;
        NavMesh.CalculatePath(transform.position, point, NavMesh.AllAreas, path);
    }

    public void MoveByPath()
    {
        if (path != null && cornerIndex >= path.corners.Length) return;
        Vector3 direction = path.corners[cornerIndex] - transform.position;
        Move(direction, Speed);
        if (Vector3.Distance(transform.position, path.corners[cornerIndex]) <= 0.5f)
        {
            cornerIndex++;
        }
    }
}