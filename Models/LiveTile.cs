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
        public void AddTile(string image_source)
        {
            TileContent tile_content = SetTileContent(image_source);
            var notification = new TileNotification(tile_content.GetXml());
            TileUpdateManager.CreateTileUpdaterForApplication().Update(notification);
        }

        public TileContent SetTileContent(string image_source)
        {
            return new TileContent()
            {
                Visual = new TileVisual()
                {
                    TileMedium = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {                         
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
