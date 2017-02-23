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
                            // (a, b, c, d) Hash Value (composed of the four component's hash values)
                            int[] hashValue = new int[4]
                            {
                                reader.ReadInt32(),
                                reader.ReadInt32(),
                                reader.ReadInt32(),
                                reader.ReadInt32(),
                            };
                            
                            GameItems.BasePotion potion =
                                new GameItems.BasePotion
                                    (
                                        // (b) Name
                                        reader.ReadString(),
                                        // (c) Value
                                        reader.ReadInt32(),
                                        // (d) Flavor Text
                                        reader.ReadString(),
                                        // (e) String of Effect Description
                                        reader.ReadString(),
                                        // (-) Portion Hash Value
                                        hashValue
                                    );
                            potions.Add(hashValue, potion);
                        }

                        // (ii) Ingrediant Data
                        for (int i = 0; i < ingrediantCount; i++)
                        {
                            ingrediants.Add
                            (
                                i,
                                new GameItems.BaseIngredient
                                    (
                                        // (a) Ingrediant Hash Value
                                        reader.ReadInt32(),
                                        // (b) Name
                                        reader.ReadString(),
                                        // (c) Value
                                        reader.ReadInt32(),
                                        // (d) Flavor Text
                                        reader.ReadString()
                                    )
                            );
                        }
                        // (iii) Recipie Data

                            // TO DO: Implement Recipies (Lower Priority)

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
