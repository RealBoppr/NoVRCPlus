using System.Collections;
using MelonLoader;
using UnityEngine;

[assembly: MelonInfo(typeof(NoVRCPlus.Main), "NoVRCPlus", "0.1", "Boppr")]
[assembly: MelonGame("VRChat", "VRChat")]

namespace NoVRCPlus
{
    public class Main : MelonMod
    {
        public override void OnApplicationStart() => MelonCoroutines.Start(CheckQMParent());
        private IEnumerator CheckQMParent()
        {
            while (GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent") == null)
            {
                yield return null;
            }

            string[] names = new string[]
            {
                "UserInterface/MenuContent/Backdrop/Header/Tabs/ViewPort/Content/VRC+PageTab",
                "UserInterface/MenuContent/Screens/UserInfo/Buttons/RightSideButtons/RightUpperButtonColumn/GiftVRChatPlusButton",
                "UserInterface/MenuContent/Screens/Avatar/Vertical Scroll View/Viewport/Content/Favorite Avatar List/GetMoreFavorites",
                "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/VRC+_Banners",
                "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Carousel_Banners",
                "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_SelectedUser_Local/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_UserActions/Button_GiftVRCPlus"
            };

            foreach (string name in names)
            {
                GameObject gameObject = GameObject.Find(name);
                gameObject.transform.localScale = Vector3.zero;
                gameObject.SetActive(false);
            }
        }
    }
}
