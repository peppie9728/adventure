using System;
using System.Collections.Generic;
using System.Text;

namespace text_based_adventure
{
    class UI
    {
        int i = 0;
        public void UiStart(game _game)
        {
            i++;
            if (i == 5)
            {
                _game.showLocation();
                _game.showInventory();
                _game.ShowStats();
                i = 0;
            }
        }
    
        
    
    
    }
}
