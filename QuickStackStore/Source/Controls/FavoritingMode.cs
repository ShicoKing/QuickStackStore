﻿using UnityEngine;
using static QuickStackStore.QSSConfig;

namespace QuickStackStore
{
    internal class FavoritingMode
    {
        private static bool hasCurrentlyToggledFavoriting = false;

        private const string blackStar = "\u2605";
        private const string whiteStar = "\u2606";

        internal static bool HasCurrentlyToggledFavoriting
        {
            get => hasCurrentlyToggledFavoriting;
            set
            {
                hasCurrentlyToggledFavoriting = value;

                if (!ButtonRenderer.favoritingTogglingButtonText)
                {
                    return;
                }

                if (FavoriteConfig.FavoriteToggleButtonStyle.Value == FavoriteToggleButtonStyle.TextStarInItemFavoriteColor)
                {
                    var color = ColorUtility.ToHtmlStringRGB(FavoriteConfig.BorderColorFavoritedItem.Value);

                    ButtonRenderer.favoritingTogglingButtonText.text = $"<color=#{color}>{(value ? blackStar : whiteStar)}</color>";
                }
                else
                {
                    ButtonRenderer.favoritingTogglingButtonText.text = value ? blackStar : whiteStar;
                }
            }
        }

        internal static bool IsInFavoritingMode()
        {
            return HasCurrentlyToggledFavoriting
                || HotkeyListener.IsKeyHeld(FavoriteConfig.FavoritingModifierKeybind1.Value)
                || HotkeyListener.IsKeyHeld(FavoriteConfig.FavoritingModifierKeybind2.Value);
        }
    }
}