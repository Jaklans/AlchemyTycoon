using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchemyTycoon
{
    class PlayerData
    {
        //Attributes - Factors pertaining to a specific user that need to be saved and loaded
        string playerName;
        int gold;


        //Constructor - Requires a name
        public PlayerData(string name)
        {
            playerName = name;
        }
    }
}
