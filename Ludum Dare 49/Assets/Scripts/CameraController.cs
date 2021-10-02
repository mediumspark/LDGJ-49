using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class CameraController
    {
        private GameObject _camera;
        private GameObject _player;

        private CameraAngles _camAngle;
        public CameraAngles CamAngle
        {
            get { return _camAngle; }
            set { _camAngle = value; }
        }

        bool transitioning = false;

        public CameraController(GameObject cam, GameObject player)
        {
            _camera = cam;
            _player = player;
        }

        public void PositionCamera()
        {
            if (!transitioning)
            {
                if (CamAngle == CameraAngles.NormalLeft)
                {
                    Vector3 camPos = new Vector3(_player.transform.position.x - 4.04f, 2.67f, _camera.transform.position.z);
                    _camera.transform.position = camPos;
                }
                else if (CamAngle == CameraAngles.NormalRight)
                {
                    Vector3 camPos = new Vector3(_player.transform.position.x + 4.04f, 2.67f, _camera.transform.position.z);
                    _camera.transform.position = camPos;
                }
            }
        }

        public void BeginTransition()
        {
            transitioning = true;
        }
        public IEnumerator Transition()
        {
            
            float target = CamAngle == CameraAngles.NormalRight ? -4.04f : 4.04f;
            float offset = 0f;

            if (target > 0)
            {
                CamAngle = CameraAngles.NormalRight;
                while (offset < target)
                {
                    
                        offset += 0.05f;
                   
                    Vector3 camPos = new Vector3(_player.transform.position.x + offset, 2.67f, _camera.transform.position.z);

                    _camera.transform.position = camPos;

                    yield return new WaitForSeconds(0.000001f);
                }
            }
            else
            {
                CamAngle = CameraAngles.NormalLeft;
                while (offset > target)
                {

                    offset -= 0.05f;

                    Vector3 camPos = new Vector3(_player.transform.position.x + offset, 2.67f, _camera.transform.position.z);

                    _camera.transform.position = camPos;

                    yield return new WaitForSeconds(0.000001f);
                }
            }
            transitioning = false;
        }

    }
}
