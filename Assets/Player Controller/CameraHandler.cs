using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LC
{
    public class CameraHandler : MonoBehaviour
    {
        InputHandler inputHandler;
        PlayerManager playerManager;
        
        public Transform targetTransform;
        public Transform cameraTransform;
        public Transform cameraPivotTransform;
        public LayerMask ignoreLayers;
        public LayerMask environmentLayer;
        private Transform myTransform;
        private Vector3 cameraTransformPosition;
        private Vector3 cameraFollowVelocity = Vector3.zero;

        public static CameraHandler singleton;

        public float lookSpeed = 0.1f;
        public float followSpeed = 0.1f;
        public float pivotSpeed = 0.03f;

        private float targetPosition;
        private float defaultPosition;
        private float lookAngle;
        private float pivotAngle;
        public float minimumPivot = -35;
        public float maximumPivot = 35;

        public float cameraSphereRadius = 0.2f;
        public float cameraCollisionOffset = 0.2f;
        public float minimumCollisionOffset = 0.2f;
        public float lockedPivotPosition = 4.25f;
        public float unlockedPivotPosition = 3.1f;

        public Transform currentLockOnTarget;

        List<CharacterManager> availbleTargets = new List<CharacterManager>();
        public Transform nearestLockOnTarget;
        public Transform leftLockTarget;
        public Transform rightLockTarget;
        public float maximumLockOnDistance = 30.0f;

        private void Awake()
        {
            singleton = this;
            myTransform = transform;
            defaultPosition = cameraTransform.localPosition.z;
            ignoreLayers = ~(1 << 8 | 1 << 9 | 1 << 10);
            targetTransform = FindObjectOfType<PlayerManager>().transform;
            inputHandler = FindObjectOfType<InputHandler>();
            playerManager = FindObjectOfType<PlayerManager>();
        }
        private void Start()
        {
            environmentLayer = LayerMask.NameToLayer("Environment");
        }

        public void FollowTarget(float delta)
        {
            Vector3 targetPosition = Vector3.SmoothDamp(myTransform.position, targetTransform.position, ref cameraFollowVelocity, delta / followSpeed);
            myTransform.position = targetPosition;
            HandleCameraCollision(delta);
        }

        public void HandleCameraRotation(float delta, float mouseXInput, float mouseYInput)
        {
            if(inputHandler.lockOnFlag == false && currentLockOnTarget == null)
            {
                lookAngle += (mouseXInput * lookSpeed) / delta;
                pivotAngle -= (mouseYInput * pivotSpeed) / delta;
                pivotAngle = Mathf.Clamp(pivotAngle, minimumPivot, maximumPivot);

                Vector3 rotation = Vector3.zero;
                rotation.y = lookAngle;
                Quaternion targetRotation = Quaternion.Euler(rotation);
                myTransform.rotation = targetRotation;

                rotation = Vector3.zero;
                rotation.x = pivotAngle;

                targetRotation = Quaternion.Euler(rotation);
                cameraPivotTransform.localRotation = targetRotation;
            }
            else
            {
                float velocity = 0;

                Vector3 dir = currentLockOnTarget.position - transform.position;
                dir.Normalize();
                dir.y = 0;
                Quaternion targetRotation = Quaternion.LookRotation(dir);
                transform.rotation = targetRotation;

                dir = currentLockOnTarget.position - cameraPivotTransform.position;
                dir.Normalize();

                targetRotation = Quaternion.LookRotation(dir);
                Vector3 eulerAngles = targetRotation.eulerAngles;
                eulerAngles.y = 0;
                cameraPivotTransform.localEulerAngles = eulerAngles;
            }

        }

        private void HandleCameraCollision(float delta)
        {
            targetPosition = defaultPosition;
            RaycastHit hit;
            Vector3 direction = cameraTransform.position - cameraPivotTransform.position;
            direction.Normalize();

            if(Physics.SphereCast(cameraPivotTransform.position, cameraSphereRadius, direction, out hit, Mathf.Abs(targetPosition), ignoreLayers))
            {
                float dis = Vector3.Distance(cameraPivotTransform.position, hit.point);
                targetPosition = -(dis - cameraCollisionOffset);
 
            }
            if (Mathf.Abs(targetPosition) < minimumCollisionOffset)
            {
                targetPosition = -minimumCollisionOffset;
            }
            cameraTransformPosition.z = Mathf.Lerp(cameraTransform.localPosition.z, targetPosition, delta / 0.2f);
            cameraTransform.localPosition = cameraTransformPosition;
        }

        public void HandleLockOn()
        {            

            availbleTargets.Clear();

            float shortestDistance = Mathf.Infinity;
            float shortestDistanceLeftTarget = Mathf.Infinity;
            float shortestDistanceRightTarget = Mathf.Infinity;

            Collider[] colliders = Physics.OverlapSphere(transform.position, 26);

            if (colliders.Length > 0)
            {
                for (int i = 0; i < colliders.Length; i++)
                {
                    CharacterManager charHandler = colliders[i].GetComponent<CharacterManager>();

                    if (charHandler != null)
                    {
                        Vector3 lockTargetDir = charHandler.transform.position - transform.position;

                        float lockTargetDis = Vector3.Distance(transform.position, charHandler.transform.position);

                        float viewableAngle = Vector3.Angle(lockTargetDir, transform.forward);

                        RaycastHit hit;

                        if (charHandler.transform.root != transform.root  //Make sure we don't lock onto ourselves and the target is on screen and we are close enough to lock on
                            && viewableAngle > -50 && viewableAngle < 50
                            && lockTargetDis <= maximumLockOnDistance)
                        {
                            if(Physics.Linecast(playerManager.transform.position, charHandler.lockOnTransform.position, out hit))
                            {
                                Debug.DrawLine(playerManager.lockOnTransform.position, charHandler.lockOnTransform.position);

                                if(hit.transform.gameObject.layer == environmentLayer)
                                {
                                    //cannot lock onto target, object in the way
                                }

                                else
                                {
                                    availbleTargets.Add(charHandler);
                                }
                            }

                            
                        }

                    }
                }

                if (availbleTargets.Count > 0)
                {
                    for (int k = 0; k < availbleTargets.Count; k++)
                    {
                        float distFromTarget = Vector3.Distance(transform.position, availbleTargets[k].transform.position);

                        if (distFromTarget < shortestDistance)
                        {
                            shortestDistance = distFromTarget;
                            nearestLockOnTarget = availbleTargets[k].lockOnTransform;
                        }

                        if (inputHandler.lockOnFlag)
                        {
                            //This is the big change, from enemy position to player
                            Vector3 relativePlayerPostion = transform.InverseTransformPoint(availbleTargets[k].transform.position);

                            var distanceFromLeftTarget = 1000f; //_currentLockOnTarget.transform.position.x - _availableTargets[k].transform.position.x;
                            var distanceFromRightTarget = 1000f; //_currentLockOnTarget.transform.position.x + _availableTargets[k].transform.position.x;

                            if (relativePlayerPostion.x < 0.00)
                            {
                                distanceFromLeftTarget = Vector3.Distance(currentLockOnTarget.position, availbleTargets[k].transform.position);
                            }
                            else if (relativePlayerPostion.x > 0.00)
                            {
                                distanceFromRightTarget = Vector3.Distance(currentLockOnTarget.position, availbleTargets[k].transform.position);
                            }

                            if (relativePlayerPostion.x < 0.00 && distanceFromLeftTarget < shortestDistanceLeftTarget)
                            {
                                shortestDistanceLeftTarget = distanceFromLeftTarget;
                                currentLockOnTarget = availbleTargets[k].lockOnTransform;
                            }

                            if (relativePlayerPostion.x > 0.00 && distanceFromRightTarget < shortestDistanceRightTarget)
                            {
                                shortestDistanceRightTarget = distanceFromRightTarget;
                                currentLockOnTarget = availbleTargets[k].lockOnTransform;
                            }
                        }
                    }

                }
                else
                {
                    Debug.Log("no lock on targets found A");
                }
            }
            else
            {
                Debug.Log("no lock on targets found B");
            }
        }
        public void ClearLockOnTarget()
        {
            availbleTargets.Clear();
            nearestLockOnTarget = null;
            currentLockOnTarget = null;
        }

        public void SetCameraHeight()
        {
            Vector3 velocity = Vector3.zero;
            Vector3 newLockedPosition = new Vector3(0, lockedPivotPosition);
            Vector3 newUnlockedPosition = new Vector3(0, unlockedPivotPosition);

            if(currentLockOnTarget != null)
            {
                cameraPivotTransform.transform.localPosition = Vector3.SmoothDamp(cameraPivotTransform.transform.localPosition, newLockedPosition, ref velocity, Time.deltaTime);
            }
            else
            {
                cameraPivotTransform.transform.localPosition = Vector3.SmoothDamp(cameraPivotTransform.transform.localPosition, newUnlockedPosition, ref velocity, Time.deltaTime);
            }
        }

    }
    
}

