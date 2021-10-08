using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfViewShaderOnlyVisible : MonoBehaviour
{
    public float viewDistance; // Distance for view to work (radius of circle)

    [Range(0,360)]
    public float viewAngle; // The angle or width of the view cone (total)

    public LayerMask targetMask;
    public LayerMask obstacleMask;

    public List<Transform> visibleTargets = new List<Transform>();


    [Range(0,1)]
    public float meshRayCount = 1; // Number of rays to use when generating the mesh for the player FOV Vision Cone

    public MeshFilter viewMeshFilter;
    Mesh viewMesh;

    public GameObject fovObject;

    public int objectEdgeAccuracyIterator = 5;

    
    // Start is called before the first frame update
    void Start()
    {
        
        viewMesh = new Mesh();
        viewMesh.name = "View Mesh";
        viewMeshFilter.mesh = viewMesh;
        

        StartCoroutine("FindTargetsWithDelay", 0.25f);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        DrawFieldOfViewVisionCone();
    }


    IEnumerator FindTargetsWithDelay(float delay) {
        while(true) {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }

    void FindVisibleTargets() {
        visibleTargets.Clear();
        Collider[] targetsInViewDistance = Physics.OverlapSphere(transform.position, viewDistance, targetMask);

        for(int i = 0; i < targetsInViewDistance.Length; i++) {
            Transform currentTarget = targetsInViewDistance[i].transform;
            Vector3 directionToTarget = (currentTarget.position - transform.position).normalized;

            if(Vector3.Angle(transform.forward, directionToTarget) < viewAngle / 2) {
                float distanceToTarget = Vector3.Distance(transform.position, currentTarget.position);

                if(!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstacleMask)) 
                {
                    visibleTargets.Add(currentTarget);
                }
            }
        }
    }

    void DrawLine(Vector3 start, Vector3 end, float duration = 0.2f)
         {
             GameObject myLine = new GameObject();
             myLine.transform.position = start;
             myLine.AddComponent<LineRenderer>();
             LineRenderer lr = myLine.GetComponent<LineRenderer>();
             //lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
             lr.startColor = Color.white;
             lr.endColor = Color.magenta;
             lr.startWidth = 0.1f;
             lr.endWidth = 0.1f;
             lr.SetPosition(0, start);
             lr.SetPosition(1, end);
             GameObject.Destroy(myLine, duration);
         }

    void DrawFieldOfViewVisionCone() {
        int fovSectionCount = Mathf.RoundToInt(viewAngle * meshRayCount); // The number of sections to divide FOV into
        float fovSectionAngleSize = viewAngle / fovSectionCount; // Angle for each fov section

        List<Vector3> viewPoints = new List<Vector3>();

        ViewCastInformation oldViewCast = new ViewCastInformation();

        for(int i = 0; i <= fovSectionCount; i++) {
            float angle = transform.eulerAngles.y - viewAngle / 2 + fovSectionAngleSize * i;
            //Debug.DrawLine(transform.position, transform.position + DirectionFromAngle(angle, true) * viewDistance, Color.magenta);

            ViewCastInformation newViewCast = ViewCast(angle);

            if(i > 0) {
                if(oldViewCast.hit != newViewCast.hit) {
                    // Find object edge
                    EdgeInfo edge = FindObjectEdge(oldViewCast, newViewCast);
                    if(edge.pointA != Vector3.zero) {
                        viewPoints.Add(edge.pointA);
                    }
                    if(edge.pointB != Vector3.zero) {
                        viewPoints.Add(edge.pointA);
                    }
                }
            }

            viewPoints.Add(newViewCast.point);

            //DrawLine(transform.position, newViewCast.point);

            oldViewCast = newViewCast;
        }

        int vertexCount = viewPoints.Count + 1;
        Vector3[] vertices = new Vector3[vertexCount];
        int[] triangles = new int[(vertexCount-2) * 3];

        vertices[0] = Vector3.zero;
        for(int i = 0; i < viewPoints.Count - 1; i++) {
            vertices[i + 1] = transform.InverseTransformPoint(viewPoints[i]);
            //vertices[i + 1] = viewPoints[i];

            //Debug.Log(i);
            triangles[i*3] = 0;
            triangles[i*3+1] = i + 1;
            triangles[i*3+2] = i + 2;
        }

        viewMesh.Clear();
        viewMesh.vertices = vertices;
        viewMesh.triangles = triangles;
        viewMesh.RecalculateNormals();
      
    }

    EdgeInfo FindObjectEdge(ViewCastInformation minViewCast, ViewCastInformation maxViewCast) {
        float minAngle = minViewCast.angle;
        float maxAngle = maxViewCast.angle;
        Vector3 minPoint = Vector3.zero;
        Vector3 maxPoint = Vector3.zero;

        for(int i = 0; i < objectEdgeAccuracyIterator; i++) {
            float angle = (minAngle + maxAngle) / 2;
            ViewCastInformation newViewCast = ViewCast(angle);
            if(newViewCast.hit == minViewCast.hit) {
                minAngle = angle;
                minPoint = newViewCast.point;
            } else {
                maxAngle = angle;
                maxPoint = newViewCast.point;
            }
        }
        return new EdgeInfo(minPoint, maxPoint);
    }


    ViewCastInformation ViewCast(float globalAngle) {
        Vector3 direction = DirectionFromAngle(globalAngle, true);
        RaycastHit hit;

        ViewCastInformation hitInfo = new ViewCastInformation(false, transform.position + direction * viewDistance, viewDistance, globalAngle);

        if(Physics.Raycast(transform.position, direction, out hit, viewDistance, obstacleMask)) {
            hitInfo = new ViewCastInformation(true, hit.point, hit.distance, globalAngle);

        }
      /*  if(Physics.Raycast(transform.position, direction, out hit, viewDistance, targetMask)) {
            
            if(hit.distance <= hitInfo.distance) {
                hitInfo = new ViewCastInformation(true, hit.point, hit.distance, globalAngle);
            }
        }*/
        
        
        return hitInfo;
    }


    public Vector3 DirectionFromAngle(float viewAngle, bool globalAngle) {
        if(!globalAngle) {
            viewAngle += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(viewAngle * Mathf.Deg2Rad),0,Mathf.Cos(viewAngle * Mathf.Deg2Rad));
    }

    public struct ViewCastInformation {
        public bool hit;
        public Vector3 point;
        public float distance;
        public float angle;

        public ViewCastInformation(bool _hit, Vector3 _point, float _distance, float _angle) {
            hit = _hit;
            point = _point;
            distance = _distance;
            angle = _angle;
        }
    }

    public struct EdgeInfo {
        public Vector3 pointA;
        public Vector3 pointB;

        public EdgeInfo(Vector3 _pointA, Vector3 _pointB) {
            pointA = _pointA;
            pointB = _pointB;
        }
    }
}
