using System;
using Kiwi.Core;
using Kiwi.Extensions;
using UnityEngine;

[DefaultExecutionOrder(-1000)]
[DisallowMultipleComponent]
public class GestureManager : MonoBehaviourSingleton<GestureManager>
{
    [Header("Gesture Configs")]
    [SerializeField] private TapGestureConfig tapGestureConfig = null;
    [SerializeField] private DragGestureConfig dragGestureSettings = null;
    [SerializeField] private SwipeGestureConfig swipeGestureConfig = null;
    [SerializeField] private TwoFingerPanGestureConfig twoFingerPanGestureConfig = null;
    [SerializeField] private PinchSpreadGestureConfig pinchSpreadGestureConfig = null;
    [SerializeField] private RotateGestureConfig rotateGestureConfig = null;

    public event EventHandler<DragEventArgs> OnDrag;
    public event EventHandler<TapEventArgs> OnTap;
    public event EventHandler<SwipeEventArgs> OnSwipe;
    public event EventHandler<TwoFingerPanEventArgs> OnTwoFingerPan;
    public event EventHandler<PinchSpreadEventArgs> OnPinchSpread;
    public event EventHandler<RotateEventArgs> OnRotate;

    private Touch gestureFinger1;
    private Touch gestureFinger2;
    private Vector2 startPos;
    private Vector2 endPos;
    private float gestureTime;

    protected override void SingletonAwake()
    {
        
    }

    private void Update()
    {
        if (Input.touchCount == 0)
            return;

        if (Input.touchCount == 1)
        {
            gestureFinger1 = Input.GetTouch(0);
            ProcessOneTouchGesture();
        }
        else if (Input.touchCount == 2)
        {
            gestureFinger1 = Input.GetTouch(0);
            gestureFinger2 = Input.GetTouch(1);
            ProcessTwoTouchGesture();
        }
    }

    private void ProcessTwoTouchGesture()
    {
        if (twoFingerPanGestureConfig.IsValidGesture(gestureFinger1, gestureFinger2))
        {
            FireTwoFingerPan();
            return;
        }

        if (rotateGestureConfig.IsValidGesture(gestureFinger1, gestureFinger2))
        {
            Vector2 prev1 = gestureFinger1.GetPreviousPoint();
            Vector2 prev2 = gestureFinger2.GetPreviousPoint();
            Vector2 prevVector = prev1 - prev2;
            Vector2 curVector = gestureFinger1.position - gestureFinger2.position;
            float angle = Vector2.SignedAngle(prevVector, curVector);

            if (Mathf.Abs(angle) >= rotateGestureConfig.MinDelta)
            {
                FireRotateEvent(angle);
                return;
            }
        }
        
        if (pinchSpreadGestureConfig.IsValidGesture(gestureFinger1, gestureFinger2))
        {
            Vector2 prev1 = gestureFinger1.GetPreviousPoint();
            Vector2 prev2 = gestureFinger2.GetPreviousPoint();
            float curDistance = Vector2.Distance(gestureFinger1.position, gestureFinger2.position);
            float prevDistance = Vector2.Distance(prev1, prev2);
            float diff = curDistance - prevDistance;

            if (Mathf.Abs(diff) >= pinchSpreadGestureConfig.MinChange * Screen.dpi)
            {
                FirePinchSpread(diff);
                return;
            }
        }
    }

    private void FireTwoFingerPan()
    {
        Vector2 midPoint = gestureFinger1.position.GetMidPoint(gestureFinger2.position);
        GameObject hitGameObject = GetHitGameObject(midPoint);
        TwoFingerPanEventArgs args = new TwoFingerPanEventArgs(gestureFinger1, gestureFinger2);
        
        OnTwoFingerPan?.Invoke(this, args);

        if (hitGameObject != null)
        {
            if (hitGameObject.TryGetComponent(out ITwoFingerPannable twoFingerPan))
            {
                twoFingerPan.OnTwoFingerPan(args);
            }
        }
    }

