using clsPokemon;
using PokeService.ViewModels.Utility;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeService.ViewModels
{
    internal class PokemonsVM
    {
        #region Atributos
        private List<ClsPokemon> pokemons;
        private DelegateCommand cmdPedirPokemons;
        private int cont=0;
        #endregion

        #region Propiedades
        public List<ClsPokemon> Pokemons {  get { return pokemons; } }
        public DelegateCommand CmdPedirPokemons { get {return cmdPedirPokemons;} }
        #endregion

        #region Constructores
        public PokemonsVM() 
        { 
            pokemons = new List<ClsPokemon>();
            cmdPedirPokemons = new DelegateCommand(cmdPedirPokemons_Execute, cmdPedirPokemons_CanExecute);
        }

        #endregion

        #region Command
        private bool cmdPedirPokemons_CanExecute()
        {
            return true;
        }

        private async void cmdPedirPokemons_Execute()
        {
            ClsManejadora manejadora = new ClsManejadora();
            List<ClsPokemon> listaPokemon = await manejadora.getPokemons(cont);

            pokemons.AddRange(listaPokemon);
            cont += 20;
            
        }
        #endregion
    }
}
