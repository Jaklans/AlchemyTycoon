using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AlchemyTycoon.GameItems
{
    class Recipe
    {
        private BasePotion potion;
        private BaseIngredient[] components;
        private Texture2D recipeTexture;
        
        public Recipe(BasePotion potion)
        {
            this.potion = potion;
            components = new BaseIngredient[4]
            {
                Data.Instance.Ingrediants(potion.PotionHashValue[0]),
                Data.Instance.Ingrediants(potion.PotionHashValue[1]),
                Data.Instance.Ingrediants(potion.PotionHashValue[2]),
                Data.Instance.Ingrediants(potion.PotionHashValue[3])
            };
        }
    }
}
