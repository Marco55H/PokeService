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
        private int cont=0;
        private int id = 0;
        #endregion

        #region Propiedades
        public ObservableCollection<ClsPokemon> Pokemons 
        {  
            get
            {
                return pokemons;
            }
            set
            {
                NotifyPropertyChanged("pokemons"); pokemons = value;
            }
        }
        public DelegateCommand CmdPedirPokemons { get {return cmdPedirPokemons;} }
        #endregion

        #region Constructores
        public PokemonsVM() 
        { 
            pokemons = new ObservableCollection<ClsPokemon>();
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


            foreach (ClsPokemon pokemon in listaPokemon)
            {
                pokemons.Add(pokemon);
            }

            cont += 20;           
        }
        #endregion

        #region Property Changed
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