    private void FireRotateEvent(float angle)
    {
        Vector2 midPoint = gestureFinger1.position.GetMidPoint(gestureFinger2.position);
        GameObject hitGameObject = GetHitGameObject(midPoint);
        RotateEventArgs args = new RotateEventArgs(gestureFinger1, gestureFinger2, angle, hitGameObject);
        
        OnRotate?.Invoke(this, args);

        if (hitGameObject != null)
        {
            if (hitGameObject.TryGetComponent(out IRotatable rotate))
            {
                rotate.OnRotate(args);
            }
        }
    }

    private void FirePinchSpread(float diff)
    {
        Vector2 midPoint = gestureFinger1.position.GetMidPoint(gestureFinger2.position);
        GameObject hitGameObject = GetHitGameObject(midPoint);
        PinchSpreadEventArgs args = new PinchSpreadEventArgs(gestureFinger1, gestureFinger2, diff, hitGameObject);
        
        OnPinchSpread?.Invoke(this, args);

        if (hitGameObject != null)
        {
            if (hitGameObject.TryGetComponent(out IPinchSpreadable pinchSpread))
            {
                pinchSpread.OnPinchSpread(args);
            }
        }
    }

    private void ProcessOneTouchGesture()
    {
        if (gestureFinger1.phase == TouchPhase.Began)
        {
            startPos = gestureFinger1.position;
            gestureTime = 0;
        }
        else if (gestureFinger1.phase == TouchPhase.Ended)
        {
            endPos = gestureFinger1.position;

            if (swipeGestureConfig.IsValidGesture(gestureTime, startPos, endPos))
            {
                FireSwipeEvent();
            }
            else if (tapGestureConfig.IsValidGesture(gestureTime, startPos, endPos))
            {
                FireTapEvent();
            }
        }
        else
        {
            gestureTime += Time.deltaTime;

            if (dragGestureSettings.IsValidGesture(gestureTime))
            {
                FireDragEvent();
            }
        }
    }

    private void FireTapEvent()
    {
        GameObject hitObj = GetHitGameObject(startPos);
        TapEventArgs args = new TapEventArgs(startPos, hitObj);
        OnTap?.Invoke(this, args);

        if (hitObj != null)
        {
            if (hitObj.TryGetComponent(out ITappable tappedObj))
            {
                tappedObj.OnTap();
            }
        }
    }

    private void FireSwipeEvent()
    {
        Vector2 diff = endPos - startPos;
        Direction dir;

        if (Mathf.Abs(diff.x) > Mathf.Abs(diff.y))
        {
            dir = diff.x > 0 ? Direction.Right : Direction.Left;
        }
        else
        {
            dir = diff.y > 0 ? Direction.Up : Direction.Down;
        }

        GameObject hitGameObject = GetHitGameObject(startPos);
        SwipeEventArgs args = new SwipeEventArgs(startPos, diff, dir, hitGameObject);
        OnSwipe?.Invoke(this, args);

        if (hitGameObject != null)
        {
            if (hitGameObject.TryGetComponent(out ISwipeable swipeable))
            {
                swipeable.OnSwipe(args);
            }
        }
    }

    private void FireDragEvent()
    {
        GameObject hitObj = GetHitGameObject(gestureFinger1.position);
        DragEventArgs args = new DragEventArgs(gestureFinger1, hitObj);
        OnDrag?.Invoke(this, args);

        if (hitObj != null)
        {
            if (hitObj.TryGetComponent(out IDraggable draggable))
            {
                draggable.OnDrag(args);
            }
        }
    }

    private GameObject GetHitGameObject(Vector2 screenPos)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPos);

        if (Physics.Raycast(ray, out RaycastHit hit, 10f))
        {
            return hit.transform.gameObject;
        }

        return null;
    }

    protected override void SingletonOnDestroy()
    {
        
    }
}
