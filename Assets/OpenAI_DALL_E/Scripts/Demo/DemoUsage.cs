using OpenAI_DALL_E.Scripts.Main;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace OpenAI_DALL_E.Scripts.Demo
{
    public class DemoUsage : MonoBehaviour
    {
        public DALL_E_ImageFetcher ImageFetcher;
        [Header("UI References")]
        public Image uiImage;
        public Button generateButton;
        public TMP_InputField text;
        public int imageSize;
        private Texture2D _lastTex;

        private void OnEnable()
        {
            generateButton.onClick.AddListener(()=>
            {
                ImageFetcher.GetImageFromPrompt(new DALL_E_ImageFetcher.InputData(text.text , 1 , imageSize));
                generateButton.interactable = false;
            });
            ImageFetcher.OnImageGenerated += SetUIImage;
        }

        private void SetUIImage(Texture2D tex)
        {
            generateButton.interactable = true;
            if (!tex)
            {
                Debug.LogError("Something Went Wrong try again");
            }
            if(_lastTex) Destroy(_lastTex);
            _lastTex = tex;
            uiImage.sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        }
    }
}
