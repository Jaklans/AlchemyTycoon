using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace AlchemyTycoon
{
    class Data
    {
        //Declare Structures

        //All items have a hash value, which they are stored by here
        private Dictionary<int, GameItems.BasePotion> potions;
        private Dictionary<int, GameItems.BaseIngredient> ingrediants;

        //Potions have a potionHashValue comprised of their components,
        //which is mapped to their hash value here
        private Dictionary<int[], int> potionHashValues;


        //Accessors
        public GameItems.BasePotion Potions(int hash)
        {
            if (potions.ContainsKey(hash))
            {
                return potions[hash];
            }
            return null;
        }
        public GameItems.BaseIngredient Ingrediants(int hash)
        {
            if (ingrediants.ContainsKey(hash))
            {
                return ingrediants[hash];
            }
            return null;
        }



        //Constructor and Initialization
        public Data(string targetFolderName)
        {
            try
            {
                potions = new Dictionary<int, GameItems.BasePotion>();
                ingrediants = new Dictionary<int, GameItems.BaseIngredient>();
                potionHashValues = new Dictionary<int[], int>();

                //Get list of all files in directory
                ReadAll(targetFolderName);

                //Gets lists of all elements starting with "p" and "i"
                ReadPotions();
                ReadIngredients();

                //Adds potions and items to dictionaries
                AddPotions(targetFolderName);
                AddIngredients(targetFolderName);

                
                // TO DO: Implement Recipies (Medium Priority)

            }
            catch (Exception e)
            {

            }
        }

        //Texture Loading
        public bool LoadContent(ContentManager content, string targetFolderName)
        {
            try
            {
                foreach (GameItems.GameItem i in potions.Values)
                {
                    i.Texture = content.Load<Texture2D>(targetFolderName + "/" + i.TextureName);
                }
                foreach (GameItems.GameItem i in ingrediants.Values)
                {
                    i.Texture = content.Load<Texture2D>(targetFolderName + "/" + i.TextureName);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        //Potion Creation
        public GameItems.BasePotion CreatePotion(
            GameItems.BaseIngredient input1,
            GameItems.BaseIngredient input2,
            GameItems.BaseIngredient input3,
            GameItems.BaseIngredient input4)
        {
            int[] potion = new int[4] { input1.HashValue, input2.HashValue, input3.HashValue, input4.HashValue };

            Array.Sort(potion);

            if (potionHashValues.ContainsKey(potion))
            {
                return potions[potionHashValues[potion]];
            }
            else
            {
                return null;
                //TO DO: Return a bad potion (Low Priority)
            }
        }

        public GameItems.BasePotion CreatePotion2(
            int input1,
            int input2,
            int input3,
            int input4)
        {
            int[] potion = new int[4] { input1, input2, input3, input4 };

            Array.Sort(potion);

            if (potionHashValues.ContainsKey(potion))
            {
                return potions[potionHashValues[potion]];
            }
            else
            {
                return null;
                //TO DO: Return a bad potion (Low Priority)
            }
        }

        // READING IN TEXT FILES

        // Array with all files from the folder where we'll have all files
        List<string> allFiles = new List<string>();
        List<string> potionFiles = new List<string>();
        List<string> ingredientFiles = new List<string>();

        // Reads every file in the folder, so they can be sorted
        private void ReadAll(string folder)
        {
            allFiles = Directory.GetFiles(folder).Select(Path.GetFileName).ToList(); // Getfiles("") will have the directory where we'll be storing files
        }

        // Adds potions strings to be used
        private void ReadPotions()
        {
            foreach(string file in allFiles)
            {
                if(file[0] == 'p')
                {
                    potionFiles.Add(file);
                }
            }
        }

        // Adds ingredients strings to then be pulled 
        private void ReadIngredients()
        {
            foreach(string file in allFiles)
            {
                if(file[0] == 'i')
                {
                    ingredientFiles.Add(file);
                }
            }
        }

        // Adds potion objects to the list of potions
        private void AddPotions(string directory)
        {
            foreach (string pFileName in potionFiles)
            {
                Stream inStream = new FileStream(directory + "/" + pFileName, FileMode.Open);
                StreamReader reader = new StreamReader(inStream);
                GameItems.BasePotion potion =
                    new GameItems.BasePotion
                        (
                            // (a) Hash Value
                            int.Parse(reader.ReadLine()),
                            // (b) Name
                            reader.ReadLine(),
                            // (c) Value
                            int.Parse(reader.ReadLine()),
                            // (d, e, f, g) Portion Hash Value
                            // Comprised of the hash values 
                            // of the potions ingrediants
                            new int[4]
                            {
                            int.Parse(reader.ReadLine()),
                            int.Parse(reader.ReadLine()),
                            int.Parse(reader.ReadLine()),
                            int.Parse(reader.ReadLine()),
                            },
                            // (h) Flavor Text
                            reader.ReadLine(),
                            // (i) String of Effect Description
                            reader.ReadLine(),
                            // (j) Name of Texture File
                            reader.ReadLine()
                        );
                inStream.Close();
                reader.Close();

                potions.Add(potion.HashValue, potion);
            }
        }

        // Adds ingredient objects the list of ingredients
        private void AddIngredients(string directory)
        {
            foreach (string iFileName in ingredientFiles)
            {
                Stream inStream = new FileStream(directory + "/" + iFileName, FileMode.Open);
                StreamReader reader = new StreamReader(inStream);

                GameItems.BaseIngredient ingrediant =
                    new GameItems.BaseIngredient
                        (
                            // (a) Hash Value
                            int.Parse(reader.ReadLine()),
                            // (b) Name
                            reader.ReadLine(),
                            // (c) Value
                            int.Parse(reader.ReadLine()),
                            // (d) Flavor Text
                            reader.ReadLine(),
                            // (e) Name of Texture File
                            reader.ReadLine()
                        );
                inStream.Close();
                reader.Close();

                ingrediants.Add(ingrediant.HashValue, ingrediant);
            }
        }
    }

    // JOHN'S OLD CODE

    /*Stream inStream = new FileStream(targetFileName, FileMode.Open);
                StreamReader reader = new StreamReader(inStream);*/

    //-------------Data Reading--------------

    //(Input files should match up to this spec)

    // (1) Data about how many of each item exists is recorded

    // (i) Potion Count
    // int potionCount = int.Parse(reader.ReadLine());

    // (ii) Ingrediant Count
    // int ingrediantCount = int.Parse(reader.ReadLine());

    // (iii) Recipie Count
    // int recipieCount = int.Parse(reader.ReadLine());

    // (2) Create objects baised on recorded counts

    // (i) Potion Data
    /*for (int i = 0; i < potionCount; i++)
    {
        GameItems.BasePotion potion =
            new GameItems.BasePotion
                (
                    // (a) Hash Value
                    int.Parse(reader.ReadLine()),
                    // (b) Name
                    reader.ReadLine(),
                    // (c) Value
                    int.Parse(reader.ReadLine()),
                    // (d, e, f, g) Portion Hash Value
                    // Comprised of the hash values 
                    // of the potions ingrediants
                    new int[4]
                    {
                                int.Parse(reader.ReadLine()),
                                int.Parse(reader.ReadLine()),
                                int.Parse(reader.ReadLine()),
                                int.Parse(reader.ReadLine()),
                    },
                    // (h) Flavor Text
                    reader.ReadLine(),
                    // (i) String of Effect Description
                    reader.ReadLine(),
                    // (j) Name of Texture File
                    reader.ReadLine()
                );
        potions.Add(potion.HashValue, potion);
    }*/

    // (ii) Ingrediant Data
    /*for (int i = 0; i < ingrediantCount; i++)
    {
        ingrediants.Add
        (
            i,
            new GameItems.BaseIngredient
                (
                    // (a) Hash Value
                    int.Parse(reader.ReadLine()),
                    // (b) Name
                    int.Parse(reader.ReadLine()),
                    // (c) Value
                    int.Parse(reader.ReadLine()),
                    // (d) Flavor Text
                    int.Parse(reader.ReadLine()),
                    // (e) Name of Texture File
                    int.Parse(reader.ReadLine())
                )
        );
    }*/
}
