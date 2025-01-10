using clsPokemon;
using PokeService.ViewModels.Utility;
using Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PokeService.ViewModels
{
    internal class PokemonsVM: INotifyPropertyChanged
    {
        #region Atributos
        private ObservableCollection<ClsPokemon> pokemons;
        private DelegateCommand cmdPedirPokemons;
        private DelegateCommand cmdPokemonsAtras;
        private int cont= -20;
        private int id = 0;

        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region Propiedades
        public ObservableCollection<ClsPokemon> Pokemons 
        {  
            get
            {
                return pokemons;
            }

        }
        public DelegateCommand CmdPedirPokemons { get {return cmdPedirPokemons;} }
        public DelegateCommand CmdPokemonsAtras { get { return cmdPokemonsAtras; } }

        #endregion

        #region Constructores
        public PokemonsVM() 
        { 
            pokemons = new ObservableCollection<ClsPokemon>();
            cmdPokemonsAtras = new DelegateCommand(cmdPokemonsAtras_Execute, cmdPedirPokemons_CanExecute);
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
            cont += 20;

            ClsManejadora manejadora = new ClsManejadora();
            List<ClsPokemon> listaPokemon = await manejadora.getPokemons(cont);

            pokemons.Clear();

            foreach (ClsPokemon pokemon in listaPokemon)
            {
                pokemons.Add(pokemon);
            }
        }

        private async void cmdPokemonsAtras_Execute()
        {
            
            cont -= 20;

            ClsManejadora manejadora = new ClsManejadora();
            List<ClsPokemon> listaPokemon = await manejadora.getPokemons(cont);

            pokemons.Clear();

            foreach (ClsPokemon pokemon in listaPokemon)
            {
                pokemons.Add(pokemon);
            }
            
        }
        #endregion

    }
}
