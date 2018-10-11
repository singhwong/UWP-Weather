using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Notifications;

namespace UsefulWeather.Models
{
    public class LiveTile
    {
        private TileContent tile_content;
        public void AddTile(string title, string detail, string image_source)
        {
            tile_content = SetTileContent(title, detail, image_source);
            var notification = new TileNotification(tile_content.GetXml());
            TileUpdateManager.CreateTileUpdaterForApplication().Update(notification);
        }

        public TileContent SetTileContent(string title, string detail, string image_source)
        {
            return new TileContent()
            {
                Visual = new TileVisual()
                {
                    TileSmall = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                        {
                            new AdaptiveText()
                            {
                                Text = title,
                                HintStyle = AdaptiveTextStyle.Title
                            },
                            new AdaptiveText()
                            {
                                Text = detail,
                                HintStyle = AdaptiveTextStyle.Subtitle
                            }
                        },
                            BackgroundImage = new TileBackgroundImage()
                            {
                                Source = image_source
                            }
                        }
                    },
                    TileMedium = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                        {
                            new AdaptiveText()
                            {
                                Text = title,
                                HintStyle = AdaptiveTextStyle.Title
                            },
                            new AdaptiveText()
                            {
                                Text = detail,
                                HintStyle = AdaptiveTextStyle.Subtitle
                            }
                        },
                            BackgroundImage = new TileBackgroundImage()
                            {
                                Source = image_source
                            }
                        }
                    },
                    TileWide = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                        {
                            new AdaptiveText()
                            {
                                Text = title,
                                HintStyle = AdaptiveTextStyle.Title
                            },
                            new AdaptiveText()
                            {
                                Text = detail,
                                HintStyle = AdaptiveTextStyle.Subtitle
                            }
                        },
                            BackgroundImage = new TileBackgroundImage()
                            {
                                Source = image_source
                            }
                        }
                    },
                    TileLarge = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                        {
                            new AdaptiveText()
                            {
                                Text = title,
                                HintStyle = AdaptiveTextStyle.Title
                            },
                            new AdaptiveText()
                            {
                                Text = detail,
                                HintStyle = AdaptiveTextStyle.Subtitle
                            }
                        },
                            BackgroundImage = new TileBackgroundImage()
                            {
                                Source = image_source
                            }
                        }
                    }
                }
            };
        }
    }
}
