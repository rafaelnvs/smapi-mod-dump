﻿using StardewModdingAPI;
using StardewModdingAPI.Events;
using sdv_helper.Detectors;
using sdv_helper.Config;
using sdv_helper.Labels;
using StardewValley;
using sdv_helper.Menu;

namespace sdv_helper
{
    public class ModEntry : Mod
    {
        private static Detector detector;
        private static Settings settings;
        private static LabelDrawingManager drawingManager;
        private static ConfigMenu configMenu;

        public override void Entry(IModHelper helper)
        {
            settings = new Config.Settings(Helper);
            configMenu = new ConfigMenu(settings);
            drawingManager = new LabelDrawingManager(settings);
            detector = new Detector(settings);
            detector.AddDetector("NPC")
                .AddDetector("Object")
                .AddDetector("FarmAnimal")
                .AddDetector("WaterEntity");

            Helper.Events.Display.RenderingHud += Display_RenderingHud;
            Helper.Events.Player.Warped += Player_Warped;
            Helper.Events.Input.ButtonPressed += Input_ButtonPressed;
        }

        private void Display_RenderingHud(object sender, RenderingHudEventArgs e)
        {
            detector.Detect();
            drawingManager.LabelEntities(detector);
        }

        private void Input_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button == settings.LoadKey)
            {
                settings.LoadSettings();
                drawingManager.SendHudMessage("Loaded settings from file", 4);
            }
            else if (e.Button == settings.MenuKey)
                Game1.activeClickableMenu = configMenu;
        }

        private void Player_Warped(object sender, WarpedEventArgs e)
        {
            if (e.IsLocalPlayer)
                detector.SetLocation(e.NewLocation);
        }
    }
}