//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.IO;
//using Microsoft.Xna.Framework.Content;
//using Microsoft.Xna.Framework.Graphics;
//
//Written by John Shull
//namespace AlchemyTycoon
//{
//    class Data
//    {
//        //Declare Structures
//
//            //All items have a hash value, which they are stored by here
//        private Dictionary<int, GameItems.BasePotion> potions;
//        private Dictionary<int, GameItems.BaseIngredient> ingrediants;
//
//            //Potions have a potionHashValue comprised of their components,
//            //which is mapped to their hash value here
//        private Dictionary<int[], int> potionHashValues;
//        
//
//        //Constructor and Initialization
//        public Data(string targetFileName)
//        {
//            try
//            {
//                Stream inStream = new FileStream(targetFileName, FileMode.Open);
//                BinaryReader reader = new BinaryReader(inStream);
//
//                //-------------Data Reading--------------
//
//                //(Input files should match up to this spec)
//
//                    // (1) Data about how many of each item exists is recorded
//
//                        // (i) Potion Count
//                        int potionCount = reader.ReadInt32();
//                        
//                        // (ii) Ingrediant Count
//                        int ingrediantCount = reader.ReadInt32();
//                        
//                        // (iii) Recipie Count
//                        int recipieCount = reader.ReadInt32();
//                    
//                    // (2) Create objects baised on recorded counts
//
//                        // (i) Potion Data
//                        for (int i = 0; i < potionCount; i++)
//                        {
//                            GameItems.BasePotion potion =
//                                new GameItems.BasePotion
//                                    (
//                                        // (a) Hash Value
//                                        reader.ReadInt32(),
//                                        // (b) Name
//                                        reader.ReadString(),
//                                        // (c) Value
//                                        reader.ReadInt32(),
//                                        // (d) Flavor Text
//                                        reader.ReadString(),
//                                        // (e) String of Effect Description
//                                        reader.ReadString(),
//                                        // (f, g, h, i) Portion Hash Value
//                                            // Comprised of the hash values 
//                                            // of the potions ingrediants
//                                        new int[4]
//                                        {
//                                            reader.ReadInt32(),
//                                            reader.ReadInt32(),
//                                            reader.ReadInt32(),
//                                            reader.ReadInt32(),
//                                        },
//                                        // (j) Name of Texture File
//                                        reader.ReadString()
//                                    );
//                            potions.Add(potion.HashValue, potion);
//                        }
//
//                        // (ii) Ingrediant Data
//                        for (int i = 0; i < ingrediantCount; i++)
//                        {
//                            ingrediants.Add
//                            (
//                                i,
//                                new GameItems.BaseIngredient
//                                    (
//                                        // (a) Hash Value
//                                        reader.ReadInt32(),
//                                        // (b) Name
//                                        reader.ReadString(),
//                                        // (c) Value
//                                        reader.ReadInt32(),
//                                        // (d) Flavor Text
//                                        reader.ReadString(),
//                                        // (e) Name of Texture File
//                                        reader.ReadString()
//                                    )
//                            );
//                        }
//                        // (iii) Recipie Data
//
//                            // TO DO: Implement Recipies (Medium Priority)
//
//            }
//            finally
//            {
//                Stream inStream = null;
//                StreamReader reader = null;
//                inStream.Close();
//                reader.Close();
//            }
//        }
//
//        //Texture Loading
//        public bool LoadContent(ContentManager content)
//        {
//            try
//            {
//                foreach (GameItems.GameItem i in potions.Values)
//                {
//                    i.Texture = content.Load<Texture2D>(i.TextureName);
//                }
//                foreach (GameItems.GameItem i in ingrediants.Values)
//                {
//                    i.Texture = content.Load<Texture2D>(i.TextureName);
//                }
//                return true;
//            }
//            catch (Exception e)
//            {
//                return false;
//            }
//
//        }
//
//        //Potion Creation
//        public GameItems.BasePotion CreatePotion(
//            GameItems.BaseIngredient input1,
//            GameItems.BaseIngredient input2,
//            GameItems.BaseIngredient input3,
//            GameItems.BaseIngredient input4)
//        {
//            int[] potion = new int[4] {input1.HashValue, input2.HashValue, input3.HashValue, input4.HashValue};
//
//            Array.Sort(potion);
//
//            if (potionHashValues.ContainsKey(potion))
//            {
//                return potions[potionHashValues[potion]];
//            }
//            else
//            {
//                return null; 
//                //TO DO: Return a bad potion (Low Priority)
//            }
//        }
//    }
//}
