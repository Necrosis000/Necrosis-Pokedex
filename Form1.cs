using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PokeApiNet;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace necrosisPokedex
{
    public partial class pokédex : Form
    {
        public pokédex()
        {
            InitializeComponent();


        }

        async private void button1_Click(object sender, EventArgs e)
        {
            PokeApiClient pokeClient = new PokeApiClient();
            Pokemon pokemon = await pokeClient.GetResourceAsync<Pokemon>(pokemonEnterLbl.Text);
            float pokeheight = pokemon.Height;
            float pokeweight = pokemon.Weight;
            pokemonSpriteImg.Load(pokemon.Sprites.FrontDefault);
            shinyPokemonImg.Load(pokemon.Sprites.FrontShiny);
            normalFormLbl.Text = "Normal Form";
            shinyFormLbl.Text = "Shiny Form";
            pokemonNameLbl.Text = "Name: " + pokemon.Name.ToUpper();
            pokemonIdLbl.Text = "ID: " + pokemon.Id;
            heightLbl.Text = "Height: " + pokeheight / 10 + "m";
            weightLbl.Text = "Weight: " + pokeweight / 10 + "kg";

            try
            {
                typesLbl.Text = "Types: " + pokemon.Types[0].Type.Name.ToUpper() + ", " + pokemon.Types[1].Type.Name.ToUpper();   // Error
            }

            catch (ArgumentOutOfRangeException)
            {
                typesLbl.Text = "Types: " + pokemon.Types[0].Type.Name.ToUpper();
            }
            

        }

        private void pokemonEnterLbl_KeyDown(object sender, KeyEventArgs e)
        {
           if (e.KeyCode == Keys.Enter)
           {
                generateBtn.PerformClick();
           }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void githubBtn_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", "https://github.com/Necrosis000");
        }

        private void pokédex_Load(object sender, EventArgs e)
        {

        }
    }
}
