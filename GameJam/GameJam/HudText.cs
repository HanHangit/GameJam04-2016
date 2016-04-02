using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;


namespace GameJam
{
    class HudText
    {
        Text text;
        public String textName;

        /// <summary>
        /// Prints Text with standard configuration
        /// </summary>
        /// <param name="text"> Please Enter Text to Print </param>
        /// <param name="position"> Please enter the PositionVecor of the Text </param>
        public HudText(String _textName, String displayString, Vector2f position)
        {
            textName = _textName;

            text = new Text();
            text.DisplayedString = displayString;
            text.Position = position;
            text.CharacterSize = 15;
            text.Color = Color.Black;
            text.Font = new Font("fonts/arial.ttf");
        }

        public HudText(String _textName, String displayString, Vector2f position, Font font, Color color, uint characterSize)
        {
            textName = _textName;

            text = new Text();
            text.DisplayedString = displayString;
            text.Position = position;
            text.Font = font;
            text.Color = color;
            text.CharacterSize = characterSize;
        }

        public void ChangeText(String newString)
        {
            this.text.DisplayedString = newString;
        }

        public void RemoveText()
        {
            this.text.DisplayedString = "---";
        }

        public Text getText()
        {
            return text;
        }

    }
}
