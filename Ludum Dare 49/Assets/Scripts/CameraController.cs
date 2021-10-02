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

       

        bool transitioning = false;

        public CameraController(GameObject cam, GameObject player)
        {
            _camera = cam;
            _player = player;
            SettingsRegistry.Instance.CamAngle = CameraAngles.NormalRight;
        }

        public void PositionCamera()
        {
            
                if (SettingsRegistry.Instance.CamAngle == CameraAngles.NormalLeft)
                {
                    Vector3 camPos = new Vector3(_player.transform.position.x - 4.04f, 2.67f, _camera.transform.position.z);
                    _camera.transform.position = camPos;
                }
                else if (SettingsRegistry.Instance.CamAngle == CameraAngles.NormalRight)
                {
                    Vector3 camPos = new Vector3(_player.transform.position.x + 4.04f, 2.67f, _camera.transform.position.z);
                    _camera.transform.position = camPos;
                }
            
        }

    
   /**    public IEnumerator Transition()
        {
            yield return new WaitForSeconds(0.001f);
            float target = SettingsRegistry.Instance.CamAngle == CameraAngles.NormalRight ? -4.04f : 4.04f;
            if(SettingsRegistry.Instance.Offset == SettingsRegistry.OFFSETFLAG)
            {

                SettingsRegistry.Instance.Offset = target * -1;
            }
          

            if (target > 0)
            {
                SettingsRegistry.Instance.CamAngle = CameraAngles.NormalRight;
                while (SettingsRegistry.Instance.Offset < target)
                {

                    Vector3 camPos = new Vector3(_player.transform.position.x + SettingsRegistry.Instance.Offset, 2.67f, _camera.transform.position.z);
                    SettingsRegistry.Instance.Offset += 0.1f;
                    _camera.transform.position = camPos;

                    yield return new WaitForSeconds(0.000001f);
                }
            }
            else
            {
                SettingsRegistry.Instance.CamAngle = CameraAngles.NormalLeft;
                while (SettingsRegistry.Instance.Offset > target)
                {

                    Vector3 camPos = new Vector3(_player.transform.position.x + SettingsRegistry.Instance.Offset, 2.67f, _camera.transform.position.z);

                    SettingsRegistry.Instance.Offset -= 0.1f;

                    _camera.transform.position = camPos;

                    yield return new WaitForSeconds(0.000001f);
                }
            }
            SettingsRegistry.Instance.Offset = SettingsRegistry.OFFSETFLAG;
            SettingsRegistry.Instance.PanEnabled = true;
            SettingsRegistry.Instance.TransitionCamera = false;
        } **/

    }
}
