using System;
using UnityEngine;
using System.Collections;
using System.Diagnostics;

namespace UnityStandardAssets.Utility
{
    public class FPSCounter : MonoBehaviour
    {
        const float fpsMeasurePeriod = 0.5f;
        private int m_FpsAccumulator = 0;
        private float m_FpsNextPeriod = 0;
        private int m_CurrentFps;
        const string display = "{0} FPS";
        private GUIText m_GuiText;
		public TextMesh textMesh;


		private float startTime = 0;
		private string fpsText = "";
		private Stopwatch stopwatch;

		private void Awake(){
			stopwatch = new Stopwatch ();
			m_FpsNextPeriod = Time.realtimeSinceStartup + fpsMeasurePeriod;
			m_GuiText = GetComponent<GUIText>();
		}
        private void Start()
        {

			StartCoroutine (EndOfFrame());
        }

		public void updateLog(string text){
			textMesh.text += "\n" + text;
		}
		public void overrideLog(string text){
			textMesh.text = fpsText + "\n" + text;
		}


        private void Update()
		{
			//updateLog ("FPS UPDATE");
			startTime = Time.realtimeSinceStartup;
			stopwatch.Start ();

			// measure average frames per second
            m_FpsAccumulator++;
            if (Time.realtimeSinceStartup > m_FpsNextPeriod)
            {
                m_CurrentFps = (int) (m_FpsAccumulator/fpsMeasurePeriod);
                m_FpsAccumulator = 0;
				m_FpsNextPeriod += fpsMeasurePeriod;
				fpsText = string.Format(display, m_CurrentFps);
				if(m_GuiText != null){
					m_GuiText.text = fpsText;
				}
				if(textMesh != null){
					//Debug.Log(debugText);
				}
            }
        }

		private IEnumerator EndOfFrame(){
			while (true) {
				yield return new WaitForEndOfFrame ();
				float frameTimeMS = (Time.realtimeSinceStartup - startTime) * 1000;
				frameTimeMS = stopwatch.ElapsedMilliseconds;
				stopwatch.Reset();

				string text = frameTimeMS.ToString("F2") + " MS";
				//fpsText = string.Format(display, (1f / frameTimeMS * 1000f).ToString("F0"));
				overrideLog(text);
				//updateLog("End of Frame");
			}
		}
    }
}
