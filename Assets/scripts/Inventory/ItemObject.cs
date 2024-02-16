using UnityEngine;

public class ItemObject:MonoBehaviour
{
    public int ItemCount;
    public ObjectTypes type { get { return _type; } }
    [SerializeField] private ObjectTypes _type;
}