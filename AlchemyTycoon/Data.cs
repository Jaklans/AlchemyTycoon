using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AlchemyTycoon
{
    class Data
    {
        //Declair Structures
        private Dictionary<int[], GameItems.BasePotion> potions;
        private Dictionary<int, GameItems.BaseIngredient> ingrediants;

        //Constructor and Initialization
        public Data(string targetFileName)
        {
            try
            {
                Stream inStream = new FileStream(targetFileName, FileMode.Open);
                BinaryReader reader = new BinaryReader(inStream);

                //-------------Data Reading--------------

                //(Input files should match up to this spec)

                    // (1) Data about how many of each item exists is recorded

                        // (i) Potion Count
                        int potionCount = reader.ReadInt32();
                        
                        // (ii) Ingrediant Count
                        int ingrediantCount = reader.ReadInt32();
                        
                        // (iii) Recipie Count
                        int recipieCount = reader.ReadInt32();
                    
                    // (2) Create objects baised on recorded counts

                        // (i) Potion Data
                        for (int i = 0; i < potionCount; i++)
                        {
                            potions.Add
                            (
                                new GameItems.BasePotion
                                    (
                                        // (a) Name
                                        reader.ReadString(),
                                        // (b) Value
                                        reader.ReadInt32(),
                                        // (c) Flavor Text
                                        reader.ReadString(),
                                        // (d) Color (three numbers, in the order of Red, Green, Blue)
                                        new int[reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32()],
                                        // (e) Hash Value
                                        reader.ReadUInt32(),
                                        // (f) String of Effect Description
                                        reader.ReadString()
                                    )
                            )
                        }
            }
            finally
            {
                Stream inStream = null;
                StreamReader reader = null;
                inStream.Close();
                reader.Close();
            }
        }
    }
}
