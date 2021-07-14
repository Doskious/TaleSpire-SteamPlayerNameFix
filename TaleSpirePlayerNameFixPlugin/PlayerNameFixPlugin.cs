using UnityEngine;
using BepInEx;
using Bounce.Unmanaged;
using System.Collections.Generic;
using System.Linq;
using TMPro;

namespace Doskious
{
    [BepInPlugin(Guid, "Player Name Fix Plug-In", Version)]
    public class PlayerNameFixPlugin : BaseUnityPlugin
    {
        // Plugin info
        private const string Guid = "org.doskious.plugins.playernamefix";
        private const string Version = "1.0.0.0";

        // Configs
        private ConfigEntry<string> playerone { get; set; }
        private ConfigEntry<string> playertwo { get; set; }
        private ConfigEntry<string> playerthree { get; set; }
        private ConfigEntry<string> playerfour { get; set; }
        private ConfigEntry<string> playerfive { get; set; }
        private ConfigEntry<string> playersix { get; set; }
        private ConfigEntry<string> playerseven { get; set; }
        private ConfigEntry<string> playereight { get; set; }
        private IDictionary<string, string> fixplayernames = new Dictionary<string, string>();

        /// <summary>
        /// Awake - Executed Once On Plugin Load
        /// </summary>
        void Awake()
        {
            // Config.Bind("Section","Name","Default value");
            playerone = Config.Bind("Piped Player Identifier Replacements", "Player1", "~SteamName1~|DisplayName1");
            playertwo = Config.Bind("Piped Player Identifier Replacements", "Player2", "~SteamName2~|DisplayName2");
            playerthree = Config.Bind("Piped Player Identifier Replacements", "Player3", "~SteamName3~|DisplayName3");
            playerfour = Config.Bind("Piped Player Identifier Replacements", "Player4", "~SteamName4~|DisplayName4");
            playerfive = Config.Bind("Piped Player Identifier Replacements", "Player5", "~SteamName5~|DisplayName5");
            playersix = Config.Bind("Piped Player Identifier Replacements", "Player6", "~SteamName6~|DisplayName6");
            playerseven = Config.Bind("Piped Player Identifier Replacements", "Player7", "~SteamName7~|DisplayName7");
            playereight = Config.Bind("Piped Player Identifier Replacements", "Player8", "~SteamName8~|DisplayName8");
            string[] pairOne = playerone.Split("|");
            string[] pairTwo = playertwo.Split("|");
            string[] pairThree = playerthree.Split("|");
            string[] pairFour = playerfour.Split("|");
            string[] pairFive = playerfive.Split("|");
            string[] pairSix = playersix.Split("|");
            string[] pairSeven = playerseven.Split("|");
            string[] pairEight = playereight.Split("|");
            fixplayernames.Add(pairOne[0], pairOne[1]);
            fixplayernames.Add(pairTwo[0], pairTwo[1]);
            fixplayernames.Add(pairThree[0], pairThree[1]);
            fixplayernames.Add(pairFour[0], pairFour[1]);
            fixplayernames.Add(pairFive[0], pairFive[1]);
            fixplayernames.Add(pairSix[0], pairSix[1]);
            fixplayernames.Add(pairSeven[0], pairSeven[1]);
            fixplayernames.Add(pairEight[0], pairEight[1]);

            StateDetection.Initialize(this.GetType());
        }

        /// <summary>
        /// Update - Executed Periodically While Plugin Is Running
        /// </summary>
        void Update()
        {
            // Debug.Log("Dosktastic!");
            TMPro.TextMeshProUGUI[] texts = UnityEngine.Object.FindObjectsOfType<TextMeshProUGUI>();
            string result;
            for (int i = 0; i < texts.Length; i++)
            {
                if (fixplayernames.TryGetValue(texts[i].text, out result))
                {
                    Debug.Log(texts[i].text);
                    texts[i].text = result;
                }
            }
        }
    }
}
