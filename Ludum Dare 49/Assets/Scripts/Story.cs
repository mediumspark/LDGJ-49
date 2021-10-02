using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts;

namespace Assets.Scripts
{
    public class Story : MonoBehaviour, IHasText
    {
        TextMeshProUGUI lblStory;
        string[] _lines;
        int i = 0;

        private ICommand controller;
        public void Start()
        {
            SettingsRegistry.Instance.ControlsEnabled = false;
            SettingsRegistry.Instance.DialogControls = true;

            FileReader reader = new FileReader();
            _lines = reader.ReadFile(@"Assets\Resources\Story.txt");
            lblStory = GameObject.Find("lblStory").GetComponent<TextMeshProUGUI>();

            lblStory.color = Color.clear;
            lblStory.text = _lines[i++];

            StartCoroutine(TextFadeIn());
        }

        public void Update()
        {
            controller.Execute();
        }

        public void SetController(ICommand c)
        {
            controller = c;
        }
        IEnumerator TextFadeIn()
        {

            for (float f = 0; f < 1.0f; f+= 0.01f)
            {
                lblStory.color = Color.Lerp(Color.clear, Color.white, f);
                yield return new WaitForSeconds(0.001f);
            }
            lblStory.text += "\n(Press Space to Continue)";
            SettingsRegistry.Instance.ControlsEnabled = true;

        }

        IEnumerator TextFadeOut()
        {
            for (float f = 0; f < 1.0f; f += 0.01f)
            {
                lblStory.color = Color.Lerp(Color.white, Color.clear, f);
                yield return new WaitForSeconds(0.001f);
            }

            if (i < _lines.Length)
            {
                lblStory.text = _lines[i++];
                StartCoroutine(TextFadeIn());
            }
        }

        public void ScrollText()
        {
            if (i < _lines.Length)
            {
                SettingsRegistry.Instance.ControlsEnabled = false;
                StartCoroutine(TextFadeOut());
            }
            else
            {
                SettingsRegistry.Instance.ControlsEnabled = true;
                SettingsRegistry.Instance.DialogControls = false;
                SceneManager.LoadScene("TestScene2");
            }

        }
    }
}
