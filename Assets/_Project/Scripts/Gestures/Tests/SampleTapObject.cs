using UnityEngine;

public class SampleTapObject : MonoBehaviour, ITappable, ISwipeable
{
    [SerializeField] private Vector3 targetPos;
    [SerializeField] private float speed = 10;

    private void OnEnable()
    {
        targetPos = transform.position;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }

    public void OnTap()
    {
        targetPos += new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
    }

    public void OnSwipe(SwipeEventArgs swipeEventArgs)
    {
        Vector3 moveDir = swipeEventArgs.RawDirection.normalized;
        targetPos = targetPos + (moveDir * 5f);
    }

    public void OnDrag(DragEventArgs args)
    {
        Ray ray = Camera.main.ScreenPointToRay(args.TargetFinger.position);
        Vector3 point = ray.GetPoint(4f);

        transform.position = point;
        targetPos = point;
    }
}
